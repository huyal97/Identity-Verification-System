using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TcKimlikTest.Models
{
    public class TcKimlik : BaseEntity
    {
        
        public long TCKimlikNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int DogumYili { get; set; }
    }
}
