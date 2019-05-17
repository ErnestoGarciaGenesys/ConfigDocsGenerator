using System;
using Visio = Microsoft.Office.Interop.Visio;
using CfgDoc.Input;
using CfgDoc.CfgObjects;

namespace CfgDoc.Output.VisioHostDiagram.Parser {
	
	class ApplicationTextVisitor : CharsVisitor {
		internal protected CfgApplication application;

        public ApplicationTextVisitor(CfgApplication application, Visio.Characters chars)
            : 
			base(chars) {
			this.application = application;
		}
		
		public override void Name() {
			Text(application.Name);
		}
		public override void Type() {
			Text(application.Type);
		}
		public override void Version() {
			Text(application.Version);
		}
		public override void Primary() {  }
		public override void IP() {  }
	}
}
