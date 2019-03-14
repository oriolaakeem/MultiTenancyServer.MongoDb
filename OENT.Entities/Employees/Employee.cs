using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using OryxDomainServices;
using System.ComponentModel.DataAnnotations.Schema;

namespace OENT.Entities.Employees
{
    public class Employee : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }

        [MaxLength(100)]
        public string Name { get{ return FirstName.ToUpper() + " " + MiddleName + " " + LastName; } }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]

        public string FirstName { get; set; }

        [MaxLength(50)]

        public string MiddleName { get; set; }

        [Required]
        [MaxLength(200)]

        public string Email { get; set; }

        [MaxLength(50)]
        [Required]

        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime EffectiveDate { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime CreateDate { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime? UpdateDate { get; set; }

        [MaxLength(1)]
        public string Status { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }


        public DateTime? StartDate { get; set; }


        public DateTime? HireDate { get; set; }

        [MaxLength(50)]
        public string EmploymentStatus { get; set; }
        [MaxLength(50)]
        public string EmploymentType { get; set; }

        public DateTime? TermDate { get; set; }

        public string TermReason { get; set; }

        [MaxLength(50)]
        public string UserId { get; set; }

        [MaxLength(50)]
        public string InitialPassword { get; set; }

        [MaxLength(50)]
        public Boolean SendEmail { get; set; }
        public Boolean EmailSent { get; set; }

        [Required]
        [MaxLength(50)]
        public string EmployeeNo { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [MaxLength(50)]
        public string Manager { get; set; }

        [MaxLength(50)]
        public string HR { get; set; }

        [MaxLength(50)]
        public string Department { get; set; }

        [MaxLength(50)]
        public string BusinessUnit { get; set; }
        public DateTime LastWorkedDate { get; set; }
        public bool Rehire { get; set; }
        public bool RegretTermination { get; set; }
        public string Note { get; set; }
        public Boolean CreateUser { get; set; }
        public ICollection<NoKInfo> NextOfKins { get; set; }
        public ICollection<BiographicalInfo> BiographicalInfos { get; set; }
        public ICollection<AddressInfo> Addresses { get; set; }
        public ICollection<ContactInfo> Contacts { get; set; }
        public ICollection<DependantInfo> Dependants { get; set; }
        public ICollection<EmergencyContact> EmergencyContacts { get; set; }
        public ICollection<PersonInfo> PersonInfos { get; set; }
        public ICollection<ProfileInfo> ProfileInfos { get; set; }
        public string CreatedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    [NotMapped]
    public class EmployeeLookup
    {
        public ObjectId Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
    }
}
