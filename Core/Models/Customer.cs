using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TcKimlikTest.Models
{
    public class Customer : BaseEntity
    {
        
        public int TcKimlikId { get; set; }

        [ForeignKey(nameof(TcKimlikId))]
        public TcKimlik TcKimlik { get; set; }
        
        public int CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }

    }
}
