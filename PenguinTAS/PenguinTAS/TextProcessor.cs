namespace PenguinTAS;

public static class TextProcessor {
    public static void ProcessAll() {
        foreach (var box in PenguinTAS.TextBoxes) {
            Process(box);
        }
    }

    public static void Process(RichTextBox textBox) {
        RichTextBox tempBox = PenguinTAS.TempBox!;

        tempBox.Rtf = textBox.Rtf;
        AutoCorrect.Correct(tempBox);
        AutoIndenter.Indent(tempBox);
        SyntaxHighlighter.Highlight(tempBox);
        textBox.Rtf = tempBox.Rtf;
        TextSelection.UpdateTextBox(textBox);
    }
}