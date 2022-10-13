using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Portal
{
    public partial class insertwindow : Form
    {
        dbhandler dbh = new dbhandler();
        viewWindow vw;
        int idvalue;
        public insertwindow()
        {
            InitializeComponent();
        }
        public insertwindow(viewWindow fv)
        {
            vw = fv;
            InitializeComponent();
        }
        public insertwindow(int id,viewWindow fv2)
        {
            idvalue = id;
            vw = fv2;
            InitializeComponent();
        }
        void insert()
        {
            try
            {
                dbh.connectionopen();
                dbh.cmd.CommandText = "Insert into studentdetails(stu_roll,stu_name,stu_place,stu_phone,stu_dob) " +
                    "values(@rollno,@name,@place,@phone,@dob)";
                dbh.cmd.Parameters.AddWithValue("@rollno", roll.Text);
                dbh.cmd.Parameters.AddWithValue("@name", name.Text);
                dbh.cmd.Parameters.AddWithValue("@place", place.Text);
                dbh.cmd.Parameters.AddWithValue("@phone", phoneno.Text);
                dbh.cmd.Parameters.AddWithValue("@dob", dob.Text);
                dbh.cmd.ExecuteNonQuery();
                MessageBox.Show("Saved Successfully", "Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vw.displaydata();
                dbh.connectionclose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (save.Text == "Save")
            {
                if (roll.Text != "" && name.Text != "" && place.Text != "" && phoneno.Text != "" && dob.Text != "")
                {
                    insert();
                }
                else
                {
                    MessageBox.Show("Please fill all the fields", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (MessageBox.Show("Do you want to Edit", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        dbh.connectionopen();
                        dbh.cmd.CommandText = "update studentdetails set stu_roll=@rollno,stu_name=@name,stu_place=@place,stu_phone=@phone,stu_dob=@dob where stu_id=" + idvalue;
                        dbh.cmd.Parameters.AddWithValue("@rollno", roll.Text);
                        dbh.cmd.Parameters.AddWithValue("@name", name.Text);
                        dbh.cmd.Parameters.AddWithValue("@place", place.Text);
                        dbh.cmd.Parameters.AddWithValue("@phone", phoneno.Text);
                        dbh.cmd.Parameters.AddWithValue("@dob", dob.Text);
                        dbh.cmd.ExecuteNonQuery();
                        MessageBox.Show("Updated Successfully", "Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        vw.displaydata();
                        this.Close();
                    }
                    catch (Exception ec)
                    {
                        MessageBox.Show(ec.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        dbh.connectionclose();
                    }
                }
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            roll.Clear();
            name.Clear();
            place.Clear();
            phoneno.Clear();
            dob.Clear();
        }

        private void cls_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
