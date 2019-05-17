using Visio = Microsoft.Office.Interop.Visio;
using CfgDoc.Input;
using CfgDoc.CfgObjects;

namespace CfgDoc.Output.VisioHostDiagram {
	/// <summary>
	/// Generates a Visio host diagram.
	/// </summary>
	class VisioHostOutput : ICfgOutput {
		
		public VisioHostSettings Settings = new VisioHostSettings();

        public void Generate(CfgSystem system)
        {
			Visio.Application visio = new Visio.Application();
			Visio.Document doc = visio.Documents.Add("");
			Visio.Page page = doc.Pages[1];
			page.Name = "Architecture";
			
			// Open with flags Visio.VisOpenSaveArgs.visOpenRO | Visio.VisOpenSaveArgs.visOpenDocked.
			Visio.Document stencil = visio.Documents.OpenEx(Settings.StencilName, 0x2 | 0x4);
			Visio.Master serverMaster = stencil.Masters["Server"];
			
			double paperHeight = doc.get_PaperHeight(Visio.VisUnitCodes.visInches);
			double paperWidth = doc.get_PaperWidth(Visio.VisUnitCodes.visInches);
			
			int numColumns = 2;
            int numRows = (system.Hosts.Count + (numColumns - 1))/ numColumns;
			double verticalGap = paperHeight / numRows;
			double horizontalGap = paperWidth / numColumns;
			double verticalMargin = verticalGap / 2;
			double horizontalMargin = horizontalGap / 2;
	
			double verticalPosition = verticalMargin;
			double horizontalPosition = horizontalMargin;
			int verticalIndex = 1;
			int horizontalIndex = 1;

            foreach (CfgHost host in system.Hosts)
            {
				Visio.Shape shape = page.Drop(serverMaster, horizontalPosition, verticalPosition);
				modifyShapeText(shape, host);
	
				if (verticalIndex == numRows) {
					verticalIndex = 1;
					verticalPosition = verticalMargin;			 
					horizontalIndex += 1;
					horizontalPosition += horizontalGap;
				}
				else {
					verticalIndex += 1;
					verticalPosition += verticalGap;
				}
			}
		}
		
		void modifyShapeText(Visio.Shape shape, CfgHost host) {
			shape.Name = host.Name;
			
			Visio.Characters chars = shape.Characters;
			chars.set_ParaProps(6, 0); // Left alignment
			
			if (Settings.WriteHost)
				modifyTextHost(chars, host);
			
			if (Settings.WriteApplicationList) {
				foreach (CfgServer server in host.Servers) {
                    CfgApplication app = server.Application;
					chars.Begin = chars.End;
                    modifyTextApplication(chars, app);
				}
			}
		}

        void modifyTextHost(Visio.Characters chars, CfgHost host)
        {
			new Parser.Parser().parseText(Settings.HostText,
				new Parser.HostTextVisitor(host, chars));
		}

        void modifyTextApplication(Visio.Characters chars, CfgApplication application)
        {
			appendEndOfLine(chars);
			chars.Begin = chars.End;
			new Parser.Parser().parseText(Settings.ApplicationText,
				new Parser.ApplicationTextVisitor(application, chars));
		}
		
		void appendEndOfLine(Visio.Characters chars) {
			chars.Begin = chars.End;
			chars.Text = "\n";
		}
	}
}
