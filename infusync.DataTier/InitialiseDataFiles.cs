using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using infusync.DataTier.Repositories;
using Microsoft.AspNetCore.Hosting;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OENT.Entities.General;

namespace infusync.DataTier
{
    public class InitialiseDataFiles
    {
        private readonly MenuRepository _context;
        private IHostingEnvironment _env;
        //private ConfigOptions _options;
        public InitialiseDataFiles(IHostingEnvironment env, MenuRepository context)
        {
            _context = context; ;
            _env = env;
        }

        public void InitFiles(int version)
        {
            var updObjectId = "fb52e98c-8369-4a8b-86ab-69a166fd29c3";
            string contentRootPath = _env.ContentRootPath;
            //var SectionJSON = System.IO.File.ReadAllText(contentRootPath + "/DataFiles/Layout/Sections.json");
            //var TileJSON = System.IO.File.ReadAllText(contentRootPath + "/DataFiles/Layout/tiles.json");
            var MenuJSON = string.Empty; // System.IO.File.ReadAllText(contentRootPath + "/DataFiles/Layout/Menus.json");
            var assembly = Assembly.Load("infusync.Embedded");
            var resourceStream = assembly.GetManifestResourceStream("infusync.Embedded.DataFiles.Layout.menus.json");
            using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
            {
                MenuJSON = reader.ReadToEnd();
            }
            //var sections = JsonConvert.DeserializeObject<IEnumerable<Section>>(SectionJSON);
            //var tiles = JsonConvert.DeserializeObject<IEnumerable<Tile>>(TileJSON);
            var menus = JsonConvert.DeserializeObject<IEnumerable<Menu>>(MenuJSON);
           //var menus = new JavaScriptSerializer().Deserialize<IEnumerable<Menu>>(MenuJSON);
            foreach (var client in menus.ToList())
            {
                client.Id = ObjectId.GenerateNewId();
                client.UserSign = updObjectId;
                client.CreateDate = DateTime.Now;
                client.UpdateDate = DateTime.Now;
                client.Status = "A";
                foreach (var sec in client.Securables)
                {
                    sec.UserSign = updObjectId;
                    sec.CreateDate = DateTime.Now;
                    sec.UpdateDate = DateTime.Now;
                    sec.Status = "A";
                    sec.MenuId = client.Id;
                    sec.Id = ObjectId.GenerateNewId();
                }

                var menuI = _context.GetAll().Where(arg => arg.Code == client.Code).FirstOrDefault();
                if (menuI == null)
                {
                    _context.Add(client, updObjectId);
                }
            }

            //var updObjectId = "fb52e98c-8369-4a8b-86ab-69a166fd29c3";

            //string contentRootPath = _env.ContentRootPath;

            //var SectionJSON = System.IO.File.ReadAllText(contentRootPath + "/DataFiles/Layout/Sections.json");
            //var TileJSON = System.IO.File.ReadAllText(contentRootPath + "/DataFiles/Layout/tiles.json");
            //var MenuJSON = System.IO.File.ReadAllText(contentRootPath + "/DataFiles/Layout/Menus.json");

            //var sections = JsonConvert.DeserializeObject<IEnumerable<Section>>(SectionJSON);
            //var tiles = JsonConvert.DeserializeObject<IEnumerable<Tile>>(TileJSON);
            //var menus = JsonConvert.DeserializeObject<IEnumerable<Menu>>(MenuJSON);

            ////foreach (var item in sections)
            ////{
            ////    if (!_context.Sections.Any(c => c.Id == item.Id))
            ////    {
            ////        item.UserSign = updObjectId;
            ////        item.CreateDate = DateTime.Now;
            ////        item.UpdateDate = DateTime.Now;
            ////        item.Status = "A";
            ////        _context.Sections.Add(item);
            ////    }
            ////}

            ////foreach (var item in tiles)
            ////{
            ////    if (!_context.Tiles.Any(c => c.Id == item.Id))
            ////    {
            ////        item.UserSign = updObjectId;
            ////        item.CreateDate = DateTime.Now;
            ////        item.UpdateDate = DateTime.Now;
            ////        item.Status = "A";
            ////        _context.Tiles.Add(item);
            ////    }
            ////}

            //foreach (var item in menus)
            //{
            //    if (!menus.Any(c => c.Id == item.Id))
            //    {
            //        item.Id =  ObjectId.GenerateNewId();
            //        item.UserSign = updObjectId;
            //        item.CreateDate = DateTime.Now;
            //        item.UpdateDate = DateTime.Now;
            //        item.Status = "A";
            //        //foreach (var sec in item.Securables)
            //        //{
            //        //    sec.UserSign = updObjectId;
            //        //    sec.CreateDate = DateTime.Now;
            //        //    sec.UpdateDate = DateTime.Now;
            //        //    sec.Status = "A";
            //        //    //sec.Id = new ObjectId();
            //        //}
            //        _repository.Add(item);
            //    }
            //}

        }
    }
}
