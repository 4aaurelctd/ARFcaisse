using System.Collections.Generic;

namespace SkateparkManagement
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pin { get; set; }
        public List<Sale> Sales { get; set; } = new List<Sale>();
        public double HoursWorked { get; set; }
        public double Salary { get; set; }
    }
}
