using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.General
{
    public enum InputPriority
    {
        First = 0,
        Second = 1,
        Third = 2,
        Fourth = 3,
        Fifth = 4
    }

    public enum InputType
    {
        input = 0,
        select = 1,
        checkbox = 2,
        option = 3,
        ngSelect = 4,
        datePicker = 5,
        effectiveDate = 6,
        textArea = 7
    }

    public class FormControlOption : IEntityBase<ObjectId>
    {
        private string _form;
        private InputType _type;
        private string _label = "";
        private string _userlabel = "";
        private string _module = "";
        private string _name;
        private string _placeholder = "Placeholder";
        private string _optionsProvider = "";
        private string _columns = "l6 m6 s12";
        private bool _hidden = false;
        private InputPriority _inputPriority = InputPriority.Fifth;
        private bool _detailsDisplay = false;
        private bool _view = true;
        private string _viewEntityProvider = "";
        private string _viewColumns = "l6 m6 s12";
        private string dataType = "";
        private bool _keepOnePerRow = false;
        private string _backendType = "";

        public ObjectId Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }

        public string OptionsProvider { get => _optionsProvider; set => _optionsProvider = value; }
        [Required]
        public string Form { get => _form; set => _form = value; }
        public string Label { get => _label; set => _label = value; }
        public string Module { get => _module; set => _module = value; }
        public string UserLabel { get => _userlabel; set => _userlabel = value; }
        [Required]
        public string Name { get => _name; set => _name = value; }
        public string Placeholder { get => _placeholder; set => _placeholder = value; }
        public string Columns { get => _columns; set => _columns = value; }
        public bool Hidden { get => _hidden; set => _hidden = value; }
        [Required]
        public InputType FormInputType { get => _type; set => _type = value; }
        public string Type { get => _type.ToString(); }
        public InputPriority InputPriority { get => _inputPriority; set => _inputPriority = value; }
        public bool DetailsDisplay { get => _detailsDisplay; set => _detailsDisplay = value; }
        public bool View { get => _view; set => _view = value; }
        public string ViewEntityProvider { get => _viewEntityProvider; set => _viewEntityProvider = value; }
        public string ViewColumns { get => _viewColumns; set => _viewColumns = value; }
        public string DataType { get => dataType; set => dataType = value; }
        public bool KeepOnePerrow { get => _keepOnePerRow; set => _keepOnePerRow = value; }
        public string BackendType { get => _backendType; set => _backendType = value; }
        public string CreatedBy { get; set; }
    }
}
