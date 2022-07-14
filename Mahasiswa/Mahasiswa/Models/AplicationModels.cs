using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mahasiswa.Models
{
    public class AplicationModels
    {

    }

    public class MahasiswaModel
    {
        // public string id { get; set; }
        [Required(ErrorMessage = "Please enter nim!")]
        [StringLength(10, MinimumLength = 3)]
        public string nim { get; set; }
        [Required(ErrorMessage = "Please enter nama!")]
        public string nama { get; set; }
        [Required(ErrorMessage = "Please eneter jurusan!")]
        public string jurusan { get; set; }

    }


}