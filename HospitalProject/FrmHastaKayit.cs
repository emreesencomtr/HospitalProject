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
    public partial class FrmHastaKayit : Form
    {
        public FrmHastaKayit()
        {
            InitializeComponent();
        }

        private void TxtAdi_TextChanged(object sender, EventArgs e)
        {

        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        private void BtnKayitYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TblHastalar (HastaAd,HastaSoyad,HastaTC,HastaTelefon,HastaSifre,HastaCinsiyet) values (@p1,@p2,@p3,@p4,@p5,@p6) ", bgl.baglanti());
            komut.Parameters.Add("@p1",TxtAdi.Text);
            komut.Parameters.Add("@p2",TxtSoyadi.Text);
            komut.Parameters.Add("@p3",MskTC.Text);
            komut.Parameters.Add("@p4",maskedTelefon.Text);
            komut.Parameters.Add("@p5",TxtSifre.Text);
            komut.Parameters.Add("@p6", comboBoxCinsiyet.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız Gerçekleştirilmiştir. Şifreniz: " + TxtSifre.Text,"Bilgi", MessageBoxButtons.OK,MessageBoxIcon.Information);

        }
    }
}
