using JiangH.Interfaces;
using JiangH.Messages;

namespace JiangH.Systems
{
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
