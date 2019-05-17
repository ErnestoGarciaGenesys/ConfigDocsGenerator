using System;

// FIXME: parse for correctness differently for hosts and for applications.
// TODO: make better token delimiters: {token} is more readable than $token$,
//       especially when there are many tokens in a row.
namespace CfgDoc.Output.VisioHostDiagram.Parser {
	public class Parser {
		public class SyntaxErrorException : Exception {
			public int ErrorPosition;
			
			public SyntaxErrorException(string msg) : this(msg, -1) {}
			
			public SyntaxErrorException(string msg, int errorPosition) : base(msg) {
				ErrorPosition = errorPosition;
			}
		}
		
		public void parseText(string text, IParseVisitor visitor) {
			int startIndex = 0;
			while (startIndex < text.Length) {
				int endIndex = getToken(text, startIndex);
				handleToken(text, startIndex, endIndex, visitor);
				startIndex = endIndex + 1;
			}
		}
		
		/// <summary>
		/// Returns the index where the next token starts.
		/// <param name="startIndex">must be less than text.Length.</param>
		/// </summary>
		private int getToken(string text, int startIndex) {
			int result;
			
			int nextDollarPosition = text.IndexOf('$', startIndex + 1);
			
			if (text[startIndex] == '$') {
				// Variable.
				if (nextDollarPosition == -1) {
					throw new SyntaxErrorException("Closing $ sign missing.", startIndex);
				}
				else {
					result = nextDollarPosition;
				}
			}
			else {
				// Text.
				if (nextDollarPosition == -1) {
					result = text.Length - 1;
				}
				else {
					result = nextDollarPosition - 1;
				}
			}
			
			return result;
		}
		
		private void handleToken(string text, int startIndex, int endIndex, IParseVisitor visitor) {
			string token = text.Substring(startIndex, endIndex - startIndex + 1);
			
			if (token[0] == '$') {
				switch (token) {
					case "$name$": visitor.Name(); break;
					case "$type$": visitor.Type(); break;
					case "$version$": visitor.Version(); break;
					case "$primary$": visitor.Primary(); break;
					case "$beginbold$": visitor.BeginBold(); break;
					case "$endbold$": visitor.EndBold(); break;
					case "$beginitalic$": visitor.BeginItalic(); break;
					case "$enditalic$": visitor.EndItalic(); break;
					case "$ip$": visitor.IP(); break;
					case "$$": visitor.Text("$"); break;
					default:
						throw new SyntaxErrorException("Invalid token: " + token + ".", startIndex);
				}
			}
			else {
				visitor.Text(token);
			}
		}
	}
}
