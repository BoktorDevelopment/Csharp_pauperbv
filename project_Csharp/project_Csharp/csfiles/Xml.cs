using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Xml;

namespace project_Csharp.csfiles
{
    public class Xml
    {
        public void readXML() {
            XmlTextReader playlist = new XmlTextReader("data/playlist.xml");
            while (playlist.Read())
            {
                // Gegevens hier verwerken.
                Console.WriteLine(playlist.Name);
            }
            Console.ReadLine();
        }
    }
}