using Microsoft.VisualBasic;
using OKUL_OTOMASYON.Business.Concrete;
using OKUL_OTOMASYON.WinformUI.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OKUL_OTOMASYON.WinformUI.UserOperations
{
    public partial class ForgetPassword : Form
    {

        TeachersManager mg = new TeachersManager();
        public ForgetPassword()
        {
            InitializeComponent();
        }


        private void btnKodGonder_Click(object sender, EventArgs e)
        {

            mg.KodGonder();
            string Kod = Interaction.InputBox("Bilgi Girişi", "Güvenlik kodunu giriniz!!", "bos",300,300);

          // var result = mg.IsCodeTrue(Kod);
            MessageBox.Show(Kod);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Ana Sayfaya Geri Dönmek İstiyor Musunuz?", "Çıkış Ekranı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {

            
                var frm = CompositionRoot.Resolve<Login>();

                this.Hide();
                frm.ShowDialog();

            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAnaSayfayaDon_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Ana Sayfaya Geri Dönmek İstiyor Musunuz?", "Çıkış Ekranı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {


                var frm = CompositionRoot.Resolve<Login>();

                this.Hide();
                frm.ShowDialog();

            }
        }
    }
}
