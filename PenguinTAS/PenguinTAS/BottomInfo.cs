namespace PenguinTAS;

public static class BottomInfo {
    public static void UpdateInfo(Label label) {
        if (PenguinTAS.TextBoxes.Length == 0) return;

        int totalFrames = 0;
        RichTextBox textBox = PenguinTAS.TextBoxes[0];
        for (int i = 0; i < Lines.Count(textBox); i++) {
            string numberPart = Lines.NumberPart(textBox, i);
            int frames = numberPart.Length > 0 ? int.Parse(numberPart) : 0;
            totalFrames += frames;
        }

        label.Text = $"Total frame count: {totalFrames}";
    }
}