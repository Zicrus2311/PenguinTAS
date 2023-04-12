using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PenguinTAS;

public static class RTBExtensions {

    public static void ScrollToCharPosition(this RichTextBox rtb, Int32 charPosition) {
        const Int32 WM_USER = 0x400;
        const Int32 EM_GETOLEINTERFACE = WM_USER + 60;
        const Int32 tomStart = 32;

        if (charPosition < 0 || charPosition > rtb.TextLength - 1) {
            throw new ArgumentOutOfRangeException(nameof(charPosition), $"{nameof(charPosition)} must be in the range of 0 to {rtb.TextLength - 1}.");
        }

        // retrieve the rtb's OLEINTERFACE and use the Interop Marshaller to cast it as an ITextDocument
        // The control calls the AddRef method for the object before returning, so the calling application must call the Release method when it is done with the object.
        ITextDocument doc = null;
        SendMessage(new HandleRef(rtb, rtb.Handle), EM_GETOLEINTERFACE, IntPtr.Zero, ref doc);
        ITextRange rng = null;
        if (doc != null) {
            try {
                rng = (RTBExtensions.ITextRange)doc.Range(charPosition, charPosition);
                rng.ScrollIntoView(tomStart);
            }
            finally {
                if (rng != null) {
                    Marshal.ReleaseComObject(rng);
                }
                Marshal.ReleaseComObject(doc);
            }
        }
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private extern static IntPtr SendMessage(HandleRef hWnd, Int32 msg, IntPtr wParam, ref ITextDocument lParam);

    [ComImport, Guid("8CC497C0-A1DF-11CE-8098-00AA0047BE5D")]
    private interface ITextDocument {
        [MethodImpl((short)0, MethodCodeType = MethodCodeType.Runtime)]
        void _VtblGap1_17();
        [return: MarshalAs(UnmanagedType.Interface)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(15)]
        ITextRange Range([In] int cp1, [In] int cp2);
    }

    [ComImport, Guid("8CC497C2-A1DF-11CE-8098-00AA0047BE5D")]
    private interface ITextRange {
        [MethodImpl((short)0, MethodCodeType = MethodCodeType.Runtime)]
        void _VtblGap1_49();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x242)]
        void ScrollIntoView([In] int Value);
    }
}