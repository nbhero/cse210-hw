using System.ComponentModel.DataAnnotations.Schema;
using FinalProject;

public class ProductManager
{
    private Dictionary<int, Product> productsList = new Dictionary<int, Product>();

    public void ProductService()
    {
        bool returtToMenu = false;

        while (!returtToMenu)
        {
            Console.WriteLine();
            Console.WriteLine($"Store Manager");
            Console.WriteLine();
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Remove Product");
            Console.WriteLine("3. Search Product");
            Console.WriteLine("4. Exit");
            Console.WriteLine("What menu do you want to access? Choose a number!");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    
                    break;
                case "2":
                    
                    break;
                case "3":
                    
                    break;
                case "4":
                    
                    break;
                default:
                    Console.WriteLine("Choose a valid option!");
                    break;
            }
        }
    }

    public void Add()
    {
        Console.WriteLine("What's the ID?");
        string productId = Console.ReadLine();
        int productIdToINT = int.Parse(productId);
        Console.WriteLine("What's the name?");
        string productName = Console.ReadLine();
        Console.WriteLine("What's the price?");
        string price = Console.ReadLine();
        decimal priceToDecimal = decimal.Parse(price);
        Console.WriteLine("What's the quantity?");
        string quantity = Console.ReadLine();
        int quantityToINT = int.Parse(quantity);

        AddProduct(productIdToINT, productName, priceToDecimal, quantityToINT);
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

    private void SearchProduct(int id)
    {
        if (productsList.TryGetValue(id, out Product product))
        {
            Console.Clear();
            product.ProductReport(product._id, product._name, product._price, product._quantity);
        }
        else
        {
            Console.WriteLine($"User with ID {id} not found.");
        }
    }

    private void EditProduct(int id)
    {
        Console.WriteLine($"What attribute you want to change for the product with ID: {id}");
        Console.WriteLine("1. Name");
        Console.WriteLine("2. Price");
        Console.WriteLine("3. Quantity");

        string attributeInput = Console.ReadLine();
        if (productsList.TryGetValue(id, out Product product))
        {
            Console.Clear();
            switch (attributeInput)
            {
                case "1":
                    Console.WriteLine("Type in the new name:");
                    string newName = Console.ReadLine();
                    product._name = newName;
                    break;
                case "2":
                    Console.WriteLine("Type in the new price:");
                    string newPrice = Console.ReadLine();
                    decimal priceToDecimal = decimal.Parse(newPrice);
                    product._price = priceToDecimal;
                    break;
                case "3":
                    Console.WriteLine("Type in the new quantity");
                    string newQuantity = Console.ReadLine();
                    int quantityToDecimal = int.Parse(newQuantity);
                    product._quantity = quantityToDecimal;
                    break;

                default:
                    Console.WriteLine("Choose a valid option!");
                    break;
            }

        }
    }

}