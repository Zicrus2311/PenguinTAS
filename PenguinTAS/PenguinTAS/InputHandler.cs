namespace PenguinTAS;

public static class InputHandler {
    public static bool HandleCharInput(RichTextBox textBox, KeyPressEventArgs e) {
        char character = e.KeyChar;
        if (character == Characters.playerSeperator) {
            return true;
        }
        else if (character == Characters.commentStart) {
            HandleCommentStart(textBox, character);
            TextProcessor.ProcessAll();
        }
        else if (Lines.IsComment(textBox, TextSelection.Line) && TextSelection.Count == 0) {
            HandleCommentText(textBox, character);
            TextProcessor.ProcessAll();
        }
        else if (Characters.IsNumber(character)) {
            HandleNumber(textBox, character);
            TextProcessor.ProcessAll();
        }
        else if (Characters.IsAction(character)) {
            HandleAction(textBox, character);
            TextProcessor.ProcessAll();
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
                TextProcessor.ProcessAll();
                break;
            case Keys.Back:
                HandleBack(textBox, e);
                TextProcessor.ProcessAll();
                break;
            case Keys.Delete:
                HandleDelete(textBox, e);
                TextProcessor.ProcessAll();
                break;
        }
        return true;
    }

    static void HandleCommentStart(RichTextBox textBox, char character) {
        int selectedLine = TextSelection.Line;
        int selectionCount = TextSelection.Count;
        if (Lines.IsComment(textBox, selectedLine)) {
            TextEditor.RemoveComment(selectedLine);
            for (int i = 1; i < selectionCount - 1; i++) {
                TextEditor.RemoveComment(selectedLine + i);
            }
        }
        else {
            TextEditor.AddComment(selectedLine);
            for (int i = 1; i < selectionCount - 1; i++) {
                TextEditor.AddComment(selectedLine + i);
            }
        }
        TextSelection.UpdateTextBox(textBox);
    }

    static void HandleCommentText(RichTextBox textBox, char character) {
        if (!Characters.IsAllowedInComments(character)) return;

        int editPos = Lines.EditPosition(textBox, TextSelection.Line);
        int index = Lines.Start(textBox, TextSelection.Line) + editPos;
        TextEditor.Insert(textBox, index, character);
        TextSelection.UpdateTextBox(textBox);
    }

    static void HandleNumber(RichTextBox textBox, char character) {
        if (TextSelection.Count > 0) {
            TextEditor.RemoveSelectedLines();
            TextEditor.AddLine(TextSelection.Line - 1);
            TextSelection.SelectLine(textBox, TextSelection.Line);
        }

        int editPos = Lines.EditPosition(textBox, TextSelection.Line);
        int index = Lines.Start(textBox, TextSelection.Line) + editPos;
        TextEditor.Insert(textBox, index, character);
        TextEditor.SyncNumbers(textBox, TextSelection.Line);
        TextSelection.UpdateTextBox(textBox);
    }

    static void HandleAction(RichTextBox textBox, char character) {
        int selectedLine = TextSelection.Line;
        int selectionCount = TextSelection.Count;
        if (Lines.NumberPart(textBox, selectedLine).Length == 0) return;

        character = Characters.UpperCase(character);
        char[] actions = Lines.Actions(textBox, TextSelection.Line);
        if (actions.Contains(character)) {
            TextEditor.RemoveAction(textBox, selectedLine, character);
            for (int i = 1; i < selectionCount - 1; i++) {
                TextEditor.RemoveAction(textBox, selectedLine + i, character);
            }
        }
        else {
            TextEditor.AddAction(textBox, selectedLine, character);
            for (int i = 1; i < selectionCount - 1; i++) {
                TextEditor.AddAction(textBox, selectedLine + i, character);
            }
        }
        TextSelection.UpdateTextBox(textBox);
    }

    static void HandleUp(RichTextBox textBox, KeyEventArgs e) {
        TextSelection.SelectLine(textBox, TextSelection.Line - 1);
    }

    static void HandleDown(RichTextBox textBox, KeyEventArgs e) {
        int selectionEnd = TextSelection.Line + Math.Max(TextSelection.Count - 1, 0);
        TextSelection.SelectLine(textBox, selectionEnd + 1);
    }

    static void HandleReturn(RichTextBox textBox, KeyEventArgs e) {
        if (TextSelection.Count > 0) {
            TextEditor.RemoveSelectedLines();
            TextSelection.SelectLine(textBox, TextSelection.Line - 1);
        }

        TextEditor.AddLine(TextSelection.Line);
        TextSelection.SelectLine(textBox, TextSelection.Line + 1);
    }

    static void HandleBack(RichTextBox textBox, KeyEventArgs e) {
        if (TextSelection.Count > 0) {
            TextEditor.RemoveSelectedLines();
            TextSelection.SelectLine(textBox, TextSelection.Line - 1);
            return;
        }

        int editPos = Lines.EditPosition(textBox, TextSelection.Line);
        bool removingComment = Lines.IsComment(textBox, TextSelection.Line) && editPos == 1;
        if (editPos > 0 && !removingComment) {
            int lineStart = Lines.Start(textBox, TextSelection.Line);
            TextEditor.Remove(textBox, lineStart + editPos - 1, 1);
            TextEditor.SyncNumbers(textBox, TextSelection.Line);
            TextSelection.UpdateTextBox(textBox);
        }
        else {
            TextEditor.RemoveLine(TextSelection.Line);
            TextSelection.SelectLine(textBox, TextSelection.Line - 1);
        }
    }

    static void HandleDelete(RichTextBox textBox, KeyEventArgs e) {
        TextEditor.RemoveSelectedLines();
        TextSelection.SelectLine(textBox, TextSelection.Line - 1);
    }
}