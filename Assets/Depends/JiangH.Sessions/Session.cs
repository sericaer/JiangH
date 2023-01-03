using JiangH.Dates;
using JiangH.Interfaces;
using JiangH.Messages;
using JiangH.Messages.Interfaces;
using JiangH.Relations;
using JiangH.Sects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiangH.Sessions
{
    partial class Session : ISession
    {
        public IDate date { get; private set; }
        public ITerrainMap terrainMap { get; private set; }
        public IEnumerable<IRegion> regions => entities.OfType<IRegion>();
        public IEnumerable<ISect> sects => entities.OfType<ISect>();
        public IEnumerable<IPerson> persons => entities.OfType<IPerson>();

        public IMessageBus messageBus { get; } = new MessageBus();

        private List<IEntity> entities { get; } = new List<IEntity>();
        private List<ISystem> systems { get; } = new List<ISystem>();

        private RelationDataBase relationDB { get; } = new RelationDataBase();
    }
}
