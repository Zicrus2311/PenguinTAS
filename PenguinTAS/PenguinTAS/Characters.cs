namespace PenguinTAS;

public static class Characters {
    public const char playerSeperator = '|';
    public const char numberSeperator = ' ';
    public const char actionSeperator = ',';
    public const char commentStart = '#';

    static readonly char[] actions = {
        'W', 'A', 'S', 'D'
    };

    static readonly char[] whitespace = {
        ' ', '\n'
    };

    static readonly char[] commentSpecialChars = {
        ' ', '.', ',', ':', ';', '!', '?', '\'', '"', '&', '_',
        '(', ')', '-', '+', '/', '*', '=', '%', '<', '>', '~'
    };

    public static bool IsAction(RichTextBox textBox, int index) {
        return textBox.Text.Length > index && IsAction(textBox.Text[index]);
    }

    public static bool IsAction(char character) {
        char upperChar = UpperCase(character);
        return actions.Contains(upperChar);
    }

    public static bool IsWhitespace(RichTextBox textBox, int index) {
        return textBox.Text.Length > index && IsWhitespace(textBox.Text[index]);
    }

    public static bool IsWhitespace(char character) {
        char upperChar = UpperCase(character);
        return whitespace.Contains(upperChar);
    }

    public static bool IsNumber(RichTextBox textBox, int index) {
        return textBox.Text.Length > index && IsNumber(textBox.Text[index]);
    }

    public static bool IsNumber(char character) {
        return character >= '0' && character <= '9';
    }

    public static bool IsAllowedInComments(char character) {
        return IsLetter(character) || IsNumber(character) || commentSpecialChars.Contains(character);
    }

    public static char UpperCase(char character) {
        return character.ToString().ToUpper()[0];
    }

    static bool IsLetter(char character) {
        return UpperCase(character) >= 'A' && UpperCase(character) <= 'Z';
    }
}