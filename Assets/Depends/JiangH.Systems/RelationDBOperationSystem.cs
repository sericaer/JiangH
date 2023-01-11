using JiangH.Interfaces;
using JiangH.Messages;
using System.Linq;

namespace JiangH.Systems
{
    public class RelationDBOperationSystem : MessageIn, ISystem
    {
        public IRelationDataBase relationDB { get; set; }

        public RelationDBOperationSystem(Relations.RelationDataBase relationDB)
        {
            this.relationDB = relationDB;

            RegisterMsg<MESSAGE_CHANGE_REGION_OWNER>(OnMessageChangeRegionOwner);
            RegisterMsg<MESSAGE_ADD_PATROLER_TO_REGION>(OnMessageAddPatrolerToRegion);
            RegisterMsg<MESSAGE_REMOVE_PATROLER_FROM_REGION>(OnMessageRemovePatrolerFromRegion);
            RegisterMsg<MESSAGE_PERSON_WILL_JOININ_SECT>(OnMessagePersonWillJoinInSect);
            RegisterMsg<MESSAGE_PERSON_JOININ_SECT>(OnMessagePersonJoininSect);
        }

        private void OnMessageChangeRegionOwner(MESSAGE_CHANGE_REGION_OWNER msg)
        {
            var oldRelation = relationDB.Where(x => x.label == IRelation.Label.Owner).SingleOrDefault(x => x.to == msg.region);
            if (oldRelation != null)
            {
                relationDB.RemoveRelation(oldRelation);
            }

            relationDB.AddRelation(msg.owner as IEntity, msg.region as IEntity, IRelation.Label.Owner);
        }

        private void OnMessageAddPatrolerToRegion(MESSAGE_ADD_PATROLER_TO_REGION msg)
        {
            //var oldRelation = relationDB.Where(x => x.label == IRelation.Label.Owner).SingleOrDefault(x => x.to == msg.region);
            //if (oldRelation != null)
            //{
            //    relationDB.RemoveRelation(oldRelation);
            //}

            relationDB.AddRelation(msg.patroler as IEntity, msg.region as IEntity, IRelation.Label.Patrol);
        }

        private void OnMessageRemovePatrolerFromRegion(MESSAGE_REMOVE_PATROLER_FROM_REGION msg)
        {
            var oldRelation = relationDB.Where(x => x.label == IRelation.Label.Patrol).SingleOrDefault(x => x.from == msg.patroler);
            if (oldRelation != null)
            {
                relationDB.RemoveRelation(oldRelation);
            }
        }

        private void OnMessagePersonWillJoinInSect(MESSAGE_PERSON_WILL_JOININ_SECT msg)
        {
            relationDB.AddRelation(msg.person as IEntity, msg.sect as IEntity, IRelation.Label.WillJoinin);
        }

        private void OnMessagePersonJoininSect(MESSAGE_PERSON_JOININ_SECT msg)
        {
            var oldRelation = relationDB.Where(x => x.label == IRelation.Label.WillJoinin).SingleOrDefault(x => x.from == msg.person);
            if (oldRelation != null)
            {
                relationDB.RemoveRelation(oldRelation);
            }

            relationDB.AddRelation(msg.person as IEntity, msg.sect as IEntity, IRelation.Label.Member);
        }
    }
}
