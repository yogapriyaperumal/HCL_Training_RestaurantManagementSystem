using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Exceptions;
using RestaurantManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace RestaurantManagementSystem.Sevices
{
    public class MenuManagement
    {
        public List<MenuItem> Menu = new List<MenuItem>();
        private JsonFileHandler<MenuItem> fileHandler =
    new JsonFileHandler<MenuItem>("MenuItems.json");
        public MenuManagement()
        {
            Menu = fileHandler.Load();
        }
        public MenuItem item = new MenuItem(0, "", "", 0);
        public void AddItems()
        {
            item.ItemId = 0;
            while (item.ItemId <= 0)
            {
                Console.Write("Enter Item ID: ");
                int.TryParse(Console.ReadLine(), out int id);
                item.ItemId = id;
                if (item.ItemId <= 0)
                    throw new RestaurantManagementException("Invalid Id");
            }
            item.Name = "";
            while (string.IsNullOrWhiteSpace(item.Name))
            {
                Console.Write("Enter Item Name: ");
                string n = Console.ReadLine();
                item.Name = n;
                if (string.IsNullOrWhiteSpace(item.Name))
                    Console.WriteLine("Invalid Name!");
            }
            item.Category = "";
            while (string.IsNullOrWhiteSpace(item.Category))
            {
                Console.Write("Enter Item Category: ");
                string c = Console.ReadLine();
                item.Category = c;
                if (string.IsNullOrWhiteSpace(item.Category))
                    Console.WriteLine("Invalid Catogory!");
            }
            item.Price = 0;
            while (item.Price <= 0)
            {
                Console.Write("Enter Item Price: ");
                decimal.TryParse(Console.ReadLine(), out decimal p);
                item.Price = p;
                if (item.Price < 0)
                    Console.WriteLine("Invalid Price!");
            }

            item.IsAvailable = true;
            Menu.Add(item);
            fileHandler.Save(Menu);

            Console.WriteLine("Menu item added successfully!");

        }
        public void Display()
        {
            foreach (MenuItem item in Menu)
            {
                Console.WriteLine(
                    $"ID: {item.ItemId} | " +
                    $"Name: {item.Name} | " +
                    $"Category: {item.Category} | " +
                    $"Price: {item.Price:F2} | " +
                    $"Available: {item.IsAvailable}");
            }
        }
        public void GetItemById()
        {
            Console.Write("Enter Item ID to search: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID!");
                return;
            }

            MenuItem item = Menu.FirstOrDefault(
                m => m.ItemId == id);

            if (item == null)
            {
                Console.WriteLine("Menu item not found!");
                return;
            }

            Console.WriteLine($"ID: {item.ItemId}");
            Console.WriteLine($"Name: {item.Name}");
            Console.WriteLine($"Category: {item.Category}");
            Console.WriteLine($"Price: {item.Price:N2}");
            Console.WriteLine($"Available: {item.IsAvailable}");
        }
        public void SearchTitle()
        {
            Console.Write("Enter item name to search: ");
            string? name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Invalid!");
                return;
            }

            bool found = false;

            foreach (MenuItem item in Menu)
            {
                if (item.Name.Contains(name,
                    StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(
                        $"{item.ItemId} | {item.Name} | " +
                        $"{item.Category} | {item.Price:N2}");

                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Item not found!");
            }
        }
        public void SearchCategory()
        {
            Console.Write("Enter item Category to search: ");
            string? cat = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(cat))
            {
                Console.WriteLine("Invalid!");
                return;
            }

            bool found = false;

            foreach (MenuItem item in Menu)
            {
                if (item.Category.Contains(cat,
                    StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(
                        $"{item.ItemId} | {item.Name} | " +
                        $"{item.Category} | {item.Price:N2}");

                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Item not found!");
            }
        }
        public void Update()
        {
            Console.WriteLine("Enter Item ID to update:");
            int.TryParse(Console.ReadLine(), out int id);
            if (id <= 0)
            {
                Console.WriteLine("Invalid Item Id");
            }
            foreach (MenuItem item in Menu)
            {
                if (item.ItemId == id)
                {
                    Console.WriteLine("Enter Name");
                    string n = Console.ReadLine();
                    item.Name= n;
                    Console.WriteLine("Enter Category");
                    string c = Console.ReadLine();
                    item.Category = c;
                    Console.WriteLine("Enter Price");
                    decimal.TryParse(Console.ReadLine(), out decimal p);
                    item.Price = p;
                    Console.WriteLine("Enter Availabily True/False");
                    bool.TryParse(Console.ReadLine(), out bool a);
                    item.IsAvailable=a;

                    Console.WriteLine("Item Updated");


                }
            }

        }
        public void MarkItemAvailable()
        {
            Console.WriteLine("Enter Item ID to update Availability:");
            int.TryParse(Console.ReadLine(), out int id);
            if (id <= 0)
            {
                Console.WriteLine("Invalid Item Id");
            }
            foreach(MenuItem item in Menu)
            {
                if(item.ItemId == id)
                {
                    Console.WriteLine("Enter Availabily True/False");
                    bool.TryParse(Console.ReadLine(), out bool a);
                    item.IsAvailable = a;
                    Console.WriteLine("Updated");
                }
            }

        }

        public void DeleteItem()
        {
            Console.Write("Enter Item ID to delete: ");
            int.TryParse(Console.ReadLine(), out int id);

            MenuItem? item = Menu.FirstOrDefault(m => m.ItemId == id);

            if (item == null)
            {
                Console.WriteLine("Item not found!");
                return;
            }
            Menu.Remove(item);
            fileHandler.Save(Menu);
            Console.WriteLine("Item deleted successfully!");
            
            
        }


    }
}

