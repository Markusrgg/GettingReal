﻿using BeierholmWPF.Commands;
using BeierholmWPF.Model.EIncome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace BeierholmWPF.ViewModel
{
    public class ListViewModel
    {
        private EIncomeRepository incomeRepository = new EIncomeRepository();
        //  private FileManager manager = new FileManager(Directory.GetCurrentDirectory + "../../../../../Data/");

        public ObservableCollection<EIncomeViewModel> SelectedEIncomes { get; set; } = new ObservableCollection<EIncomeViewModel>();
        public ObservableCollection<EIncomeViewModel> EIncomes { get; set; } = new ObservableCollection<EIncomeViewModel>();

        public EIncomeViewModel SelectedItem { get; set; }

        public ListViewModel()
        {
            foreach (EIncome eIncome in incomeRepository.EIncomes)
            {
                EIncomes.Add(new EIncomeViewModel(eIncome));
            }
        }

        public void SetSelectedEIncomes(string CVR) //26550688
        {
            SelectedEIncomes.Clear();
            foreach (EIncomeViewModel evm in EIncomes)
            {
                if (evm.CVR == int.Parse(CVR))
                {
                    SelectedEIncomes.Add(evm);
                }
            }
        }

        public void SetSelectedEIncomes(string CVR, DateTime? startDate, DateTime? endDate)
        {
            SelectedEIncomes.Clear();
            foreach (EIncomeViewModel evm in EIncomes)
            {
                if (int.Parse(CVR) == evm.CVR && startDate <= evm.PeriodStart && endDate >= evm.PeriodEnd)
                {
                    SelectedEIncomes.Add(evm);
                }
            }
        }

        public void SetSelectedEIncomes(DateTime? startDate, DateTime? endDate)
        {
            SelectedEIncomes.Clear();
            foreach (EIncomeViewModel evm in EIncomes)
            {
                if (startDate <= evm.PeriodStart && endDate >= evm.PeriodEnd)
                {
                    SelectedEIncomes.Add(evm);
                }
            }
        }

        public ICommand ShowEIncomeData { get; set; } = new ShowEIncomeDataCmd();
    }
}
