using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OryxDomainServices
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Base class for Entities of type Master Data. </summary>
    ///
    /// <remarks>   Tayo, 20/03/2018. </remarks>
    ///
    /// <typeparam name="TId">  Type of the identifier. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class MasterDataBase<TId> : IMasterDataBase<TId>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [Required]
        public string UserSign { get; set; }

        public string CreatedBy { get; set; }

        public string Status { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        public TId Id { get; set; }
    }
}
