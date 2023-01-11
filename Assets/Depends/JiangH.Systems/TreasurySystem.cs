using JiangH.Interfaces;
using JiangH.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
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

    public class RecruitSystem : MessageInOut, ISystem
    {
        const int MAX_JOB_SEEKER_COUNT = 5;

        private ISession session;
        private Random random;

        public RecruitSystem(ISession session)
        {
            this.session = session;
            this.random = new Random();

            RegisterMsg<MESSAGE_DATE_INC>(OnMessageDateInc);
        }

        void OnMessageDateInc(MESSAGE_DATE_INC msg)
        {
            foreach (var sect in session.sects)
            {
                if(sect.willJoininPersons.Count() >= MAX_JOB_SEEKER_COUNT)
                {
                    continue;
                }

                foreach (var person in session.persons.Where(x => x.sect == null && x.willJoinInSect == null))
                {
                    if (!MeetRequirement(person, sect.recruitRequest))
                    {
                        continue;
                    }

                    var desire = CalcDWillJoinIn(person, sect);
                    if (desire < random.Next(0, 100))
                    {
                        continue;
                    }

                    var msgPersonWillJoininSect = new MESSAGE_PERSON_WILL_JOININ_SECT();
                    msgPersonWillJoininSect.person = person;
                    msgPersonWillJoininSect.sect = sect;

                    SendMessage(msgPersonWillJoininSect);
                }
            }
        }

        private bool MeetRequirement(IPerson person, object recruitRequest)
        {
            return random.Next(0, 100) > 50;
        }

        private int CalcDWillJoinIn(IPerson person, ISect sect)
        {
            return random.Next(0, 100);
        }
    }

}
