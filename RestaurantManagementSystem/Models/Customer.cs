
namespace RestaurantManagementSystem.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }

        public Customer(int customerId, string fullName,string phoneNumber, string? email = null)
        {
            CustomerId = customerId;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
