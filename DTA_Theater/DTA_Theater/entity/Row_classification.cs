using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTA_Theater.entity
{
    class Row_classification
    {
        private int id;
        private String row_name;
        private String type;

        public Row_classification(int id, string row_name, string type)
        {
            this.Id = id;
            this.Row_name = row_name;
            this.Type = type;
        }

        public int Id { get => id; set => id = value; }
        public string Row_name { get => row_name; set => row_name = value; }
        public string Type { get => type; set => type = value; }

        public override string ToString()
        {
            return Id + " | " + Row_name + " | " + type;
        }
    }
}
