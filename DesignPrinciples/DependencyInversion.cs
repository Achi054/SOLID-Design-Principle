using System;

namespace DesignPrinciples
{
    /// <summary>
    /// Dependency-Inversion Principle
    /// High-level class must not depend upon a low level class. They must both depend upon abstraction.
    /// Abstraction must not depend on details, rather the details must depend upon abstractions.
    /// </summary>
    public class DependencyInversion
    {
        public class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime DOB { get; set; }
        }

        public class DependencyInversionBad
        {
            public class CustomerDomain
            {
                private readonly CustomerDataProcessor customerDataProcessor;
                public CustomerDomain(CustomerDataProcessor customerDataProcessor)
                {
                    this.customerDataProcessor = customerDataProcessor;
                }

                public Customer GetCustomer(int id)
                {
                    return customerDataProcessor.Get(id);
                }

                public void AddCustomer(Customer customer)
                {
                    customerDataProcessor.Add(customer);
                }
            }

            public class CustomerDataProcessor
            {
                public Customer Get(int id)
                {
                    // Get Data

                    return default;
                }

                public void Add(Customer customer)
                {
                    // Insert data
                }
            }
        }

        public class DependencyInversionGood
        {
            public interface ICustomerDomain
            {
                Customer GetCustomer(int id);
                void AddCustomer(Customer customer);
            }

            public class CustomerDomain : ICustomerDomain
            {
                private readonly ICustomerDataProcessor customerDataProcessor;
                public CustomerDomain(ICustomerDataProcessor customerDataProcessor)
                {
                    this.customerDataProcessor = customerDataProcessor;
                }

                public Customer GetCustomer(int id)
                {
                    return customerDataProcessor.Get(id);
                }

                public void AddCustomer(Customer customer)
                {
                    customerDataProcessor.Add(customer);
                }
            }

            public interface ICustomerDataProcessor
            {
                Customer Get(int id);
                void Add(Customer customer);
            }

            public class CustomerDataProcessor : ICustomerDataProcessor
            {
                public Customer Get(int id)
                {
                    // Get Data

                    return default;
                }

                public void Add(Customer customer)
                {
                    // Insert data
                }
            }
        }
    }
}
