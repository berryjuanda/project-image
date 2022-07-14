using Mahasiswa.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Mahasiswa.Services;

namespace Mahasiswa.Controllers
{
    public class ImageController : Controller
    {
        string mainConnection = WebConfigurationManager.ConnectionStrings["MahasiswaConnection"].ConnectionString;
        ImageServices imageservices = new ImageServices();
        // GET: Image
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Image imageModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            imageModel.ImagePath = "~/Content/img/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Content/img/" + fileName));
            imageModel.ImageFile.SaveAs(fileName);

            ViewBag.image = imageservices.insertImage(imageModel);
            ModelState.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.image = imageservices.getImage();
            return View();

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            ViewBag.detail = imageservices.detail(id);
            ViewBag.title = ViewBag.detail.Title;
            ViewBag.path = ViewBag.detail.ImagePath;
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.edit = imageservices.detail(id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Image imageModel)
        {
            string fileEditName = Path.GetFileNameWithoutExtension(imageModel.ImageFileEdit.FileName);
            string extension = Path.GetExtension(imageModel.ImageFileEdit.FileName);
            fileEditName = fileEditName + DateTime.Now.ToString("yymmssfff") + extension;
            imageModel.ImagePath = "~/Content/img/" + fileEditName;
            fileEditName = Path.Combine(Server.MapPath("~/Content/img/" + fileEditName));
            imageModel.ImageFileEdit.SaveAs(fileEditName);

            ViewBag.edit = imageservices.edit(imageModel);
            ModelState.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.deleteDetail = imageservices.detail(id);
            ViewBag.id = ViewBag.deleteDetail.ImageID;
            ViewBag.title = ViewBag.deleteDetail.Title;
            ViewBag.path = ViewBag.deleteDetail.ImagePath;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Image imageModel, int id)
        {
            ViewBag.delete = imageservices.delete(imageModel, id);
            return RedirectToAction("Index");
        }
    }
}