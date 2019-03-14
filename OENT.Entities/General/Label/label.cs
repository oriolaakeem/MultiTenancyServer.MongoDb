using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OENT.Entities.General
{
    public class TemplateAttribute : Attribute
    {
        private string _templateName;
        public TemplateAttribute()
        {
            _templateName = "";
        }

        public TemplateAttribute(string templateName)
        {
            _templateName = templateName;
        }

        public string TemplateName
        {
            get
            {
                return _templateName;
            }
        }
    }

    public class UIComponent : IEntityBase<ObjectId>
    {
        public UIComponent()
        {
            Labels = new HashSet<Label>();
        }
        [TemplateAttribute("UIComponent")]
        public ObjectId Id { get; set; }
        [TemplateAttribute("UIComponent")]
        [NotMapped]
        public int ParentKey { get; set; } = 0;
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string UserSign { get; set; }
        public string Status { get; set; }
        [Required]
        [MaxLength(254)]
        [TemplateAttribute("UIComponent")]
        public string Name { get; set; } = "";
        [TemplateAttribute("UIComponent")]
        [Required]
        public string Module { get; set; } = new ObjectId().ToString();
        public ICollection<Label> Labels { get; set; }
        public string CreatedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    public class Label : IEntityBase<ObjectId>
    {
        [TemplateAttribute("Label")]
        [NotMapped]
        public int ParentKey { get; set; } = 0;
        public ObjectId Id { get; set; }
        [TemplateAttribute("Label")]
        [Required]
        public int DocNum { get; set; } = 0;
        [Required]
        [MaxLength(100)]
        [TemplateAttribute("Label")]
        public string Name { get; set; } = "New Label";       
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string UserSign { get; set; }
        public string Status { get; set; }
        [TemplateAttribute("Label")]
        public string DefaultText { get; set; } = "New Text";
        [TemplateAttribute("Label")]
        public string UserText { get; set; } = "New Text";
        [TemplateAttribute("Label")]
        public ObjectId UIComponentId { get; set; } = ObjectId.GenerateNewId();
        public string CreatedBy { get ; set; }
    }
}
