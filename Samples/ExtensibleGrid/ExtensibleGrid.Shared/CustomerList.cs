// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows.Media;
using System.Windows.Controls;

namespace ExtensibleGrid.Shared
{
    /// <summary>
    /// Represents a collection of Customer objects.
    /// </summary>
    public class CustomerCollection : ObjectCollection 
    {
    
        /// <summary>
        /// Initializes a CustomerCollection object with 25 customers.
        /// </summary>
        public CustomerCollection()
            : base(SampleCustomerCollection(25))
        {
        }

        /// <summary>
        /// Initializes a CustomerCollection.
        /// </summary>
        /// <param name="customerCount">The number of customers to generate.</param>
        public static IEnumerable<Customer> SampleCustomerCollection(int customerCount)
        {
            List<Customer> customers = new List<Customer>();

            // Fake Data
            if (customerCount > 0)
            {
                customers.Add(new Customer("John", "Doe", Colors.Orange, 1, "Obere Str. 57, Berlin 12209, Germany", (decimal)12.25, false, null, 35, Status.Active, Status.Closed));
            }
            if (customerCount > 1)
            {
                customers.Add(new Customer("Jane", "Doe", Colors.Purple, 5, "24, place Kléber, 67000 Strasbourg, France", (decimal)15.55, true, null, 57, Status.Resolved, null));
            }
            if (customerCount > 2)
            {
                customers.Add(new Customer("Joe", "Anybody", Colors.Yellow, 1, "Strada Provinciale 124, 42100 Reggio Emilia, Italy", (decimal)11.5, true, false, null, Status.Closed, Status.Closed));
            }
            if (customerCount > 3)
            {
                customers.Add(new Customer("Jill", "Anybody", Colors.Green, 1, "Geislweg 36, Salzburg 5020, Austria", (decimal)9.99, false, true, null, Status.Active, null));
            }
            for (int customer = 4; customer < customerCount; customer++)
            {
                customers.Add(Customer.GetRandomCustomer(customer));
            }
            return customers;
        }

       }
}
