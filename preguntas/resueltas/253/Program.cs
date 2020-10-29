using System;

namespace _253
{
    class Program
    {
        static void Main(string[] args)
        {
             OrderDetails orderdetalles = new OrderDetails("nombre", 1, DateTime.Now);
              Order order = new Order(1, DateTime.Now);
              Console.WriteLine ($" {orderdetalles.ProductName} { orderdetalles.OrderId} { orderdetalles.OrderDate}" ) ;
        }

   
    }

    public class OrderDetails : Order 
    {
          public String ProductName {get;set;}


        public OrderDetails(string productName, int orderId, DateTime orderDate)  : base (orderId,orderDate )
 
           
             { ProductName = productName;}
 
    }

    public class Order
    {
        public int OrderId {get;set;}
        public DateTime OrderDate {get;set;}

        public Order(int orderid, DateTime orderdate)
        {
            this.OrderId = orderid;
            this.OrderDate = orderdate;
        }
    }


   
 
}
