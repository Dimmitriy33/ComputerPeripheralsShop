﻿using ComputerPeripheralsShop.Database;
using ComputerPeripheralsShop.Models.DataAccess;
using ComputerPeripheralsShop.ViewModels.Base;
using ComputerPeripheralsShopModel.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ComputerPeripheralsShopModel.ViewModels.MenuPagesViewModels
{
    internal class MicrophonesViewModel : ViewModel
    {

        private ObservableCollection<Product> _microphones;
        public ObservableCollection<Product> Microphones { get => this._microphones; set => this._microphones = value; }

        public ICommand Info_Button { get; }

        public MicrophonesViewModel()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                Microphones = unitOfWork.ProductRepository.getMicrophones();
            }
            Info_Button = new RelayCommand(executeInfo);
        }

        private void executeInfo(object obj)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "Views/Pages/", "Product", ".xaml"), UriKind.RelativeOrAbsolute));
                    using (UnitOfWork context = new UnitOfWork())
                    {
                        ComputerPeripheralsShop.Models.CurrentProduct.currentProduct = context.ProductRepository.GetProductById((int)obj);
                    }
                }
            }
        }
    }
}
