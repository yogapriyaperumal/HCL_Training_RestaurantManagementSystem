using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagementSystem.Exceptions
{
    public class RestaurantManagementException:Exception
    {
        public RestaurantManagementException(string msg) :base(msg){

        }
    }
}
