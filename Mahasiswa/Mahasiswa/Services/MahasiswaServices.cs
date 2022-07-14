using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Mahasiswa.Models;

using System.Web.Configuration;
namespace Mahasiswa.Services
{
    public class MahasiswaServices
    {
        //string mainConnection = ConfigurationManager.AppSettings["MahasiswaConnection"];
        string mainConnection = WebConfigurationManager.ConnectionStrings["MahasiswaConnection"].ConnectionString;

        public List<MahasiswaModel> getMahasiswa()
        {
            List<MahasiswaModel> mahasiswaList = new List<MahasiswaModel>();


            SqlConnection conn = new SqlConnection(mainConnection);
            SqlCommand cmd = new SqlCommand("stp_GetMahasiswa", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    MahasiswaModel mahasiswa = new MahasiswaModel();
                   // mahasiswa.id = dr["id"].ToString();
                    mahasiswa.nim = dr["nim"].ToString();
                    mahasiswa.nama = dr["nama"].ToString();
                    mahasiswa.jurusan = dr["jurusan"].ToString();
                }
            }


            var cek = mahasiswaList;
            conn.Close();
            return mahasiswaList;
        }

        public List<MahasiswaModel> pageMahasiswa(int skip, int take)
        {
            List <MahasiswaModel> mahasiswaList = new List<MahasiswaModel>();
            SqlConnection conn = new SqlConnection(mainConnection);
            SqlCommand cmd = new SqlCommand("stp_PageMahasiswa", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@skip",skip);
            cmd.Parameters.AddWithValue("@take",take);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    MahasiswaModel mahasiswa = new MahasiswaModel();
                    mahasiswa.nim = dr["nim"].ToString();
                    mahasiswa.nama = dr["nama"].ToString();
                    mahasiswa.jurusan = dr["jurusan"].ToString();
                    mahasiswaList.Add(mahasiswa);
                }
            }
            conn.Close();
            return mahasiswaList;
        }

        public List<MahasiswaModel> searchMahasiswa(string search)
        {
            List<MahasiswaModel> list = new List<MahasiswaModel>();
            SqlConnection conn = new SqlConnection(mainConnection);
            SqlCommand cmd = new SqlCommand("stp_SearchData", conn);
            cmd.CommandType= System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nama", search);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    MahasiswaModel data = new MahasiswaModel();
                    data.nim = dr["nim"].ToString();
                    data.nama = dr["nama"].ToString();
                    data.jurusan = dr["jurusan"].ToString();
                    list.Add(data);
                }
            }
            conn.Close();
            return list;
        }

        public int getJmlMahasiswa()
        {
            int row = 0;
            SqlConnection conn = new SqlConnection(mainConnection);
            SqlCommand cmd = new SqlCommand("stp_GetMahasiswa", conn);
           
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    row++;
                }
            }
            conn.Close();
            return row;
        }

        public List<MahasiswaModel> mahasiswaData()
        {
            List<MahasiswaModel> result = new List<MahasiswaModel>();
            //MahasiswaModel result2 = new MahasiswaModel();
            SqlConnection conn = new SqlConnection(mainConnection);
            SqlCommand cmd = new SqlCommand("stp_GetMahasiswa", conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    MahasiswaModel result2 = new MahasiswaModel();
                   // result2.id = dr["id"].ToString();
                    result2.nim = dr["nim"].ToString();
                    result2.nama = dr["nama"].ToString();
                    result2.jurusan = dr["jurusan"].ToString();
                    result.Add(result2);
                }
            }
            return result;
        }

        public bool insertMahasiswa(MahasiswaModel mahasiswa)
        {
            List<MahasiswaModel> input = new List<MahasiswaModel>();
            SqlConnection conn = new SqlConnection(mainConnection);
            SqlCommand cmd = new SqlCommand("stp_insertMahasiswa",conn);
            // cmd.Parameters.AddWithValue("@id",Convert.ToInt32(mahasiswa.id));
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nim",mahasiswa.nim);
            cmd.Parameters.AddWithValue("@nama", mahasiswa.nama);
            cmd.Parameters.AddWithValue("@jurusan", mahasiswa.jurusan);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            var is_success = false;
            if (dr.RecordsAffected == 1)
            {
                is_success = true;
                
            }

            return is_success;
        }

        // Get Data Mahasiswa Berdasarkan nim
        public MahasiswaModel getDetails(string nim)
        {
            MahasiswaModel getNim = new MahasiswaModel();
            SqlConnection conn = new SqlConnection(mainConnection);
            SqlCommand cmd = new SqlCommand("stp_getNim", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nim", nim);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    
                    getNim.nim = dr["nim"].ToString();
                    getNim.nama = dr["nama"].ToString();
                    getNim.jurusan = dr["jurusan"].ToString();
                   
                }
            }
            conn.Close();
            return getNim;
        }
        public List<MahasiswaModel> editMahasiswa(MahasiswaModel mahasiswa,string nim)
        {
            List<MahasiswaModel> edit = new List<MahasiswaModel>();
            SqlConnection conn = new SqlConnection(mainConnection);
            SqlCommand cmd = new SqlCommand("stp_UpdateMahasiswa",conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nim", nim);
            cmd.Parameters.AddWithValue("@nama", mahasiswa.nama);
            cmd.Parameters.AddWithValue("@jurusan", mahasiswa.jurusan);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    MahasiswaModel edit2 = new MahasiswaModel();
                    edit2.nim = dr["nim"].ToString();
                    edit2.nama = dr["nama"].ToString();
                    edit2.jurusan = dr["jurusan"].ToString();
                    edit.Add(edit2);
                }
            }
            conn.Close();
            return edit;
        }

        public List<MahasiswaModel> deleteMahasiswa(MahasiswaModel mahasiswa, string nim)
        {
            List<MahasiswaModel> deleteList = new List<MahasiswaModel>();
            SqlConnection conn = new SqlConnection(mainConnection);
            SqlCommand cmd = new SqlCommand("stp_DeleteMahasiswa", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nim", nim);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    MahasiswaModel delete = new MahasiswaModel();
                    delete.nim = dr["nim"].ToString();
                    delete.nama = dr["nama"].ToString();
                    delete.jurusan = dr["jurusan"].ToString();
                    deleteList.Add(delete);
                }
            }
            conn.Close();
            return deleteList;
        }

    }
}