using BeierholmWPF.Model.Customers;
using BeierholmWPF.Model.Enums;
using System;
using System.Collections.Generic;
using System.IO;

namespace BeierholmWPF.Model.EIncomes
{
    public class FileManager
    {
        public Utility utility = new Utility();
        public EIncomeRepository EIncomeRepository = new EIncomeRepository();
        public CustomerRepository CustomerRepository = new CustomerRepository();
        private string FilePath { get; set; } = Directory.GetCurrentDirectory + "../../../../../Data/";

        public FileManager()
        {
            InitializeRepository();
        }

        public void InitializeRepository()
        {
            int costumerID = 0;
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
                                    double data = utility.StringToDouble(fieldData[next]);
                                    collectedData.Add($"{split[1]}", data);
                                }
                                temp++; //Increases to get next value for the specific "Feltnr".
                            }
                        }
                        EIncome income = new EIncome(int.Parse(fileCVR), name, periodStart, periodEnd, createdDate, collectedData);
                        EIncomeRepository.AddEIncome(income);

                        Customer c = CustomerRepository.GetCustomers().Find(x => x.CVR == utility.StringToInt(fileCVR));

                        if (c == null)
                        {
                            Customer costumer = new Customer(name, costumerID, int.Parse(fileCVR), BusinessType.ApS);

                            CustomerRepository.AddCustomer(costumer);
                            CustomerRepository.AddCustomerEIncome(costumer, income);
                            costumerID++;
                        }
                        else
                        {
                            CustomerRepository.AddCustomerEIncome(c, income);
                        }
                    }
                }
            }
        }

        private DateTime ConvertFromString(string period)
        {
            int year = utility.StringToInt(period.Substring(0, 4));
            int month = utility.StringToInt(period.Substring(4, 2));

            DateTime datetime = new DateTime(year, month, 1);

            return datetime;
        }

        private DateTime ConvertFromString(string date, string time) //Dannet i eIndkomst 2023.11.08 09:23:18
        {
            string[] split = date.Split(".");
            string[] split2 = time.Split(":");

            int year = utility.StringToInt(split[0]);
            int month = utility.StringToInt(split[1]);
            int day = utility.StringToInt(split[2]);

            int hour = utility.StringToInt(split2[0]);
            int minute = utility.StringToInt(split2[1]);
            int second = utility.StringToInt(split2[2]);

            DateTime dateTime = new DateTime(year, month, day, hour, minute, second);

            return dateTime;
        }

        private FileInfo[] GetAllFiles(string type)
        {
            DirectoryInfo d = new DirectoryInfo(FilePath);

            FileInfo[] files = d.GetFiles(type);

            return files;
        }
    }
}
