namespace FinalProject
{
    public class StoreManager
    {
        public void RunSystem()
            {
                bool exitProgram = false;
                while (!exitProgram)
                {
                    Console.Clear();
                    Console.WriteLine($"\nStore Manager\n");
                    Console.WriteLine("1. Product");
                    Console.WriteLine("2. User");
                    Console.WriteLine("3. Supplier");
                    Console.WriteLine("4. Exit");
                    Console.WriteLine("What menu do you want to access? Choose a number!");
                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                        ProductManager productManager = new ProductManager();
                        productManager.ProductService();
                        break;
                        case "2":
                            UserManager user = new UserManager();
                            user.UserService();
                            break;
                        case "3":
                            SupplierManager newSupplier = new SupplierManager();
                            newSupplier.SupplierService();
                            break;
                        case "4":
                            exitProgram = true;
                            break;
                        default:
                            Console.WriteLine("Choose a valid option!");
                            break;
                    }
                }
            }
    }
}

