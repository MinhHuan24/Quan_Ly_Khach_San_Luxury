using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyKhachSan.Models;
using QuanLyKhachSan.Views;

namespace QuanLyKhachSan
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static string user;
        public static string idLogin;
        public frmMain()
        {
            InitializeComponent();
            idLogin = string.Empty;
            DisEndMenuLogin(true, idLogin);
        }
        public void skin()
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel themes = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            themes.LookAndFeel.SkinName = "Valentine";
        }
        public void DisEndMenuLogin(bool e, string _idLogin)
        {
            btnLogin.Enabled = e;
            bool isLoggedIn = !e && !string.IsNullOrEmpty(_idLogin);

            btnChangePass.Enabled = isLoggedIn;
            btnLogout.Enabled = isLoggedIn;
            btnPhanQuyen.Enabled = isLoggedIn;
            btnBackup.Enabled = isLoggedIn;
            btnRestore.Enabled = isLoggedIn;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            skin();
            DisEndMenuLogin(true, idLogin);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr;
            dr = XtraMessageBox.Show("Bạn có muốn thoát ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmLogin login = new frmLogin();
            while (true)
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    if (string.IsNullOrEmpty(login.txtUser.Text))
                    {
                        XtraMessageBox.Show("Hãy nhập vào username !");
                        continue;
                    }
                    if (string.IsNullOrEmpty(login.txtPass.Text))
                    {
                        XtraMessageBox.Show("Hãy nhập vào password !");
                        continue;
                    }

                    string username = login.txtUser.Text;
                    string pass = Models.UserControl.SHA256(login.txtPass.Text);
                    string result = LoginCtrl.checkDangNhap(username, pass);

                    if (string.IsNullOrEmpty(result))
                    {
                        XtraMessageBox.Show("Đăng nhập thất bại. Kiểm tra lại Tài khoản hoặc Mật khẩu !");
                    }
                    else
                    {
                        user = username;
                        idLogin = result;
                        DisEndMenuLogin(false, idLogin);
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        private void btnLogout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(XtraMessageBox.Show("Bạn có muốn đăng xuất ? ", "Thông báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DisEndMenuLogin(true, idLogin);
                btnLogin_ItemClick(sender, e);
            }
        }
    }
}
