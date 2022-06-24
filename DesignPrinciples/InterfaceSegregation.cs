using System;

namespace DesignPrinciples
{
    /// <summary>
    /// Interface Segregation Principle.
    /// client(s) should not be forced to implement interfaces they don’t use.
    /// </summary>
    public class InterfaceSegregation
    {
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime DOB { get; set; }
        }

        public class Order
        {
            public int Id { get; set; }
            public int Quantity { get; set; }
            public string Item { get; set; }
        }

        public class InterfaceSegregationBad
        {
            public interface ICustomer
            {
                public User GetUser(int userId);
                public void AddUser(User user);

                public Order GetOrder(int orderId);
                public void AddOrder(Order order);
            }
        }

        public class InterfaceSegregationGood
        {
            public interface ICustomer
            {
                public User GetUser(int userId);
                public void AddUser(User user);
            }

            public interface IOrder
            {
                public Order GetOrder(int orderId);
                public void AddOrder(Order order);
            }
        }
    }
}
