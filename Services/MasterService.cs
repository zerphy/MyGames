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
        public OprResult Logon(string accountName, string pwd)
        {
            OprResult r = new OprResult();
            bool val = GameManager.Business.Logon(accountName, pwd);
            r.Opr = "MasterLogin";
            r.Result = val ? "success" : "fail";
            return r;
        }

        public OprResult Register(string accountName, string pwd, string email)
        {
            OprResult r = new OprResult();
            int val = GameManager.Business.Register(accountName, pwd, email);
            r.Opr = "MasterRegister";
            r.Result = (val > 0) ? "success" : "fail";
            return r;
        }

        public OprResult Create(string accountId, string masterName, string race, string professional, string sex)
        {
            OprResult r = new OprResult();
            int val = GameManager.Business.Create(accountId, masterName, Convert.ToInt32(race), Convert.ToInt32(professional), Convert.ToInt32(sex));
            r.Opr = "MasterCreate";
            r.Result = (val > 0) ? "success" : "fail";
            return r;
        }

        public Master GetMasterById(string id)
        {
            return GameManager.Business.GetMasterByAccountId(id);
        }

    }
}
