namespace PenguinTAS;

public static class TextSelection {
    public static int Line { get; private set; }
    public static int Count { get; private set; }

    public static void SelectLine(int line) {
        Line = line;
        Count = 0;
        UpdateTextBoxes();
    }

    public static void SelectLines(int startLine, int endLine) {
        Line = startLine;
        Count = endLine - startLine + 1;
        UpdateTextBoxes();
    }

    static void UpdateTextBoxes() {
        foreach (var textBox in PenguinTAS.TextBoxes) {
            UpdateTextBox(textBox);
        }
    }

    static void UpdateTextBox(RichTextBox textBox) {
        if (Count > 0) {
            UpdateTextBoxSelection(textBox);
        }
        else {
            UpdateTextBoxCaret(textBox);
        }
    }

    static void UpdateTextBoxCaret(RichTextBox textBox) {
        int start = Lines.Start(textBox, Line);
    }

    static void UpdateTextBoxSelection(RichTextBox textBox) {
        int start = Lines.Start(textBox, Line);
        int end = Lines.Start(textBox, Line + Count) - "\n?".Length;
        textBox.SelectionStart = start;
        textBox.SelectionLength = end - start;
    }
}