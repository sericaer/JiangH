using JiangH.Dates;
using JiangH.Interfaces;
using JiangH.Messages.Interfaces;
using JiangH.Regions;
using JiangH.Sects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JiangH.Sessions
{
    public partial class Session
    {
        public static class Builder
        {
            public static ISession Build(GMInit gmInit)
            {
                var session = new Session();

                session.date = new Date();

                session.terrainMap = JiangH.Maps.TerrainMap.Builder.Build(gmInit.mapHeight, gmInit.mapWidth);

                session.entities.AddRange(Region.Builder.BuildCollection(session.terrainMap, gmInit.regionCount));

                session.entities.AddRange(Sect.Builder.BuildCollection(gmInit.sectCount));

                BuildRelationSect2Reigions(session);

                session.systems.AddRange(BuildSystems(session.entities, session.relationDB));

                RegisterMessages(session);

                return session;
            }

            private static void RegisterMessages(Session session)
            {
                session.messageBus.Register((Date)session.date);

                foreach(var system in session.systems)
                {
                    if(system is IMessageInOut)
                    {
                        session.messageBus.Register((IMessageInOut)system);
                    }
                    else if(system is IMessageIn)
                    {
                        session.messageBus.Register((IMessageIn)system);
                    }
                    else if (system is IMessageOut)
                    {
                        session.messageBus.Register((IMessageInOut)system);
                    }
                }
            }

            private static List<ISystem> BuildSystems(List<IEntity> entities, Relations.RelationDataBase relationDB)
            {
                var systems = new List<ISystem>();

                var treasurySys = new TreasurySystem();
                treasurySys.items = entities.SelectMany(x => x.components).OfType<ITreasury>();

                systems.Add(treasurySys);

                var relationDBOperationSystem = new RelationDBOperationSystem();
                relationDBOperationSystem.relationDB = relationDB;
                systems.Add(relationDBOperationSystem);

                return systems;
            }

            private static void BuildRelationSect2Reigions(Session session)
            {
                Random random = new Random();
                var regionStack = new Queue<IRegion>(session.regions.OrderBy(_ => random.Next(0, int.MaxValue)));
                foreach (var sect in session.sects)
                {
                    var region = regionStack.Dequeue();

                    session.relationDB.AddRelation(sect as IEntity, region as IEntity, IRelation.Label.Owner);
                    session.relationDB.AddRelation(region as IEntity, sect as IEntity, IRelation.Label.Location);
                }
            }
        }
    }
}
