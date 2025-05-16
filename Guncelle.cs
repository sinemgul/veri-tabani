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
    public partial class Guncelle : Form
    {
        public Guncelle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=GALREN\SQLEXPRESS;Initial Catalog=galren;Integrated Security=True");

        private void uyeler()
        {
            baglanti.Open();
            string query = "select *from Uyeler";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void Guncelle_Load(object sender, EventArgs e)
        {
            uyeler();
        }
        int key = 0;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Eğer bir satır tıklanmışsa devam edelim
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Verileri kontrollere atama işlemi
                key = Convert.ToInt32(row.Cells["UyeID"].Value);
                AdTb.Text = row.Cells["Ad"].Value.ToString();
                SoyadTb.Text = row.Cells["Soyad"].Value.ToString();
                CinsiyetCb.Text = row.Cells["Cinsiyet"].Value.ToString();
                DogumTarihiTb.Text = row.Cells["DogumTarihi"].Value.ToString();
                TelefonTb.Text = row.Cells["Telefon"].Value.ToString();
                EmailTb.Text = row.Cells["Email"].Value.ToString();
                UyelikBaslangicTb.Text = row.Cells["UyelikBaslangic"].Value.ToString();
                UyelikBitisTb.Text = row.Cells["UyelikBitis"].Value.ToString();
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

      

            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            private void button3_Click(object sender, EventArgs e)
            {
                AdTb.Text = "";
                SoyadTb.Text = "";
                TelefonTb.Text = "";
                CinsiyetCb.Text = "";
                DogumTarihiTb.Text = "";
                EmailTb.Text = "";
                UyelikBaslangicTb.Text = "";
                UyelikBitisTb.Text = "";

            }

            private void button2_Click(object sender, EventArgs e)
            {
                AnaSayfa anasayfa = new AnaSayfa();
                anasayfa.Show();
                this.Hide();
            }

            private void button4_Click(object sender, EventArgs e)
            {
                if (key == 0)
                {
                    MessageBox.Show("Silinecek üyeyi seciniz.");
                }
                else
                {
                    try
                    {
                        baglanti.Open();
                        string query = "delete from Uyeler where UyeId=" + key + ";";
                        SqlCommand komut = new SqlCommand(query, baglanti);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Üye Basarıyla silindi");
                        baglanti.Close();
                        uyeler();
                    } catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0 || AdTb.Text == "" || SoyadTb.Text == "" || TelefonTb.Text == "" || CinsiyetCb.Text == "" || DogumTarihiTb.Text == "" || UyelikBaslangicTb.Text == "" || UyelikBitisTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "update Uyeler set Ad= '" + AdTb.Text + "', Soyad='" + SoyadTb.Text + "', Telefon='" + TelefonTb.Text + "', Cinsiyet='" + CinsiyetCb.Text + "', Email='" + EmailTb.Text + "', UyelikBaslangic='" + UyelikBaslangicTb.Text + "', UyelikBitis='" + UyelikBitisTb.Text + "' where UyeID=" + key + ";";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Üye Başarıyla Güncellendi");
                    baglanti.Close();
                    uyeler();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    } 
}
