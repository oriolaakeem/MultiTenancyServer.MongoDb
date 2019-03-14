using System;

namespace OENT.Entities.General
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class OryxHrAssociationAttribute : Attribute
    {
        private string _displayName;

        public OryxHrAssociationAttribute(string displayName)
        {
            _displayName = displayName;
        }

        public virtual string DisplayName
        {
            get { return _displayName; }
        }
    }


}
