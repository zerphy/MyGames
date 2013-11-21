using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyGames.Contracts;
using MyGames.Model;
using MyGames.DAL;
using MyGames;

namespace MyGames.Services
{
    public class MasterService : IMaster
    {
        public bool Logon(string accountName, string pwd)
        {
            return GameManager.Business.Logon(accountName, pwd);
        }

        public int Register(string accountName, string pwd, string email)
        {
            return GameManager.Business.Register(accountName, pwd, email);
        }

        public int Create(string accountId, string masterName, string race, string professional, string sex)
        {
            return GameManager.Business.Create(accountId, masterName, Convert.ToInt32(race), Convert.ToInt32(professional), Convert.ToInt32(sex));
        }

        public Master GetMasterById(string id)
        {
            return GameManager.Business.GetMasterByAccountId(id);
        }

    }
}
