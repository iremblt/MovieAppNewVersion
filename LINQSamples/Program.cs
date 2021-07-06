using LINQSamples.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQSamples
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }
    class CustomerModel
    {
        public CustomerModel()
        {
            this.Orders = new List<OrderModel>();
        }
        public string CustomerId { get; set; }
        public string  CustomerName { get; set; }
        public int OrderCount { get; set; }
        public List<OrderModel> Orders { get; set; }
    }
    class OrderModel
    {
        public int OrderId { get; set; }
        public decimal Total { get; set; }
        public List<ProductModel> Products { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (var db=new NorthwindContext())
            {
                /*
                var products = db.Products.Select(p => new ProductModel
                {
                    Name = p.ProductName,
                    Price = p.UnitPrice
                }).ToList();
                */
                // var product = db.Products.Find();
                // var product = db.Products.Select(p => new { p.ProductName, p.UnitPrice }).FirstOrDefault();
                // Console.WriteLine(product.ProductName+ " "+product.UnitPrice);
                //var products = db.Products.Select(p=> new { p.ProductName, p.UnitPrice }).ToList();
                //   var products = db.Products.Select(p=>p.ProductName).ToList();
                //  var products = db.Products.ToList();
                /*
                foreach (var p in products)
                {
                    Console.WriteLine(p.Name+ ' ' +p.Price);
                }
                */
                // var products = db.Products.Where(p=>p.UnitPrice>18).ToList();
                //   var products = db.Products.Where(p => p.UnitPrice > 18 && p.UnitPrice<30).Select(p => new { p.ProductName, p.UnitPrice }).ToList();
                //var products = db.Products.Where(p=>p.CategoryId<5).ToList();
                // var products = db.Products.Where(p => p.CategoryId==1).Select(p => new { p.ProductName, p.UnitPrice }).ToList();
                /*  var customers = db.Customers.Select(c=>new { c.ContactName, c.CustomerId});
                  foreach (var customer in customers)
                  {
                      Console.WriteLine(customer.ContactName+" "+ customer.CustomerId);
                  }
                
                var customers = db.Customers.Where(c => c.Country.Equals("Germany")).Select(c=> new { c.Country,c.ContactName}).ToList();
                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.ContactName+" "+customer.Country);
                }
                var customer = db.Customers.Where(c => c.ContactName == "Diego Roel").Select(c=> new { c.Country,c.ContactName}).FirstOrDefault();
                Console.WriteLine(customer.ContactName+" "+customer.Country);
                var products = db.Products.Where(p => p.UnitsInStock == 0).Select(p=>new {p.ProductName,p.UnitsInStock }).ToList();
                foreach (var product in products)
                {
                    Console.WriteLine(product.ProductName+" "+product.UnitsInStock);
                }
                var employees = db.Employees.Select(e=> new { FullNmae=e.FirstName+ " "+ e.LastName}).ToList();
                foreach (var emp in employees)
                {
                    Console.WriteLine(emp.FullNmae);
                }
                var products = db.Products.Take(5).ToList();
                foreach (var product in products)
                {
                    Console.WriteLine(product.ProductName + " " + product.ProductId);
                }
                
                var products = db.Products.Skip(5).Take(5).ToList();
                foreach (var product in products)
                {
                    Console.WriteLine(product.ProductName + " " + product.ProductId);
                }
                */
                /*
                var result = db.Products.Count(i => i.UnitPrice > 10 && i.UnitPrice < 20);
                Console.WriteLine(result);
                */
                //var result = db.Products.Count(i => i.Discontinued == false);
                // var result = db.Products.Min(i => i.UnitPrice);
                //var result = db.Products.Where(p=>p.CategoryId==2).Max(i => i.UnitPrice);
                //var result = db.Products.Average(p => p.UnitPrice);
                // var result = db.Products.Sum(p => p.UnitPrice);
                // Console.WriteLine(result);
                //  var result = db.Products.OrderBy(p=>p.UnitPrice).ToList();  //artan
                //   var result = db.Products.OrderByDescending(p => p.UnitPrice).ToList(); //azalan
                /*
                foreach (var item in result)
                {
                    Console.WriteLine(item.ProductName+" "+item.UnitPrice);
                }
                */
                /*
                var p1 = new Product() { ProductName = "New item" };
                db.Products.Add(p1);
                db.SaveChanges();
                Console.WriteLine("Added");
                Console.WriteLine(p1.ProductId);

                var products = new List<Product>()
                {
                    new Product(){ ProductName="New product 2"},
                    new Product(){ProductName="New Product 3"}
                };
                db.Products.AddRange(products);
                db.SaveChanges();
               */
                /*
                 var result = db.Products.Where(p => p.ProductId==1).FirstOrDefault();
                 if (result != null)
                 {
                     result.UnitsInStock += 10;
                     db.SaveChanges();
                 }
                 Console.WriteLine("Updated");
                
                var product = new Product() { ProductId = 1 };
                db.Products.Attach(product);
                product.UnitsInStock = 50;
                db.SaveChanges();
                
                var product = db.Products.Find(1);
                if (product != null)
                {
                    product.UnitPrice = 20;
                    db.Update(product);
                    db.SaveChanges();
                }
                */
                /*
                var product = db.Products.Find(82);
                if (product != null)
                {
                    db.Remove(product);
                    db.SaveChanges();
                }
                
                var product = new Product() { ProductId = 80 };
                //db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.Products.Remove(product);

                var p1 = new Product() { ProductId = 79 };
                var p2 = new Product() { ProductId = 78 };
                //db.Products.RemoveRange(p1, p2);
                var products = new List<Product> { p1, p2 };
                db.Products.RemoveRange(products);
                db.SaveChanges(); 
                */
                //var products = db.Products.Include(p=>p.Category).Where(p=>p.Category.CategoryName == "Beverage").ToList();
                /* var products = db.Products.Where(p => p.Category.CategoryName == "Beverages")
                     .Select(p => new
                     {
                         name=p.Category.CategoryName,
                         id=p.CategoryId,
                        categoryName= p.ProductName
                     }).ToList();
                 foreach (var item in products)
                 {
                     Console.WriteLine(item.name+""+item.id+" "+item.categoryName);
                 }
                var category = db.Categories.Where(c=>c.Products.Any()).ToList();
                foreach (var item in category)
                {
                    Console.WriteLine(item.CategoryName);
                }
                
                var products = db.Products
                    .Select(d => new {
                        companyName=d.Supplier.CompanyName,
                        contactName=d.Supplier.ContactName,
                        name=d.ProductName
                    })
                    .ToList();
                foreach (var item in products)
                {
                    Console.WriteLine(item.companyName+" "+item.contactName+" "+item.name);
                }
                Bunlar extensions method örneğiydi
                Query expression;
                */
                /*
                var products = (from p in db.Products
                                where p.UnitPrice > 10
                                select p
                              ).ToList();
                */
                //Inner join;
                /*
                var products=(from p in db.Products
                             join s in db.Suppliers on p.SupplierId equals s.SupplierId
                             select new
                             {
                                 p.ProductName,
                                 s.ContactName,
                                 s.CompanyName
                             }).ToList();
                             
                */
                /*
                var customer = db.Customers.Where(c => c.Orders.Count > 0)
                    .Select(c => new
                    {
                        contactName=c.ContactName,
                        orderCout=c.Orders.Count
                    }).ToList();
                foreach (var item in customer)
                {
                    Console.WriteLine(item.contactName+""+item.orderCout);
                }
                */
                /*
                var customer = db.Customers
                    .Where(c => c.Orders.Any())
                    .Select(c => new CustomerModel
                    {
                        CustomerId = c.CustomerId,
                        CustomerName = c.ContactName,
                        OrderCount = c.Orders.Count,
                        Orders = c.Orders.Select(o => new OrderModel {
                            OrderId = o.OrderId,
                            Total = o.OrderDetails.Sum(od => od.Quantity * od.UnitPrice),
                            Products = o.OrderDetails.Select(p => new ProductModel
                            {
                                ProductId = p.ProductId,
                                Price = p.UnitPrice,
                                Name=p.Product.ProductName
                            }).ToList()
                        }).ToList()
                    }).ToList();
                foreach (var item in customer)
                {
                    Console.WriteLine(item.CustomerId+" "+item.CustomerName+" => "+item.OrderCount);
                    Console.WriteLine("Orders:");
                    foreach (var order in item.Orders)
                    {
                        Console.WriteLine(order.OrderId + "=>" + order.Total);
                        Console.WriteLine("Products: ");
                        foreach (var product in order.Products)
                        {
                            Console.WriteLine(product.ProductId+" =>"+product.Name+"=>"+product.Price);
                        }
                    }
                }
                */
                //  var result = db.Database.ExecuteSqlRaw("delete from products where productsId=77");
                //  var result = db.Database.ExecuteSqlRaw("update products set unitprice=unitprice*1.2 where categoryId=4");

                // Console.WriteLine(result);
                /*
                var products = db.Products.FromSqlRaw("select * from products where categoryId=4").ToList();
                foreach (var item in products)
                {
                    Console.WriteLine(item.ProductName);
                }
                */
            }
            using (var db = new CustomerNorthWindContext())
            {
                var products = db.ProductModels.FromSqlRaw("select ProductId,ProductName as Name, UnitPrice as Price from products where categoryId=4").ToList();
                foreach (var item in products)
                {
                    Console.WriteLine(item.Name);
                }
            }
            Console.ReadLine();
        }
    }
}
