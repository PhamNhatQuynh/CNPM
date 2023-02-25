using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace N4
{
    public partial class Form1 : Form
    {
        DataModel dm;
        public Form1()
        {
            InitializeComponent();
            LoadDataModel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbb.Items.Add("Tp. Hồ Chí Minh");
            cbb.Items.Add("Quang Nam");
            cbb.Items.Add("Đồng Tháp");
            cbb.Items.Add("Thanh Hóa");
            cbb.Items.Add("Hà Nội");
        }

        public bool CheckSdt(string sdt)
        {
            return Regex.IsMatch(sdt, "^[0-9]{10,12}$");
        }

        public bool CheckMK(string mk)
        {
            return Regex.IsMatch(mk, "^[a-zA-Z0-9]{6,24}$");
        }

        public bool CheckEmail(string e)
        {
            return Regex.IsMatch(e, @"^[a-zA-Z0-9_.]{3,20}@gmail.com(.vn|)$");
        }

        private void LoadDataModel()
        {
            dm = new DataModel();

        }
        private void btn_dangky_Click(object sender, EventArgs e)
        {
            string hoten = txtbox_hoten.Text;
            //string nam = radiobtn_nam.Text;
            //string nu = radiobtn_nu.Text;
            string quequan = "";
            if(cbb.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn quê quán!");
                return;
            } else
            {
                quequan = cbb.SelectedItem.ToString();
            }

            string tk = txtbox_sdt.Text;
            string mk = txtbox_mk.Text;
            string xnmk = txtbox_checkmk.Text;
            string email = txt_email.Text;

            if (!CheckEmail(email))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng email!");
                return;
            }

            else if (!CheckSdt(tk))
            {
                MessageBox.Show("Vui lòng nhập lại sđt!");
                return;
            }

            else if (!CheckMK(mk))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu dài từ 6-24 ký tự, với các chữ và số, chữ hoa và chữ thường!");
                return;
            }

            else if (xnmk != mk)
            {
                MessageBox.Show("Vui lòng xác nhận lại mật khẩu!");
                return;
            }

            //SqlConnection con = new SqlConnection("Data Source=607-30\\SQLEXPRESS;Initial Catalog=Nhom4;Integrated Security=True");
            //SqlCommand cmd = new SqlCommand("insert into abc values ('sdsdsdsa')", con);
            string value = "";
            if (radiobtn_nam.Checked) {
                value = radiobtn_nam.Text;

            } else {
                value = radiobtn_nu.Text;
            }

            if (!dm.AddNewRow(hoten, value, email, quequan, tk, mk))
            {
                MessageBox.Show("Failed");
            }

        }

        private void txtbox_checkmk_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
