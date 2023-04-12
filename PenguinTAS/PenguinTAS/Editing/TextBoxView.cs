using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PenguinTAS;

public static class TextBoxView {
    enum ScrollBarType : uint {
        SbHorz = 0,
        SbVert = 1,
        SbCtl = 2,
        SbBoth = 3
    }

    enum Message : uint {
        WM_VSCROLL = 0x0115
    }

    enum ScrollBarCommands : uint {
        SB_THUMBPOSITION = 4
    }

    public static void SyncZoom(RichTextBox textBox) {
        foreach (var box in PenguinTAS.TextBoxes) {
            box.ZoomFactor = textBox.ZoomFactor;
        }
    }

    public static void SyncScroll(RichTextBox textBox) {
        int scroll = GetScroll(textBox);
        foreach (var box in PenguinTAS.TextBoxes) {
            if (box == textBox || GetScroll(box) == scroll) continue;

            SetScroll(box, scroll);
        }
    }

    public static int GetScroll(RichTextBox textBox) {
        return GetScrollPos(textBox.Handle, (int)ScrollBarType.SbVert) << 16;
    }

    public static void SetScroll(RichTextBox textBox, int scroll) {
        uint wParam = (uint)ScrollBarCommands.SB_THUMBPOSITION | (uint)scroll;
        _ = SendMessage(textBox.Handle, (int)Message.WM_VSCROLL, new IntPtr(wParam), new IntPtr(0));
    }

    [DllImport("User32.dll")]
    extern static int GetScrollPos(IntPtr hWnd, int nBar);

    [DllImport("User32.dll")]
    extern static int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
}