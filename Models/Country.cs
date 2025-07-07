using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerticalGridDemo.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public Country(int id, string name, string code)
        {
            Id = id;
            Name = name;
            Code = code;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}