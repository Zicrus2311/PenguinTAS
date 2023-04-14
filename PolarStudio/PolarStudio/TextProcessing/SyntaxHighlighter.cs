namespace PolarStudio;

public static class SyntaxHighlighter {
    static readonly Color commentColor = Color.LightGreen;
    static readonly Color numberColor = Color.Orange;
    static readonly Color actionColor = Color.LightBlue;

    public static void Highlight(RichTextBox textBox) {
        for (int i = 0; i < textBox.Lines.Length; i++) {
            HighlightLine(textBox, i);
        }
    }

    static void HighlightLine(RichTextBox textBox, int line) {
        if (textBox.Lines[line].Length == 0) return;

        int lineStart = textBox.GetFirstCharIndexFromLine(line);
        if (textBox.Text[lineStart] == Characters.commentStart) {
            SetColor(textBox, lineStart, textBox.Lines[line].Length, commentColor);
        }
        else {
            int numberLength = Lines.NumberPart(textBox, line).Length;
            if (numberLength > 0) {
                SetColor(textBox, lineStart, numberLength, numberColor);
            }

            int actionsLength = Lines.Length(textBox, line) - numberLength;
            if (actionsLength > 0) {
                SetColor(textBox, lineStart + numberLength, actionsLength, actionColor);
            }
        }
    }

    static void SetColor(RichTextBox textBox, int start, int length, Color color) {
        textBox.Select(start, length);
        textBox.SelectionColor = color;
    }
}