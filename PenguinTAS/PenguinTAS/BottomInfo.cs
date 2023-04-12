namespace PenguinTAS;

public static class BottomInfo {
    public static void AddInfo(RichTextBox textBox) {
        string lastLine = textBox.Lines[textBox.Lines.Length - 1];
        if (lastLine.Length > 0 && lastLine[0] == '@') {

        }
        else {
            textBox.Text += "\n@Hello!";
        }
    }
}