namespace PolarStudio;

public static class FileManager {
    static string? currentPath = null;

    public static void New() {
        for (int i = 0; i < PolarStudio.TextBoxes.Length; i++) {
            PolarStudio.TextBoxes[i].Text = $"{Characters.commentStart}Player {i + 1}";
        }
        WriteToActive(MergeTextBoxText());
        currentPath = null;
        TextProcessor.ProcessAll();
    }

    public static void OpenPath(string path) {
        string fileText = File.ReadAllText(path);
        ApplyFileText(fileText);
        WriteToActive(fileText);
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
        WriteToActive(fileText);
    }

    public static void SaveAs() {
        SaveFileDialog sfd = new();
        sfd.Filter = "TAS Files (.2tas)|*.2tas";
        sfd.Title = "Save As...";
        if (sfd.ShowDialog() == DialogResult.OK) {
            string fileText = MergeTextBoxText();
            File.WriteAllText(sfd.FileName, fileText);
            WriteToActive(fileText);
            currentPath = sfd.FileName;
        }
    }

    public static void ApplyFileText(string fileText) {
        for (int i = 0; i < PolarStudio.TextBoxes.Length; i++) {
            PolarStudio.TextBoxes[i].Text = GetPlayerText(fileText, i);
        }
    }

    public static string MergeTextBoxText() {
        string fileText = string.Empty;
        for (int i = 0; i < PolarStudio.TextBoxes.Length; i++) {
            fileText += PolarStudio.TextBoxes[i].Text;

            bool lastPlayer = i == PolarStudio.TextBoxes.Length - 1;
            if (!lastPlayer) {
                fileText += Characters.playerSeperator;
            }
        }
        return fileText;
    }

    static void WriteToActive(string fileText) {
        string directory = AppDomain.CurrentDomain.BaseDirectory + "/TAS Files";
        if (!Directory.Exists(directory)) return;

        string path = directory + "/polar_active.2tas";
        File.SetAttributes(path, File.GetAttributes(path) & ~FileAttributes.Hidden);
        File.WriteAllText(path, fileText);
        File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden);
    }

    static string GetPlayerText(string fileText, int player) {
        string[] splitFile = fileText.Split(Characters.playerSeperator);
        return splitFile.Length > player ? splitFile[player] : string.Empty;
    }
}