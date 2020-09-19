using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignApp.Model
{
    public class SignItem
    {
        public int Id { get; set; }

        public decimal Value { get; set; }

        public string Type { get; set; }

        public string Title { get; set; }

        public string Context { get; set; }

    }
}
