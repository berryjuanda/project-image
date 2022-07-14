using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
namespace Mahasiswa.Models
{
    public class ImageTest
    {

    }

    public class Image
    {
        public int ImageID { get; set; }
        public string Title { get; set; }
        [DisplayName("Upload File")]
        public string ImagePath { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        public HttpPostedFileBase ImageFileEdit { get; set; }
    }
}