using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 

namespace UrunSatis_EntityUygulama_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Kategori Ekleme";

        }

        UrunSatisEntities db = new UrunSatisEntities();
        private void BtnListele_Click(object sender, EventArgs e)
        {
            var kategoriler = db.TBLKATEGORI.ToList();
            dataGridView1.DataSource = kategoriler;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TBLKATEGORI t = new TBLKATEGORI();
            t.AD = TxtKatAd.Text;
            db.TBLKATEGORI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori eklendi");
        }

     
        private void BtnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtKatID.Text);
            var k = db.TBLKATEGORI.Find(x);
            db.TBLKATEGORI.Remove(k);
            db.SaveChanges();
            MessageBox.Show("Kategori silindi");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtKatID.Text);
            var k = db.TBLKATEGORI.Find(x);
            k.AD = TxtKatAd.Text;
            db.SaveChanges();
            MessageBox.Show("Kayıt güncellendi.");
        }
    }
}
