using JiangH.Interfaces;
using JiangH.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JiangH.Systems
{
    public class TreasurySystem : MessageInOut, ISystem
    {
        public IEnumerable<ITreasury> items { get; set; }

        public TreasurySystem(IEnumerable<ITreasury> items)
        {
            this.items = items;

            RegisterMsg<MESSAGE_DATE_INC>(OnMessageDateInc);
        }

        void OnMessageDateInc(MESSAGE_DATE_INC msg)
        {
            if (msg.day == 1)
            {
                foreach (var treasury in items)
                {
                    treasury.current += treasury.surplus;
                }
            }
        }
    }

    public class PlayerSystem : MessageIn , ISystem
    {
        private ISession session;

        public PlayerSystem(ISession session)
        {
            this.session = session;

            RegisterMsg<MESSAGE_CHANGE_PLAYER>(OnMessageChangePlayer);
        }

        void OnMessageChangePlayer(MESSAGE_CHANGE_PLAYER msg)
        {
            this.session.player = msg.newPlayer;
        }
    }

}
