using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.ServiceModel;
using System.ServiceModel.Description;

using MyGames.Contracts;
using MyGames.Services;
using MyGames.GameManager;

using System.Security.Cryptography;

namespace Hosting
{
    public partial class HostForm : Form
    {
        //private ServiceHost _host = null;

        private ServiceHost _hostMaster = null;

        public HostForm()
        {
            InitializeComponent();
            this.Init();
        }

        private void Init()
        {
            string s = "a";
            byte[] result = Encoding.Default.GetBytes(s);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string v = BitConverter.ToString(output).Replace("-", "");
            string w = v.ToLower();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //if (_host == null)
            //{
            //    _host = new ServiceHost(typeof(CalculatorService));
            //    _host.Opened += new EventHandler(OnHostOpened);
            //    _host.Closed += new EventHandler(OnHostClosed);
            //}

            //_host.Open();

            if (_hostMaster == null)
            {
                _hostMaster = new ServiceHost(typeof(MasterService));
                _hostMaster.Opened += new EventHandler(OnHostOpened);
                _hostMaster.Closed += new EventHandler(OnHostClosed);
            }

            _hostMaster.Open();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //if (_host != null)
            //{
            //    _host.Close();
            //    _host = null;
            //}

            if (_hostMaster != null)
            {
                _hostMaster.Close();
                _hostMaster = null;
            }
        }

        public void OnHostOpened(object sender, EventArgs e)
        {
            this.SetButtonState(btnStart, false);
            this.SetButtonState(btnStop, true);
            MyGames.GameManager.Business.LaunchServer();
            this.SetLabelText(lblServerStatus, "服务已启动。");
        }

        public void OnHostClosed(object sender, EventArgs e)
        {
            this.SetButtonState(btnStart, true);
            this.SetButtonState(btnStop, false);
            this.SetLabelText(lblServerStatus, "服务已关闭。");
        }

        delegate void SetLabelTextCallback(Label label, string text);
        private void SetLabelText(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                SetLabelTextCallback d = new SetLabelTextCallback(SetLabelText);
                label.Invoke(d, new object[] { label, text });
            }
            else
            {
                label.Text = text;
            }
        }

        delegate void SetButtonStateCallback(Button btn, bool enabled);
        private void SetButtonState(Button btn, bool enabled)
        {
            if (btn.InvokeRequired)
            {
                SetButtonStateCallback d = new SetButtonStateCallback(SetButtonState);
                btn.Invoke(d, new object[] { btn, enabled });
            }
            else
            {
                btn.Enabled = enabled;
            }
        }
    }
}
