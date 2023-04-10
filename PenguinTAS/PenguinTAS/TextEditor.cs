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
            if (CommentSelected()) {
                InsertBeforeSelection(e.KeyChar.ToString());
                return true;
            }

            char character = e.KeyChar.ToString().ToUpper()[0];
            if (IsNumber(character)) {
                int line = textBox.GetLineFromCharIndex(textBox.SelectionStart);
                if (textBox.Lines[line].Length > 0) {
                    InsertBeforeSelection(character.ToString());
                }
                else {
                    InsertBeforeSelection(character.ToString() + ' ');
                }
            }
            if (allowedLetters.Contains(character)) {
                int line = textBox.GetLineFromCharIndex(textBox.SelectionStart);
                if (textBox.Lines[line].Length > 0) {
                    InsertAtEndOfLine(',' + character.ToString());
                }
            }
            if (character == '#') {
                if (textBox.SelectionStart != 0 && !whitespace.Contains(textBox.Text[textBox.SelectionStart - 1])) {
                    InsertAtEndOfLine("\n#");
                }
                else {
                    InsertAtEndOfLine("#");
                }
            }
            FixSelection();
            return true;
        }

        public static bool HandleKeyInput(KeyEventArgs e) {
            if (e.KeyCode == Keys.Up) {
                int line = textBox.GetLineFromCharIndex(textBox.SelectionStart);
                if (line > 0) {
                    line--;
                    int newIndex = textBox.GetFirstCharIndexFromLine(line);
                    if (e.Control) {
                        while (line > 0 && (textBox.Lines[line].Length == 0 || textBox.Lines[line][0] != '#')) {
                            line--;
                        }
                        newIndex = textBox.GetFirstCharIndexFromLine(line);
                    }
                    if (e.Shift) {
                        textBox.SelectionLength += textBox.SelectionStart - newIndex;
                        textBox.SelectionStart = newIndex;
                    }
                    else {
                        textBox.SelectionLength = 0;
                        textBox.SelectionStart = newIndex;
                    }
                }
            }
            if (e.KeyCode == Keys.Down) {
                int line = textBox.GetLineFromCharIndex(textBox.SelectionStart + textBox.SelectionLength);
                if (line < textBox.Lines.Length - 1) {
                    line++;
                    int newIndex = textBox.GetFirstCharIndexFromLine(line);
                    if (e.Control) {
                        while (line < textBox.Lines.Length - 1 && (textBox.Lines[line].Length == 0 || textBox.Lines[line][0] != '#')) {
                            line++;
                        }
                        newIndex = textBox.GetFirstCharIndexFromLine(line);
                    }
                    if (e.Shift) {
                        textBox.SelectionLength += newIndex - textBox.SelectionStart;
                    }
                    else {
                        textBox.SelectionLength = 0;
                        textBox.SelectionStart = newIndex;
                    }
                }
            }
            if (e.KeyCode == Keys.Back) {
                if (textBox.SelectionLength > 0) {
                    DeleteSelection();
                }
                else {
                    DeleteBeforeSelection();
                }
            }
            if (e.KeyCode == Keys.Delete) {
                DeleteSelectedLine();
            }
            if (e.KeyCode == Keys.Return) {
                InsertAtEndOfLine("\n ");
            }
            FixSelection();
            return true;
        }

        static void InsertAtEndOfLine(string text) {
            int selectionStart = textBox.SelectionStart;
            int line = textBox.GetLineFromCharIndex(selectionStart);
            if (textBox.Lines.Length <= line) return;

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
            if (selectionStart == 0) {
                DeleteSelectedLine();
                return;
            }

            if (IsNumber(textBox.Text[selectionStart - 1])) {
                textBox.Text = textBox.Text.Remove(selectionStart - 1, 1);
                textBox.Select(selectionStart - 1, 0);
            }
            else {
                DeleteSelectedLine();
            }
        }

        static void DeleteSelection() {

            int selectionStart = textBox.SelectionStart;
            int selectionLength = textBox.SelectionLength;
            textBox.Text = textBox.Text.Remove(selectionStart, selectionLength);
            textBox.Select(selectionStart, 0);
        }

        static void DeleteSelectedLine() {
            if (textBox.Text.Length == 0) return;

            int line = textBox.GetLineFromCharIndex(textBox.SelectionStart);
            int lineStart = textBox.GetFirstCharIndexFromLine(line);
            if (textBox.Lines.Length <= line) {
                textBox.Text = textBox.Text.Remove(lineStart - 1, 1);
            }
            else {
                int lineLength = textBox.Lines[line].Length;
                textBox.Text = textBox.Text.Remove(lineStart, Math.Min(lineLength + 1, textBox.Text.Length - lineStart));
            }
            textBox.Select(Math.Max(lineStart - 1, 0), 0);
        }

        static bool CommentSelected() {
            if (textBox.SelectionLength > 0 || textBox.Lines.Length == 0) return false;

            int line = textBox.GetLineFromCharIndex(textBox.SelectionStart);
            return textBox.Lines.Length > line && textBox.Lines[line].Length > 0 && textBox.Lines[line][0] == '#';
        }

        public static void FixSelection() {
            int selectionStart = textBox.SelectionStart;
            int selectionLength = textBox.SelectionLength;
            int line = textBox.GetLineFromCharIndex(selectionStart);
            if (selectionLength > 0) {
                int startLine = textBox.GetLineFromCharIndex(selectionStart);
                int endLine = textBox.GetLineFromCharIndex(selectionStart + selectionLength - 1);
                int startIndex = textBox.GetFirstCharIndexFromLine(startLine);
                int endIndex = textBox.GetFirstCharIndexFromLine(endLine) + textBox.Lines[endLine].Length;
                textBox.SelectionStart = startIndex;
                textBox.SelectionLength = endIndex - startIndex;
            }
            else if (CommentSelected()) {
                int lineStart = textBox.GetFirstCharIndexFromLine(line);
                int lineLength = textBox.Lines[line].Length;
                int lineEnd = lineStart + lineLength;
                textBox.SelectionStart = lineEnd;
            }
            else if (textBox.Lines.Length > line) {
                int lineStart = textBox.GetFirstCharIndexFromLine(line);
                string[] splitLine = textBox.Lines[line].Split(',');
                if (splitLine.Length > 0) {
                    textBox.SelectionStart = lineStart + splitLine[0].Trim().Length;
                }
            }
        }

        static bool IsNumber(char character) {
            return character >= '0' && character <= '9';
        }
    }
}