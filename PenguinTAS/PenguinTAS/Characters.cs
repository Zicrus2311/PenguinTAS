namespace PenguinTAS;

public static class Characters {
    public const char numberSeperator = ' ';
    public const char actionSeperator = ',';

    static readonly char[] actions = {
        'W',
        'A',
        'S',
        'D'
    };

    static readonly char[] whitespace = {
        ' ',
        '\n'
    };

    static readonly char[] comment = {
        '#'
    };

    static readonly char[] info = {
        '@'
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

    public static bool IsCommentStart(RichTextBox textBox, int index) {
        return textBox.Text.Length > index && IsCommentStart(textBox.Text[index]);
    }

    public static bool IsCommentStart(char character) {
        char upperChar = UpperCase(character);
        return comment.Contains(upperChar);
    }

    public static bool IsInfoStart(RichTextBox textBox, int index) {
        return textBox.Text.Length > index && IsInfoStart(textBox.Text[index]);
    }

    public static bool IsInfoStart(char character) {
        char upperChar = UpperCase(character);
        return info.Contains(upperChar);
    }

    public static bool IsNumber(RichTextBox textBox, int index) {
        return textBox.Text.Length > index && IsNumber(textBox.Text[index]);
    }

    public static bool IsNumber(char character) {
        return character >= '0' && character <= '9';
    }

    public static char UpperCase(char character) {
        return character.ToString().ToUpper()[0];
    }
}