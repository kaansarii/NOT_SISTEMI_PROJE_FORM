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

namespace NOT_SISTEMI_PROJE_FORM
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=Kaan\SQLEXPRESS; Initial Catalog=BonusOkul; Integrated Security=True; TrustServerCertificate=True");


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLKULUPLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbOgrenciKulup.DisplayMember = "KULUPAD";
            CmbOgrenciKulup.ValueMember = "KULUPID";
            CmbOgrenciKulup.DataSource = dt;
            baglanti.Close();
        }

        string c = "";
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                c = "ERKEK";
            }
            if(radioButton2.Checked == true)
            {
                c = "KIZ";
            }
            ds.OgrenciEkle(TxtOgrenciAd.Text, TxtOgrenciSoyad.Text, byte.Parse(CmbOgrenciKulup.SelectedValue.ToString()), c);
            MessageBox.Show("Öğrenci Ekleme Yapıldı");
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void CmbOgrenciKulup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(TxtOgrenciid.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtOgrenciid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtOgrenciAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtOgrenciSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            CmbOgrenciKulup.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(); // Kulüp sütunu [3] olabilir

            // Cinsiyetin kontrol edilmesi (örneğin: 'Erkek' veya 'Kadın')
            string cinsiyet = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(); // Cinsiyet sütunu [4] olabilir

            if (cinsiyet == "ERKEK")
            {
                radioButton1.Checked = false;
                radioButton1.Checked = true; // Erkek radiobutton'ı seçili hale getiriliyor
            }
            else if (cinsiyet == "KIZ")
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true; // Kadın radiobutton'ı seçili hale getiriliyor
            }

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(TxtOgrenciAd.Text, TxtOgrenciSoyad.Text, byte.Parse(CmbOgrenciKulup.SelectedValue.ToString()), c, int.Parse(TxtOgrenciid.Text));
            MessageBox.Show("Öğrenci Güncelleme Yapıldı");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                c = "KIZ";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "ERKEK";
            }
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource= ds.OgrenciGetir(TxtAranacak.Text);
        }
    }
}
