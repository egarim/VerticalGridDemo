using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerticalGridDemo.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public Country Country { get; set; }
        public bool IsActive { get; set; }

        public Customer()
        {
            // Default constructor
        }

        public Customer(int id, string firstName, string lastName, string email, string phone, DateTime birthDate, Country country, bool isActive = true)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            BirthDate = birthDate;
            Country = country;
            IsActive = isActive;
        }

        public string FullName => $"{FirstName} {LastName}";

        public override string ToString()
        {
            return FullName;
        }
    }
}