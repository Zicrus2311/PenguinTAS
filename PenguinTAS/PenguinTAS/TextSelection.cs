namespace PenguinTAS;

public static class TextSelection {
    static int selectedLine;
    static int selectionCount;

    public static void SelectLine(int line) {
        selectedLine = line;
        selectionCount = 0;
        UpdateTextBoxes();
    }

    public static void SelectLines(int startLine, int endLine) {
        selectedLine = startLine;
        selectionCount = endLine - startLine + 1;
        UpdateTextBoxes();
    }

    static void UpdateTextBoxes() {
        foreach (var textBox in PenguinTAS.textBoxes) {
            UpdateTextBox(textBox);
        }
    }

    static void UpdateTextBox(RichTextBox textBox) {
        if (selectionCount > 0) {
            UpdateTextBoxSelection(textBox);
        }
        else {
            UpdateTextBoxCaret(textBox);
        }
    }

    static void UpdateTextBoxCaret(RichTextBox textBox) {

    }

    static void UpdateTextBoxSelection(RichTextBox textBox) {
        int start = Lines.Start(textBox, selectedLine);
        int end = Lines.Start(textBox, selectedLine + selectionCount) - "\n?".Length;
        textBox.SelectionStart = start;
        textBox.SelectionLength = end - start;
    }
}