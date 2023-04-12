namespace PenguinTAS;

public static class SyntaxHighlighter {
    public static void Highlight(RichTextBox textBox) {
        int selectionStart = textBox.SelectionStart;
        int selectionLength = textBox.SelectionLength;

        for (int i = 0; i < textBox.Lines.Length; i++) {
            HighlightLine(textBox, i);
        }

        textBox.Select(selectionStart, selectionLength);
    }

    static void HighlightLine(RichTextBox textBox, int line) {
        if (textBox.Lines[line].Length == 0) return;

        int lineStart = textBox.GetFirstCharIndexFromLine(line);
        if (textBox.Text[lineStart] == Characters.commentStart) {
            SetColor(textBox, lineStart, textBox.Lines[line].Length, Color.LightGreen);
        }
        else {
            int numberLength = Lines.NumberPart(textBox, line).Length;
            if (numberLength > 0) {
                SetColor(textBox, lineStart, numberLength, Color.Orange);
            }

            int actionsLength = Lines.Length(textBox, line) - numberLength;
            if (actionsLength > 0) {
                SetColor(textBox, lineStart + numberLength, actionsLength, Color.LightBlue);
            }
        }
    }

    static void SetColor(RichTextBox textBox, int start, int length, Color color) {
        textBox.Select(start, length);
        textBox.SelectionColor = color;
    }
}