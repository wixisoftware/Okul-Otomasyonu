using OKUL_OTOMASYON.Business.Security;
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
    public partial class NewPassword : Form
    {
        public NewPassword()
        {
            InitializeComponent();
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

        private void button2_Click(object sender, EventArgs e)
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

        #endregion

        #region Şifre Gösterme İşlemleri

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox1.Checked == true ) // 1. yol
            //{

            //}

            if (checkBox1.CheckState == CheckState.Unchecked) // 1. yol
            {
                txtPassword.PasswordChar = '*';
            }
            else
            {
                txtPassword.PasswordChar = '\0';
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked == false) // 1. yol
            {
                txtPasswordAgain.PasswordChar = '*';
            }
            else
            {
                txtPasswordAgain.PasswordChar = '\0';
            }
        }


        #endregion

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            SifreTespit();


        }

        private void txtPasswordAgain_TextChanged(object sender, EventArgs e)
        {
            SifreTespit();
        }


        public void SifreTespit()
        {
            if( txtPassword.Text != txtPasswordAgain.Text)
            {
                return;
            }

            string password = txtPassword.Text;

           PasswordPowerDetected ps = new PasswordPowerDetected();

           var result = ps.GetLevel(password);

            switch (result)
            {
                case PasswordPowerDetected.PasswordStrenghLevel.Gecersiz:

                    prgBar_PasswordPower.Value = ps.GeneratePasswordScore(password);
                    prgBar_PasswordPower.ForeColor = Color.Gray;
                    lblPasswordPower.Text = "Şifre Geçersiz";
                    lblPasswordPower.ForeColor = Color.Gray;
                    break;
                case PasswordPowerDetected.PasswordStrenghLevel.Zayif:
                    prgBar_PasswordPower.Value = ps.GeneratePasswordScore(password);
                    prgBar_PasswordPower.ForeColor = Color.Red;
                    lblPasswordPower.Text = "Zayıf";
                    lblPasswordPower.ForeColor = Color.Red;
                    break;
                case PasswordPowerDetected.PasswordStrenghLevel.Normal:
                    prgBar_PasswordPower.Value = ps.GeneratePasswordScore(password);
                    prgBar_PasswordPower.ForeColor = Color.Yellow;
                    lblPasswordPower.Text = "Normal";
                    lblPasswordPower.ForeColor = Color.Yellow;
                    break;
                case PasswordPowerDetected.PasswordStrenghLevel.Guclu:
                    prgBar_PasswordPower.Value = ps.GeneratePasswordScore(password);
                    prgBar_PasswordPower.ForeColor =Color.Green;
                    lblPasswordPower.Text = "Güçlü";
                    lblPasswordPower.ForeColor = Color.Green;
                    break;
                case PasswordPowerDetected.PasswordStrenghLevel.Guvenli:


                    prgBar_PasswordPower.Value = ps.GeneratePasswordScore(password);
                    prgBar_PasswordPower.ForeColor = Color.Green;
                    lblPasswordPower.Text = "Güvenli";
                    lblPasswordPower.ForeColor = Color.Green;
                    break;
              
            }

        }

    
    }
}
