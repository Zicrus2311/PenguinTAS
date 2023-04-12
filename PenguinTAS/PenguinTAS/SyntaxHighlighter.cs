﻿namespace PenguinTAS;

public static class SyntaxHighlighter {
    public static void Highlight(RichTextBox textBox) {
        int selectionStart = textBox.SelectionStart;
        int selectionLength = textBox.SelectionLength;

        for (int i = 0; i < textBox.Lines.Length; i++) {
            HighlightLine(textBox, i);
        }

        textBox.Select(selectionStart, selectionLength);
    }

    static void HighlightLine(RichTextBox textBox, int line) {
        if (textBox.Lines[line].Length == 0) return;

        int lineStart = textBox.GetFirstCharIndexFromLine(line);
        if (textBox.Text[lineStart] == '@') {
            SetColor(textBox, lineStart, textBox.Lines[line].Length, Color.Orange);
        }
        else if (textBox.Text[lineStart] == '#') {
            SetColor(textBox, lineStart, textBox.Lines[line].Length, Color.LightGreen);
        }
    }

    static void SetColor(RichTextBox textBox, int start, int length, Color color) {
        textBox.Select(start, length);
        textBox.SelectionColor = color;
    }
}