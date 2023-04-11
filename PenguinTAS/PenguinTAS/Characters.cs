namespace PenguinTAS;

public static class Characters {
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

    public static bool IsAction(char character) {
        char upperChar = UpperCase(character);
        return actions.Contains(upperChar);
    }

    public static bool IsWhitespace(char character) {
        char upperChar = UpperCase(character);
        return whitespace.Contains(upperChar);
    }

    public static bool IsCommentStart(char character) {
        char upperChar = UpperCase(character);
        return comment.Contains(upperChar);
    }

    public static bool IsInfoStart(char character) {
        char upperChar = UpperCase(character);
        return info.Contains(upperChar);
    }

    public static bool IsNumber(char character) {
        return character >= '0' && character <= '9';
    }

    public static char UpperCase(char character) {
        return character.ToString().ToUpper()[0];
    }
}