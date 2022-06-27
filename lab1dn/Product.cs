using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLibrary
{
    
    public class Product   
    {
        public string _ProductID { get; set; }
        public string _ProductName { get; set; }
        public string _ManufacturerName { get; set; }
        public double _ProductWeightPack { get; set; }
        public double _ProductPrice { get; set; }
        public List<ProductArrivalDates> _productArrivalDates = new List<ProductArrivalDates>();
        public void ArrivalDate(Storage storage, DateTime date, int amount)  
        {
            if (amount * this._ProductWeightPack < storage._MaxWeight - storage._CurrentWeight)
            {
                _productArrivalDates.Add(new ProductArrivalDates
                {
                    _ProductStorage = storage,
                    _Date = date,
                    _AmountOfProductPacks = amount
                });
                storage._CurrentWeight += amount * this._ProductWeightPack;
            }
            else
            {
                Console.WriteLine("Sorry, storage {0} is full. Choose another one.", storage._StorageID);
            }
        }

        public int QuantityOfProduct()
        {
            int quantityOfProduct = 0;
            for (int i = 0; i < _productArrivalDates.Count; i++)
            {
                quantityOfProduct += _productArrivalDates[i]._AmountOfProductPacks;
            }
            return quantityOfProduct;
        }


        public override string ToString()
        {
            return string.Format(@"Товар: 
                Артикул {0} Найменування ""{1}""              
                Вага одиницi {2} кг
                Цiна одиницi {3} грн
                Виробник ""{4}""", _ProductID, _ProductName, _ProductWeightPack, _ProductPrice, _ManufacturerName);
        }
    }

}
