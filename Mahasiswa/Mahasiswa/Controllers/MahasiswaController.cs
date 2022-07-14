using Mahasiswa.Models;
using Mahasiswa.Services;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Mahasiswa.Controllers
{

    public class MahasiswaController : Controller
    {
        //string mainConection = ConfigurationManager.AppSettings["MahasiswaConnection"];
        string mainConnection = WebConfigurationManager.ConnectionStrings["MahasiswaConnection"].ConnectionString;
        MahasiswaServices mahasiswaservices = new MahasiswaServices();
        // GET: Mahasiswa
        public ActionResult Index(int pg=1, int skip=0, int take=10, string search="")
        {

            // ViewBag.mahasiswa = mahasiswaservices.mahasiswaData();

            const int pageSize = 10;
            if (pg < 1)
             pg = 1;

            skip = (pg - 1) * pageSize;
            take = pageSize;
            //int record = 1;
            ViewBag.pageMahasiswa = mahasiswaservices.pageMahasiswa(skip, take);
            //var result = ViewBag.pageMahasiswa.Skip(skip).Take(take).ToList();
            int recsCount = mahasiswaservices.getJmlMahasiswa();
            var pager = new Pager(recsCount, pg, pageSize);
            ViewBag.search = mahasiswaservices.searchMahasiswa(search);
            ViewBag.Pager = pager;

            return View();

        }

       


        // GET : Mahasiswa/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST : Mahasiswa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MahasiswaModel mahasiswa)
        {
            ViewBag.mahasiswa = mahasiswaservices.insertMahasiswa(mahasiswa);
            return RedirectToAction("index");
        }

        // GET : Mahasiswa/Edit
        [HttpGet]
        public ActionResult Edit(string nim)
        {
            ViewBag.edit = mahasiswaservices.getDetails(nim);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MahasiswaModel mahasiswa,string nim)
        {
            ViewBag.mahasiswa = mahasiswaservices.editMahasiswa(mahasiswa,nim);
           
            return RedirectToAction("index");

        }

        [HttpGet]
        public ActionResult Details(string nim)
        {
            ViewBag.details = mahasiswaservices.getDetails(nim);   
            ViewBag.nim = ViewBag.details.nim;
            ViewBag.nama = ViewBag.details.nama;
            ViewBag.jurusan = ViewBag.details.jurusan;
            return View();
        }

        [HttpGet]
        public ActionResult Delete(string nim)
        {
            ViewBag.delete = mahasiswaservices.getDetails(nim);
            ViewBag.nim = ViewBag.delete.nim;
            ViewBag.nama = ViewBag.delete.nama;
            ViewBag.jurusan = ViewBag.delete.jurusan;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MahasiswaModel mahasiswa, string nim)
        {
           ViewBag.delete = mahasiswaservices.deleteMahasiswa(mahasiswa, nim);
            return RedirectToAction("index");
        }

    }
}