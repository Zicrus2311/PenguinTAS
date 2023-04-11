namespace PenguinTAS;

public static class AutoCorrect {
    enum ExpectedChar {
        Number,
        Action,
        Seperator
    }

    // TODO: Check for duplicate and/or exclusive actions!
    public static bool IsValidLine(string lineText) {
        ExpectedChar expectedChar = ExpectedChar.Number;
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
                    if (!Characters.IsAction(character)) {
                        return false;
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
        return true;
    }
}