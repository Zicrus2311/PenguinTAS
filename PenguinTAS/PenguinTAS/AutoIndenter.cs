namespace PenguinTAS;

public static class AutoIndenter {
    const int numberIndentation = 4;

    public static void Indent(RichTextBox textBox) {
        for (int i = 0; i < textBox.Lines.Length; i++) {
            IndentLine(textBox, i);
        }
    }

    static void IndentLine(RichTextBox textBox, int line) {
        if (textBox.Lines[line].Length == 0) return;

        if (!Lines.IsComment(textBox, line)) {
            int numberLength = Lines.NumberPart(textBox, line).Length;
            textBox.SelectionStart = Lines.Start(textBox, line);
            textBox.SelectionIndent = (int)(0.75f * (numberIndentation - numberLength) * textBox.Font.Size);
        }
    }
}