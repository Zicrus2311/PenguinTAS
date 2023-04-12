namespace PenguinTAS;

public static class AutoCorrect {
    enum ExpectedChar {
        Number,
        Action,
        Seperator
    }

    public static void Correct(RichTextBox textBox) {

    }

    public static void CorrectLine(RichTextBox textBox, int line) {

    }

    // TODO: Check for exclusive actions!
    public static bool IsValidLine(string lineText) {
        ExpectedChar expectedChar = ExpectedChar.Number;
        List<char> actions = new();
        foreach (var character in lineText) {
            switch (expectedChar) {
                case ExpectedChar.Number:
                    if (character == Characters.numberSeperator) {
                        expectedChar = ExpectedChar.Action;
                        continue;
                    }
                    else if (!Characters.IsNumber(character)) {
                        return false;
                    }
                    break;
                case ExpectedChar.Action:
                    if (!Characters.IsAction(character) || actions.Contains(character)) {
                        return false;
                    }
                    else {
                        actions.Add(character);
                    }
                    expectedChar = ExpectedChar.Seperator;
                    break;
                case ExpectedChar.Seperator:
                    if (character != Characters.actionSeperator) {
                        return false;
                    }
                    expectedChar = ExpectedChar.Action;
                    break;
            }
        }
        return (actions.Count == 0 && expectedChar == ExpectedChar.Number) ||
               (actions.Count > 0 && expectedChar == ExpectedChar.Seperator);
    }
}