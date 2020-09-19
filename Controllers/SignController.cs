using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignApp.Model;

namespace SignApp.Controllers
{
    [Route("api/signList")]
    [ApiController]
    public class SignController : ControllerBase
    {
        /// <summary>
        /// all signers for prediction
        /// </summary>
        private List<SignItem> signers = new List<SignItem>();

        [HttpGet]
        public IEnumerable<SignItem> Get()
        {
            signers.Clear();
            this.LoadJson();
            Console.WriteLine("signers are collected!");
            //int i = 0;
            //signers.ForEach(signer => signer.Id = ++i);

            return signers.ToArray();
        }

        private void LoadJson()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string startupPath = Path.Combine(currentDirectory, "Data\\loveSigns.json");

            // Read the file as one string. 
            //string text = System.IO.File.ReadAllText(startupPath);

            using (StreamReader r = new StreamReader(startupPath))
            {
                string json = r.ReadToEnd();
                List<SignItem> signs = JsonConvert.DeserializeObject<List<SignItem>>(json);
                signers.AddRange(signs);
            }

            // add busineess signers
            string busSignPath = Path.Combine(currentDirectory, "Data\\businessSigns.json");

            using (StreamReader r = new StreamReader(busSignPath))
            {
                string json = r.ReadToEnd();
                List<SignItem> signs = JsonConvert.DeserializeObject<List<SignItem>>(json);
                signers.AddRange(signs);
            }
        }
    }
}
