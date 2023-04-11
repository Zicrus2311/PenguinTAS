namespace PenguinTAS;

public static class TextEditor {
    public static void AddLine(int prevLine, string text = "") {
        foreach (var textBox in PenguinTAS.TextBoxes) {
            AddLine(textBox, prevLine, text);
        }
    }

    public static void RemoveSelectedLines() {
        TextEditor.RemoveLine(TextSelection.Line);
        for (int i = 1; i < TextSelection.Count; i++) {
            TextEditor.RemoveLine(TextSelection.Line);
        }
    }

    public static void RemoveLine(int line) {
        foreach (var textBox in PenguinTAS.TextBoxes) {
            RemoveLine(textBox, line);
        }
    }

    public static void AddComment(RichTextBox textBox, int line) {
        int index = Lines.Start(textBox, line);
        if (!Lines.IsComment(textBox, line)) {
            Insert(textBox, index, Characters.commentStart);
        }
    }

    public static void RemoveComment(RichTextBox textBox, int line) {
        int index = Lines.Start(textBox, line);
        string lineText = Lines.GetText(textBox, line);
        if (Lines.IsComment(textBox, line) && AutoCorrect.IsValidLine(lineText[1..])) {
            Remove(textBox, index, 1);
        }
    }

    public static void AddAction(RichTextBox textBox, int line, char action) {
        char[] actions = Lines.Actions(textBox, line);
        int index = Lines.End(textBox, line);
        if (!actions.Contains(action)) {
            char seperator = actions.Length == 0 ? Characters.numberSeperator : Characters.actionSeperator;
            Insert(textBox, index, $"{seperator}{action}");
        }
    }

    public static void RemoveAction(RichTextBox textBox, int line, char action) {
        char[] actions = Lines.Actions(textBox, line);
        if (actions.Contains(action)) {
            int indexInLine = Lines.GetText(textBox, line).IndexOf(action);
            int startIndex = Lines.Start(textBox, line) + indexInLine;
            if (action == actions[0] && actions.Length > 1) {
                Remove(textBox, startIndex, "?,".Length);
            }
            else {
                Remove(textBox, startIndex - ",".Length, ",?".Length);
            }
        }
    }

    public static void Insert(RichTextBox textBox, int index, char character) {
        Insert(textBox, index, character.ToString());
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