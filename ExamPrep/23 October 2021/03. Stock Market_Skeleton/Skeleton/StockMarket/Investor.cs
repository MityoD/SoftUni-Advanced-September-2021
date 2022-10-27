using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
		//private readonly List<Stock> portfolio;

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;

            Portfolio = new List<Stock>();
        }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public List<Stock> Portfolio { get; }

        public int Count => Portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && this.MoneyToInvest >= stock.PricePerShare )
            {
                this.MoneyToInvest -= stock.PricePerShare;
                Portfolio.Add(stock);
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock stock = Portfolio.Where(x => x.CompanyName == companyName).FirstOrDefault();

            if (stock == null)
            {
                return $"{companyName} does not exist.";
            }
            else if (sellPrice < stock.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }
            else
            {
                Portfolio.Remove(stock);
                this.MoneyToInvest += sellPrice;
                return $"{companyName} was sold.";
            }
        }
        public Stock FindStock(string companyName) => Portfolio.FirstOrDefault(x => x.CompanyName == companyName);

        public Stock FindBiggestCompany() => Portfolio.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();
        //{
        //    if (Portfolio.Count == 0)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        return Portfolio.OrderByDescending(x => x.MarketCapitalization).First();
        //    }
        //}

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");
            foreach (var stock in Portfolio)
            {
                sb.AppendLine(stock.ToString());
            }

            return sb.ToString().TrimEnd();
        }
        /*
	•	Method string InvestorInformation() - returns information about the Investor and his portfolio in the following format:
"The investor {fullName} with a broker {brokerName} has stocks: 
{Stock1}
{Stock2}
*/
    }
}
