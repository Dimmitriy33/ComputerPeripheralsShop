﻿using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace ComputerPeripheralsShop.ViewModels.MenuPagesViewModels
{
    internal class ProductVerificationViewModel
    {
        public ICommand ToMoreInfoLink { get; }

        public ProductVerificationViewModel()
        {
            ToMoreInfoLink = new CommandViewModel(executeToMoreInfoLink);
        }

        private void executeToMoreInfoLink()
        {
            OpenUrl("https://www.kingston.com/en/company/covid-19-statement");
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