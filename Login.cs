using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Login : Form
    {
        SqlConnection baglan = new SqlConnection
            ("Data Source=Galren\\SQLEXPRESS;Initial Catalog=galren;Integrated Security=True");
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            this.antrenorlerTableAdapter.Fill(this.galrenDataSet.Antrenorler);

        }

        private void textBox1_TextChanged_3(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
           

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            KullaniciAdiTbl.Text = "";
            SifreTbl.Text = "";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (KullaniciAdiTbl.Text==""||SifreTbl.Text=="")
            {
                MessageBox.Show("Eksik Bigi");
            }
            else if (KullaniciAdiTbl.Text=="Admin"|| SifreTbl.Text=="1234")
            {
                AnaSayfa anasayfa= new AnaSayfa();
                anasayfa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı Veya Şifre");
            }
        }

        private void SifreTbl_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            KullaniciAdiTbl.Text = "";
            SifreTbl.Text = "";
        }
    }
}
