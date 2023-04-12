namespace PenguinTAS;

public static class EditHistory {
    const int savedEdits = 100;

    static List<string> undoBuffer = new();
    static List<string> redoBuffer = new();

    public static void RecordState() {
        Record(undoBuffer);
        redoBuffer.Clear();
    }

    public static void Undo() {
        if (undoBuffer.Count == 0) return;

        Record(redoBuffer);
        FileManager.ApplyFileText(undoBuffer[^1]);
        undoBuffer.RemoveAt(undoBuffer.Count - 1);
        TextProcessor.ProcessAll();
        TextSelection.UpdateTextBoxes();
    }

    public static void Redo() {
        if (redoBuffer.Count == 0) return;

        Record(undoBuffer);
        FileManager.ApplyFileText(redoBuffer[^1]);
        redoBuffer.RemoveAt(redoBuffer.Count - 1);
        TextProcessor.ProcessAll();
        TextSelection.UpdateTextBoxes();
    }

    static void Record(List<string> buffer) {
        string fileText = FileManager.MergeTextBoxText();
        if (buffer.Count == 0 || buffer[^1] != fileText) {
            buffer.Add(fileText);
            if (buffer.Count > savedEdits) {
                buffer.RemoveAt(0);
            }
        }
    }
}