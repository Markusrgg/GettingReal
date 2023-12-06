﻿using BeierholmWPF.Model;
using BeierholmWPF.Model.EIncomes;
using BeierholmWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BeierholmWPF.Commands
{
    public class ShowEIncomeCmd : ICommand
    {
        private Utility utility = new Utility();

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            bool result = false;
            if (parameter is MainViewModel mvm)
            {
                bool isInt = false;
                if (mvm?.SelectedText != null || mvm?.SelectedText != "")
                {
                    result = true;
                }
                if (mvm?.SelectedStartDate != null && mvm?.SelectedEndDate != null)
                {
                    result = true;
                }
                if (result)
                {
                    if (mvm?.SelectedText != null && mvm?.SelectedText.Length > 0)
                    {
                        isInt = int.TryParse(mvm?.SelectedText, out int value);
                        if (mvm?.SelectedText.Length > 8 && mvm.SelectedBox == "InputEIncome")
                        {
                            result = false;
                            string final = utility.RemovePastMax(mvm.SelectedText);
                            mvm.SelectedText = final;
                            MessageBox.Show("Forkert input! Maks. 8 tal er acceperet.");
                        }
                        if (!isInt)
                        {
                            result = false;
                        }
                    }
                }
            }
            return result;
        }

        public void Execute(object? parameter)
        {
            bool check = false;
            if (parameter is MainViewModel mvm)
            {
                switch (mvm.SelectedBox)
                {
                    case "InputEIncome":
                    case "InputCustomerID":
                        if (mvm?.SelectedStartDate == null || mvm?.SelectedEndDate == null)
                        {
                            if (mvm?.SelectedText != null)
                            {
                                check = mvm.lvm.SetSelectedEIncomes(mvm.SelectedText);
                            }
                        }
                        else if (mvm.SelectedText != null && mvm.SelectedText.Length > 0)
                        {
                            if (mvm.dvm.GetEIncomes(mvm.SelectedText, mvm.SelectedStartDate, mvm.SelectedEndDate).Count <= 1)
                            {
                                check = mvm.dvm.SetDataFields(mvm.SelectedText, mvm.SelectedStartDate, mvm.SelectedEndDate);
                            }
                            else
                            {
                                check = mvm.lvm.SetSelectedEIncomes(mvm.SelectedText, mvm.SelectedStartDate, mvm.SelectedEndDate);
                            }
                        }
                        else
                        {
                            check = mvm.lvm.SetSelectedEIncomes(mvm?.SelectedStartDate, mvm?.SelectedEndDate);
                        }
                        if (!check)
                        {
                            string s = mvm.SelectedBox == "InputEIncome" ? "CVR" : "Kundenr";
                            if (mvm.SelectedText.Length < 8 && s == "CVR")
                            {
                                MessageBox.Show("Et CVR har 8 tal");
                            }
                            else
                            {
                                MessageBox.Show($"{s}: '{mvm.SelectedText}' findes ikke i systemet");
                            }
                        }

                        //mvm.dvm.SetDataFieldsByCustomerID(mvm?.SelectedText, mvm?.SelectedStartDate, mvm?.SelectedEndDate);
                        break;
                    case "InputEndDate":
                    case "InputStartDate":
                        if (mvm.SelectedText == null && mvm.SelectedStartDate != null && mvm.SelectedEndDate != null)
                        {
                            mvm.lvm.SetSelectedEIncomes(mvm.SelectedStartDate, mvm.SelectedEndDate);
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
