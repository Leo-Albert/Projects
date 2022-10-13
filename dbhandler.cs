using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Student_Portal
{
    class dbhandler
    {
        public MySqlConnection con;
        public MySqlCommand cmd;


       
        public string connectionopen()
        {

            try
            {
                string constring = "Server=localhost;Database=studentdata;Uid=Leo Albert;Pwd=leot";
                con = new MySqlConnection(constring);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd = con.CreateCommand();
                return null;
            }
            catch (Exception conn)
            {
                return conn.Message;
            }
        }
        public void connectionclose()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public DataSet Showdata()
        {
            //try//
            //{
                cmd.CommandText = "Select stu_id AS ID, stu_roll AS 'ROLL NUMBER' ,stu_name as 'NAME',stu_dob as 'DOB',stu_place as 'PLACE',stu_phone as 'PHONE NUMBER' from studentdetails";
                MySqlDataAdapter mda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                mda.Fill(ds);
                return ds;
           // }
            //catch (Exception ex)
            //{
                return null;
           // }
        }

    }
}

