using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDAPI.Models
{
    public class ProductRepository : IProductRepository //uses interface
    {
        //initialize things
        private List<Product> products = new List<Product>();
        private int _nextId = 1;

        public ProductRepository()
            //note that this uses the Add() method defined below
        {
            Add(new Product { Name = "Tomato soup", Category = "Groceries", Price = 1.39M });
            Add(new Product { Name = "Yo-yo", Category = "Toys", Price = 3.75M });
            Add(new Product { Name = "Hammer", Category = "Hardware", Price = 16.99M });
        }

        public IEnumerable<Product> GetAll()
            //returns all products
        {
            return products;
        }

        public Product Get(int id)
            //returns product by id
        {
            return products.Find(p => p.Id == id);
        }

        public Product Add(Product item)
            //adds a new item
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            products.Add(item);
            return item;
        }

        public void Remove(int id)
            //removes item by id
        {
            products.RemoveAll(p => p.Id == id);
        }

        public bool Update(Product item)
            //finds item by id and replaces it with new info
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = products.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            products.RemoveAt(index);
            products.Add(item);
            return true;
        }

    }
}