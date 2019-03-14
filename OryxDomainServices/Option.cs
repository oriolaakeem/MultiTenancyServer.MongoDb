using System;
using System.Collections.Generic;
using System.Text;

namespace OryxDomainServices
{
    public class Option<TId>
    {
        public TId Id { get; set; }
        public string Name { get; set; }
    }
}
