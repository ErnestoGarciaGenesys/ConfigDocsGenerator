using System;
using System.Collections.Generic;
using System.Text;

namespace CfgDoc.Output.Html
{
    class HtmlSettings
    {
        public string OutputPath = System.IO.Directory.GetCurrentDirectory();
        public string DiagramFilePath = System.IO.Directory.GetCurrentDirectory();
        public string CompanyName = "";
        public string ProjectId = "";
        public string ProjectName = "";
        public string AuthorName = "";
        public string Description = "";
    }
}
