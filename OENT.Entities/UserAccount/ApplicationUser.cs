using System;
using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;
using Newtonsoft.Json;
using OENT.Entities.CompanyInfo;
using infusync.Security;
using OryxDomainServices;

namespace OENT.Entities
{
    public class ApplicationUser : MongoIdentityUser<ObjectId>, IEntityBase<ObjectId>
    {
        public ApplicationUser() : base()
        {
        }

        public ApplicationUser(string userName, string email) : base()
        {
        }
        public bool Admin { get; set; }
        public string Application { get; set; }
        public string City { get; set; }
        public string CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public string Country { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string Department { get; set; }
        public string DurationOfStay { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string HashedPassword { get; set; }
        public string HomeAddress { get; set; }
        [JsonConverter(typeof(ObjectIdConverter))]
        public override ObjectId Id { get; set; }

        public byte[] IDdocument { get; set; }
        public string IDdocumentExtension { get; set; }
        public bool IsActive { get; set; }
        public bool IsBanned { get; set; }
        public bool IsNewUser { get; set; }
        public string LastName { get; set; }
        public int Level { get; set; }
        public string MiddleName { get; set; }
        public string Name { get { return LastName + ", " + FirstName; } set { value = LastName + ", " + FirstName; } }
        public string NOKAddress { get; set; }
        public string NOKEmailAddress { get; set; }
        public string NOKFullName { get; set; }
        public string NOKPhoneNumber { get; set; }
        public string OperatorId { get; set; }
        public string Password { get; set; }
        public byte[] Picture { get; set; }
        public string PictureExtension { get; set; }
        public string RelationshipType { get; set; }
        public string Role { get; set; }
        public string State { get; set; }
        public string Status { get; set; }
        public string SubjectId { get; set; }
        public string TenantId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserSign { get; set; }
    }
}