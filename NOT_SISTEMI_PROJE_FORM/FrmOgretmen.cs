using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NOT_SISTEMI_PROJE_FORM
{
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmKulup frmk = new FrmKulup();
            frmk.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDersler frmd = new FrmDersler();
            frmd.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmOgrenci frmo = new FrmOgrenci();
            frmo.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmOgretmenler  frog = new FrmOgretmenler();
            frog.Show();    
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSinavNotlar frsi = new FrmSinavNotlar();
            frsi.Show();
        }
    }
}
