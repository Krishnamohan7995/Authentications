using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Authentications.Models
{
    public class Repository
    {
        string q = ConfigurationManager.ConnectionStrings["auth"].ToString();
        public void Add(RegisterModel model)
        {
            SqlConnection con=new SqlConnection(q);
            string query = "insert into Users values('" + model.Id + "','" + model.Username + "','" + model.Pwd + "','" + model.Cpwd + "','" + model.Age + "','" + model.Gender + "','" + model.Email + "','" + model.Phone + "')";
            SqlCommand cmd=new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public bool Check(LoginModel model)
        {
            SqlConnection con = new SqlConnection(q);
            string query = "Select count(*) from Users where Email='" + model.Email + "' and Password='" + model.Pwd + "'";
            bool flag=true;
           SqlCommand cmd=new SqlCommand(query, con);
            con.Open();
            flag=Convert.ToBoolean(cmd.ExecuteScalar());
            con.Close();
            return flag;
        }

        public void Forget(ForgetModel model)
        {
            SqlConnection con = new SqlConnection(q);
            string query="update Users set Password='"+model.Pwd+"', CPassword='"+model.Cpwd+"' where Email='"+model.Email+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<RegisterModel> GetList()
        {
            SqlConnection con = new SqlConnection(q);
            string query = "select * from Users";
            List<RegisterModel> obj=new List<RegisterModel>();
            SqlCommand cmd=new SqlCommand(query, con);
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            DataTable dt= new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach(DataRow dr in dt.Rows)
            {
                obj.Add(new RegisterModel
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Username =Convert.ToString (dr["UserName"]),
                    Pwd= Convert.ToString(dr["Password"]),
                    Cpwd= Convert.ToString(dr["CPassword"]),
                    Age = Convert.ToInt32(dr["Age"]),
                    Gender= Convert.ToString(dr["Gender"]),
                    Email= Convert.ToString(dr["Email"]),
                    Phone = Convert.ToInt64(dr["Phone"])
                });
            }
            return obj;
        }
    }
}