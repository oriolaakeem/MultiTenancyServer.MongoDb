using System;
using System.Collections.Generic;
using System.Text;


////////////////////////////////////////////////////////////////////////////////////////////////////
// namespace: OryxDomainServices.Attributes
//
// summary:	.
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace OryxDomainServices.Attributes
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Attribute for Entities. It specifies properties to include for data templates </summary>
    ///
    /// <remarks>   Tayo, 20/03/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class TemplateAttribute : Attribute
    {
        private string _templateName;
        public TemplateAttribute()
        {
            _templateName = "";
        }

        public TemplateAttribute(string templateName)
        {
            _templateName = templateName;
        }

        public string TemplateName
        {
            get
            {
                return _templateName;
            }
        }
    }
}
