using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace OrdersTests
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void OrderQty5()
        {
            int customer_id = 1;
            string kitType = "Standard";
            int amount = 5;
            DateTime Delivery_date = new DateTime(2024, 12, 18, 12, 0, 0);

            Order.ProcessOrder(customer_id, kitType, amount, Delivery_date);




        }

        [TestMethod]
        public void OrderQty10()
        {
            int customer_id = 2;
            string kitType = "Standard";
            int amount = 10;
            DateTime Delivery_date = new DateTime(2024, 1, 11, 12, 0, 0);

            Order.ProcessOrder(customer_id, kitType, amount, Delivery_date);


        }
        [TestMethod]
        public void OrderQty50()
        {
            int customer_id = 3;
            string kitType = "Standard";
            int amount = 50;
            DateTime Delivery_date = new DateTime(2024, 8, 1, 12, 0, 0);

            Order.ProcessOrder(customer_id, kitType, amount, Delivery_date);


        }
        [TestMethod]
        public void OrderIncorrectQuantity()  
        {
            int customer_id = 4;
            string kitType = "Standard";
            int amount = 10000;
            DateTime Delivery_date = new DateTime(2024, 2, 15, 12, 0, 0);

            Order.ProcessOrder(customer_id, kitType, amount, Delivery_date);



        }
        [TestMethod]
        public void OrderIncorrectDate()
        {
            int customer_id = 5;
            string kitType = "Standard";
            int amount = 100;
            DateTime Delivery_date = new DateTime(2022, 6, 15, 12, 0, 0);

            Order.ProcessOrder(customer_id, kitType, amount, Delivery_date);



        }
        [TestMethod]
        public void OrderIncorrectNumber()
        {
            int customer_id = 6;
            string kitType = "Standard";
            int amount = -13;
            DateTime Delivery_date = new DateTime(2024, 8, 1, 12, 0, 0);

            Order.ProcessOrder(customer_id, kitType, amount, Delivery_date);



        }
        [TestMethod]
        public void ZListOrders()
        {
            Order.ListOrders();
        }
    }
}