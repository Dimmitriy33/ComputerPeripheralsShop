using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace ComputerPeripheralsShop.ViewModels.MenuPagesViewModels
{
    internal class ContactsViewModel
    {
        public ICommand ToForum { get; }

        public ContactsViewModel()
        {
            ToForum = new CommandViewModel(executeToForum);
        }

        private void executeToForum()
        {
            OpenUrl("https://4pda.ru/forum/index.php?showtopic=907116");
        }

        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
