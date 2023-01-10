using JiangH.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JiangH.Offices
{
    class Office : IOffice
    {
        public string name => authorities.Contains(IOffice.Authority.Possessor) ? "Master" : "Member";

        public IEnumerable<IOffice.Authority> authorities => _authorities;

        private List<IOffice.Authority> _authorities = new List<IOffice.Authority>();
        internal void AddAuthority(IOffice.Authority possessor)
        {
            _authorities.Add(possessor);
        }
    }
}
