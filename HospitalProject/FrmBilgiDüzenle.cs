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
    public partial class FrmBilgiDüzenle : Form
    {
        public FrmBilgiDüzenle()
        {
            InitializeComponent();
        }
        public string TCno;
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmBilgiDüzenle_Load(object sender, EventArgs e)
        {
            MskTC.Text = TCno;
            SqlCommand komut = new SqlCommand("Select * from TblHastalar where HastaTC=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtAdi.Text = dr[1].ToString();
                TxtSoyadi.Text = dr[2].ToString();
                maskedTelefon.Text = dr[4].ToString();
                TxtSifre.Text = dr[5].ToString();
                comboBoxCinsiyet.Text = dr[6].ToString();

            }
         
            bgl.baglanti().Close();
        }

        private void BtnBilgiGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update TblHastalar set HastaAd=@p1,HastaSoyad=@p2,HastaTelefon=@p3,HastaSifre=@p4,HastaCinsiyet=@p5 where HastaTC=@p6", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", TxtAdi.Text);
            komut2.Parameters.AddWithValue("@p2", TxtSoyadi.Text);
            komut2.Parameters.AddWithValue("@p3", maskedTelefon.Text);
            komut2.Parameters.AddWithValue("@p4", TxtSifre.Text);
            komut2.Parameters.AddWithValue("@p5", comboBoxCinsiyet.Text);
            komut2.Parameters.AddWithValue("@p6", MskTC.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz Güncellendi.","Bilgi", MessageBoxButtons.OK,MessageBoxIcon.Warning);


        }
    }
}
