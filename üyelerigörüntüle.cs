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
    public partial class üyelerigörüntüle : Form
    {
        public üyelerigörüntüle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=GALREN\SQLEXPRESS;Initial Catalog=galren;Integrated Security=True");

        private void uyeler()
        {
            baglanti.Open();
            string query = "select *from Uyeler";
            SqlDataAdapter sda= new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder= new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void üyelerigörüntüle_Load(object sender, EventArgs e)
        {
            uyeler();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa= new AnaSayfa();
            anaSayfa.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
