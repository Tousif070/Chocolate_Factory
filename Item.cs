using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate_Factory
{
    class Item
    {
        private String name = "";
        private String shortCode = "";
        private double price = 0;

        public void setName(String inputName)
        {
            name = inputName;
        }

        public String getName()
        {
            return name;
        }

        public void setShortCode(String inputShortCode)
        {
            shortCode = inputShortCode;
        }

        public String getShortCode()
        {
            return shortCode;
        }

        public void setPrice(double inputPrice)
        {
            price = inputPrice;
        }

        public double getPrice()
        {
            return price;
        }
    }
}
