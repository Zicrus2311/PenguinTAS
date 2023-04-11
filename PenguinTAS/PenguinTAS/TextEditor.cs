namespace PenguinTAS;

public static class TextEditor {
    public static void AddLine(int prevLine, string text = "") {
        foreach (var textBox in PenguinTAS.TextBoxes) {
            AddLine(textBox, prevLine, text);
        }
    }

    public static void RemoveLine(int line) {
        foreach (var textBox in PenguinTAS.TextBoxes) {
            RemoveLine(textBox, line);
        }
    }

    public static void Insert(RichTextBox textBox, int index, string text) {
        int start = Math.Clamp(index, 0, textBox.TextLength);
        textBox.Text = textBox.Text.Insert(start, text);
    }

    public static void Remove(RichTextBox textBox, int index, int length) {
        if (textBox.TextLength == 0) return;

        int start = Math.Clamp(index, 0, textBox.TextLength - 1);
        int end = Math.Clamp(index + length, 0, textBox.TextLength);
        textBox.Text = textBox.Text.Remove(start, end - start);
    }

    static void AddLine(RichTextBox textBox, int prevLine, string text) {
        int prevLineEnd = Lines.End(textBox, prevLine);
        Insert(textBox, prevLineEnd, $"\n{text}");
    }

    static void RemoveLine(RichTextBox textBox, int line) {
        int lineStart = Lines.Start(textBox, line);
        int lineLength = Lines.Length(textBox, line);
        Remove(textBox, lineStart - "\n".Length, lineLength + "\n".Length);
    }
}