using System.Text;

namespace StockMarket
{
    public class Stock
    {
        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShares)
        {
            CompanyName = companyName;
            Director = director;
            PricePerShare = pricePerShare;
            TotalNumberOfShares = totalNumberOfShares;
        }

        public string CompanyName { get; set; }
        public string Director { get; set; }
        public decimal PricePerShare { get; set; }
        public int TotalNumberOfShares { get; set; }


        public decimal MarketCapitalization => this.PricePerShare * this.TotalNumberOfShares;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Company: {this.CompanyName}");
            sb.AppendLine($"Director: {this.Director}");
            sb.AppendLine($"Price per share: ${this.PricePerShare}");
            sb.AppendLine($"Market capitalization: ${this.MarketCapitalization}");

            return sb.ToString().TrimEnd();
        }
        /*  MarketCapitalization is a calculated property between PricePerShare and a TotalNumberOfShares. 
The class should also have the following methods:
	•	Override ToString() method in the format:
"Company: {CompanyName}
Director: {Director}
Price per share: ${PricePerShare}
Market capitalization: ${MarketCapitalization}"
*/
    }
}
