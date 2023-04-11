namespace PenguinTAS;

public static class Lines {
    public static bool IsComment(RichTextBox textBox, int line) {
        string lineText = textBox.Lines[line];
        return lineText.Length > 0 && Characters.IsCommentStart(lineText[0]);
    }
}