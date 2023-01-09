using JiangH.Dates;
using JiangH.Interfaces;
using JiangH.Messages.Interfaces;
using JiangH.Persons;
using JiangH.Regions;
using JiangH.Sects;
using JiangH.Systems;
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

                session.terrainMap = Maps.TerrainMap.Builder.Build(gmInit.mapHeight, gmInit.mapWidth);

                session.entities.AddRange(Region.Builder.BuildCollection(session.terrainMap, gmInit.regionCount));
                session.entities.AddRange(Sect.Builder.BuildCollection(gmInit.sectCount));
                session.entities.AddRange(Person.Builder.BuildCollection(gmInit.personCount));

                session.systems.Add(new TreasurySystem(session.entities.SelectMany(x => x.components).OfType<ITreasury>()));
                session.systems.Add(new RelationDBOperationSystem(session.relationDB));
                session.systems.Add(new PlayerSystem(session));

                BuildRelation(session);

                RegisterMessages(session);

                session.player = session.sects.First().persons.First();

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

            private static void BuildRelation(Session session)
            {
                Random random = new Random();
                var regionStack = new Queue<IRegion>(session.regions.OrderBy(_ => random.Next(0, int.MaxValue)));
                foreach (var sect in session.sects)
                {
                    var region = regionStack.Dequeue();

                    session.relationDB.AddRelation(sect as IEntity, region as IEntity, IRelation.Label.Owner);
                    session.relationDB.AddRelation(region as IEntity, sect as IEntity, IRelation.Label.Location);
                }

                foreach(var person in session.persons)
                {
                    var index = random.Next(-1, session.sects.Count());
                    if(index == -1)
                    {
                        continue;
                    }

                    var sect = session.sects.ElementAt(index);

                    session.relationDB.AddRelation(sect as IEntity, person as IEntity, IRelation.Label.Owner);
                }

                foreach (var region in session.regions.Where(x=>x.sect != null))
                {
                    var validPerson = region.sect.persons.Where(x => x.patrolRegion == null);

                    var index = random.Next(-1, validPerson.Count());
                    if (index == -1)
                    {
                        continue;
                    }

                    var person = validPerson.ElementAt(index);

                    session.relationDB.AddRelation(person as IEntity, region as IEntity, IRelation.Label.Patrol);
                }
            }
        }
    }
}
