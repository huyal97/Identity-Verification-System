using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TcKimlikTest.Core.Interfaces;

namespace TcKimlikTest.BusinessLogic
{
    public class MersisTest : IMersisTest
    {

        private IMersisSoapBuilder _SoapBuilder { get; set; }
        


        public MersisTest(IMersisSoapBuilder SoapBuilder)
        {       
            _SoapBuilder = SoapBuilder;
        }
        




        public bool KisiVarMi(long TCKimlikNo, string Adi, string Soyadi, int DogumYili)
        {
            
            string requestUrl = "https://tckimlik.nvi.gov.tr/service/kpspublic.asmx";
            byte[] bytes = Encoding.UTF8.GetBytes(_SoapBuilder.RequestXml(TCKimlikNo, Adi, Soyadi, DogumYili));
            int num = bytes.Length;
            HttpWebRequest request = _SoapBuilder.BuildRequest(requestUrl, num);
            Console.WriteLine(request);
            return _SoapBuilder.GetResponse(request, bytes);
        }

       






    }
}
