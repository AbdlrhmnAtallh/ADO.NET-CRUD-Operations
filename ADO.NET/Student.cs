using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    internal class Student
    {
     
           
            public int ID { get; set; }
            public string? Name { get; set; }
            public string? PhoneNumber { get; set; }
            public string? Email { get; set; }
            public int Age { get; set; }

        public override string ToString()
        {
            return $"[{ID}], {Name}, [ {PhoneNumber}, {Email}, {Age}";

        }

    }
}
