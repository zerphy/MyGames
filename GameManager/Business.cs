using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Linq.Expressions;

using MyGames.DAL;
using MyGames.Model;
using MyGames.BLL;

namespace MyGames.GameManager
{
    public static class Business
    {
        private static OnlineMaster _masters = new OnlineMaster();

        public static void LaunchServer()
        {
            MasterBLL.NewServer();
            _masters.Clear();
        }

        public static bool Logon(string accountName, string password)
        {
            if (MasterBLL.Logon(accountName, password))
            {
                Master master = MasterBLL.GetMasterByAccountName(accountName);
                _masters.MasterLogon(master);
                return true;
            }
            
            return false;
        }

        public static void Logoff(Guid accountId)
        {
            MasterBLL.Logoff(accountId);
            _masters.MasterLogoff(accountId);
        }

        public static void AllLogoff()
        {
            MasterBLL.AllLogoff();
            _masters.Clear();
        }

        public static void MasterRefresh(Guid accountId)
        {
            _masters.MasterRefresh(accountId);
        }

        public static int Register(string name, string pwd, string email)
        {
            return MasterBLL.Register(name, pwd, email);
        }

        public static int Create(string accountId, string masterName, int race, int professional, int sex)
        {
            return MasterBLL.Create(accountId, masterName, race, professional, sex);
        }

        public static Master GetMasterByAccountId(string id)
        {

            return MasterBLL.GetMasterByAccountId(new Guid(id));
        }

        //public static Master GetMasterById(Guid id)
        //{
            
        //    return null;
        //}

        //public static Master GetMasterByName(string name)
        //{
            
        //    return null;
        //}
    }
}
