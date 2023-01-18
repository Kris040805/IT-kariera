using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularExam
{
    class FlowerStore
    {
        private string name;
        List<Flower> flowersList = new List<Flower>(); 

        
        public FlowerStore(string name)
        {
            this.Name = name;
            new List<Flower>();
        }

        public string Name
        {
            get { return name; }
            set {
                if (value.Length<6)
                {
                    throw new ArgumentException("Invalid flower store name!");
                }
                name = value; 
            }
        }

        public void AddFlower(Flower flower)
        {
            flowersList.Add(flower);
        }

        public bool SellFlower(Flower flower)
        {
            if (flowersList.Contains(flower))
            {
                flowersList.Remove(flower);
                return true;
            }
            return false;
        }

        public double CalculateTotalPrice()
        {
            double result = 0;
            foreach (Flower flower in flowersList)
            {
                result += flower.Price;
            }

            return result;
        }

        public Flower GetFlowerWithHighestPrice()
        {
            Flower highestPriceFlower = flowersList[0];
            for (int i = 0; i < flowersList.Count; i++)
            {
                if (flowersList[i].Price > highestPriceFlower.Price)
                {
                    highestPriceFlower = flowersList[i];
                }
            }
            return highestPriceFlower;
        }

        public Flower GetFlowerWithLowestPrice()
        {
            Flower lowestPriceFlower = flowersList[0];
            for (int i = 0; i < flowersList.Count; i++)
            {
                if (flowersList[i].Price < lowestPriceFlower.Price)
                {
                    lowestPriceFlower = flowersList[i];
                }
            }
            return lowestPriceFlower;
        }

        public void RenameFlowerStore(string newName)
        {
            this.Name = newName;
        }

        public void SellAllFlowers()
        {
            flowersList.RemoveRange(0, flowersList.Count());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int listCount = flowersList.Count();
            if (listCount >= 1)
            {
                sb.Append($"Flower store {name} has {listCount} flower/s:\n");

                for (int i = 0; i < listCount; i++)
                {
                    Flower flower = flowersList[i];
                    sb.Append($"Flower {flower.Type} with color {flower.Color} costs {(flower.Price):F2}\n");
                }
            }
            else
            {
                sb.Append($"Flower store {name} has no available flowers.");
            }
            return sb.ToString();
        }
    }
}
