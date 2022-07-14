using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mahasiswa.Models;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace Mahasiswa.Services
{
    public class ImageServices
    {
        string mainConnection = WebConfigurationManager.ConnectionStrings["MahasiswaConnection"].ConnectionString;

        public bool insertImage(Image imageModel)
        {
            List<Image> insertList = new List<Image>();
            SqlConnection conn = new SqlConnection(mainConnection);
            SqlCommand cmd = new SqlCommand("stp_UploadImage", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@title", imageModel.Title);
            cmd.Parameters.AddWithValue("@imagePath", imageModel.ImagePath);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            var is_success = false;
            if(dr.RecordsAffected == 1)
            {
                is_success = true;
            }
            return is_success;
        }

        public List<Image> getImage()
        {
            List<Image> imageList = new List<Image>();
            SqlConnection conn = new SqlConnection(mainConnection);
            SqlCommand cmd = new SqlCommand("stp_DisplayImage", conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Image img = new Image();
                    img.ImageID = Convert.ToInt32(dr["ImageId"]);
                    img.Title = dr["Title"].ToString();
                    img.ImagePath = dr["ImagePath"].ToString();
                    imageList.Add(img);
                }
            }
            return imageList;
        }

        public Image detail(int id)
        {
            Image image = new Image();
            SqlConnection conn = new SqlConnection(mainConnection);
            SqlCommand cmd = new SqlCommand("stp_DetailImage", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    image.ImageID = Convert.ToInt32(dr["ImageID"]);
                    image.Title = dr["Title"].ToString();
                    image.ImagePath = dr["ImagePath"].ToString();
                }
            }
            conn.Close();
            return image;
        }
        
        public List<Image> edit(Image imageModel)
        {
            List<Image> editList = new List<Image>();
            SqlConnection conn = new SqlConnection(mainConnection);
            SqlCommand cmd = new SqlCommand("stp_UpdateImage", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", imageModel.ImageID);
            cmd.Parameters.AddWithValue("@title", imageModel.Title);
            cmd.Parameters.AddWithValue("@path", imageModel.ImagePath);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Image image = new Image();
                    image.ImageID = Convert.ToInt32(dr["ImageID"]);
                    image.Title = dr["Title"].ToString();
                    image.ImagePath = dr["ImagePath"].ToString();
                    editList.Add(image);
                }
            }
            conn.Close();
            return editList;
        }

        public List<Image> delete(Image imageModel, int id)
        {
            List<Image> deleteList = new List<Image>();
            SqlConnection conn = new SqlConnection(mainConnection);
            SqlCommand cmd = new SqlCommand("stp_DeleteImage", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Image img = new Image();
                    img.ImageID = Convert.ToInt32(dr["ImageID"]);
                    img.Title = dr["Title"].ToString();
                    img.ImagePath = dr["ImagePath"].ToString();
                    deleteList.Add(img);
                }
            }
            conn.Close();
            return deleteList;
        }
    }
}