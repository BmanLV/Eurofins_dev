using System;
using System.Collections.Generic;


namespace Homework
{
    public class Order
    {
        private readonly int customer_id;
        private int amount;
        private DateTime Delivery_date;
        private double kit_price;
        private double priceTotal;

        private static List<Order> orders = new List<Order>();

        private static Dictionary<string, double> kitPrices = new Dictionary<string, double>
        {
            { "Standard", 98.99 }
        };
        public static void AddOrder(Order order)
        {
            orders.Add(order);
        }

        public static void ListOrders()
        {
            foreach (Order order in orders)
            {
                Console.WriteLine($"Customer ID: {order.customerID}" +
                    $", Amount: {order.Amount}," +
                    $" Delivery Date: {order.Delivery}," +
                    $" Kit Price: {order.Price}, " + 
                    $"Price Total: {order.priceTotal}");
            }
        }
        

        public Order(int m_customer_id, double m_kit_price, int m_amount, DateTime m_Delivery_date, double m_sum)
        {
            customer_id = m_customer_id;
            kit_price = m_kit_price;
            amount = m_amount;
            Delivery_date = m_Delivery_date;
            priceTotal = m_sum;
        }
        public int customerID
        {
            get { return customer_id; }
        }
        public int Amount
        {
            get { return amount; }
        }
        public DateTime Delivery
        {
            get { return Delivery_date; }
        }
        public double Price
        {
            get {return kit_price; }
        }
        public double PriceTotal
        {
            get { return priceTotal; }
        }

        public void Discount()
        {
            if (amount >= 50)
            {
                kit_price = kit_price * 0.85; // 15% discount >= 50 kits 
            }
            else if (amount >= 10)
            {
                kit_price = kit_price * 0.95; // 5% discount >= 10 kits
            }
        }

        public void Reject()
        {
            DateTime DateNow = DateTime.Now;
            DateTime DateGiven = Delivery_date;
            int Date = DateTime.Compare(DateNow, DateGiven);
            if (Date > 0)
            {
                throw new Exception("Delivery date is not in future");
            }
            else if(amount <= 0)
            {
                throw new Exception("Desired amount is not positive round number");
            }
            else if (amount > 999)
            {
                throw new Exception("Desired amount is greater than 999");
            }
        }
        public static void ProcessOrder(int customer_id, string kitType, int amount, DateTime Delivery_date)
        {
            try
            {
                if (!kitPrices.ContainsKey(kitType))
                {
                    Console.WriteLine("Invalid kit type");
                    return;
                }

                double kit_price = kitPrices[kitType];
                double priceTotal = kit_price * amount;

                Order order = new Order(customer_id, kit_price, amount, Delivery_date, priceTotal);

                order.Discount();
                order.Reject();

                double price = order.Price * amount;
                string price_ToS = price.ToString();
                Console.WriteLine("Kit price: {0}, Price Total: {1}", order.Price, price_ToS);

                Order.AddOrder(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred: " + ex.Message);
            }
        }

        public static void Main(string[] args)
        {
            if (args.Length != 5)
            {
                return;
            }

            int customer_id = int.Parse(args[0]);
            string kitType = args[1];
            int amount = int.Parse(args[2]);
            DateTime delivery_date = DateTime.Parse(args[3]);

            ProcessOrder(customer_id, kitType, amount, delivery_date);

            Order.ListOrders();
        }
    }
}