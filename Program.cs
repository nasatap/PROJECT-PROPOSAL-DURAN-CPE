using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;



namespace ProjectProposal_test1
{
    internal class Program
    {
        static List<HomeOwner> homeownersList = new List<HomeOwner>();
        static List<Visitor> visitorsList = new List<Visitor>();
        static List<AdminUpdate> adminUpdateList = new List<AdminUpdate>();
        static List<ReceiptUpdate> receiptUpdateList = new List<ReceiptUpdate>();
        static string homeownersFilePath = @"C:\DURAN CODINH\CODING\proposal.csv";
        static string visitorsFilePath = @"C:\DURAN CODINH\CODING\visitors.csv";
        static string receiptFilePath = @"C:\DURAN CODINH\CODING\receipts.csv";
        static string adminFilePath = @"C:\DURAN CODINH\CODING\admin.csv";
        static string mainMenu = @"C:\DURAN CODINH\CODING\main menu.txt";
        static string titlePage = @"C:\DURAN CODINH\CODING\title.txt";

        static void Main(string[] args)
        {
            try
            {
                using (StreamReader reader = new StreamReader(titlePage))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fail");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            LoadData();

            bool go = true;
            while (go)
            {
                try
                {
                    using (StreamReader reader = new StreamReader(mainMenu))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fail");
                }


                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.Clear();
                    switch (choice)
                    {
                        case 1:
                            Console.Write("╔════════════════════════════════════════════════════════════════════════════════╗\r\n║                                1. Add Homeowner        \t\t\t\t\t\t\t\t\t\t\t \r\n╚════════════════════════════════════════════════════════════════════════════════╝\r\n\r\n╔════════════════════════════════════════════════════════════════════════════════╗\r\n║                                2. Add Visitor            \t\t\t\t\t\t\t\t\t\t\t \r\n╚════════════════════════════════════════════════════════════════════════════════╝\r\n\r\n╔════════════════════════════════════════════════════════════════════════════════╗\r\n║                                3. Back to Main Menu            \t\t\t\t\t\t\t\t\t\t\t \r\n╚════════════════════════════════════════════════════════════════════════════════╝\n");

                            if (int.TryParse(Console.ReadLine(), out int choice1)&& choice1 >= 1 && choice1 <= 3)
                            {
                                switch (choice1)
                                {
                                    case 1:
                                        AddHomeowner();
                                        SaveData(homeownersFilePath, visitorsFilePath, adminFilePath, receiptFilePath);
                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    case 2:
                                        AddVisitor();
                                        SaveData(homeownersFilePath, visitorsFilePath, adminFilePath, receiptFilePath);
                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    case 3:
                                        Console.Clear();
                                        break;
                                }

                            }
                            else
                            {
                                Console.WriteLine("Invalid Choice. Back to Main Menu. Press any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 2:
                            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════╗\r\n║                                1. View Homeowner List        \t\t\t\t\t\t\t\t\t\t\t \r\n╚════════════════════════════════════════════════════════════════════════════════╝\r\n\r\n╔════════════════════════════════════════════════════════════════════════════════╗\r\n║                                2. View Visitor List           \t\t\t\t\t\t\t\t\t\t\t \r\n╚════════════════════════════════════════════════════════════════════════════════╝\r\n\r\n╔════════════════════════════════════════════════════════════════════════════════╗\r\n║                                3. View Receipt List           \t\t\t\t\t\t\t\t\t\t\t \r\n╚════════════════════════════════════════════════════════════════════════════════╝\r\n\r\n╔════════════════════════════════════════════════════════════════════════════════╗\r\n║                                4. View Admin History Update          \t\t\t\t\t\t\t\t\t\t\t \r\n╚════════════════════════════════════════════════════════════════════════════════╝\r\n\r\n╔════════════════════════════════════════════════════════════════════════════════╗\r\n║                                5. Back to Main Menu          \t\t\t\t\t\t\t\t\t\t\t \r\n╚════════════════════════════════════════════════════════════════════════════════╝");
                            if (int.TryParse(Console.ReadLine(), out int choice2)&& choice2 >= 1 && choice2 <= 5)
                            {
                                switch (choice2)
                                {
                                    case 1:
                                        ViewHomeowners();
                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    case 2:
                                        ViewVisitors();
                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    case 3:
                                        ViewReceiptList();
                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    case 4:
                                        AdminUpdate();
                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    case 5:
                                        Console.Clear();
                                        break;

                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Choice. Back to Main Menu. Press any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 3:
                            if (homeownersList.Count > 0)
                            {
                                AdminMod();
                                SaveData(homeownersFilePath, visitorsFilePath, adminFilePath, receiptFilePath);
                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("No homeowners in the list");
                                Console.WriteLine("Press any key to return to the menu...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 4:
                            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════╗\r\n║                                1. Make Payment    \t\t\t\t\t\t\t\t\t\t\t \r\n╚════════════════════════════════════════════════════════════════════════════════╝\r\n\r\n╔════════════════════════════════════════════════════════════════════════════════╗\r\n║                                2. Add Payment needed to specific Homeowner          \t\t\t\t \r\n╚════════════════════════════════════════════════════════════════════════════════╝\r\n\r\n╔════════════════════════════════════════════════════════════════════════════════╗\r\n║                                3. Back to Main Menu     \t\t\t\t\t\t\t\t\t\t\t \r\n╚════════════════════════════════════════════════════════════════════════════════╝");
                            if (int.TryParse(Console.ReadLine(), out int choice5)&& choice5 >= 1 && choice5 <= 3)
                            {
                                switch (choice5)
                                {
                                    case 1:
                                        HomeownerPayment();
                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    case 2:
                                        AddHomeownerPayment();
                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    case 3:
                                        Console.Clear();
                                        break;
                                }

                            }
                            else
                            {
                                Console.WriteLine("Invalid Choice. Back to Main Menu. Press any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 5:
                            SearchHomeowner();
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 6:
                            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════╗\r\n║                                1. Remove something from List       \t\t\t\t\t\t\t\t\t\t\t \r\n╚════════════════════════════════════════════════════════════════════════════════╝\r\n\r\n╔════════════════════════════════════════════════════════════════════════════════╗\r\n║                                2. Delete all data in List           \t\t\t\t\t\t\t\t\t\t\t \r\n╚════════════════════════════════════════════════════════════════════════════════╝\r\n\r\n╔════════════════════════════════════════════════════════════════════════════════╗\r\n║                                3. Exit       \t\t\t\t\t\t\t\t\t\t\t \r\n╚════════════════════════════════════════════════════════════════════════════════╝");

                            if (int.TryParse(Console.ReadLine(), out int choice3) && choice3 >= 1 && choice3 <= 3)
                            {
                                switch (choice3)
                                {
                                    case 1:
                                        RemoveFromList();
                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    case 2:
                                        DeleteAllData();
                                        Console.Clear();
                                        break;
                                    case 3:
                                        Console.Clear();
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Choice. Back to Main Menu. Press any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 7:
                            go = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Press any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Put numbers only. Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }

            }
            //failsafe
            SaveData(homeownersFilePath, visitorsFilePath, adminFilePath, receiptFilePath);
        }

        static void AddHomeowner()
        {
            string name;
            while (true)
            {
                Console.Write("Enter Homeowner Name: ");
                name = Console.ReadLine();

                bool nameExist = false;

                foreach (var nameHO in homeownersList)
                {
                    if (nameHO.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("The name already exists inside the association");
                        nameExist = true;
                        break;
                    }
                }
                if (!nameExist)
                {
                    break;
                }

            }
            int blockNum;
            while (true)
            {
                Console.Write("Enter Block Number: ");
                if (int.TryParse(Console.ReadLine(), out blockNum) && blockNum >0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid block number");
                }
            }

            int lotNum;

            while (true)
            {
                Console.Write("Enter Lot Number: ");
                if (!int.TryParse(Console.ReadLine(), out lotNum) || lotNum <= 0)
                {
                    Console.WriteLine("Invalid lot number.");
                    continue;
                }

                bool lotExist = false;
                foreach (var nameHO in homeownersList)
                {
                    if (nameHO.BlockNo == blockNum && nameHO.LotNo == lotNum)
                    {
                        Console.WriteLine("The lot number already exists inside the association");
                        lotExist = true;
                        break;
                    }
                }
                if (!lotExist)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter different Lot number");
                }

            }

            decimal debt;

            while (true)
            {
                Console.Write("Enter Initial Payment: ");
                if (decimal.TryParse(Console.ReadLine(), out debt) && debt >= 0)
                {
                    HomeOwner homeowner = new HomeOwner(name, blockNum, lotNum, debt);
                    homeownersList.Add(homeowner);
                    Console.WriteLine("Homeowner added successfully");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid amount. Enter a positive amount (You can input 0)");
                }
            }

        }
        static void AddVisitor()
        {
            DateTime datenow = DateTime.Now;
            Console.Write("Enter Visitor Name: ");
            string name1 = Console.ReadLine();
            int blockNum;
            while (true)
            {
                Console.Write("Enter Block Number to visit: ");
                if (int.TryParse(Console.ReadLine(), out blockNum) && blockNum > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid block number");
                }
            }

            int lotNum;

            while (true)
            {
                Console.Write("Enter Lot Number to visit: ");
                if (int.TryParse(Console.ReadLine(), out lotNum) && lotNum > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid lot number");
                }
            }
            Console.Write("Enter Purpose of Visit: ");
            string purpose = Console.ReadLine();

            Visitor visitor = new Visitor(name1, blockNum, lotNum, purpose, datenow);
            visitorsList.Add(visitor);
            Console.WriteLine("Visitor added successfully");//okay na
        }
        static void ViewHomeowners()
        {
            Console.WriteLine("\nList of Homeowners:");
            if (homeownersList.Count > 0)
            {
                foreach (var homeowner in homeownersList)
                {
                    homeowner.DisplayInfo();
                }
            }
            else
            {
                Console.WriteLine("No homeowners entered the subdivision");
            }
        }

        static void ViewVisitors()
        {
            visitorsList.Reverse();
            Console.WriteLine("\nList of Visitors:");
            if (visitorsList.Count > 0)
            {
                foreach (var visitor in visitorsList)
                {
                    visitor.DisplayInfo();
                }
            }
            else
            {
                Console.WriteLine("No visitors entered the subdivision");
            }
        }

        static void AdminMod()
        {
            try
            {
                Admin admin = new Admin();
                Console.Write("Enter Admin Username: ");
                string username = Console.ReadLine();
                Console.Write("Enter Admin Password: ");
                string password = Console.ReadLine();
                DateTime datenow = DateTime.Now;
                if (admin.CheckAdmin(username, password))
                {
                    Console.Write("What will be the name for the payment? ");
                    string paymentName = Console.ReadLine();
                    decimal totalCost;

                    while (true)
                    {
                        Console.Write("What will be the cost? ");
                        string input = Console.ReadLine();

                        try
                        {
                            if (decimal.TryParse(input, out totalCost) && totalCost > 0)
                            {
                                admin.MakePayments(homeownersList, totalCost);
                                AdminUpdate adminUpdate = new AdminUpdate(paymentName, totalCost, datenow);
                                adminUpdateList.Add(adminUpdate);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a positive amount");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error occurred: {ex.Message}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect username or password.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
        }

        static void HomeownerPayment()
        {
            try
            {
                Console.WriteLine("Homeowner List");
                ViewHomeowners();

                Console.WriteLine();

                HomeOwner homeowner = null;
                DateTime dateTime = DateTime.Now;
                while (homeowner == null)
                {
                    Console.Write("Enter Homeowner Name: ");
                    string name = Console.ReadLine();

                    foreach (var nameHO in homeownersList)
                    {
                        if (nameHO.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                        {
                            homeowner = nameHO;
                            break;
                        }
                    }

                    if (homeowner == null)
                    {
                        Console.WriteLine("Homeowner not found");
                    }
                }

                while (true)
                {
                    Console.Write("Enter Payment Amount: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal paymentAmount) && paymentAmount > 0)
                    {
                        homeowner.MakePayment(paymentAmount);

                        string ID = DateTime.Now.ToString("mmss");
                        string receipt = $"Name: {homeowner.Name}, Paid: {paymentAmount}, Remaining Balance: {homeowner.DuesForOwners}, Date: {DateTime.Now}";
                        Console.WriteLine(receipt);
                        ReceiptUpdate receiptUpdate = new ReceiptUpdate(ID, homeowner.Name, paymentAmount, homeowner.DuesForOwners, dateTime);
                        receiptUpdateList.Add(receiptUpdate);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid positive payment");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Occured: {ex.Message}");
            }
        }

        static void ViewReceiptList()
        {
            if (receiptUpdateList.Count > 0)
            {
                receiptUpdateList.Reverse();
                Console.WriteLine("\nReceipt List:");
                foreach (var adminUp in receiptUpdateList)
                {
                    adminUp.DisplayInfo();
                }
            }
            else { Console.WriteLine("No receipts"); }
        }
        static void AdminUpdate()
        {

            if (adminUpdateList.Count > 0)
            {
                adminUpdateList.Reverse();
                Console.WriteLine("\nAdmin Changes:");
                foreach (var adminUp in adminUpdateList)
                {
                    adminUp.DisplayInfo();
                }
            }
            else { Console.WriteLine("No Updates from admin"); }
        }

        static void SaveData(string homeownerFilePath, string visitorsFilePath, string adminFilePath, string receiptFilePath)
        {
            try
            {
                try
                {
                    if (!File.Exists(homeownerFilePath))
                    {
                        using (File.Create(homeownerFilePath)) { }
                    }
                    if (!File.Exists(visitorsFilePath))
                    {
                        using (File.Create(visitorsFilePath)) { }
                    }
                    if (!File.Exists(adminFilePath))
                    {
                        using (File.Create(adminFilePath)) { }
                    }
                    if (!File.Exists(receiptFilePath))
                    {
                        using (File.Create(receiptFilePath)) { }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error ensuring file existence: {ex.Message}");
                    return;
                }

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true
                };

                using (StreamWriter writer = new StreamWriter(homeownersFilePath))
                using (CsvWriter csvwrite = new CsvWriter(writer, config))
                {
                    csvwrite.WriteRecords(homeownersList);
                }

                using (StreamWriter writer = new StreamWriter(visitorsFilePath))
                using (CsvWriter csvwrite = new CsvWriter(writer, config))
                {
                    csvwrite.WriteRecords(visitorsList);
                }
                using (StreamWriter writer = new StreamWriter(adminFilePath))
                using (CsvWriter csvwrite = new CsvWriter(writer, config))
                {
                    csvwrite.WriteRecords(adminUpdateList);
                }
                using (StreamWriter writer = new StreamWriter(receiptFilePath))
                using (CsvWriter csvwrite = new CsvWriter(writer, config))
                {
                    csvwrite.WriteRecords(receiptUpdateList);
                }
            }
            catch (Exception ex) { Console.WriteLine("Error occured in saving Data"); }


            Console.WriteLine("Data saved successfully");
        }

        static void LoadData()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true
            };

            try
            {
                if (File.Exists(homeownersFilePath))
                {
                    using (StreamReader reader = new StreamReader(homeownersFilePath))
                    using (CsvReader csv = new CsvReader(reader, config))
                    {
                        homeownersList = new List<HomeOwner>(csv.GetRecords<HomeOwner>());
                    }
                }
                else
                {
                    Console.WriteLine("Homeowners does not exist");
                }

                if (File.Exists(visitorsFilePath))
                {
                    using (StreamReader reader = new StreamReader(visitorsFilePath))
                    using (CsvReader csv = new CsvReader(reader, config))
                    {
                        visitorsList = new List<Visitor>(csv.GetRecords<Visitor>());
                    }
                }
                else
                {
                    Console.WriteLine("Visitor file does not exist");
                }
                if (File.Exists(adminFilePath))
                {
                    using (StreamReader reader = new StreamReader(adminFilePath))
                    using (CsvReader csv = new CsvReader(reader, config))
                    {
                        adminUpdateList = new List<AdminUpdate>(csv.GetRecords<AdminUpdate>());
                    }
                }
                else
                {
                    Console.WriteLine("Admin updates file does not exist");
                }

                if (File.Exists(receiptFilePath))
                {
                    using (StreamReader reader = new StreamReader(receiptFilePath))
                    using (CsvReader csv = new CsvReader(reader, config))
                    {
                        receiptUpdateList = new List<ReceiptUpdate>(csv.GetRecords<ReceiptUpdate>());
                    }
                }
                else
                {
                    Console.WriteLine("Receipt file does not exist");
                }
                //Console.WriteLine("Loaded successfully");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        static void DeleteAllData()
        {
            Console.Write("Delete data? (yes/no): ");
            string confirm = Console.ReadLine();
            Console.Clear();
            if (confirm.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                while (true)
                {
                    Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════╗\r\n║                                1. Homeowner List     \t\t\t\t\t\t\t\t\t\t\t \r\n╚════════════════════════════════════════════════════════════════════════════════╝\r\n\r\n╔════════════════════════════════════════════════════════════════════════════════╗\r\n║                                2. Visitor List           \t\t\t\t\t\t\t\t\t\t\t \r\n╚════════════════════════════════════════════════════════════════════════════════╝\r\n\r\n╔════════════════════════════════════════════════════════════════════════════════╗\r\n║                                3. Receipt List       \t\t\t\t\t\t\t\t\t\t\t \r\n╚════════════════════════════════════════════════════════════════════════════════╝\r\n\r\n╔════════════════════════════════════════════════════════════════════════════════╗\r\n║                                4. Admin Update List           \t\t\t\t\t\t\t\t\t\t\t \r\n╚════════════════════════════════════════════════════════════════════════════════╝\r\n\r\n╔════════════════════════════════════════════════════════════════════════════════╗\r\n║                                5. All Data           \t\t\t\t\t\t\t\t\t\t\t \r\n╚════════════════════════════════════════════════════════════════════════════════╝\r\n\r\n╔════════════════════════════════════════════════════════════════════════════════╗\r\n║                                6. Exit          \t\t\t\t\t\t\t\t\t\t\t \r\n╚════════════════════════════════════════════════════════════════════════════════╝");
                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                homeownersList.Clear();
                                if (File.Exists(homeownersFilePath))
                                {
                                    File.Delete(homeownersFilePath);
                                }
                                Console.WriteLine("All data in homeowners are deleted.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                break;

                            case 2:
                                visitorsList.Clear();
                                if (File.Exists(visitorsFilePath))
                                {
                                    File.Delete(visitorsFilePath);
                                }
                                Console.WriteLine("All data in visitors are deleted.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                break;

                            case 3:
                                receiptUpdateList.Clear();
                                if (File.Exists(receiptFilePath))
                                {
                                    File.Delete(receiptFilePath);
                                }
                                Console.WriteLine("All data in receipt are deleted.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                break;

                            case 4:
                                adminUpdateList.Clear();
                                if (File.Exists(adminFilePath))
                                {
                                    File.Delete(adminFilePath);
                                }
                                Console.WriteLine("All data in admin are deleted.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                break;

                            case 5:
                                homeownersList.Clear();
                                visitorsList.Clear();
                                receiptUpdateList.Clear();
                                adminUpdateList.Clear();

                                if (File.Exists(homeownersFilePath))
                                {
                                    File.Delete(homeownersFilePath);
                                }
                                if (File.Exists(visitorsFilePath))
                                {
                                    File.Delete(visitorsFilePath);
                                }
                                if (File.Exists(receiptFilePath))
                                {
                                    File.Delete(receiptFilePath);
                                }
                                if (File.Exists(adminFilePath))
                                {
                                    File.Delete(adminFilePath);
                                }
                                Console.WriteLine("All data are deleted.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                break;
                            case 6:
                                break;

                            default:
                                Console.WriteLine("Invalid choice. Please select a number between 1-6");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1-6");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
            else
            {
                Console.WriteLine("Exiting since the answer is not 'yes'");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void RemoveFromList()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose what list to modify");
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════╗\r\n║                                1. Homeowner List       \t\t\t\t\t\t\t\t\t\t\t \r\n╚════════════════════════════════════════════════════════════════════════════════╝\r\n\r\n╔════════════════════════════════════════════════════════════════════════════════╗\r\n║                                2. Visitor List           \t\t\t\t\t\t\t\t\t\t\t \r\n╚════════════════════════════════════════════════════════════════════════════════╝\r\n\r\n╔════════════════════════════════════════════════════════════════════════════════╗\r\n║                                3. Admin Update History List        \t\t\t\t\t\t\t\t\t\t\t \r\n╚════════════════════════════════════════════════════════════════════════════════╝\r\n\r\n╔════════════════════════════════════════════════════════════════════════════════╗\r\n║                                4. Receipt List           \t\t\t\t\t\t\t\t\t\t\t \r\n╚════════════════════════════════════════════════════════════════════════════════╝\r\n\r\n╔════════════════════════════════════════════════════════════════════════════════╗\r\n║                                5. Exit           \t\t\t\t\t\t\t\t\t\t\t \r\n╚════════════════════════════════════════════════════════════════════════════════╝");
                try
                {

                    if (int.TryParse(Console.ReadLine(), out int choice) && choice>0 && choice <= 5)
                    {
                        Console.Clear();
                        if (choice == 1)
                        {

                            ViewHomeowners();
                            Console.Write("Enter homeowner name to remove: ");
                            string name = Console.ReadLine();

                            HomeOwner homeowner = null;
                            foreach (var nameHO in homeownersList)
                            {
                                if (nameHO.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                                {
                                    homeowner = nameHO;
                                    break;
                                }
                            }

                            if (homeowner != null)
                            {
                                homeownersList.Remove(homeowner);
                                Console.WriteLine("Homeowner removed. Press any key to continue...");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Homeowner not found. Press any key to continue...");
                                Console.ReadKey();
                            }
                        }
                        else if (choice == 2)
                        {
                            ViewVisitors();
                            Console.Write("Enter visitor name to remove: ");
                            string name = Console.ReadLine();

                            Visitor visitor = null;
                            foreach (var nameHO in visitorsList)
                            {
                                if (nameHO.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                                {
                                    visitor = nameHO;
                                    break;
                                }
                            }

                            if (visitor != null)
                            {
                                visitorsList.Remove(visitor);
                                Console.WriteLine("Visitor removed. Press any key to continue...");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Visitor not found. Press any key to continue...");
                                Console.ReadKey();
                            }
                        }
                        else if (choice == 3)
                        {
                            AdminUpdate();
                            Console.Write("Enter the name of the payment to remove: ");
                            string id = Console.ReadLine();

                            AdminUpdate adminUpdate = null;
                            foreach (var update in adminUpdateList)
                            {
                                if (update.PaymentName.Equals(id, StringComparison.OrdinalIgnoreCase))
                                {
                                    adminUpdate = update;
                                    break;
                                }
                            }

                            if (adminUpdate != null)
                            {
                                adminUpdateList.Remove(adminUpdate);
                                Console.WriteLine("Admin update removed. Press any key to continue...");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Payment name not found. Press any key to continue...");
                                Console.ReadKey();
                            }
                        }
                        else if (choice == 4)
                        {
                            ViewReceiptList();
                            Console.Write("Enter the ID of the receipt to remove: ");
                            string ID = Console.ReadLine();

                            ReceiptUpdate receiptUpdate = null;
                            foreach (var receipt in receiptUpdateList)
                            {
                                if (receipt.ID.Equals(ID, StringComparison.OrdinalIgnoreCase))
                                {
                                    receiptUpdate = receipt;
                                    break;
                                }
                            }

                            if (receiptUpdate != null)
                            {
                                receiptUpdateList.Remove(receiptUpdate);
                                Console.WriteLine("Receipt removed. Press any key to continue...");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Receipt not found. Press any key to continue...");
                                Console.ReadKey();
                            }
                        }
                        else if (choice == 5)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Please select a number between 1 to 5");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        static void SearchHomeowner()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Homeowner Search");
                    Console.WriteLine("═══════════════════════");
                    Console.WriteLine("List of Homeowners:");
                    foreach (var nameHO in homeownersList)
                    {
                        Console.WriteLine($"= {nameHO.Name}");
                    }

                    Console.Write("\nEnter the homeowner's name to view details (type 'exit' to go back): ");
                    string name = Console.ReadLine();

                    if (name.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }


                    HomeOwner homeowner = null;
                    foreach (var nameHO in homeownersList)
                    {
                        if (nameHO.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                        {
                            homeowner = nameHO;
                            break;
                        }
                    }

                    if (homeowner != null)
                    {
                        Console.Clear();
                        Console.WriteLine("Homeowner Details:");
                        Console.WriteLine($"Name: {homeowner.Name}");
                        Console.WriteLine($"Block Number: {homeowner.BlockNo}");
                        Console.WriteLine($"Lot Number: {homeowner.LotNo}");
                        Console.WriteLine($"Remaining Payment: {homeowner.DuesForOwners:F2}");

                        Console.WriteLine("\nReceipts:");
                        List<ReceiptUpdate> receipts = new List<ReceiptUpdate>();
                        foreach (ReceiptUpdate receipt in receiptUpdateList)
                        {
                            if (receipt.NameHO.Equals(name, StringComparison.OrdinalIgnoreCase))
                            {
                                receipts.Add(receipt);
                            }
                        }

                        if (receipts.Count > 0)
                        {
                            foreach (var receipt in receipts)
                            {
                                receipt.DisplayInfo();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No receipts found");
                        }

                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Invalid homeowner name");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occurred: {ex.Message}");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
        static void AddHomeownerPayment()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Add Payment to Homeowner's Payment needed");
                Console.WriteLine("═══════════════════════");

                Console.WriteLine("List of Homeowners:");
                foreach (var nameHO in homeownersList)
                {
                    Console.WriteLine($"= {nameHO.Name} (Current Payment needed: {nameHO.DuesForOwners:F2})");
                }

                Console.Write("\nEnter the homeowner's name to add payments needed (or type 'exit' to go back): ");
                string name = Console.ReadLine();

                if (name.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                HomeOwner homeowner = null;
                foreach (var nameH in homeownersList)
                {
                    if (nameH.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        homeowner = nameH;
                        break;
                    }
                }

                if (homeowner != null)
                {
                    Console.Write("Enter the amount to add to payment needed: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
                    {
                        homeowner.DuesForOwners += amount;
                        Console.WriteLine($"Payment needed increased by {amount:F2}. New Payment needed: {homeowner.DuesForOwners:F2}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount entered");
                    }
                }
                else
                {
                    Console.WriteLine("Homeowner not found");
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }

    interface IDisplayInfo
    {
        void DisplayInfo();
    }

    abstract class AdminInfo
    {
        public abstract bool CheckAdmin(string username, string password);
        public abstract void MakePayments(List<HomeOwner> list, decimal totalDebt);
    }

    class BasicInfo
    {
        public string Name { get; set; }
        public int BlockNo { get; set; }
        public int LotNo { get; set; }

        public BasicInfo(string name, int blockNo, int lotNo)
        {
            Name = name;
            BlockNo = blockNo;
            LotNo = lotNo;
        }
    }

    class HomeOwner : BasicInfo, IDisplayInfo
    {
        public decimal DuesForOwners { get; set; }

        public HomeOwner() : base("", 0, 0) { }

        public HomeOwner(string name, int blockNo, int lotNo, decimal duesForOwners) : base(name, blockNo, lotNo)
        {
            DuesForOwners = duesForOwners;
        }

        public void MakePayment(decimal amount)
        {
            DuesForOwners -= amount;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Block Number: {BlockNo}, Lot Number: {LotNo}, Due: {DuesForOwners:F2}");
        }
    }

    class Visitor : BasicInfo, IDisplayInfo
    {
        public string Purpose { get; set; }
        public DateTime Date { get; set; }
        public Visitor() : base("", 0, 0)
        {

        }

        public Visitor(string name, int blockNo, int lotNo, string purpose, DateTime date) : base(name, blockNo, lotNo)
        {
            Purpose = purpose;
            Date = date;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Block Number: {BlockNo}, Lot Number: {LotNo}, Purpose: {Purpose}, Date: {Date}");
        }
    }

    class Admin : AdminInfo
    {
        private readonly string username = "excel";
        private readonly string password = "duran";

        public override bool CheckAdmin(string inputUsername, string inputPassword)
        {
            return (inputUsername == username) && (inputPassword == password);
        }

        public override void MakePayments(List<HomeOwner> list, decimal totalDebt)
        {
            decimal perHomeownerDebt = totalDebt / list.Count;
            foreach (var homeowner in list)
            {
                homeowner.DuesForOwners += perHomeownerDebt;
            }
        }
    }
    class AdminUpdate : IDisplayInfo
    {

        public DateTime Date { get; set; }

        public string PaymentName { get; set; }

        public decimal Cost { get; set; }


        public AdminUpdate() { }
        public AdminUpdate(string sentence, decimal cost, DateTime date)
        {
            Date = date;
            PaymentName = sentence;
            Cost = cost;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Payment Name: {PaymentName}, Total Cost: {Cost}, Date: {Date}");
        }

    }

    class ReceiptUpdate : IDisplayInfo
    {
        public string ID { get; set; }
        public string NameHO { get; set; }

        public decimal Amount { get; set; }
        public decimal ReceiptDue { get; set; }

        public DateTime Date { get; set; }
        public ReceiptUpdate() { }
        public ReceiptUpdate(string iD, string name, decimal amount, decimal due, DateTime date)
        {
            ID = iD;
            NameHO = name;
            Amount = amount;
            ReceiptDue = due;
            Date = date;
        }

        public void DisplayInfo()
        {

            //string receipt = $"Name: {homeowner.Name}, Paid: {paymentAmount}, Remaining Balance: {homeowner.DuesForOwners}, Date: {DateTime.Now}";
            Console.WriteLine($"ID: {ID}, Name: {NameHO}, Paid: {Amount}, Remaining Balance: {ReceiptDue}, Date: {Date}");
        }
    }

}
//might add receipt and admin history as class for csv



