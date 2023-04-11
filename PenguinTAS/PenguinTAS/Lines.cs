namespace PenguinTAS;

public static class Lines {
    public static int Count(RichTextBox textBox) {
        // TODO: Remove this!
        if(textBox.Lines.Length != textBox.Text.Split('\n').Length + 1) {
            MessageBox.Show($"Lines: {textBox.Lines.Length}, Custom: {textBox.Text.Split('\n').Length + 1}");
        }
        return textBox.Text.Split('\n').Length + 1;
    }

    public static bool IsComment(RichTextBox textBox, int line) {
        string lineText = GetText(textBox, line);
        return lineText.Length > 0 && Characters.IsCommentStart(lineText[0]);
    }

    public static string GetText(RichTextBox textBox, int line) {
        return textBox.Lines.Length > line ? textBox.Lines[line] : "";
    }

    public static int Start(RichTextBox textBox, int line) {
        return textBox.GetFirstCharIndexFromLine(line);
    }

    public static int Length(RichTextBox textBox, int line) {
        return textBox.Lines.Length > line ? textBox.Lines[line].Length : 0;
    }

    public static int End(RichTextBox textBox, int line) {
        return Start(textBox, line) + Length(textBox, line);
    }
}