using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Product
            ProductTest();
            //ProductDetailDTOTest();


            //Category
            //AddCategoryTest();
        }

        private static void AddCategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            categoryManager.Insert(new Category
            {
                CategoryId = 4,
                CategoryName = "Horror"
            });
        }

        private static void ProductDetailDTOTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetProductDetails())
            {
                Console.WriteLine(product.ProductName + " -- " + product.CategoryId 
                    + " -- " + product.CategoryName);
            }
        }

        private static void ProductTest()
        {
            Console.WriteLine("Ürünlerden fiyatı 50-70 arasını listeleme: ");
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetByUnitPrice(50, 70))
            {
                Console.WriteLine(product.ProductName);
            }

            Console.WriteLine("Tüm ürünlerin bilgilerini listeleme: ");
            ProductManager productManager2 = new ProductManager(new EfProductDal());
            foreach (var product in productManager2.GetAll())
            {
                Console.WriteLine("\nid: " + product.ProductId + "\nname: " + product.ProductName
                    + "\nunit price: " + product.UnitPrice + "\ncategory id: " + product.CategoryId);
            }

            /*Console.WriteLine("Add new product: ");
            ProductManager productManager3 = new ProductManager(new EfProductDal());
            productManager3.Insert(new Product { 
                 ProductId = 5, 
                 CategoryId = 4,
                 ProductName = "Chernobylite",
                 UnitPrice = 89
            });

            Console.WriteLine("Delete product: ");
                ProductManager deleteCar = new ProductManager(new EfProductDal());
                deleteCar.Delete(new Product { ProductId = 1 }); 

            Console.WriteLine("Update new product: ");
            ProductManager productManager4 = new ProductManager(new EfProductDal());
            productManager3.Update(new Product
            {
                ProductId = 5,
                CategoryId = 4,
                ProductName = "Chernobylite",
                UnitPrice = 99
            }); */
        }
    }
}
