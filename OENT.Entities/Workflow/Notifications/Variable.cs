using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.Notifications
{
    public class Variable : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        public string EntityId { get; set; }
        [RegularExpression(@"\${([^}]+)}", ErrorMessage = "The field must be in this format: ${variable}")]
        public string VariableToken { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string Status { get; set; }
        public string UserSign { get; set; }
        public string CreatedBy { get; set; }
    }
}
