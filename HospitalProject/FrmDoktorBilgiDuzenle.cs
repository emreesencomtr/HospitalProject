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

namespace HospitalProject
{
    public partial class FrmDoktorBilgiDuzenle : Form
    {
        public FrmDoktorBilgiDuzenle()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        public string TCNo;
        
        private void FrmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
           MskTC.Text = TCNo;

        }

        private void FrmDoktorBilgiDuzenle_Load_1(object sender, EventArgs e)
        {
            MskTC.Text = TCNo;
            SqlCommand komut = new SqlCommand("Select * from TblDoktorlar where DoktorTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",MskTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                TxtAdi.Text = dr[1].ToString();
                TxtSoyadi.Text = dr[2].ToString();
                CmbBrans.Text = dr[3].ToString();
                TxtSifre.Text = dr[5].ToString();
            }

            bgl.baglanti().Close(); 


        }

        private void BtnBilgiGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TblDoktorlar set DoktorAd=@p1, DoktorSoyad=@p2, DoktorBrans=@p3, DoktorSifre=@p4 where DoktorTC=@p5",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAdi.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyadi.Text);
            komut.Parameters.AddWithValue("@p3", CmbBrans.Text);
            komut.Parameters.AddWithValue("@p4", TxtAdi.Text);
            komut.Parameters.AddWithValue("@p5", MskTC.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti() .Close();
            MessageBox.Show("Kayıt Güncellendi!","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);



        }
    }
}
