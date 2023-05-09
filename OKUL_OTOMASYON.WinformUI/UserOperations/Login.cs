using OKUL_OTOMASYON.Business.Abstract;
using OKUL_OTOMASYON.Business.Concrete;
using OKUL_OTOMASYON.DataAccessLayer.ContextBase.GenericRepository;
using OKUL_OTOMASYON.Entities.Tables;
using OKUL_OTOMASYON.WinformUI.Admin;
using OKUL_OTOMASYON.WinformUI.Teachers;
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
    public partial class Login : Form
    {
        TeachersManager mg = new TeachersManager();
        public Login()
        {
           
            InitializeComponent();
          
        }

        private void Login_Load(object sender, EventArgs e)
        {
           pnlOgrLogin.Visible = false;
            pnlTeach.Visible = false;
        }

        #region Cancel Ve Min Butonları
        private void btnCancel_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("Ugulamadan Çıkmak İstiyor Musunuz?","Çıkış Ekranı",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);

            if (result == DialogResult.OK) {

                Application.Exit();
                    
                    
             }

        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion
        #region Labelların Click Özellikleri



        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {
            pnlOgrLogin.Visible = true;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            pnlOgrLogin.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pnlOgrLogin.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            pnlTeach.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pnlTeach.Visible = true;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            pnlTeach.Visible = true;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlTeach.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlOgrLogin.Visible = false;
        }

        #endregion
        #region Formun Hareket Ettirilmesi 

        int move;
        int Mouse_X;
        int Mouser_y;

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;

            Mouse_X = e.X;
            Mouser_y = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1 )
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouser_y);
            }
        }

        #endregion
        #region Şifre Göster
    

        private void chkSifreGoster_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSifreGoster.Checked == false)
            {
                txtPassword.PasswordChar = '*';
            }
            else
            {
                txtPassword.PasswordChar = '\0';
            }
        }

        #endregion
        #region TC Kimlikte sayı kontrolü
        private void txtOgretmenTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            // char.IsDigit içersine gönderilen char verisininin sayısal olup olamdığının boolean karşılığını döndürür.
            //if (char.IsDigit(e.KeyChar))
            //{
            //    throw new Exception(e.KeyChar.ToString());
            //}

            // delete,enter  tuşlarını tespit ediyor:
            //if (char.IsControl(e.KeyChar))
            //{
            //    throw new Exception(e.KeyChar.ToString());
            //}


            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtOgrTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
           
            if (mg.isValid(txtOgretmenTC.Text,txtOgretmenNo.Text,txtPassword.Text) && mg.isAdmin(txtOgretmenTC.Text, txtOgretmenNo.Text))
            {
                var frm = CompositionRoot.Resolve <AdminHome>();

                this.Hide();
                frm.ShowDialog();
         
            }else if(mg.isValid(txtOgretmenTC.Text, txtOgretmenNo.Text, txtPassword.Text))
            {
                var frm = CompositionRoot.Resolve<TeachersHome>();

                this.Hide();
                frm.ShowDialog();
            }
            else
            {

                MessageBox.Show("Sistemde böyle bir öğretmen kayıtlı değil", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void txtOgretmenTC_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var frm = CompositionRoot.Resolve<ForgetPassword>();

            this.Hide();
            frm.ShowDialog();
        }
    }
}
