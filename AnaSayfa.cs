﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ÖDEMELER ÖDEMELER= new ÖDEMELER();
            ÖDEMELER.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UyeEkle uyeekle = new UyeEkle();
            uyeekle.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Guncelle guncelle= new Guncelle();
            guncelle.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            üyelerigörüntüle üyelerigörüntüle = new üyelerigörüntüle();
            üyelerigörüntüle.Show();
            this.Hide();
        }
    }
}
