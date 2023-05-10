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
            // mg den girilen bilgiler ait öğretmen bilgisi var mıyı çekiceğiz var ise öğretmenin mail adresine kodu gönderticeğiz.
            
          var kullaniciVarMi =  mg.GetTeacherWithInfo( txtOgretmenNo.Text , txtTCKimlikNo.Text ,txtEMail.Text);

            if (kullaniciVarMi == false)
            {
                MessageBox.Show("Girdiğiniz kullanıcı bilgileri sistemde var olan kullanıcılar ile eşleşmiyor!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }


            mg.KodGonder();
            string Kod = Interaction.InputBox("Bilgi Girişi", "Güvenlik kodunu giriniz!!", "Lütfe Kodu Giriniz",300,300);

            var result = mg.IsCodeTrue(Kod);

            if (result == true)
            {
                // Yeni Şifre Belirleme Ekranına gidicek
            }
            else
            {
                MessageBox.Show("Girdiğiniz kod gönderilen kod ile eşleşmiyor tekrar deneyiniz!", "Uyarı", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }

           
        }

        #region Kapatma İşlemleri
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

        #endregion
    }
}
