using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace storedproceduresApp
{
    public partial class Form1 : Form
    {
        Datahandler handler = new Datahandler();
        BindingSource bs = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            dgStudents.DataSource = bs; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            handler.displayStudents();
            bs.DataSource = handler.students;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            handler.insertData(int.Parse(txtStudentID.Text), txtName.Text, txtSurname.Text, txtCourse.Text);
        }
    }
}
