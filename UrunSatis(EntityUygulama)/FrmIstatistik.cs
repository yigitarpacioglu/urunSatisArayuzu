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
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "";
        }

        UrunSatisEntities db = new UrunSatisEntities();
        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            lbl1.Text = db.TBLKATEGORI.Count().ToString();
            lbl2.Text = db.TBLURUN.Count().ToString();
            lbl3.Text = db.TBLMUSTERI.Count(x => x.DURUM == true).ToString();
            lbl4.Text = db.TBLMUSTERI.Count(x => x.DURUM == false).ToString();
            lbl5.Text = db.TBLURUN.Count(x => x.KATEGORI == 1).ToString();
            lbl6.Text = db.TBLURUN.Sum(y => y.STOK).ToString();
            lbl7.Text = (from x in db.TBLURUN orderby x.FIYAT descending select x.URUNAD).FirstOrDefault();
            lbl8.Text = (from x in db.TBLURUN orderby x.FIYAT ascending select x.URUNAD).FirstOrDefault();
            lbl9.Text = (from x in db.TBLMUSTERI select x.SEHIR).Distinct().Count().ToString();
            lbl10.Text = db.TBLSATIS.Sum(y => y.FIYAT).ToString()+" TL";
            lbl11.Text = db.MAKSMARKA().FirstOrDefault();
            lbl12.Text = db.TBLURUN.Count(x => x.URUNAD == "BUZDOLABI").ToString();
        }
    }
}
