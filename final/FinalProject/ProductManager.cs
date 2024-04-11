using System.ComponentModel.DataAnnotations.Schema;
namespace FinalProject
{
    public class ProductManager
    {
        private Dictionary<int, Product> productsList = new Dictionary<int, Product>();

        public void ProductService()
        {
            bool exitService = false;

            while (!exitService)
            {
                Console.WriteLine($"\nStore Manager: Product\n");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Remove Product");
                Console.WriteLine("3. Search Product");
                Console.WriteLine("4. Edit Product");
                Console.WriteLine("5. List All Products");
                Console.WriteLine("6. Return");
                Console.Write("What menu do you want to access? Choose a number: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        RegisterProduct();
                        break;
                    case "2":
                        PromptToRemoveProduct();
                        break;
                    case "3":
                        PromptToSearchProduct();
                        break;
                    case "4":
                        PromptToEditProduct();
                        break;
                    case "5":
                        ListAllProducts();
                        break;
                    case "6":
                        exitService = true;
                        break;
                    default:
                        Console.WriteLine("Choose a valid option!");
                        break;
                }
            }
        }

        // Add Product Methods
        private void RegisterProduct()
        {
            try
            {
                Console.WriteLine("What's the ID?");
                int productId = int.Parse(Console.ReadLine());
                
                Console.WriteLine("What's the name?");
                string productName = Console.ReadLine();

                Console.WriteLine("What's the price?");
                decimal price = decimal.Parse(Console.ReadLine());
                
                Console.WriteLine("What's the quantity?");
                int quantity = int.Parse(Console.ReadLine());
                

                AddProduct(productId, productName, price, quantity);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter the correct format.");
            }
        }

        private void AddProduct(int id, string name, decimal price, int quantity)
        {
            if (!productsList.ContainsKey(id))
            {
                Console.Clear();
                productsList.Add(id, new Product(id, name, price, quantity));
                Console.WriteLine("Product registered!");
            }
            else
            {
                Console.WriteLine($"Product with ID {id} already registered.");
            }
        }
        // Remove Product Methods
        private void PromptToRemoveProduct()
        {
            try
            {
                Console.Write("What's the ID of the Product? ");
                int removeID = int.Parse(Console.ReadLine());

                RemoveProduct(removeID);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        private void RemoveProduct(int id)
        {
            if (productsList.Remove(id))
            {
                Console.Clear();
                Console.WriteLine($"Product with ID {id} removed successfully.");
            }
            else
            {
                Console.WriteLine($"No product found with ID {id}.");
            }
        }
        // Search Product Methods
        private void PromptToSearchProduct()
        {
            try
            {
                Console.WriteLine("What's the ID of the Product?");
                int searchID = int.Parse(Console.ReadLine());
                
                SearchProduct(searchID);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        private void SearchProduct(int id)
        {
            if (productsList.TryGetValue(id, out Product product))
            {
                Console.Clear();
                product.ProductReport();
            }
            else
            {
                Console.WriteLine($"User with ID {id} not found.");
            }
        }
        // Edit Product Methods
        private void PromptToEditProduct()
        {
            try
            {
                Console.WriteLine("What's the ID of the Product?");
                int editId = int.Parse(Console.ReadLine());
                
                EditProduct(editId);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        private void EditProduct(int id)
        {
            bool edit = true;
            while (edit)
            {
                Console.Clear();
                Console.WriteLine("You are about to edit the following product:");
                productsList.TryGetValue(id, out Product editProduct);
                editProduct.ProductReport();
                Console.WriteLine("1. Name");
                Console.WriteLine("2. Price");
                Console.WriteLine("3. Quantity");
                Console.WriteLine("4. Return");
                Console.WriteLine("Type in '4' if you don't want to edit the product anymore.");

                string attributeInput = Console.ReadLine();
                if (productsList.TryGetValue(id, out Product product))
                {
                    switch (attributeInput)
                    {
                        case "1":
                            Console.WriteLine("Type in the new name:");
                            string newName = Console.ReadLine();
                            product._name = newName;
                            break;
                        case "2":
                            try
                            {
                                Console.WriteLine("Type in the new price:");
                                decimal newPrice = decimal.Parse(Console.ReadLine());
                                
                                product._price = newPrice;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a number.");
                            }
                            break;
                        case "3":
                            try
                            {
                                Console.WriteLine("Type in the new quantity");
                                int newQuantity = int.Parse(Console.ReadLine());
                                
                                product._quantity = newQuantity;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a number.");
                            }
                            break;
                        case "4":
                            edit = false;
                            break;

                        default:
                            Console.WriteLine("Choose a valid option!");
                            break;
                    }

                }
            }
            
        }

        public void ListAllProducts()
        {
            if (productsList.Values.Count > 0)
            {
                foreach (var product in productsList.Values)
                {
                    product.ProductReport();
                }
            }
            else
            {
                Console.WriteLine("There are no supplier to be listed.");
            }
        }

    }
}

