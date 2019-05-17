using System;

namespace CfgDoc.Output.VisioHostDiagram.Parser {
	/// <summary>
	/// This visitor writes messages to the console.
	/// Useful for debugging the parser.
	/// </summary>
	public class ConsoleParseVisitor : IParseVisitor {
		void w(string text) { Console.WriteLine(text); }
		public void BeginBold() { w("BeginBold"); }
		public void EndBold() { w("EndBold"); }
		public void BeginItalic() { w("BeginItalic"); }
		public void EndItalic() { w("EndItalic"); }
		public void Name() { w("Name"); }
		public void Primary() { w("Primary"); }
		public void Type() { w("Type"); }
		public void Version() { w("Version"); }
		public void IP() { w("IP"); }
		public void Text(string text) { w("Text:'" + text + "'"); }
	}
}
