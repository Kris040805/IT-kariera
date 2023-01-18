using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPreparation
{
    public class Train
    {
        private int number;
        private string name;
        private string type;
        private int cars;

        public Train(int number, string name, string type, int cars)
        {
            this.number = number;
            this.name = name;
            this.type = type;
            this.cars = cars;
        }

        public int Number
        {
            get { return this.number; }
            set { this.number = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Type
        {
            get { return type; }
            set { this.name = value; }
        }

        public int Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }

        public override string ToString()
        {
            return $"{this.Number} {this.Name} {this.Type} {this.Cars}";
        }
    }
}
