namespace PenguinTAS;

public static class InputHandler {
    public static bool HandleCharInput(RichTextBox textBox, KeyPressEventArgs e) {
        char character = e.KeyChar;
        if (character == Characters.playerSeperator) {
            return true;
        }
        if (character == Characters.commentStart) {
            HandleCommentStart(textBox, character);
        }
        else if (Lines.IsComment(textBox, TextSelection.Line)) {
            return false;
        }
        else if (Characters.IsNumber(character)) {
            HandleNumber(textBox, character);
        }
        else if (Characters.IsAction(character)) {
            HandleAction(textBox, character);
        }
        return true;
    }

    public static bool HandleKeyInput(RichTextBox textBox, KeyEventArgs e) {
        switch (e.KeyCode) {
            case Keys.Up:
                HandleUp(textBox, e);
                break;
            case Keys.Down:
                HandleDown(textBox, e);
                break;
            case Keys.Return:
                HandleReturn(textBox, e);
                break;
            case Keys.Back:
                HandleBack(textBox, e);
                break;
            case Keys.Delete:
                HandleDelete(textBox, e);
                break;
        }
        return true;
    }

    static void HandleNumber(RichTextBox textBox, char character) {

    }

    static void HandleAction(RichTextBox textBox, char character) {

    }

    static void HandleCommentStart(RichTextBox textBox, char character) {
        int selectedLine = TextSelection.Line;
        int selectionCount = TextSelection.Count;
        if (Lines.IsComment(textBox, selectedLine)) {
            TextEditor.RemoveComment(textBox, selectedLine);
            for (int i = 1; i < selectionCount - 1; i++) {
                TextEditor.RemoveComment(textBox, selectedLine + i);
            }
        }
        else {
            TextEditor.AddComment(textBox, selectedLine);
            for (int i = 1; i < selectionCount - 1; i++) {
                TextEditor.AddComment(textBox, selectedLine + i);
            }
        }
        TextSelection.SelectLines(textBox, selectedLine, selectedLine + selectionCount - 1);
    }

    static void HandleUp(RichTextBox textBox, KeyEventArgs e) {
        TextSelection.SelectLine(textBox, TextSelection.Line - 1);
    }

    static void HandleDown(RichTextBox textBox, KeyEventArgs e) {
        TextSelection.SelectLine(textBox, TextSelection.Line + 1);
    }

    static void HandleReturn(RichTextBox textBox, KeyEventArgs e) {
        TextEditor.AddLine(TextSelection.Line);
        TextSelection.SelectLine(textBox, TextSelection.Line + 1);
    }

    static void HandleBack(RichTextBox textBox, KeyEventArgs e) {
        int editPos = Lines.EditPosition(textBox, TextSelection.Line);
        if (editPos > 0) {
            int lineStart = Lines.Start(textBox, TextSelection.Line);
            TextEditor.Remove(textBox, lineStart + editPos - 1, 1);
            TextSelection.SelectLine(textBox, TextSelection.Line);
        }
        else {
            TextEditor.RemoveLine(TextSelection.Line);
            TextSelection.SelectLine(textBox, TextSelection.Line - 1);
        }
    }

    static void HandleDelete(RichTextBox textBox, KeyEventArgs e) {
        TextEditor.RemoveLine(TextSelection.Line);
        TextSelection.SelectLine(textBox, TextSelection.Line - 1);
    }
}