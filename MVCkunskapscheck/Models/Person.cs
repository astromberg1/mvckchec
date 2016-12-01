using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCkunskapscheck.Models
    {
    public class Person
        {
        public Guid id { get; set; }
        public string namn { get; set; }

        public string Telefon { get; set; }

        public DateTime skapad { get; set; }
        public string Adress { get; set; }

        
        public Person()
            {
            id = Guid.NewGuid();
            }

        }
    }
    