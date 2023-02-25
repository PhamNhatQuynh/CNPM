using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        DataModel dm;
        public Form1()
        {
            InitializeComponent();
            LoadDataModel();
        }

        private void LoadDataModel()
        {
            dm = new DataModel();

        }
        public void ResetForm()
        {
            studentDataGridView.Rows.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeForm();
            LoadStudentData();
        }

        private void LoadStudentData()
        {
            List<Dictionary<string, string>> rows = dm.FetchAllRow();
            foreach (Dictionary<string, string> row in rows)
            {
                int index = studentDataGridView.Rows.Add();
                studentDataGridView.Rows[index].Cells[0].Value = row["ID"];
                studentDataGridView.Rows[index].Cells[1].Value = row["FullName"];
                studentDataGridView.Rows[index].Cells[2].Value = row["Town"];
                studentDataGridView.Rows[index].Cells[3].Value = row["DoB"]; 

            }
        }

        private void InitializeForm()
        {
            studentDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!dm.AddNewRow(txtID.Text, txtName.Text, txtTown.Text, dtpDob.Value.ToString()))
            {
                MessageBox.Show("Failed");
            }
            ResetForm();
            LoadStudentData();
        }

        private void studentDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (!dm.RemoveRow(studentDataGridView.Rows[studentDataGridView.SelectedRows[0].Index].Cells[0].Value.ToString()))
            {
                MessageBox.Show("Failed");
            }

            ResetForm();
            LoadStudentData();
        }
    }
}
