using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyGames.Model;

namespace MyGames.GameManager
{
    public class OnlineMaster
    {
        private Dictionary<Guid, Master> _masters;
        private Dictionary<Guid, int> _onlineCount;

        public OnlineMaster()
        {
            _masters = new Dictionary<Guid, Master>();
            _onlineCount = new Dictionary<Guid, int>();
        }

        public void Clear()
        {
            _masters.Clear();
            _onlineCount.Clear();
        }

        public bool MasterLogon(Master master)
        {
            if (_masters.ContainsKey(master.AccountId))
            {
                _onlineCount[master.AccountId] = master.OnlineCount;
                //TODO:已登录，踢掉或者其他处理
            }
            else
            {
                _masters.Add(master.AccountId, master);
                _onlineCount.Add(master.AccountId, master.OnlineCount);

                System.Diagnostics.Debug.WriteLine(string.Format("User Logon: id-{0}, name-{1}", master.AccountId, master.MName));
                return true;
            }
            return false;
        }

        public bool MasterLogoff(Guid accountId)
        {
            if (_masters.ContainsKey(accountId))
            {
                _masters.Remove(accountId);
                _onlineCount.Remove(accountId);
                return true;
            }

            return false;
        }

        public void MasterOnlineTest()
        {
            foreach (KeyValuePair<Guid, int> pair in _onlineCount)
            {
                if (pair.Value > 0)
                {
                    _onlineCount[pair.Key]--;
                    if (_onlineCount[pair.Key] == 0)
                    {
                        _masters.Remove(pair.Key);
                    }
                }
            }
        }

        public void MasterRefresh(Guid accountId)
        {
            if (_masters.ContainsKey(accountId))
            {
                _onlineCount[accountId] = 100;
            }
        }

    }
}
