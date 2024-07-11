using System.Collections.Generic;

namespace SkateparkManagement
{
    public class Sale
    {
        public double Amount { get; set; }
        public string Date { get; set; }
        public List<Article> Articles { get; set; }
    }
}
