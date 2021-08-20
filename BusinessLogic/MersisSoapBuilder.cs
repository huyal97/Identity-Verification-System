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
    public class MersisSoapBuilder : IMersisSoapBuilder
    {

        public string RequestXml(long _TCKimlikNo, string _Adi, string _Soyadi, int _DogumYili)
        {
            string str = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
            str += "<soap12:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap12=\"http://www.w3.org/2003/05/soap-envelope\">";
            str += "<soap12:Body>";
            str += "<TCKimlikNoDogrula xmlns=\"http://tckimlik.nvi.gov.tr/WS\">";
            object obj = str;
            str = obj + "<TCKimlikNo>" + _TCKimlikNo + "</TCKimlikNo>";
            str = str + "<Ad>" + _Adi + "</Ad>";
            str = str + "<Soyad>" + _Soyadi + "</Soyad>";
            object obj2 = str;
            str = obj2 + "<DogumYili>" + _DogumYili + "</DogumYili>";
            str += "</TCKimlikNoDogrula>";
            str += "</soap12:Body>";
            return str + "</soap12:Envelope>";
        }

        public HttpWebRequest BuildRequest(string requestUrl, long contentLength)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
            httpWebRequest.ContentType = "application/soap+xml; charset=utf-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentLength = contentLength;

            return httpWebRequest;
        }




        public bool GetResponse(HttpWebRequest request, byte[] requestBytesArray)
        {

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(requestBytesArray, 0, (int)request.ContentLength);
            }
            try
            {
                string text;
                using (WebResponse webResponse = request.GetResponse())
                {
                    if (webResponse == null)
                    {
                        return false;
                    }
                    using (StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        text = streamReader.ReadToEnd().Trim();
                    }
                }
                XDocument xDocument = XDocument.Parse(text);
                string value = xDocument.Descendants().SingleOrDefault((XElement x) => x.Name.LocalName == "TCKimlikNoDogrulaResult").Value;
                return bool.Parse(value);
            }
            catch
            {
                return false;
            }
        }
    }




   
}
