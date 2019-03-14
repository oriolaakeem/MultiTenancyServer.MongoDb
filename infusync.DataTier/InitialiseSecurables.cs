using System;
using System.Linq;
using infusync.DataTier.Repositories;
using Microsoft.AspNetCore.Hosting;
using MongoDB.Bson;
using OENT.Entities.Authorization;

namespace infusync.DataTier
{
    public class InitialiseSecurables
    {
        private readonly SecurableRepository _context;
        private IHostingEnvironment _env;

        public InitialiseSecurables(IHostingEnvironment env, SecurableRepository context)
        {
            _context = context; ;
            _env = env;
        }

        public void Initialize(int version)
        {
            string updObjectId = "fb52e98c-8369-4a8b-86ab-69a166fd29c3";

            var sec = new Securable[]
            {
                new Securable
                {
                    Id = ObjectId.GenerateNewId(),
                    SecuredItem = SecurableEnum.Patients, Name = "Patients",
                    AssignedPermissions = new SecurablePermission[]
                    {
                        new SecurablePermission{Permission = PermissionOption.Add},
                        new SecurablePermission{Permission = PermissionOption.Remove},
                        new SecurablePermission{Permission = PermissionOption.Update},
                        new SecurablePermission{Permission = PermissionOption.View},
                    }
                },

            };

            foreach (var item in sec)
            {
                var menuI = _context.GetAll().Where(arg => arg.Name == item.Name).FirstOrDefault();
                if (menuI == null)
                {
                    item.UserSign = updObjectId;
                    item.CreateDate = DateTime.Now;
                    item.UpdateDate = DateTime.Now;
                    item.Status = "A";
                    foreach (var p in item.AssignedPermissions)
                    {
                        p.UserSign = updObjectId;
                        p.SecurableId = item.Id;
                        p.Id = ObjectId.GenerateNewId();
                        p.CreateDate = DateTime.Now;
                        p.UpdateDate = DateTime.Now;
                        p.Status = "A";
                    }
                    _context.Add(item, updObjectId);
                }
            }
        }

    }
}
