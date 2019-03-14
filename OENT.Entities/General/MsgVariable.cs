using System.Collections.Generic;

namespace OENT.Entities.General
{
    public class MsgVariable
    {
        public string Name { get; set; }
        public IList<string> FieldNames { get; set; }
    }
}