namespace PenguinTAS {
    public static class Characters {
        public static readonly char[] actions = {
            'W',
            'A',
            'S',
            'D'
        };

        public static readonly char[] whitespace = {
            ' ',
            '\n'
        };

        public static readonly char[] comment = {
            '#'
        };

        public static readonly char[] info = {
            '@'
        };

        public static bool IsNumber(char character) {
            return character >= '0' && character <= '9';
        }
    }
}