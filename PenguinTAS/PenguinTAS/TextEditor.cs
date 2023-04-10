using static System.Net.Mime.MediaTypeNames;

namespace PenguinTAS {
    public static class TextEditor {
        public static RichTextBox? textBox;

        public static bool HandleCharInput(KeyPressEventArgs e) {
            if (IsNumber(e.KeyChar)) {
                InsertBeforeSelection(e.KeyChar);
            }
            return true;
        }

        public static bool HandleKeyInput(KeyEventArgs e) {
            if (e.KeyCode == Keys.Back) {
                if (textBox.SelectionLength > 0) {
                    DeleteSelection();
                }
                else {
                    DeleteBeforeSelection();
                }
            }
            if (e.KeyCode == Keys.Return) {
                InsertBeforeSelection('\n');
            }
            return true;
        }

        static void InsertBeforeSelection(char text) {
            int selectionStart = textBox.SelectionStart;
            DeleteSelection();
            textBox.Text = textBox.Text.Insert(selectionStart, text.ToString());
            textBox.Select(selectionStart + 1, 0);
        }

        static void DeleteBeforeSelection() {
            int selectionStart = textBox.SelectionStart;
            if (selectionStart == 0) return;
            textBox.Text = textBox.Text.Remove(selectionStart - 1, 1);
            textBox.Select(selectionStart - 1, 0);
        }

        static void DeleteSelection() {
            int selectionStart = textBox.SelectionStart;
            int selectionLength = textBox.SelectionLength;
            textBox.Text = textBox.Text.Remove(selectionStart, selectionLength);
            textBox.Select(selectionStart, 0);
        }

        static void FixSelection() {
            int selectionStart = textBox.SelectionStart;
            int selectionLength = textBox.SelectionLength;
            if (selectionLength > 0) {
                int startLine = textBox.GetLineFromCharIndex(selectionStart);
                int endLine = textBox.GetLineFromCharIndex(selectionStart + selectionLength - 1);
                int startIndex = textBox.GetFirstCharIndexFromLine(startLine);
                int endIndex = textBox.GetFirstCharIndexFromLine(endLine) + textBox.Lines[endLine].Length;
                textBox.SelectionStart = startIndex;
                textBox.SelectionLength = endIndex - startIndex;
            }
            else {
                int line = textBox.GetLineFromCharIndex(selectionStart);
                //textBox.SelectionStart = textBox.GetFirstCharIndexFromLine(line) + OFFSET;
            }
        }

        static bool IsNumber(char character) {
            return character >= '0' && character <= '9';
        }
    }
}