﻿using System;
using System.Windows;
using System.Windows.Input;

namespace BeierholmWPF.Commands
{
    public class DownloadPDFCmd : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            MessageBox.Show("Downloading PDF");
        }
    }
}
