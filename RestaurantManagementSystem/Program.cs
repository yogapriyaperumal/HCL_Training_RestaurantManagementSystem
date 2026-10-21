using RestaurantManagementSystem.Models;
using RestaurantManagementSystem.Sevices;

MenuManagement m = new MenuManagement();




m.AddItems();
m.Display();
m.GetItemById();
m.SearchTitle();
m.SearchCategory();
m.Update();
m.MarkItemAvailable();
m.DeleteItem();


CustomerManagement cm = new CustomerManagement();
cm.AddCustomer();
cm.Display();
cm.GetItemById();
cm.SearchName();
cm.SearchPhoneNumber();
cm.Update();
cm.DeleteCustomer();
