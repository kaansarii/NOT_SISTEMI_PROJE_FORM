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

namespace NOT_SISTEMI_PROJE_FORM
{
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=Kaan\SQLEXPRESS; Initial Catalog=BonusOkul; Integrated Security=True; TrustServerCertificate=True");
        public string numara;
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT DERSAD,SINAV1,SINAV2,SINAV3,PROJE,ORTALAMA,DURUM FROM TBLNOTLAR\r\nINNER JOIN TBLDERSLER ON TBLNOTLAR.DERSID=TBLDERSLER.DERSID WHERE OGRID=@P1", baglanti);
            komut.Parameters.AddWithValue("@P1",numara);
            SqlDataAdapter da = new SqlDataAdapter(komut);      
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            //NO'SU GİRİŞ YAPAN ÖĞRENCİNİN ADINI FORMA YAZDIRMA
            SqlCommand komut2 = new SqlCommand("Select * from TBLOGRENCILER WHERE OGRID=@P2", baglanti);
            komut2.Parameters.AddWithValue("@P2", numara);
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                string ogrenciIsmi = dt2.Rows[0]["OGRAD"].ToString();
                this.Text = ogrenciIsmi; // Form başlığına öğrenci ismini yaz
            }
            else
            {
                MessageBox.Show("Öğrenci bulunamadı.");
            }

        }
    }
}
