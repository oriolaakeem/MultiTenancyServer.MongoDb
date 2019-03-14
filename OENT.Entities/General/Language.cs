﻿using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.General
{
    public class Language : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }
        [MaxLength(50)]
        [Required]
        public string EmployeeId { get; set; }
        public string CreatedBy { get; set; }
    }
}
