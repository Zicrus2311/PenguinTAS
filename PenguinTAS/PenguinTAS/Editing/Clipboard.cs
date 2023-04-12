namespace PenguinTAS;

public static class Clipboard {
    static string[]? storedText;
    static int storedLineCount;

    public static void Cut() {
        EditHistory.RecordState();
        Copy();
        TextEditor.RemoveSelectedLines();
    }

    public static void Copy() {
        if (PenguinTAS.TextBoxes.Length == 0) return;

        storedText ??= new string[PenguinTAS.TextBoxes.Length];

        for (int i = 0; i < storedText.Length; i++) {
            storedText[i] = TextSelection.GetSelectedLinesText(PenguinTAS.TextBoxes[i]);
        }

        storedLineCount = storedText[0].Split('\n').Length;
    }

    public static void Paste() {
        if (storedText is null || PenguinTAS.TextBoxes.Length == 0) return;

        EditHistory.RecordState();
        if (TextSelection.Count > 0) {
            TextEditor.RemoveSelectedLines();
            TextEditor.AddLine(TextSelection.Line - 1);
            TextSelection.SelectLine(PenguinTAS.TextBoxes[0], TextSelection.Line);
        }

        if (!Lines.IsEmpty(TextSelection.Line)) {
            TextEditor.AddLine(TextSelection.Line);
            TextSelection.SelectLine(PenguinTAS.TextBoxes[0], TextSelection.Line + 1);
        }
        for (int i = 0; i < storedText.Length; i++) {
            int index = Lines.Start(PenguinTAS.TextBoxes[i], TextSelection.Line);
            TextEditor.Insert(PenguinTAS.TextBoxes[i], index, storedText[i]);
        }

        TextProcessor.ProcessAll();
        TextSelection.SelectLine(PenguinTAS.TextBoxes[0], TextSelection.Line + storedLineCount - 1);
    }

    public static void Duplicate() {
        if (PenguinTAS.TextBoxes.Length == 0) return;

        EditHistory.RecordState();
        string[] tempText = new string[PenguinTAS.TextBoxes.Length];
        for (int i = 0; i < tempText.Length; i++) {
            tempText[i] = TextSelection.GetSelectedLinesText(PenguinTAS.TextBoxes[i]);
        }

        int endLine = TextSelection.Line + Math.Max(TextSelection.Count - 1, 0);
        TextEditor.AddLine(endLine);
        for (int i = 0; i < storedText.Length; i++) {
            int index = Lines.Start(PenguinTAS.TextBoxes[i], endLine + 1);
            TextEditor.Insert(PenguinTAS.TextBoxes[i], index, storedText[i]);
        }

        TextProcessor.ProcessAll();
        if (TextSelection.Count > 0) {
            TextSelection.SelectLines(PenguinTAS.TextBoxes[0], endLine + 1, endLine + TextSelection.Count);
        }
        else {
            TextSelection.SelectLine(PenguinTAS.TextBoxes[0], endLine + 1);
        }
    }
}