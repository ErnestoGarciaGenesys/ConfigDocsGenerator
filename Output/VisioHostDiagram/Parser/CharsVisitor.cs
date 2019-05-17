using System;
using Visio = Microsoft.Office.Interop.Visio;

namespace CfgDoc.Output.VisioHostDiagram.Parser {
	
	public class CharsVisitor : IParseVisitor {
		
		protected Visio.Characters chars;
		
		protected readonly short visCharacterStyle = 2;
		
		// Possible values for visCharacterStyle.
		protected readonly short visBold = 1;
		protected readonly short visItalic = 2;
		protected readonly short visUnderLine = 4;
		protected readonly short visSmallCaps = 8;
		
		protected short currentCharacterStyle = 0;

		/// <param name="chars">
		/// Visio Characters object. Its contents will be substituted by this Visitor.
		/// </param>
		public CharsVisitor(Visio.Characters chars) {
			this.chars = chars;
			chars.Text = "";
			// Now: chars.Begin == chars.End
		}
		
		protected void ApplyCharacterStyle(short charStyle, bool apply) {
			if (apply)
				currentCharacterStyle |= charStyle;
			else
				currentCharacterStyle &= (short)~charStyle;
		}
		
		public void BeginBold() {
			ApplyCharacterStyle(visBold, true);
		}
		
		public void EndBold() {
			ApplyCharacterStyle(visBold, false);
		}
		
		public void BeginItalic() {
			ApplyCharacterStyle(visItalic, true);
		}
		
		public void EndItalic() {
			ApplyCharacterStyle(visItalic, false);
		}
		
		public void Text(string text) {
			chars.Begin = chars.End;
            chars.Text = ReferenceEquals(text, null) ? "<NULL>" : text;
			chars.set_CharProps(visCharacterStyle, currentCharacterStyle);
		}
		
		public virtual void Name() {}
		public virtual void Type() {}
		public virtual void Version() {}
		public virtual void Primary() {}
		public virtual void IP() {}
	}
}
