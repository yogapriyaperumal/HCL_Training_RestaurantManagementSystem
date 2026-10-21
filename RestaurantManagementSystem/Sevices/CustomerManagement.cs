using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagementSystem.Sevices
{
    public class CustomerManagement
    {
        public List<Customer> CusList=new List<Customer>();
        private JsonFileHandler<Customer> fileHandler =
    new JsonFileHandler<Customer>("Customers.json");
        public CustomerManagement()
        {
            CusList = fileHandler.Load();
        }
        public Customer customer = new Customer(0, "", "", "");
        public void AddCustomer()
        {
            customer.CustomerId = 0;
            while (customer.CustomerId <= 0)
            {
                Console.Write("Enter Customer ID: ");
                int.TryParse(Console.ReadLine(), out int id);
                customer.CustomerId = id;
                if (customer.CustomerId <= 0)
                    Console.WriteLine("Invalid ID!");
            }
            customer.FullName = "";
            while (string.IsNullOrWhiteSpace(customer.FullName))
            {
                Console.Write("Enter Customer Name: ");
                string n = Console.ReadLine();
                customer.FullName = n;
                if (string.IsNullOrWhiteSpace(customer.FullName))
                    Console.WriteLine("Invalid Name!");
            }
            customer.PhoneNumber = "";
            while (string.IsNullOrWhiteSpace(customer.PhoneNumber))
            {
                Console.Write("Enter Customer Phone Number: ");
                string c = Console.ReadLine();
                customer.PhoneNumber = c;
                if (string.IsNullOrWhiteSpace(customer.PhoneNumber))
                    Console.WriteLine("Invalid PhoneNumber!");
            }
            customer.Email = "";
            while (string.IsNullOrWhiteSpace(customer.Email))
            {
                Console.Write("Enter Customer Email: ");
                string e = Console.ReadLine();
                customer.Email = e;
                if (string.IsNullOrWhiteSpace(customer.Email))
                    Console.WriteLine("Invalid Email!");
            }


            CusList.Add(customer);
            fileHandler.Save(CusList);

            Console.WriteLine("Customer Details added successfully!");

        }
        public void Display()
        {
            foreach (Customer customer in CusList)
            {
                Console.WriteLine(
                    $"Customer ID: {customer.CustomerId} | " +
                    $"Name: {customer.FullName} | " +
                    $"PhoneNumber: {customer.PhoneNumber} | " +
                    $"Email: {customer.Email} | ");
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

            Customer item = CusList.FirstOrDefault(
                m => m.CustomerId == id);

            if (item == null)
            {
                Console.WriteLine("Menu item not found!");
                return;
            }
            Console.WriteLine(
                    $"Customer ID: {customer.CustomerId} | " +
                    $"Name: {customer.FullName} | " +
                    $"PhoneNumber: {customer.PhoneNumber} | " +
                    $"Email: {customer.Email} | ");

        }
        public void SearchName()
        {
            Console.Write("Enter Customer Name to search: ");
            string? name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Invalid!");
                return;
            }

            bool found = false;

            foreach (Customer customer in CusList)
            {
                if (customer.FullName.Contains(name,
                    StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(
                   $"Customer ID: {customer.CustomerId} | " +
                   $"Name: {customer.FullName} | " +
                   $"PhoneNumber: {customer.PhoneNumber} | " +
                   $"Email: {customer.Email} | ");

                    found = true;
                }
            }

        }
        public void SearchPhoneNumber()
        {
            Console.Write("Enter Customer Phonenumebr to search: ");
            string? n = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(n))
            {
                Console.WriteLine("Invalid!");
                return;
            }

            bool found = false;

            foreach (Customer customer in CusList)
            {
                if (customer.PhoneNumber.Contains(n,
                    StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(
                   $"Customer ID: {customer.CustomerId} | " +
                   $"Name: {customer.FullName} | " +
                   $"PhoneNumber: {customer.PhoneNumber} | " +
                   $"Email: {customer.Email} | ");

                    found = true;
                }
            }

        }
        public void Update()
        {
            Console.WriteLine("Enter Customer ID to update contact Details:");
            int.TryParse(Console.ReadLine(), out int id);
            if (id <= 0)
            {
                Console.WriteLine("Invalid Id");
            }
            foreach (Customer customer in CusList)
            {
                if (customer.CustomerId== id)
                {
                    Console.WriteLine("Enter Phonenumber");
                    string n = Console.ReadLine();
                    customer.PhoneNumber = n;
                    Console.WriteLine("Enter Email");
                    string e = Console.ReadLine();
                    customer.Email = e;
      
                    Console.WriteLine("Customer Conatact Details Updated");


                }
            }

        }
        public void DeleteCustomer()
        {
            Console.Write("Enter Cutomer ID to delete: ");
            int.TryParse(Console.ReadLine(), out int id);

            Customer? item = CusList.FirstOrDefault(m => m.CustomerId == id);

            if (item == null)
            {
                Console.WriteLine("Item not found!");
                return;
            }
            CusList.Remove(item);
            fileHandler.Save(CusList);
            Console.WriteLine("Customer deleted successfully!");
        }
    }
}
