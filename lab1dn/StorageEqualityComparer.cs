using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLibrary
{
    class StorageEqualityComparer : IEqualityComparer<Storage>
    {
        public bool Equals(Storage storage1, Storage storage2)
        {
            if (storage1._StorageID == storage2._StorageID
                  && storage1._CurrentWeight == storage2._CurrentWeight
                  && storage1._MaxWeight == storage2._MaxWeight)
                return true;
            else return false;
        }

        public int GetHashCode(Storage obj)
        {
            return obj._StorageID;
        }
    }

}
