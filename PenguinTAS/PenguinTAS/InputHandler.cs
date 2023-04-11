﻿namespace PenguinTAS;

public static class InputHandler {
    public static bool HandleCharInput(RichTextBox textBox, KeyPressEventArgs e) {
        char character = e.KeyChar;
        if (Lines.IsComment(textBox, TextSelection.Line)) {
            return false;
        }
        else if (Characters.IsNumber(textBox, character)) {

        }
        else if (Characters.IsAction(textBox, character)) {

        }
        else if (Characters.IsCommentStart(textBox, character)) {

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

    static void HandleUp(RichTextBox textBox, KeyEventArgs e) {

    }

    static void HandleDown(RichTextBox textBox, KeyEventArgs e) {

    }

    static void HandleReturn(RichTextBox textBox, KeyEventArgs e) {

    }

    static void HandleBack(RichTextBox textBox, KeyEventArgs e) {

    }

    static void HandleDelete(RichTextBox textBox, KeyEventArgs e) {

    }
}