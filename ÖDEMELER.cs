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
    public partial class ÖDEMELER : Form
    {
        public ÖDEMELER()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=GALREN\SQLEXPRESS;Initial Catalog=galren;Integrated Security=True");
       
        private void FillName() 
        { 
            baglanti.Open(); 
            SqlCommand komut = new SqlCommand("select Telefon from Uyeler",baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dataTable= new DataTable();
            dataTable.Columns.Add("Telefon",typeof(string));
            dataTable.Load(rdr);
            TelefonCb.ValueMember = "Telefon";
            TelefonCb.DataSource= dataTable;
            baglanti.Close();
            
        
        
        }
        private void uyeler()
        {
            baglanti.Open();
            string query = $"Select * From OdemeTbl;";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TelefonCb.Text = "";
            OdemeTb.Text = "";

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
          if(TelefonCb.Text==""|| OdemeTb.Text == "" || TutarTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                string odemeperiyot= OdemeTb.Value.Month.ToString() + OdemeTb.Value.Year.ToString();
                baglanti.Open();
                SqlDataAdapter sda =new SqlDataAdapter("select count(*) from OdemeTbl where Ouye='" + TelefonCb.SelectedValue.ToString()+"' and Oay='"+odemeperiyot+"'", baglanti);
                DataTable dt= new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Zaten ödeme yapıldı");
                }
                else
                {
                    string query="insert into OdemeTbl (Oay, Ouye, Omiktar)values('" + odemeperiyot+ "','"+TelefonCb.SelectedValue.ToString()+"',"+TutarTb.Text+")";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Tutar başarıyla ödendi");
                }
                baglanti.Close();
                uyeler();
            }      
        }

        private void ÖDEMELER_Load(object sender, EventArgs e)
        {
            FillName();
            uyeler();
        }

        private void TelefonCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
