using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerticalGridDemo.Models;

namespace VerticalGridDemo.Services
{
    public class DataService
    {
        public static List<Country> GetCountries()
        {
            return new List<Country>
            {
                new Country(1, "United States", "US"),
                new Country(2, "United Kingdom", "UK"),
                new Country(3, "Germany", "DE"),
                new Country(4, "France", "FR"),
                new Country(5, "Japan", "JP")
            };
        }

        public static List<Customer> GetCustomers()
        {
            var countries = GetCountries();
            
            return new List<Customer>
            {
                new Customer(1, "John", "Smith", "john.smith@example.com", "+1-555-123-4567", 
                    new DateTime(1980, 5, 15), countries[0]),
                    
                new Customer(2, "Alice", "Johnson", "alice.johnson@example.com", "+44-555-234-5678", 
                    new DateTime(1985, 8, 22), countries[1]),
                    
                new Customer(3, "Hans", "Mueller", "hans.mueller@example.com", "+49-555-345-6789", 
                    new DateTime(1975, 3, 10), countries[2]),
                    
                new Customer(4, "Sophie", "Dubois", "sophie.dubois@example.com", "+33-555-456-7890", 
                    new DateTime(1990, 11, 27), countries[3]),
                    
                new Customer(5, "Takashi", "Yamamoto", "takashi.yamamoto@example.com", "+81-555-567-8901", 
                    new DateTime(1982, 7, 3), countries[4])
            };
        }
    }
}