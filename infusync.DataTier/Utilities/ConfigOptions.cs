using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using OENT.Entities.General;

namespace infusync.DataTier.Utilities
{
    public class ConfigOptions
    {
        public int QueryVersion { get; set; }
        public string B1DBName { get; set; }
        public int MenuVersion { get; set; }
        public int WorkflowVersion { get; set; }
        public int SecurityVersion { get; set; }
        public string SystemUserId { get; set; }
        public string FrontEndUrl { get; set; }
        public string IDSvrUrl { get; set; }
        public string DefaultImageURL { get; set; }
        public string APIUrl { get; set; }
        public string RemoteFrontEndUrl { get; set; }
        public string RemoteAPIUrl { get; set; }
        public string RemoteIDSvrUrl { get; set; }
    }



    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = true)]
    public class FormAttribute : Attribute
    {
        private string _form;
        private InputType _type;
        private string _label = "";
        private string _name;
        private string _placeholder = "";
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
        private string _module = "";
        private bool _required = false;
        private string _errorText = "";
        private string _helperText = "";
        // private string _type = "input";

        public FormAttribute(string form, string name, string module)
        {
            _form = form;
            _name = name;
            _module = module;
        }

        public string OptionsProvider { get => _optionsProvider; set => _optionsProvider = value; }
        public string Form { get => _form; set => _form = value; }
        public string Label { get => _label; set => _label = value; }
        public string Name { get => _name; set => _name = value; }
        public string Placeholder { get => _placeholder; set => _placeholder = value; }
        public string Columns { get => _columns; set => _columns = value; }
        public bool Hidden { get => _hidden; set => _hidden = value; }
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
        public string Module { get => _module; set => _module = value; }
        public bool Required { get => _required; set => _required = value; }
        public string ErrorText { get => _errorText; set => _errorText = value; }
        public string HelperText { get => _helperText; set => _helperText = value; }
    }
}
