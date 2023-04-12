namespace PenguinTAS;

public static class TextProcessor {
    public static void ProcessAll() {
        foreach (var box in PenguinTAS.TextBoxes) {
            Process(box);
        }
    }

    public static void Process(RichTextBox textBox) {
        AutoCorrect.Correct(textBox);
        AutoIndenter.Indent(textBox);
        SyntaxHighlighter.Highlight(textBox);
    }

    public static void ProcessLine(RichTextBox textBox, int line) {
        AutoCorrect.CorrectLine(textBox, line);
        AutoIndenter.IndentLine(textBox, line);
        SyntaxHighlighter.HighlightLine(textBox, line);
    }
}