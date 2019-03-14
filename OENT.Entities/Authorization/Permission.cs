using OryxDomainServices;
using System;
using MongoDB.Bson;

namespace OENT.Entities.Authorization
{
    public class Permission : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }

        public string Name { get; set; }

        public string RoleId { get; set; }

        public string UserId { get; set; }

        public bool IsGranted { get; set; }
        DateTime? IEntityBase<ObjectId>.UpdateDate { get; set; }
    }
}
