﻿using BeierholmWPF.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeierholmWPF.Model.EIncome
{
    public class EIncomeRepository //26550688
    {
        private string FilePath { get; set; } = Directory.GetCurrentDirectory + "../../../../../Data/";
        public ObservableCollection<EIncome> EIncomes { get; set; } = new ObservableCollection<EIncome>();


        public EIncomeRepository()
        {
            InitializeRepository();
        }

        public void InitializeRepository()
        {
            foreach (FileInfo file in GetAllFiles("*.csv")) //Get only .csv files!
            {
                using (StreamReader read = new StreamReader(FilePath + file.Name)) //The new stuff where it automatically closes read again.
                {
                    if (read != null)
                    {
                        Dictionary<string, double> collectedData = new Dictionary<string, double>();

                        string[] fieldNames = read.ReadLine().Split(";");
                        string[] fieldData = read.ReadLine().Split(";");
                        string[] EIncome = read.ReadLine().Split(";");

                        string fileCVR = fieldData[2];
                        string name = fieldData[4];
                        DateTime periodStart = ConvertFromString(fieldData[5]);
                        DateTime periodEnd = ConvertFromString(fieldData[6]);

                        //Dannet i eIndkomst 2023.11.08 09:23:18
                        string date = EIncome[2].Substring(19, 10); //19, 10 = 2023.11.08
                        string time = EIncome[2].Substring(29, 9); //29, 9 = 09:23:18
                        DateTime createdDate = ConvertFromString(date, time);

                        int temp = 0; //Temp created to get next value for the next field name. 
                        foreach (string field in fieldNames) //The dynamic part!
                        {
                            if (field.Contains("Feltnr"))
                            {
                                string[] split = field.Split(" "); //Collects only the field value e.g "Feltnr 0012" = "0012"
                                int next = 8 + temp; //8 = First "Feltnr" from the file.   temp = next field e.g (8 + 1) = "Feltnr" 9 etc.

                                if (fieldData[next] != null && fieldData[next] != "")
                                {
                                    double data = StringToDouble(fieldData[next]);
                                    collectedData.Add($"{split[1].Replace(" ", "")}", data);
                                }
                                temp++; //Increases to get next value for the specific "Feltnr".
                            }
                        }
                        EIncome income = new EIncome(int.Parse(fileCVR), name, periodStart, periodEnd, createdDate, collectedData);
                        EIncomes.Add(income);
                    }
                }
            }
        }

        private DateTime ConvertFromString(string period)
        {
            int year = StringToInt(period.Substring(0, 4));
            int month = StringToInt(period.Substring(4, 2));

            DateTime datetime = new DateTime(year, month, 1);

            return datetime;
        }

        private DateTime ConvertFromString(string date, string time) //Dannet i eIndkomst 2023.11.08 09:23:18
        {
            string[] split = date.Split(".");
            string[] split2 = time.Split(":");

            int year = StringToInt(split[0]);
            int month = StringToInt(split[1]);
            int day = StringToInt(split[2]);

            int hour = StringToInt(split2[0]);
            int minute = StringToInt(split2[1]);
            int second = StringToInt(split2[2]);

            DateTime dateTime = new DateTime(year, month, day, hour, minute, second);

            return dateTime;
        }

        public FileInfo[] GetAllFiles(string type)
        {
            DirectoryInfo d = new DirectoryInfo(FilePath);

            FileInfo[] files = d.GetFiles(type);

            return files;
        }

        private int StringToInt(string str)
        {
            return int.TryParse(str, out int i) == true ? i : throw new NotIntException("Not an int!");
        }

        private double StringToDouble(string str)
        {
            return double.TryParse(str, out double i) == true ? i : throw new NotDoubleException("Not a double!");
        }
    }
}
