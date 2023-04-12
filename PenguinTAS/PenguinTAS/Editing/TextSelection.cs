namespace PenguinTAS;

public static class TextSelection {
    public static int Line { get; private set; }
    public static int Count { get; private set; }

    public static void CorrectSelection(RichTextBox textBox) {
        int start = textBox.SelectionStart;
        int length = textBox.SelectionLength;
        if (length > 0) {
            int end = start + length - 1;
            int startLine = Lines.GetFromIndex(textBox, start);
            int endLine = Lines.GetFromIndex(textBox, end);
            if (Lines.Length(textBox, endLine + 1) == 0) endLine++;
            SelectLines(textBox, startLine, endLine);
        }
        else {
            int line = Lines.GetFromIndex(textBox, start);
            SelectLine(textBox, line);
        }
        UpdateTextBox(textBox);
    }

    public static void SelectLine(RichTextBox textBox, int line) {
        Line = Math.Clamp(line, 0, Lines.Count(textBox) - 1);
        Count = 0;
        UpdateTextBox(textBox);
    }

    public static void SelectLines(RichTextBox textBox, int startLine, int endLine) {
        Line = Math.Clamp(startLine, 0, Lines.Count(textBox) - 1);
        int end = Math.Clamp(endLine, 0, Lines.Count(textBox));
        Count = Math.Max(end - Line + 1, 0);
        UpdateTextBox(textBox);
    }

    public static string GetSelectedLinesText(RichTextBox textBox) {
        string text = Lines.GetText(textBox, Line);
        for (int i = 1; i < Count; i++) {
            text += $"\n{Lines.GetText(textBox, Line + i)}";
        }
        return text.TrimEnd('\n');
    }

    public static void UpdateTextBoxes() {
        foreach (var box in PenguinTAS.TextBoxes) {
            UpdateTextBox(box);
        }
    }

    public static void UpdateTextBox(RichTextBox textBox) {
        if (Count > 0) {
            UpdateTextBoxSelection(textBox);
        }
        else {
            UpdateTextBoxCaret(textBox);
        }
    }

    static void UpdateTextBoxCaret(RichTextBox textBox) {
        int start = Lines.Start(textBox, Line);
        int editPos = Lines.EditPosition(textBox, Line);
        textBox.SelectionStart = start + editPos;
        textBox.SelectionLength = 0;
    }

    static void UpdateTextBoxSelection(RichTextBox textBox) {
        int start = Lines.Start(textBox, Line);
        int end = Lines.Start(textBox, Line + Count) - "\n".Length;
        textBox.SelectionStart = start;
        textBox.SelectionLength = end - start;
    }
}