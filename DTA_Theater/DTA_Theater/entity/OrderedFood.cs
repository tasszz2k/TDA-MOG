using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTA_Theater.entity
{
    class OrderedFood
    {
        private int id;
        private String name;
        private double price;
        private int quantity;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public OrderedFood(int id, string name, double price, int quantity)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }

        public OrderedFood()
        {
        }

        public override string ToString()
        {
            return "Name: " + Name + " | Quantity" + Quantity + " | Price: " + Price +
                " | Total: " + Quantity * Price;
        }
    }
}
