namespace PenguinTAS;

public static class InputHandler {
    public static bool HandleCharInput(RichTextBox textBox, KeyPressEventArgs e) {
        char character = e.KeyChar;
        if (character == Characters.playerSeperator) {
            return true;
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
        else if (character == Characters.commentStart) {
            HandleCommentStart(textBox, character);
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

    }

    static void HandleUp(RichTextBox textBox, KeyEventArgs e) {

    }

    static void HandleDown(RichTextBox textBox, KeyEventArgs e) {

    }

    static void HandleReturn(RichTextBox textBox, KeyEventArgs e) {
        TextEditor.AddLine(TextSelection.Line);
        TextSelection.SelectLine(TextSelection.Line + 1);
    }

    static void HandleBack(RichTextBox textBox, KeyEventArgs e) {

    }

    static void HandleDelete(RichTextBox textBox, KeyEventArgs e) {
        TextEditor.RemoveLine(TextSelection.Line);
        TextSelection.SelectLine(TextSelection.Line - 1);
    }
}