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
    public partial class FrmBrans : Form
    {
        public FrmBrans()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmBrans_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TblBranslar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand  komut = new SqlCommand("insert into TblBranslar (BransAd) values (@b1)",bgl.baglanti());
            komut.Parameters.AddWithValue("@b1", TxtBransAd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Eklendi!","Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            Txtid.Text= dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtBransAd.Text= dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Delete from TblBranslar where Bransid=@b1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@b1",Txtid.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);





        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("update TblBranslar set BransAd=@b1 where Bransid=@b2 ",bgl.baglanti());
            komut3.Parameters.AddWithValue("@b1", TxtBransAd.Text);
            komut3.Parameters.AddWithValue("@b2", Txtid.Text);
            komut3.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Güncellendi!","Bilgi", MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
