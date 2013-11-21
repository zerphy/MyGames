using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Client.CalculatorService;
using Client.MasterService;

//using MyGames.DAL;
using MyGames.GameManager;
//
namespace Client
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();

            this.Init();
        }

        public void Init()
        {
            //using (CalculatorServiceClient proxy = new CalculatorServiceClient())
            //{
            //    double a = proxy.Add(1.0, 2.0);
            //    double b = proxy.Subtract(2.2, 1.3);
            //}

            using (MasterServiceClient proxy = new MasterServiceClient())
            {
                //int n = proxy.Register("abc", "abc", "abc");

                //n = proxy.Create("cff05111-8236-404a-b21a-3351ff17e05e", "路易斯", 1, 2, 3);

                //Master m = proxy.GetMasterById("cff05111-8236-404a-b21a-3351ff17e05e");
                bool l = proxy.Logon("a", "b");
            }

            int[] scores = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 4
                select score;
            foreach (int i in scoreQuery)
            {
                
            }
  

            //MyGames.GameManager.Business.LaunchServer();

            //MyGames.DAL.MyAccount account = new MyAccount();
            //account.AccountName = "a";
            //account.AccountPwd = "a";
            //MyGames.GameManager.Business.Logon(account);

            //account.AccountId = Guid.NewGuid();
            //account.AccountName = "b";
            //account.AccountPwd = "b";
            //account.Email = "b";
            //account.IP = "b";
            //account.IsOnline = false;
            //account.LastLogin = DateTime.Now;

            //MyGames.GameManager.Business.Register(account);
            
        }
    }
}
