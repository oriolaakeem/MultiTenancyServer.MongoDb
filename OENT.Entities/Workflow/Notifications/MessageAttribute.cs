using System;
using System.Collections.Generic;
using System.Text;

namespace OENT.Entities.Notifications
{
    [System.AttributeUsage(System.AttributeTargets.Class,
                       AllowMultiple = true)  // multiuse attribute  
]
    public class MessageAttribute : Attribute
    {
        private readonly string _name;
        private readonly string[] _objects;
        private WorkflowMessageType _workflowMessage;
        public MessageAttribute()
        {
            _objects = null;
            _name = "";
        }

        public MessageAttribute(string name, params string[] objects)
        {
            _objects = objects;
            _name = name;
        }

        public MessageAttribute(string name, WorkflowMessageType workflowMessageType, params string[] objects)
        {
            _objects = objects;
            _name = name;
            _workflowMessage = workflowMessageType;
        }

        public IEnumerable<string> Objects
        {
            get
            {
                return _objects;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public WorkflowMessageType WorkflowMessage { get => _workflowMessage; set => _workflowMessage = value; }
    }

    public enum WorkflowMessageType
    {
        None,
        Request,
        Approved,
        Rejected,
        Notification
    }
}
