namespace PenguinTAS;

public static class AutoIndenter {
    // TODO: Do this in AutoCorrect
    const string maxNumberString = "9999";

    public static void Indent(RichTextBox textBox) {
        int selectionStart = textBox.SelectionStart;
        int selectionLength = textBox.SelectionLength;

        for (int i = 0; i < textBox.Lines.Length; i++) {
            IndentLine(textBox, i);
        }

        textBox.Select(selectionStart, selectionLength);
    }

    public static void IndentLine(RichTextBox textBox, int line) {
        if (textBox.Lines[line].Length == 0) return;

        int lineStart = textBox.GetFirstCharIndexFromLine(line);
        if (textBox.Text[lineStart] == '#' || textBox.Text[lineStart] == '@') {
            textBox.SelectionStart = lineStart;
            textBox.SelectionIndent = 0;
        }
        else {
            string numberString = Lines.NumberPart(textBox, line);
            if (numberString.Length > 0 && int.Parse(numberString) > int.Parse(maxNumberString)) {
                textBox.Text = textBox.Text.Remove(lineStart, numberString.Length)
                                            .Insert(lineStart, maxNumberString);
            }
            int numberLength = Math.Min(numberString.Length, maxNumberString.Length);
            textBox.SelectionStart = lineStart;
            textBox.SelectionIndent = (int)(0.75f * (maxNumberString.Length - numberLength) * textBox.Font.Size);
        }
    }
}