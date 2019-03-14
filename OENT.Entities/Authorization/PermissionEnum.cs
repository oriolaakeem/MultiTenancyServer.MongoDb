using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OENT.Entities.Authorization
{
    public enum PermissionOption { 
        Add,
        Update,
        Remove,
        View
    }

    public enum PermissionEnum
    {
        [Display(Name = "Users List"), Description("Users List")]
        CompanyList = 1,
        [Display(Name = "Create Company"), Description("Create Company")]
        CreateCompany,
        [Display(Name = "Activate Company"), Description("Activate Company")]
        ActivateCompany,
        [Display(Name = "Suspend Company"), Description("Suspend Company")]
        SuspendCompany,
        [Display(Name = "Delete Company"), Description("Delete Company")]
        DeleteCompany,
        [Display(Name = "Users List"), Description("Users List")]
        UsersList,

        [Display(Name = "Create Users"), Description("Create Users")]
        CreateUsers,

        [Display(Name = "Update Users"), Description("Update Users")]
        UpdateUsers,

        [Display(Name = "Delete Users"), Description("Delete Users")]
        DeleteUsers,

        [Display(Name = "Roles List"), Description("Roles List")]
        RolesList,

        [Display(Name = "Create Roles"), Description("Create Roles")]
        CreateRoles,

        [Display(Name = "Update Roles"), Description("Update Roles")]
        UpdateRoles,

        [Display(Name = "Delete Roles"), Description("Delete Roles")]
        DeleteRoles
    }
}
