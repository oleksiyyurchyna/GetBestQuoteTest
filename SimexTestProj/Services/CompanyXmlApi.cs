using AutoMapper;
using SimexTestProj.Services.Requests;
using SimexTestProj.Services.Responses;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SimexTestProj.Services
{
    public class CompanyXmlApi : BaseCompanyApi<XmlApiRequest, XmlApiResponse>
    {
        public CompanyXmlApi(IMapper mapper)
            : base(mapper)
        {
        }

        protected override Task<XmlApiResponse> ProcessRequest(XmlApiRequest request)
        {
            var xmlSerializer = new XmlSerializer(request.GetType());
            string xml;
            using (var textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, request);
                xml = textWriter.ToString();
            }

            // processing xml... 

            var xmlResult = @"<?xml version=""1.0"" encoding=""utf-16""?>
<XmlApiResponse xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <quote>12</quote>
</XmlApiResponse>";

            XmlApiResponse result;
            var resultXmlSerializer = new XmlSerializer(typeof(XmlApiResponse));
            using (var reader = new StringReader(xmlResult))
            {
                result = (XmlApiResponse)resultXmlSerializer.Deserialize(reader);
            }

            return Task.FromResult(result);
        }
    }
}
