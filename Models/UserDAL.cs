using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCExample2.Models
{
    

    public class UserDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public UserDAL()
        {
                con = new SqlConnection(Startup.ConnectionString);
        }

        public int Save(User u)
        {
            string q = "insert into UserTable values(@FullName,@Email,@password,@Role_id)";
            cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@FullName", u.Name);
            cmd.Parameters.AddWithValue("@Email", u.Email);
            cmd.Parameters.AddWithValue("@password", u.Password);
            cmd.Parameters.AddWithValue("@Role_id", 2);
            /*cmd.Parameters.AddWithValue("@User_id", 101);*/

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public bool Verify(User u)
        {
            string email;
            string pass;
            string q = "Select Email,password from UserTable where Email=@Email";
            cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@Email", u.Email);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                email = dr["Email"].ToString();
                pass = dr["Password"].ToString();
            }
            else 
            {
                con.Close();
                return false; 
            }
            if (email == u.Email && pass == u.Password)
            {
                con.Close();
                return true;
            }
            else 
            {
                    con.Close();
                    return false;
            }
        }
    }
}
