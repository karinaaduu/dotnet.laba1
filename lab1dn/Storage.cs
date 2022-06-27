using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLibrary
{
    public class Storage
    {
        public int _StorageID { get; set; }
        public double _CurrentWeight { get; set; }
        public double _MaxWeight { get; set; }

        public override string ToString()
        {
            return string.Format(@"Склад: 
                Номер склада {0}            
                Поточна наповненiсть {1} кг
                Максимальна наповненiсть {2} кг", _StorageID, _CurrentWeight, _MaxWeight);
        }
    }

}
