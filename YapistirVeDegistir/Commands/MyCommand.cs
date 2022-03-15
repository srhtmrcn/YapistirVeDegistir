using Community.VisualStudio.Toolkit;
using Microsoft.VisualStudio.Shell;
using System.Linq;
using System.Windows;
using Task = System.Threading.Tasks.Task;

namespace YapistirVeDegistir
{
    [Command(PackageIds.MyCommand)]
    internal sealed class MyCommand : BaseCommand<MyCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            var d = await VS.Documents.GetActiveDocumentViewAsync();
            var sel = d?.TextView.Selection.SelectedSpans.FirstOrDefault();
            var cB = Clipboard.GetText();
            if (sel.HasValue && !string.IsNullOrEmpty(cB))
            {
                cB = cB.Replace("*", sel.Value.GetText());
                d.TextBuffer.Replace(sel.Value, cB);
            }
        }
    }
}
