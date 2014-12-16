using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Elyse.Languagetool
{
    public class Languagetool
    {
        private string _serverAdress;

        public Languagetool(string ServerAdress)
        {
            _serverAdress = ServerAdress;
        }

        public async Task<List<Error>> GetErrors(string text)
        {
            string xml;
            try
            {
                xml = await FetchXMLResponseAsync(text);
            }
            catch (System.Exception ex)
            {
                throw new Exception("Server request failed because: "+ex.Message+" ("+ex.GetType().Name+")");
            }

            List<Error> errors = ParseXMLResponse(xml);

            return errors;
        }

        private List<Error> ParseXMLResponse(string xmlResponse)
        {
            XDocument xdoc = XDocument.Parse(xmlResponse);

            IEnumerable<Error> errors = xdoc.Descendants("error")
                .Select(u => new Error(
                    msg:            (string)u.Attribute("msg"),
                    fromx:          (int)u.Attribute("fromx"),
                    fromy:          (int)u.Attribute("fromy"),
                    toy:            (int)u.Attribute("toy"),
                    ruleID:         (string)u.Attribute("ruleID"),
                    replacements:   (string)u.Attribute("replacements"),
                    context:        (string)u.Attribute("context"),
                    contextOffset:  (int)u.Attribute("contextoffset"),
                    offset:         (int)u.Attribute("offset"),
                    category:       (string)u.Attribute("category"),
                    locqualityissuetype: (string)u.Attribute("locqualityissuetype")
                ));

            return errors.ToList();
        }

        private async Task<string> FetchXMLResponseAsync(string text)
        {
            string content = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_serverAdress);

                HttpResponseMessage response = await client.GetAsync("?language=en-US&text=" + Uri.EscapeUriString(text));
                response.EnsureSuccessStatusCode();    // Throw if not a success code.

                content = await response.Content.ReadAsStringAsync();
            }

            return content;
        }
    }
}
