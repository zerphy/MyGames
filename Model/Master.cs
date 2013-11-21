using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGames.Model
{
    public class Master
    {
        public Guid MId
        {
            get;
            set;
        }

        public Guid AccountId
        {
            get;
            set;
        }

        public string MName
        {
            get;
            set;
        }

        public int MLevel
        {
            get;
            set;
        }

        public int CurrentXP
        {
            get;
            set;
        }

        public int MaxXP
        {
            get;
            set;
        }

        public int CurrentStamina
        {
            get;
            set;
        }

        public int MaxStamina
        {
            get;
            set;
        }

        public int StaminaCount
        {
            get;
            set;
        }

        public int OnlineCount
        {
            get;
            set;
        }
    }
}
