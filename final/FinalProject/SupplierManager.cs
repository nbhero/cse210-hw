namespace FinalProject;

class SupplierManager
{
    public void SupplierService()
    {
        bool exitService = false;
        while (!exitService)
        {
            Console.WriteLine();
            Console.WriteLine($"Store Manager: Supplier");
            Console.WriteLine();
            Console.WriteLine("1. Add Supplier");
            Console.WriteLine("2. Remove Supplier");
            Console.WriteLine("3. Search Supplier by ID");
            Console.WriteLine("4. List all Suppliers");
            Console.WriteLine("5. Return");

            Console.Write("Select an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("What's the ID?");
                    string testID = Console.ReadLine();
                    int testIDToINT = int.Parse(testID);
                    Console.WriteLine("What's the name?");
                    string testName = Console.ReadLine();
                    Console.WriteLine("What's the email?");
                    string testEmail = Console.ReadLine();

                    Supplier newS = new Supplier(testIDToINT, testName, testEmail);
                    newS.AddSupplier(testIDToINT, testName, testEmail);
                    break;
                case "2":

                    break;
                case "3":

                    break;
                case "4":
                    Supplier listSupplier = new Supplier(0, "testName", "testEmail");
                    listSupplier.ListAllSuppliers();
                    break;
            }
        }
    }
}