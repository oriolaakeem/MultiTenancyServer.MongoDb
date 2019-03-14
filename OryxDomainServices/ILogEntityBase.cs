﻿using System;
using System.ComponentModel.DataAnnotations;

namespace OryxDomainServices
{
    // <summary>

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Interface for Entities that require logging
    /// </summary>
    ///
    /// <remarks>   Tayo, 20/03/2018. </remarks>
    ///
    /// <typeparam name="TId">  The entity ID type. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public interface ILogEntityBase<ObjectId>
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the log instance. This should be autogenerated </summary>
        ///
        /// <value> The log instance. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        int LogInstance { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the actual entry </summary>
        ///
        /// <value> The identifier. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ObjectId Id { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the date entry was created. For logs this should be the as 
        ///             the original entry </summary>
        ///
        /// <value> The create date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        DateTime CreateDate { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the update.  </summary>
        ///
        /// <value> The update date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        DateTime UpdateDate { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user id that made the change </summary>
        ///
        /// <value> The user sign. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        string UserSign { get; set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Interface for log master data . </summary>
    ///
    /// <remarks>   Tayo, 20/03/2018. </remarks>
    ///
    /// <typeparam name="TId">  Type of the identifier. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public interface ILogMasterDataBase<ObjectId> : ILogEntityBase<ObjectId>
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name or description of the master data </summary>
        ///
        /// <value> The name. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [MaxLength(100)]
        string Name { get; set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Interface for log document base. </summary>
    ///
    /// <remarks>   Tayo, 20/03/2018. </remarks>
    ///
    /// <typeparam name="TId">  Type of the identifier. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public interface ILogDocumentBase<ObjectId> : ILogEntityBase<ObjectId>
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the document number. </summary>
        ///
        /// <value> The document number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        int DocNum { get; set; }
    }
}