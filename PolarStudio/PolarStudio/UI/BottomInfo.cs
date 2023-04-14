namespace PolarStudio;

public static class BottomInfo {
    const float physicsFramerate = 50;

    public static void UpdateInfo(Label label) {
        if (PolarStudio.TextBoxes.Length == 0) return;

        int totalFrames = 0;
        RichTextBox textBox = PolarStudio.TextBoxes[0];
        for (int i = 0; i < Lines.Count(textBox); i++) {
            string numberPart = Lines.NumberPart(textBox, i);
            int frames = numberPart.Length > 0 ? int.Parse(numberPart) : 0;
            totalFrames += frames;
        }

        TimeSpan time = TimeSpan.FromMilliseconds(totalFrames / physicsFramerate * 1000);
        string timeText = time.ToString("mm':'ss'.'ff");
        label.Text = $"Total frame count: {totalFrames} ({timeText})";
    }
}