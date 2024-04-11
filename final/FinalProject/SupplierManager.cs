using System;
using System.Collections.Generic;
using FinalProject;

class SupplierManager
{
    private Dictionary<int, Supplier> _suppliers = new Dictionary<int, Supplier>();
    public void SupplierService()
    {
        bool exitService = false;
        while (!exitService)
        {
            Console.WriteLine($"\nStore Manager: Supplier\n");
            Console.WriteLine("1. Add Supplier");
            Console.WriteLine("2. Set Supplier Inactive");
            Console.WriteLine("3. Set Supplier Active");
            Console.WriteLine("4. Search Supplier by ID");
            Console.WriteLine("5. List all Suppliers");
            Console.WriteLine("6. Return");

            Console.Write("Select an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    RegisterSupplier();
                    break;
                case "2":
                    PromptToRemoveSupplier();
                    break;
                case "3":
                    PromptTosupplierSupplier();
                    break;
                case "4":
                    PromptToSearchSupplier();
                    break;
                case "5":
                    ListAllSuppliers();
                    break;
                case "6":
                    exitService = true;
                    break;
            }
        }
    }
    
    // Add Supplier Methods
    private void RegisterSupplier()
    {
        try
        {
            Console.WriteLine("What's the ID?");
            int supplierId = int.Parse(Console.ReadLine());
            
            Console.WriteLine("What's the name?");
            string supplierName = Console.ReadLine();

            Console.WriteLine("What's the e-mail?");
            string supplierEmail = Console.ReadLine();            

            AddSupplier(supplierId, supplierName, supplierEmail);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter the correct format.");
        }
    }

    private void AddSupplier(int id, string name, string email, bool active = true)
    {
        if (!_suppliers.ContainsKey(id))
        {
            Console.Clear();
            _suppliers.Add(id, new Supplier(id, name, email));
            Console.WriteLine("Supplier registered successfully!");
        }
        else
        {
            Console.WriteLine($"Supplier with ID {id} already registered.");
        }
    }

    // Set Supplier Inactive
    private void PromptToRemoveSupplier()
    {
        try
        {
            Console.Write("What's the ID of the Supplier? ");
            int removeID = int.Parse(Console.ReadLine());

            SetInactive(removeID);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    private void SetInactive(int id)
    {
        if (_suppliers.TryGetValue(id, out Supplier supplier))
        {
            Console.Clear();
            supplier.SetSupplierInactive(supplier._id);
            Console.WriteLine("The following Supplier is now inactive.");
            supplier.SupplierReport();
        }
        else
        {
            Console.WriteLine($"No Supplier found with ID {id}.");
        }
    }

    // Set Supplier Active
    private void PromptTosupplierSupplier()
    {
        try
        {
            Console.Write("What's the ID of the Supplier? ");
            int supplierID = int.Parse(Console.ReadLine());

            SetActive(supplierID);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }
    
    private void SetActive(int id)
    {
        if (_suppliers.TryGetValue(id, out Supplier supplier))
        {
            Console.Clear();
            supplier.SetSupplierActive(supplier._id);
            Console.WriteLine("The following Supplier is now active.");
            supplier.SupplierReport();
        }
        else
        {
            Console.WriteLine($"No Supplier found with ID {id}.");
        }
    }

    // Search Supplier Methods
    private void PromptToSearchSupplier()
        {
            try
            {
                Console.WriteLine("What's the ID of the Supplier?");
                int searchID = int.Parse(Console.ReadLine());
                
                SearchSupplier(searchID);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

    private void SearchSupplier(int id)
    {
        if (_suppliers.TryGetValue(id, out Supplier supplier))
        {
            Console.Clear();
            supplier.SupplierReport();
        }
        else
        {
            Console.WriteLine($"Supplier with ID {id} not found.");
        }
    }

    private void ListAllSuppliers()
    {
        if (_suppliers.Count > 0)
        {
            Console.Clear();
            foreach (var supplier in _suppliers.Values)
            {
                supplier.SupplierReport();
            }
        }

        else
        {
            Console.WriteLine("No suppliers registered.");
        }
    }
}