using System;
using System.Collections.Generic;

namespace FluentValidationApp.Web.Models
{
    public class Customer
    {
        public int Id { get; set; } 

        public string Name { get; set; }    

        public string Email { get; set; }

        public int Age { get; set; }

        public DateTime? BirthDay { get; set; }

        public List<Adress> Adresses { get; set; }

        public Gender Gender { get; set; }

    }
}
