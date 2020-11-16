using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTA_Theater
{
    class Seat
    {
        private int _id;
        private String _name;
        private String _type;

        public Seat(int id, string name, string type)
        {
            Id = id;
            Name = name;
            Type = type;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Type { get => _type; set => _type = value; }
    }
}
