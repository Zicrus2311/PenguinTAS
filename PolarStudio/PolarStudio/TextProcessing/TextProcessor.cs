namespace PolarStudio;

public static class TextProcessor {
    public static void ProcessAll() {
        foreach (var box in PolarStudio.TextBoxes) {
            Process(box);
        }
    }

    public static void Process(RichTextBox textBox) {
        RichTextBox tempBox = PolarStudio.TempBox!;

        float zoom = textBox.ZoomFactor;
        tempBox.Rtf = textBox.Rtf;
        AutoIndenter.Indent(tempBox);
        SyntaxHighlighter.Highlight(tempBox);
        textBox.Rtf = tempBox.Rtf;
        textBox.ZoomFactor = zoom;
        TextSelection.UpdateTextBox(textBox);
    }
}