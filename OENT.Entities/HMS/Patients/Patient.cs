using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OENT.Entities.Employees;
using OENT.Entities.Patients;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.Patients
{
    public class Patient : IEntityBase<ObjectId>
    {
        [BsonId]
        public ObjectId Id { get; set; }



        [MaxLength(100)]
        public string FullName { get { return FirstName.ToUpper() + " " + MiddleName + " " + LastName; } }

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

        public string NIMCNo { get; set; }

        public string StateIDNo { get; set; }

        public string BVNNo { get; set; }

        public string PlaceBirth { get; set; }
        public string StateOfOrigin { get; set; }
        public string Gender { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime DateOfBirth { get; set; }
        public string BirthHour { get; set; }
        public string BirthMinutes { get; set; }
        public string BirthAMPM { get; set; }
        public string Ethniicty { get; set; }

        public string Nationality { get; set; }
        public string Unit { get; set; }
        public string NHISNo { get; set; }
        public string MotherMaidenName { get; set; }
        public string MaritalStatus { get; set; }

        public ICollection<NoKInfo> NextOfKins { get; set; }

        public ICollection<Allergy> Allergies { get; set; }

        public ICollection<AddressInfo> Contacts { get; set; }

        public ICollection<MedicalInfo> MedicalInfos { get; set; }

        public ICollection<HMOInformation> HMOInformation { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime CreateDate { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime? UpdateDate { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime EffectiveDate { get; set; }
        public string Status { get; set; }
        public string UserSign { get; set; }
        public Byte[] ProfilePic
        {
            get;
            set;
        }
        public string CreatedBy { get; set; }
    }


}
