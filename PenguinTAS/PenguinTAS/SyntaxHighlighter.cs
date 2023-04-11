namespace PenguinTAS;

public static class SyntaxHighlighter {
    public static void Highlight(RichTextBox textBox1, RichTextBox textBox2) {
        Highlight(textBox1);
        Highlight(textBox2);
    }

    public static void Highlight(RichTextBox textBox) {
        int selectionStart = textBox.SelectionStart;
        int selectionLength = textBox.SelectionLength;

        for (int i = 0; i < textBox.Lines.Length; i++) {
            if (textBox.Lines[i].Length == 0) continue;

            int lineStart = textBox.GetFirstCharIndexFromLine(i);
            if (textBox.Text[lineStart] == '@') {
                SetColor(textBox, lineStart, textBox.Lines[i].Length, Color.Orange);
            }
            else if (textBox.Text[lineStart] == '#') {
                SetColor(textBox, lineStart, textBox.Lines[i].Length, Color.LightGreen);
            }
            else {
                SetColor(textBox, lineStart, textBox.Lines[i].Length, Color.White);
            }
        }

        textBox.Select(selectionStart, selectionLength);
    }

    static void SetColor(RichTextBox textBox, int start, int length, Color color) {
        textBox.Select(start, length);
        textBox.SelectionColor = color;
    }
}