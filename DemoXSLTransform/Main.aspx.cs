using System;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Text;  

namespace DemoXSLTransform
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string xslInput = "data\\cdcatalog.xsl";
            string xmlInput = "data\\cdcatalog.xml";
                       

            // Getting file path    
            string strXSLTFile = Server.MapPath(xslInput);
            string strXMLFile = Server.MapPath(xmlInput);

            // Creating XSLCompiled object    
            XslCompiledTransform objXSLTransform = new XslCompiledTransform();
            objXSLTransform.Load(strXSLTFile);

            // Creating StringBuilder object to hold html data and creates TextWriter object to hold data from XslCompiled.Transform method    
            StringBuilder htmlOutput = new StringBuilder();
            TextWriter htmlWriter = new StringWriter(htmlOutput);

            // Creating XmlReader object to read XML content    
            XmlReader reader = XmlReader.Create(strXMLFile);

            // Call Transform() method to create html string and write in TextWriter object.    
            objXSLTransform.Transform(reader, null, htmlWriter);
            this.out1.InnerHtml = htmlOutput.ToString();

            // Closing xmlreader object    
            reader.Close();    



        }
    }
}