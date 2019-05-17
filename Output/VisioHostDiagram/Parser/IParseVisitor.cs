using System;

namespace CfgDoc.Output.VisioHostDiagram.Parser {
	public interface IParseVisitor {
		void BeginBold();
		void EndBold();
		void BeginItalic();
		void EndItalic();
		void Text(string text);
		void Name();
		void Type();
		void Version();
		void Primary();
		void IP();
	}
}
