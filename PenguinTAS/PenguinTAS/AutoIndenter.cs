namespace PenguinTAS {
    public static class AutoIndenter {
        const string maxNumberString = "9999";

        public static void Indent(RichTextBox textBox1, RichTextBox textBox2) {
            Indent(textBox1);
            Indent(textBox2);
        }

        public static void Indent(RichTextBox textBox) {
            int selectionStart = textBox.SelectionStart;
            int selectionLength = textBox.SelectionLength;

            for (int i = 0; i < textBox.Lines.Length; i++) {
                if (textBox.Lines[i].Length == 0) continue;

                int lineStart = textBox.GetFirstCharIndexFromLine(i);
                if (textBox.Text[lineStart] == '#' || textBox.Text[lineStart] == '@') {
                    textBox.SelectionStart = lineStart;
                    textBox.SelectionIndent = 0;
                }
                else {
                    string numberString = textBox.Lines[i].Split(',')[0].Trim();
                    if (numberString.Length > 0 && int.Parse(numberString) > int.Parse(maxNumberString)) {
                        textBox.Text = textBox.Text.Remove(lineStart, numberString.Length)
                                                   .Insert(lineStart, maxNumberString);
                    }
                    int numberLength = Math.Min(numberString.Length, maxNumberString.Length);
                    textBox.SelectionStart = lineStart;
                    textBox.SelectionIndent = (int)(0.75f * (maxNumberString.Length - numberLength) * textBox.Font.Size);
                }
            }

            textBox.Select(selectionStart, selectionLength);
        }
    }
}