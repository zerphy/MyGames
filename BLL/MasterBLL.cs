using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Linq.Expressions;

using MyGames.DAL;
using MyGames.Model;

namespace MyGames.BLL
{
    public static class MasterBLL
    {
        public static void NewServer()
        {
            using (DALDataContext db = new DALDataContext())
            {

                var onlinePlayers = from p in db.MyAccount
                                    where p.IsOnline == true
                                    select p;
                foreach (var player in onlinePlayers)
                {
                    player.IsOnline = false;
                }

                db.SubmitChanges();
            }
        }

        //data from db
        private static Master TransformMaster(Wizard wizard)
        {
            Master master = new Master();
            master.MId = wizard.WizardId;
            master.AccountId = wizard.AccountId;
            master.MName = wizard.WizardName;
            master.MLevel = (int)wizard.WizardLevel;
            master.CurrentXP = (int)wizard.CurrentXP;
            master.MaxXP = (int)wizard.MaxXP;
            master.CurrentStamina = (int)wizard.CurrentStamina;
            master.MaxStamina = (int)wizard.MaxStamina;
            master.StaminaCount = 0;
            master.OnlineCount = 100;

            return master;
        }

        public static bool Logon(string accountName, string passowrd)
        {
            using (DALDataContext db = new DALDataContext())
            {
                var q = db.MyAccount.Where(p =>
                    ((p.AccountName == accountName)
                    && (p.AccountPwd == passowrd)));
                if (q.Count() == 1)
                {
                    MyAccount user = q.Single();

                    //user.IP = account.IP;
                    user.IsOnline = true;

                    db.SubmitChanges();

                    var r = db.Wizard.Where(s => (s.AccountId == user.AccountId));

                    Wizard wizard = r.Single();

                    Master master = TransformMaster(wizard);

                    return true;
                }
            }
            return false;
        }

        public static void Logoff(Guid accountId)
        {
            using (DALDataContext db = new DALDataContext())
            {
                var q = db.MyAccount.Single(p => p.AccountId == accountId);

                if (q != null)
                {
                    q.IsOnline = false;
                    db.SubmitChanges();
                }
            }
        }

        public static void AllLogoff()
        {
            using (DALDataContext db = new DALDataContext())
            {
                var a = from p in db.MyAccount
                        where p.IsOnline == true
                        select p;

                foreach (var account in a)
                {
                    account.IsOnline = false;
                }

                db.SubmitChanges();
            }
        }

        public static int Register(string name, string pwd, string email)
        {
            using (DALDataContext db = new DALDataContext())
            {
                MyAccount account = new MyAccount();
                account.AccountId = Guid.NewGuid();
                account.AccountName = name;
                account.AccountPwd = pwd;
                account.Email = email;

                if (db.MyAccount.Where(p => (p.AccountName == account.AccountName)).Count() <= 0)
                {
                    if ((account.AccountPwd != null) && (account.AccountPwd != string.Empty))
                    {
                        db.MyAccount.InsertOnSubmit(account);
                        db.SubmitChanges();
                        return 1;
                    }
                }
            }
            return 0;
        }

        public static int Create(string accountId, string masterName, int race, int professional, int sex)
        {
            using (DALDataContext db = new DALDataContext())
            {
                if (db.Wizard.Where(p => (p.WizardName == masterName)).Count() <= 0)
                {
                    //TODO:唯一性判断
                    Wizard wizard = new Wizard();
                    wizard.WizardId = Guid.NewGuid();
                    wizard.AccountId = new Guid(accountId);
                    wizard.WizardName = masterName;
                    wizard.WizardLevel = 1;
                    wizard.CurrentXP = 0;
                    wizard.MaxXP = 100;
                    wizard.CurrentStamina = 10;
                    wizard.MaxStamina = 10;
                    wizard.Race = race;
                    wizard.Professional = professional;
                    wizard.Sex = sex;
                    wizard.Gold = 0;
                    wizard.Silver = 0;
                    wizard.Copper = 0;
                    wizard.VIPLevel = 0;
                    wizard.Money = 0;
                    db.Wizard.InsertOnSubmit(wizard);
                    db.SubmitChanges();
                    return 1;
                }
            }
            return 0;
        }

        public static MyAccount GetAccountById(Guid id)
        {
            using (DALDataContext db = new DALDataContext())
            {
                var q = db.MyAccount.Where(p => (p.AccountId == id));
                if (q.Count() == 1)
                {
                    MyAccount account = q.Single();
                    return account;
                }
            }
            return null;
        }

        public static Master GetMasterByAccountId(Guid id)
        {
            using (DALDataContext db = new DALDataContext())
            {
                var q = db.Wizard.Where(p => (p.AccountId == id));
                if (q.Count() == 1)
                {
                    Wizard wizard = q.Single();
                    Master master = TransformMaster(wizard);

                    return master;
                }
            }
            return null;
        }

        public static Master GetMasterByAccountName(string accountName)
        {
            using (DALDataContext db = new DALDataContext())
            {
                var q = from c in db.Wizard
                        join d in db.MyAccount
                        on c.AccountId equals d.AccountId
                        where d.AccountName == accountName
                            select c;
                if (q.Count() == 1)
                {
                    Wizard wizard = q.Single();
                    Master master = TransformMaster(wizard);

                    return master;
                }
            }
            return null;
        }

        public static Master GetMasterById(Guid id)
        {
            using (DALDataContext db = new DALDataContext())
            {
                var q = db.Wizard.Where(p => (p.WizardId == id));
                if (q.Count() == 1)
                {
                    Wizard wizard = q.Single();
                    Master master = TransformMaster(wizard);

                    return master;
                }
            }
            return null;
        }

        public static Master GetMasterByName(string name)
        {
            using (DALDataContext db = new DALDataContext())
            {
                var q = db.Wizard.Where(p => (p.WizardName == name));
                if (q.Count() == 1)
                {
                    Wizard wizard = q.Single();
                    Master master = TransformMaster(wizard);

                    return master;
                }
            }
            return null;
        }
    }
}
