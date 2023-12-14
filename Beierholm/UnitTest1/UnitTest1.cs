using BeierholmWPF.Model;
using BeierholmWPF.Model.Customers;
using BeierholmWPF.Model.EIncomes;
using BeierholmWPF.Model.Exceptions;

namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        Customer cu1, cu2, cu3;

        FileManager fileManager;

        CustomerRepository customerRepository;

        [TestInitialize]
        public void testInit() // ARRANGE
        {
            cu1 = new Customer("VAULT", 0, 15362735, BeierholmWPF.Model.Enums.BusinessType.ApS);
            cu2 = new Customer("Sharks", 1, 56473826, BeierholmWPF.Model.Enums.BusinessType.ApS);
            cu3 = new Customer("Beierholm", 2, 75837286, BeierholmWPF.Model.Enums.BusinessType.ApS);

            customerRepository = new CustomerRepository();
        }

        [TestMethod]
        public void TestAddAndRemoveCustomerFromRepository()
        {
            // ACT
            customerRepository.AddCustomer(cu1);
            customerRepository.AddCustomer(cu2);
            customerRepository.AddCustomer(cu3);

            customerRepository.RemoveCostumer(cu2);

            // ASSERT
            Assert.AreEqual(2, customerRepository.GetCustomers().Count());
        }

        [TestMethod]
        public void TestAddingEIncomesToCustomer()
        {
            // ARRANGE
            EIncome eIncome = new EIncome(15362735, "VAULT", new DateTime(), new DateTime(), new DateTime(), null);
            EIncome eIncome2 = new EIncome(15362735, "VAULT", new DateTime(), new DateTime(), new DateTime(), null);

            // ACT
            customerRepository.AddCustomerEIncome(cu1, eIncome);
            customerRepository.AddCustomerEIncome(cu1, eIncome2);

            // ASSERT
            Assert.AreEqual(2, cu1.EIncomes.Count());
        }

        [TestMethod]
        public void TestAddingEIncomesToCustomer2()
        {
            // ARRANGE
            EIncome eIncome = new EIncome(15362735, "VAULT", new DateTime(), new DateTime(), new DateTime(), null);
            EIncome eIncome2 = new EIncome(15362735, "VAULT", new DateTime(), new DateTime(), new DateTime(), null);
            EIncome eIncome3 = new EIncome(68574638, "Sharks", new DateTime(), new DateTime(), new DateTime(), null);

            // ACT
            customerRepository.AddCustomerEIncome(cu1, eIncome);
            customerRepository.AddCustomerEIncome(cu2, eIncome3);
            customerRepository.AddCustomerEIncome(cu1, eIncome2);

            // ASSERT
            Assert.AreEqual(1, cu2.EIncomes.Count());
        }

        [TestMethod]
        public void TestFileManagerInitialize()
        {
            // ARRANGE
            fileManager = new FileManager();

            // ASSERT
            Assert.AreEqual(9, fileManager.EIncomeRepository.GetEIncomes().Count());
        }

        [TestMethod]
        public void TestInitializeFileManagerAndAddNewEIncome()
        {
            // ARRANGE
            fileManager = new FileManager();

            // ACT
            fileManager.EIncomeRepository.AddEIncome(new EIncome(37362736));

            // ASSERT
            Assert.AreEqual(10, fileManager.EIncomeRepository.GetEIncomes().Count());
        }

        [TestMethod]
        public void TestReadFieldNumbersFromFile1()
        {
            // ARRANGE
            fileManager = new FileManager();

            // ACT
            double value = 0;

            /* Dokumentere at det er vigtigt at implentere denne logik i
                vores unit test da vi ikke har den i vores kode,
                da det er vigtig at teste om den læser de rigtige data fra filerne */

            foreach (EIncome income in fileManager.EIncomeRepository.GetEIncomes())
            {
                if (income.CVR == 26550688)
                {
                    if (new DateTime(2022, 10, 14) <= income.PeriodStart && new DateTime(2023, 10, 14) >= income.PeriodEnd)
                    {
                        income.Fields.TryGetValue("0015", out value);
                    }
                }
            }

            // ASSERT
            Assert.AreEqual(356267.00, value);
        }

        [TestMethod]
        public void TestReadFieldNumbersFromFile2()
        {
            // ARRANGE
            fileManager = new FileManager();

            // ACT
            double value = 0;

            /* Dokumentere at det er vigtigt at implentere denne logik i
               vores unit test da vi ikke har den i vores kode,
               da det er vigtig at teste om den læser de rigtige data fra filerne */

            foreach (EIncome income in fileManager.EIncomeRepository.GetEIncomes()) 
            {
                if (income.CVR == 36508213)
                {
                    if (new DateTime(2022, 12, 14) <= income.PeriodStart && new DateTime(2023, 10, 14) >= income.PeriodEnd)
                    {
                        income.Fields.TryGetValue("0013", out value);
                    }
                }
            }

            // ASSERT
            Assert.AreEqual(525066.26, value);
        }

        [TestMethod]
        [ExpectedException(typeof(NotDoubleException))] // ASSERT
        public void TestThrowNotDoubleExceptionWhenEnterLetter()
        {
            Utility utility = new Utility(); // ARRANGE

            utility.StringToDouble("k"); // ACT
        }

        [TestMethod]
        [ExpectedException(typeof(NotIntException))] // ASSERT
        public void TestNotIntExceptionWhenEnterDoubleValue()
        {
            Utility utility = new Utility(); // ARRANGE

            utility.StringToInt("23.1"); // ACT
        }

        [TestMethod]
        [ExpectedException(typeof(NotIntException))] // ASSERT
        public void TestNotIntExceptionWhenEnterLetter()
        {
            Utility utility = new Utility(); // ARRANGE

            utility.StringToInt("fe"); // ACT
        }
    }
}