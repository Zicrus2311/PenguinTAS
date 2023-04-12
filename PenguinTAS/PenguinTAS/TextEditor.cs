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

    public static void AddComment(int line) {
        foreach (var box in PenguinTAS.TextBoxes) {
            int index = Lines.Start(box, line);
            if (!Lines.IsComment(box, line)) {
                Insert(box, index, Characters.commentStart);
            }
        }
    }

    public static void RemoveComment(int line) {
        if (!CanRemoveComment(line)) return;

        foreach (var box in PenguinTAS.TextBoxes) {
            if (Lines.IsComment(box, line)) {
                int index = Lines.Start(box, line);
                Remove(box, index, 1);
            }
        }
    }

    static bool CanRemoveComment(int line) {
        bool canRemoveLine = true;
        int? targetNumber = null;
        foreach (var box in PenguinTAS.TextBoxes) {
            string lineText = Lines.GetText(box, line);
            if (AutoCorrect.IsValidLine(lineText[1..])) {
                int number = lineText.Length > 1 ? int.Parse(Lines.NumberPart(lineText[1..])) : -1;
                canRemoveLine &= number == targetNumber || targetNumber == null;
                targetNumber = number;
            }
            else {
                canRemoveLine = false;
            }
        }
        return canRemoveLine;
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
        if (textBox.TextLength == 0 || length == 0) return;

        int start = Math.Clamp(index, 0, textBox.TextLength - 1);
        int end = Math.Clamp(index + length, 0, textBox.TextLength);
        textBox.Text = textBox.Text.Remove(start, end - start);
    }

    public static void SyncNumbers(RichTextBox textBox, int line) {
        string number = Lines.NumberPart(textBox, line);
        foreach (var box in PenguinTAS.TextBoxes) {
            int start = Lines.Start(box, line);
            string numberPart = Lines.NumberPart(box, line);
            Remove(box, start, numberPart.Length);
            Insert(box, start, number);
        }
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