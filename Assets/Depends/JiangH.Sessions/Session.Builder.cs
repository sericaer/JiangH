﻿using JiangH.Dates;
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

                BuildRelationSect2Reigions(session.sects, session.regions);

                session.systems.AddRange(BuildSystems(session.entities));

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

            private static List<ISystem> BuildSystems(List<IEntity> entities)
            {
                var systems = new List<ISystem>();

                var treasurySys = new TreasurySystem();
                treasurySys.items = entities.SelectMany(x => x.components).OfType<ITreasury>();

                systems.Add(treasurySys);

                return systems;
            }

            private static void BuildRelationSect2Reigions(IEnumerable<ISect> sects, IEnumerable<IRegion> regions)
            {
                Sect.funcGetRegions = (sect) => regions.Where(x => x.sectInfo != null && x.sectInfo.sect == sect);

                Random random = new Random();
                var regionStack = new Queue<IRegion>(regions.OrderBy(_ => random.Next(0, int.MaxValue)));
                foreach (var sect in sects)
                {
                    var region = regionStack.Dequeue();
                    region.sectInfo = new IRegion.SectInfo(sect);
                    region.sectInfo.isSectLocation = true;
                }
            }
        }
    }
}
