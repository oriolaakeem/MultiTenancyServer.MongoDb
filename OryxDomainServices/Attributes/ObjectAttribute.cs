using System;
using System.Collections.Generic;

namespace OryxDomainServices.Attributes
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Attribute for all the classes we use in the application.
    ///              </summary>
    ///
    /// <remarks>   Tayo, 20/03/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ObjectAttribute: Attribute
    {
        private string _name;
        private string[] _objects;
        public ObjectAttribute()
        {
            _objects = null;
            _name = "";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Tayo, 20/03/2018. </remarks>
        ///
        /// <param name="name">     The name. Serves as a unique identifier </param>
        /// <param name="objects">  The objects. List of typess required by the attribute</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObjectAttribute(string name, params string[] objects)
        {
            _objects = objects;
            _name = name;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the List of types used by the class for this attribute. The fully qualified
        ///             class should be specified </summary>
        ///
        /// <value> The objects. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IEnumerable<string> Objects
        {
            get
            {
                return _objects;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the name. </summary>
        ///
        /// <value> The name. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Name
        {
            get
            {
                return _name;
            }
        }


    }
}
