namespace PenguinTAS;

public static class TextBoxView {
    public static void SyncZoom(RichTextBox textBox) {
        foreach (var box in PenguinTAS.TextBoxes) {
            box.ZoomFactor = textBox.ZoomFactor;
        }
    }
}