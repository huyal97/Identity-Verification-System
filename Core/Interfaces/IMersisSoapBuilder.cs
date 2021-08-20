using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TcKimlikTest.Core.Interfaces
{
    public interface IMersisSoapBuilder 
    {
        public string RequestXml(long _TCKimlikNo, string _Adi, string _Soyadi, int _DogumYili);

        public HttpWebRequest BuildRequest(string requestUrl, long contentLength);

        public bool GetResponse(HttpWebRequest request, byte[] requestBytesArray);
        

    }
}
