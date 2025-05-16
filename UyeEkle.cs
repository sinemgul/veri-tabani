using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace WindowsFormsApp3
{
    public partial class UyeEkle : Form
    {
        public UyeEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=GALREN\SQLEXPRESS;Initial Catalog=galren;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UyeEkle_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AdTb.Text == "" || SoyadTb.Text == "" || DogumTarihiTb.Text == "" || UyelikBaslangicTb.Text == "" || UyelikBitisTb.Text == "" || UyelikDurumuTb.Text == "" || CinsiyetCb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    baglanti.Open();

                    // Önce IDENTITY_INSERT ayarını ON yapın
                    //string setIdentOnQuery = "SET IDENTITY_INSERT Uyeler ON";
                    //SqlCommand setIdentOnCmd = new SqlCommand(setIdentOnQuery, baglanti);
                    //setIdentOnCmd.ExecuteNonQuery();

                    // Şimdi veriyi ekleyin
                    string query = $"INSERT INTO Uyeler (Ad, Soyad, DogumTarihi, UyelikBaslangic, UyelikBitis, UyelikDurumu, Cinsiyet, Telefon, Email) " +
                                   $"VALUES ('{AdTb.Text}', '{SoyadTb.Text}', '{DogumTarihiTb.Text}', '{UyelikBaslangicTb.Text}', '{UyelikBitisTb.Text}', " +
                                   $"'{UyelikDurumuTb.Text}', '{CinsiyetCb.Text}', '{TelefonTb.Text}', '{EmailTb.Text}')";

                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();

                    MessageBox.Show("Üye Başarıyla Eklendi");

                    // IDENTITY_INSERT ayarını tekrar OFF yapın
                    //string setIdentOffQuery = "SET IDENTITY_INSERT Uyeler OFF";
                    //SqlCommand setIdentOffCmd = new SqlCommand(setIdentOffQuery, baglanti);
                   // setIdentOffCmd.ExecuteNonQuery();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                finally
                {
                    baglanti.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Hide();
        }
    }
}