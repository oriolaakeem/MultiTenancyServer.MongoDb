using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.hr
{
    public class HR_Attendance : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<int> Employee { get; set; }
        public int DocNum { get; set; }
        public int Department { get; set; }
        [MaxLength(20)]
        public string SignIn { get; set; }
        [MaxLength(20)]
        public string SignOut { get; set; }
        public decimal WorkedHours { get; set; }
        public int SheetID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime EffectiveDate { get; set; }

        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }
    }
}
