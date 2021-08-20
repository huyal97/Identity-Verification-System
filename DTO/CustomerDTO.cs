using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TcKimlikTest.Models
{
    public class CustomerDTO : BaseEntity
    {
        public TcKimlik TcKimlik { get; set; }
        public string CompanyName { get; set; }

    }
}
