using System.Linq;

namespace SkateparkManagement
{
    public static class SalaryCalculation
    {
        public static void CalculateSalaries()
        {
            var totalSales = Database.Users.Sum(user => user.Sales.Sum(sale => sale.Amount));
            var totalHours = Database.Users.Sum(user => user.HoursWorked);

            foreach (var user in Database.Users)
            {
                user.Salary = (user.HoursWorked / totalHours) * totalSales;
            }
        }
    }
}
