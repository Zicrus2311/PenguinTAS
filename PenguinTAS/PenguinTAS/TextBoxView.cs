using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PenguinTAS;

public static class TextBoxView {
    public enum ScrollBarType : uint {
        SbHorz = 0,
        SbVert = 1,
        SbCtl = 2,
        SbBoth = 3
    }

    public enum Message : uint {
        WM_VSCROLL = 0x0115
    }

    public enum ScrollBarCommands : uint {
        SB_THUMBPOSITION = 4
    }

    public static void SyncZoom(RichTextBox textBox) {
        foreach (var box in PenguinTAS.TextBoxes) {
            box.ZoomFactor = textBox.ZoomFactor;
        }
    }

    public static void SyncScroll(RichTextBox textBox) {
        int scrollPos = GetScrollPos(textBox.Handle, (int)ScrollBarType.SbVert) << 16;
        uint wParam = (uint)ScrollBarCommands.SB_THUMBPOSITION | (uint)scrollPos;
        foreach (var box in PenguinTAS.TextBoxes) {
            if (box == textBox) continue;

            _ = SendMessage(box.Handle, (int)Message.WM_VSCROLL, new IntPtr(wParam), new IntPtr(0));
        }
    }

    [DllImport("User32.dll")]
    public extern static int GetScrollPos(IntPtr hWnd, int nBar);

    [DllImport("User32.dll")]
    public extern static int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
}