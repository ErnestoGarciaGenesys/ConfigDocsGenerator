using System;
using Visio = Microsoft.Office.Interop.Visio;
using CfgDoc.Input;
using CfgDoc.CfgObjects;

namespace CfgDoc.Output.VisioHostDiagram.Parser {
	
	class HostTextVisitor : CharsVisitor {
        protected CfgHost host;

        public HostTextVisitor(CfgHost host, Visio.Characters chars)
            : base(chars)
        {
			this.host = host;
		}
		
		public override void Name() {
			Text(host.Name);
		}
		public override void Type() { 	}		
		public override void Version() {  }
		public override void Primary() {  }
		public override void IP() {
            Text(host.IpAddress);
		}
	}
}
