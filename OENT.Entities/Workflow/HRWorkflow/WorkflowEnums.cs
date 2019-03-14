using System;
using System.Collections.Generic;
using System.Text;

namespace OENT.Entities.Workflow
{
    public enum ApprovingType
    {
        None,
        Standard,
        OrgUnit,
        DynamicGroup
    }

    public enum StandardType
    {
        None,
        Manager,
        ManagersManager,
        HR
    }

    public enum OrgUnitType
    {
        None,
        Department,
        BusinessUnit,
        Division
    }

    public enum CommentType
    {
        None,
        Initiator,
        Approver,
        Notifier,        
    }
}
