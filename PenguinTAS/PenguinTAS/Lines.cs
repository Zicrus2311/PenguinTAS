namespace PenguinTAS;

public static class Lines {
    public static int Count(RichTextBox textBox) {
        // TODO: Remove this!
        if(textBox.Lines.Length != textBox.Text.Split('\n').Length) {
            //MessageBox.Show($"Lines: {textBox.Lines.Length}, Custom: {textBox.Text.Split('\n').Length}");
        }
        return textBox.Text.Split('\n').Length;
    }

    public static bool IsComment(RichTextBox textBox, int line) {
        string lineText = GetText(textBox, line);
        return lineText.Length > 0 && lineText[0] == Characters.commentStart;
    }

    public static string GetText(RichTextBox textBox, int line) {
        return textBox.Lines.Length > line ? textBox.Lines[line] : string.Empty;
    }

    public static int Start(RichTextBox textBox, int line) {
        int oobIndex = Count(textBox) > line ? textBox.TextLength : textBox.TextLength + "\n".Length;
        return textBox.Lines.Length > line ? textBox.GetFirstCharIndexFromLine(line) : oobIndex;
    }

    public static int Length(RichTextBox textBox, int line) {
        return textBox.Lines.Length > line ? textBox.Lines[line].Length : 0;
    }

    public static int End(RichTextBox textBox, int line) {
        return Start(textBox, line) + Length(textBox, line);
    }

    public static int GetFromIndex(RichTextBox textBox, int index) {
        return textBox.GetLineFromCharIndex(index);
    }

    public static string NumberPart(RichTextBox textBox, int line) {
        string[] splitLine = GetText(textBox, line).Split(Characters.numberSeperator);
        bool hasNumberPart = !IsComment(textBox, line) && splitLine.Length > 0;
        return hasNumberPart ? splitLine[0] : string.Empty;
    }

    public static int EditPosition(RichTextBox textBox, int line) {
        if(IsComment(textBox, line)) {
            return Length(textBox, line);
        }
        else {
            return NumberPart(textBox, line).Length;
        }
    }
}