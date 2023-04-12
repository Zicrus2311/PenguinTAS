namespace PenguinTAS;

public static class FileManager {
    static string? currentPath = null;

    public static void New() {
        for (int i = 0; i < PenguinTAS.TextBoxes.Length; i++) {
            PenguinTAS.TextBoxes[i].Text = $"{Characters.commentStart}Player {i + 1}";
        }
        currentPath = null;
        TextProcessor.ProcessAll();
    }

    public static void OpenPath(string path) {
        string fileText = File.ReadAllText(path);
        ApplyFileText(fileText);
        currentPath = path;
        TextProcessor.ProcessAll();
    }

    public static void Open() {
        OpenFileDialog ofd = new();
        ofd.Filter = "TAS Files (.2tas)|*.2tas";
        ofd.Title = "Open...";
        if (ofd.ShowDialog() == DialogResult.OK) {
            OpenPath(ofd.FileName);
        }
    }

    public static void Save() {
        if (currentPath == null) {
            SaveAs();
            return;
        }

        string fileText = MergeTextBoxText();
        File.WriteAllText(currentPath, fileText);
    }

    public static void SaveAs() {
        SaveFileDialog sfd = new();
        sfd.Filter = "TAS Files (.2tas)|*.2tas";
        sfd.Title = "Save As...";
        if (sfd.ShowDialog() == DialogResult.OK) {
            string fileText = MergeTextBoxText();
            File.WriteAllText(sfd.FileName, fileText);
            currentPath = sfd.FileName;
        }
    }

    public static void ApplyFileText(string fileText) {
        for (int i = 0; i < PenguinTAS.TextBoxes.Length; i++) {
            PenguinTAS.TextBoxes[i].Text = GetPlayerText(fileText, i);
        }
    }

    public static string MergeTextBoxText() {
        string fileText = string.Empty;
        for (int i = 0; i < PenguinTAS.TextBoxes.Length; i++) {
            fileText += PenguinTAS.TextBoxes[i].Text;

            bool lastPlayer = i == PenguinTAS.TextBoxes.Length - 1;
            if (!lastPlayer) {
                fileText += Characters.playerSeperator;
            }
        }
        return fileText;
    }

    static string GetPlayerText(string fileText, int player) {
        string[] splitFile = fileText.Split(Characters.playerSeperator);
        return splitFile.Length > player ? splitFile[player] : string.Empty;
    }
}