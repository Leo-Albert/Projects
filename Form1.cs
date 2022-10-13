using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Student_Portal
{
    public partial class viewWindow : Form
    {
        dbhandler dbh = new dbhandler();
        int id;
        DataGridViewCellMouseEventArgs reference = null;
        insertwindow update;
        public viewWindow()
        {
            InitializeComponent();
            displaydata();
        }
       public void displaydata()
        {
          string message=  dbh.connectionopen();
            if(message != null)
            {
              if(  MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    Application.Exit();
                }
                
            }
            DataSet ds = dbh.Showdata();
            if (ds == null)
            {
                MessageBox.Show("Cannot fetch the data","Error Occured",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            dbh.connectionclose();
            dataview.DataSource = ds.Tables[0].DefaultView;
        }

        private void add_Click(object sender, EventArgs e)
        {
            insertwindow insert = new insertwindow(this);
            insert.ShowDialog();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (reference != null)
            {
                update.Text = "Edit";
                update.save.Text = "Update";
                update.clear.Visible = false;
                update.Show();
            }
            else
            {
                MessageBox.Show("Please Select a Row", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataview_RowHeaderMouseClick(object sender,DataGridViewCellMouseEventArgs e)
        {
            reference = e;
            id = Int16.Parse(dataview.Rows[e.RowIndex].Cells[0].Value.ToString());
            update = new insertwindow(id, this);
            update.roll.Text = dataview.Rows[e.RowIndex].Cells[1].Value.ToString();
            update.name.Text = dataview.Rows[e.RowIndex].Cells[2].Value.ToString();
            update.dob.Text = dataview.Rows[e.RowIndex].Cells[3].Value.ToString();
            update.place.Text = dataview.Rows[e.RowIndex].Cells[4].Value.ToString();
            update.phoneno.Text = dataview.Rows[e.RowIndex].Cells[5].Value.ToString();
            
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (reference != null)
            {
                if (MessageBox.Show("Do you Want to Delete", "warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    dbh.connectionopen();
                    dbh.cmd.CommandText = "Delete from studentdetails where stu_id=" + id;
                    dbh.cmd.ExecuteNonQuery();
                    displaydata();
                }
            }
            else
            {
                MessageBox.Show("Please Select One Row","Attention",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            displaydata();
        }
    }
}
