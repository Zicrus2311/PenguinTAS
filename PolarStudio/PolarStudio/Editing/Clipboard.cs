namespace PolarStudio;

public static class Clipboard {
    static string[]? storedText;
    static int storedLineCount;

    public static void Cut() {
        EditHistory.RecordState();
        Copy();
        TextEditor.RemoveSelectedLines();
    }

    public static void Copy() {
        if (PolarStudio.TextBoxes.Length == 0) return;

        storedText ??= new string[PolarStudio.TextBoxes.Length];

        for (int i = 0; i < storedText.Length; i++) {
            storedText[i] = TextSelection.GetSelectedLinesText(PolarStudio.TextBoxes[i]);
        }

        storedLineCount = storedText[0].Split('\n').Length;
    }

    public static void Paste() {
        if (storedText is null || PolarStudio.TextBoxes.Length == 0) return;

        EditHistory.RecordState();
        if (TextSelection.Count > 0) {
            TextEditor.RemoveSelectedLines();
            TextEditor.AddLine(TextSelection.Line - 1);
            TextSelection.SelectLine(PolarStudio.TextBoxes[0], TextSelection.Line);
        }

        if (!Lines.IsEmpty(TextSelection.Line)) {
            TextEditor.AddLine(TextSelection.Line);
            TextSelection.SelectLine(PolarStudio.TextBoxes[0], TextSelection.Line + 1);
        }
        for (int i = 0; i < storedText.Length; i++) {
            int index = Lines.Start(PolarStudio.TextBoxes[i], TextSelection.Line);
            TextEditor.Insert(PolarStudio.TextBoxes[i], index, storedText[i]);
        }

        TextProcessor.ProcessAll();
        TextSelection.SelectLine(PolarStudio.TextBoxes[0], TextSelection.Line + storedLineCount - 1);
    }

    public static void Duplicate() {
        if (PolarStudio.TextBoxes.Length == 0) return;

        EditHistory.RecordState();
        string[] tempText = new string[PolarStudio.TextBoxes.Length];
        for (int i = 0; i < tempText.Length; i++) {
            tempText[i] = TextSelection.GetSelectedLinesText(PolarStudio.TextBoxes[i]);
        }

        int endLine = TextSelection.Line + Math.Max(TextSelection.Count - 1, 0);
        TextEditor.AddLine(endLine);
        for (int i = 0; i < tempText.Length; i++) {
            int index = Lines.Start(PolarStudio.TextBoxes[i], endLine + 1);
            TextEditor.Insert(PolarStudio.TextBoxes[i], index, tempText[i]);
        }

        TextProcessor.ProcessAll();
        if (TextSelection.Count > 0) {
            TextSelection.SelectLines(PolarStudio.TextBoxes[0], endLine + 1, endLine + TextSelection.Count);
        }
        else {
            TextSelection.SelectLine(PolarStudio.TextBoxes[0], endLine + 1);
        }
    }
}