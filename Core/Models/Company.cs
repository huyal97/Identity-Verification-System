using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TcKimlikTest.Models
{
    public class Company : BaseEntity
    {
        
        public string Name { get; set; }
        public bool MersisControl { get; set; }
    }
}
