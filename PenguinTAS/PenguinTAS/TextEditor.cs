namespace PenguinTAS {
    public static class TextEditor {
        public static RichTextBox? textBox;

        public static bool HandleCharInput(KeyPressEventArgs e) {
            return false;
        }

        public static bool HandleKeyInput(KeyEventArgs e) {
            return false;
        }
    }
}