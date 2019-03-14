using infusync.DataTier.Repositories;
using infusync.DataTier.Repositories.GeneralServices;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using OENT.Entities;
using OENT.Entities.General;
using OENT.Entities.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace infusync.DataTier
{
    public class InitialiseWorkflowData
    {
        private readonly TriggerRepository _context;
        private readonly MessageTemplateRepository _message;
        private readonly ModulesRepository _module;
        private readonly WFStateRepository _wfstate;
        private IHostingEnvironment _env;

        //private ConfigOptions _options;
        public InitialiseWorkflowData(IHostingEnvironment env, TriggerRepository context,
             ModulesRepository module, WFStateRepository wfstate, MessageTemplateRepository message)
        {
            _context = context; ;
            _env = env;
            _module = module;
            _wfstate = wfstate;
            _message = message;
        }
        public void Initialise(int version, string dataFolder, string templateFolder)
        {

            var moduleJSON = string.Empty; // System.IO.File.ReadAllText(Path.Combine(_env.ContentRootPath + dataFolder, "Modules.json"));
            var triggerJSON = string.Empty; // System.IO.File.ReadAllText(Path.Combine(_env.ContentRootPath + dataFolder, "Triggers.json"));
            var stateJSON = string.Empty; // System.IO.File.ReadAllText(Path.Combine(_env.ContentRootPath + dataFolder, "States.json"));
            var msgTemplateJSON = string.Empty;

            var assembly = Assembly.Load("infusync.Embedded");
            var resourceStream = assembly.GetManifestResourceStream("infusync.Embedded.DataFiles.Workflow.Modules.json");
            using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
            {
                moduleJSON = reader.ReadToEnd();
            }

            resourceStream = assembly.GetManifestResourceStream("infusync.Embedded.DataFiles.Workflow.Triggers.json");
            using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
            {
                triggerJSON = reader.ReadToEnd();
            }

            resourceStream = assembly.GetManifestResourceStream("infusync.Embedded.DataFiles.Workflow.States.json");
            using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
            {
                stateJSON = reader.ReadToEnd();
            }

            resourceStream = assembly.GetManifestResourceStream("infusync.Embedded.DataFiles.Workflow.MessageTemplate.json");
            using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
            {
                msgTemplateJSON = reader.ReadToEnd();
            }



            var modules = JsonConvert.DeserializeObject<IEnumerable<OENT.Entities.General.Module>>(moduleJSON);
            var states = JsonConvert.DeserializeObject<IEnumerable<WFState>>(stateJSON);
            var triggers = JsonConvert.DeserializeObject<IEnumerable<WFTrigger>>(triggerJSON);
            var msg = JsonConvert.DeserializeObject<IEnumerable<MessageTemplate>>(msgTemplateJSON);

            string updObjectId = "fb52e98c-8369-4a8b-86ab-69a166fd29c3";

            foreach (var item in modules)
            {
                if (_module.GetAll().Any(c => c.Id == item.Id))
                {
                    item.UserSign = updObjectId;
                    item.CreateDate = DateTime.Now;
                    item.UpdateDate = DateTime.Now;
                    item.Status = "A";
                    _module.Add(item, updObjectId);
                }
            }

            foreach (var item in states)
            {
                if (!_wfstate.GetAll().Any(c => c.Id == item.Id))
                {
                    item.UserSign = updObjectId;
                    item.CreateDate = DateTime.Now;
                    item.UpdateDate = DateTime.Now;
                    item.Status = "A";
                    _wfstate.Add(item,updObjectId);
                }
            }

            foreach (var item in triggers)
            {
                if (!_context.GetAll().Any(c => c.Id == item.Id))
                {
                    item.UserSign = updObjectId;
                    item.CreateDate = DateTime.Now;
                    item.UpdateDate = DateTime.Now;
                    item.Status = "A";
                    _context.Add(item,updObjectId);
                }
            }

            foreach (var item in msg)
            {
                if (!_message.GetAll().Any(c => c.Id == item.Id))
                {
                    item.UserSign = updObjectId;
                    item.CreateDate = DateTime.Now;
                    item.UpdateDate = DateTime.Now;
                    item.Status = "A";
                    //var msgText = System.IO.File.ReadAllText(Path.Combine(_env.ContentRootPath + templateFolder, item.TemplateFile));
                    //item.DefaultMessage = msgText;
                    //item.MessageData = msgText;
                    item.Version = version;
                    _message.Add(item, updObjectId);
                }
                else
                {
                    var dbMsg = _message.GetAll().Where(c => c.Id == item.Id && c.Version < version).FirstOrDefault();
                    if (dbMsg != null)
                    {
                       //var msgText = System.IO.File.ReadAllText(Path.Combine(_env.ContentRootPath + templateFolder, item.TemplateFile));
                        //dbMsg.DefaultMessage = msgText;
                        dbMsg.CreateDate = DateTime.Now;
                        dbMsg.UpdateDate = DateTime.Now;
                        dbMsg.ModuleId = item.ModuleId;
                        _message.Update(dbMsg);

                    }
                }
            }


            //InitMessageTemplates(version, dataFolder, templateFolder);
        }

        private void InitMessageTemplates(int version, string dataFolder, string templateFolder)
        {
            var msgTemplateJSON = string.Empty;
            var assembly = Assembly.Load("infusync.Embedded");
            var resourceStream = assembly.GetManifestResourceStream("infusync.Embedded.DataFiles.Workflow.MessageTemplate.json");
            using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
            {
                msgTemplateJSON = reader.ReadToEnd();
            }


            //var msgTemplateJSON = System.IO.File.ReadAllText(Path.Combine(_env.ContentRootPath + dataFolder, "MessageTemplate.json"));
            var msg = JsonConvert.DeserializeObject<IEnumerable<MessageTemplate>>(msgTemplateJSON);

            string updObjectId = "fb52e98c-8369-4a8b-86ab-69a166fd29c3";
            foreach (var item in msg)
            {
                if (!_message.GetAll().Any(c => c.Id == item.Id))
                {
                    item.UserSign = updObjectId;
                    item.CreateDate = DateTime.Now;
                    item.UpdateDate = DateTime.Now;
                    item.Status = "A";
                    var msgText = System.IO.File.ReadAllText(Path.Combine(_env.ContentRootPath + templateFolder, item.TemplateFile));
                    item.DefaultMessage = msgText;
                    item.MessageData = msgText;
                    item.Version = version;
                    _message.Add(item, updObjectId);
                }
                else
                {
                    var dbMsg = _message.GetAll().Where(c => c.Id == item.Id && c.Version < version).FirstOrDefault();
                    if (dbMsg != null)
                    {
                        var msgText = System.IO.File.ReadAllText(Path.Combine(_env.ContentRootPath + templateFolder, item.TemplateFile));
                        dbMsg.DefaultMessage = msgText;
                        dbMsg.CreateDate = DateTime.Now;
                        dbMsg.UpdateDate = DateTime.Now;
                        dbMsg.ModuleId = item.ModuleId;
                        _message.Update(dbMsg);

                    }
                }
            }

        }


    }
}
