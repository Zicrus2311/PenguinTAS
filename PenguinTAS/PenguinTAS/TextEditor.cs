using static System.Net.Mime.MediaTypeNames;

namespace PenguinTAS {
    public static class TextEditor {
        public static RichTextBox? textBox;

        static readonly char[] allowedLetters = {
            'W',
            'A',
            'S',
            'D'
        };

        static readonly char[] whitespace = {
            ' ',
            '\n'
        };

        public static bool HandleCharInput(KeyPressEventArgs e) {
            char character = e.KeyChar.ToString().ToUpper()[0];
            if (IsNumber(character)) {
                InsertBeforeSelection(character.ToString());
            }
            if (allowedLetters.Contains(character)) {
                InsertBeforeSelection(character.ToString());
            }
            if (character == '#') {
                if (textBox.SelectionStart != 0 && !whitespace.Contains(textBox.Text[textBox.SelectionStart - 1])) {
                    InsertAtEndOfLine("\n#");
                }
                else {
                    InsertAtEndOfLine("#");
                }
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
                InsertAtEndOfLine("\n");
            }
            return true;
        }

        static void InsertAtEndOfLine(string text) {
            int selectionStart = textBox.SelectionStart;
            int line = textBox.GetLineFromCharIndex(selectionStart);
            int lineStart = textBox.GetFirstCharIndexFromLine(line);
            int lineLength = textBox.Lines[line].Length;
            int lineEnd = lineStart + lineLength;

            textBox.Text = textBox.Text.Insert(lineEnd, text);
            textBox.Select(lineEnd + text.Length, 0);
        }

        static void InsertBeforeSelection(string text) {
            int selectionStart = textBox.SelectionStart;
            DeleteSelection();
            textBox.Text = textBox.Text.Insert(selectionStart, text.ToString());
            textBox.Select(selectionStart + text.Length, 0);
        }

        static void DeleteBeforeSelection() {
            int selectionStart = textBox.SelectionStart;
            if (selectionStart == 0) return;

            if (IsNumber(textBox.Text[selectionStart - 1])) {
                textBox.Text = textBox.Text.Remove(selectionStart - 1, 1);
                textBox.Select(selectionStart - 1, 0);
            }
            else {
                int line = textBox.GetLineFromCharIndex(selectionStart);
                int lineStart = textBox.GetFirstCharIndexFromLine(line);
                int lineLength = textBox.Lines[line].Length;
                textBox.Text = textBox.Text.Remove(lineStart, Math.Min(lineLength + 1, textBox.Text.Length - lineStart));
                textBox.Select(Math.Max(lineStart - 1, 0), 0);
            }
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
                int lineStart = textBox.GetFirstCharIndexFromLine(line);
                //textBox.SelectionStart = lineStart + OFFSET;
            }
        }

        static bool IsNumber(char character) {
            return character >= '0' && character <= '9';
        }
    }
}