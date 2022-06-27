using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductLibrary;


namespace lab1dn
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Storage> storages = new List<Storage>   
            {
                new Storage { _StorageID =  1,
                            _CurrentWeight = 0,
                            _MaxWeight = 1000.88 },

                 new Storage { _StorageID =  2,
                            _CurrentWeight = 0,
                            _MaxWeight = 20000.54 },

                  new Storage { _StorageID =  3,
                            _CurrentWeight = 0,
                            _MaxWeight = 10000.21 },

                   new Storage { _StorageID =  4,
                            _CurrentWeight = 0,
                            _MaxWeight = 15000.33 }

            };
            List<Product> products = new List<Product>
            {
                new Product {                                   //0
                _ProductID = "DF395398",
                _ProductName = "Кава Ground Coffee",
                _ProductWeightPack = 0.5,
                _ProductPrice = 310.64,
                _ManufacturerName = "Dunkin Donuts"
                },
                new Product {                                   //1
                _ProductID = "SW985323",
                _ProductName = "Печиво Choco Cow",
                _ProductWeightPack = 0.7,
                _ProductPrice = 60.34,
                _ManufacturerName = "Milka"
                },
                new Product {                                   //2
                _ProductID = "GT398762",
                _ProductName = "Холодильник GR-187",
                _ProductWeightPack = 61,
                _ProductPrice = 22500.67,
                _ManufacturerName = "Samsung"
                },
                new Product {                                   //3
                _ProductID = "PH761129",
                _ProductName = "Духовка Induction Freestanding Range",
                _ProductWeightPack = 114.67,
                _ProductPrice = 91012.5,
                _ManufacturerName = "Electrolux"
                },
                new Product {                                   //4
                _ProductID = "YU892647",
                _ProductName = "Стiл Solid Acacia Wood ",
                _ProductWeightPack = 43.3,
                _ProductPrice = 16200,
                _ManufacturerName = "Castlery"
                },
                new Product {                                   //5
                _ProductID = "KL064573",
                _ProductName = "Диван Campbelltown",
                _ProductWeightPack = 48.08,
                _ProductPrice = 17010.4,
                _ManufacturerName = "Wayfair"
                },
                 new Product {                                   //6
                _ProductID = "MN456783",
                _ProductName = "Печиво Savoiardi",
                _ProductWeightPack = 1.2,
                _ProductPrice = 110.64,
                _ManufacturerName = "Ital.Tiram"
                },
                new Product {                                   //7
                _ProductID = "IO983012",
                _ProductName = "Буфетниця Solid Acacia Wood ",
                _ProductWeightPack = 38.4,
                _ProductPrice = 20370,
                _ManufacturerName = "Castlery"
                },
                 new Product {                                   //8
                _ProductID = "WE067548",
                _ProductName = "Шоколад Wholenut Caramel ",
                _ProductWeightPack = 0.1,
                _ProductPrice = 55.99,
                _ManufacturerName = "Milka"
                },
                  new Product {                                   //9
                _ProductID = "JK813254",
                _ProductName = "Вафлi Choco Wafer ",
                _ProductWeightPack = 0.03,
                _ProductPrice = 45.9,
                _ManufacturerName = "Milka"
                }
            };
            products[0].ArrivalDate(storages[0],new DateTime(2021, 12, 18), 100);
            products[0].ArrivalDate(storages[0], new DateTime(2022, 1, 11), 150);
            products[0].ArrivalDate(storages[0], new DateTime(2022, 2, 16), 200);

            products[1].ArrivalDate(storages[0], new DateTime(2022, 2, 1), 200);
            products[1].ArrivalDate(storages[0], new DateTime(2022, 3, 22), 300);

            products[2].ArrivalDate(storages[1], new DateTime(2022, 2, 4), 50);
            products[2].ArrivalDate(storages[1], new DateTime(2022, 4, 28), 70);

            products[3].ArrivalDate(storages[1], new DateTime(2022, 5, 21), 100);

            products[4].ArrivalDate(storages[2], new DateTime(2022, 3, 2), 50);
            products[4].ArrivalDate(storages[2], new DateTime(2022, 5, 19), 65);
       
            products[5].ArrivalDate(storages[2], new DateTime(2022, 4, 17), 20);
            products[5].ArrivalDate(storages[2], new DateTime(2022, 6, 5), 30);

            products[6].ArrivalDate(storages[3], new DateTime(2022, 6, 9), 100);

            products[7].ArrivalDate(storages[2], new DateTime(2022, 3, 12), 25);

            getAllProductsAndStorages(products, storages);  
            getTotalProductWeightOnStorages(products);
            getProductPricesMoreThan(products, 1000);
            getMostExpesiveProduct(products);
            getSortedProducts(products, 3);
            getLargestProductsAmountAtStorage(products,3); 
            getDesiredProduct(products, "Печиво");
            getGroupedProducts(products);
            getProductsWithStorages(products,storages);
            getAllProductPrice(products);
            getSelection(products,1000,50000);
            collectionToArray(products);
            collectionZIP(storages);
            collectionsUnion(storages);
            collectionIntersect(storages);
            Console.ReadKey();
        }

        static void getAllProductsAndStorages(List<Product> products, List<Storage> storages)   //1.
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n1. Вивести всi товари на складах");
            Console.ResetColor();

            var selectedproducts = products.Select(row => row);
            foreach (var product in selectedproducts)
            {
                Console.WriteLine(product.ToString());
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВивести всi склади");
            Console.ResetColor();

            foreach (var storage in storages.Select(row=>row))
            {
                Console.WriteLine(storage.ToString());
            }
        }

        static void getTotalProductWeightOnStorages(List<Product> products)     //2.
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n2. Загальна вага всiх товарiв на складах:");
            Console.ResetColor();

            var selectedproducts = from p in products
                         select new { name=p._ProductName,
                                      weight=p.QuantityOfProduct()*p._ProductWeightPack };
            foreach (var row in selectedproducts)
            {
                Console.WriteLine("Продукта {0} всього {1} кг", row.name, row.weight);
            }
        }

        static void getProductPricesMoreThan(List<Product> products, double price)       //3.
        {
            var selectedproducts = from p in products 
                                 where p._ProductPrice>price
                                 orderby p._ProductPrice  
                                 select new {p._ProductName, p._ProductPrice };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n3. Товари, в яких цiна вища {0} грн:", price);
            Console.ResetColor();

            foreach (var row in selectedproducts)
            {
                Console.WriteLine("Товар: {0},  Цiна={1}",row._ProductName,row._ProductPrice);
            }   
        }

        static void getMostExpesiveProduct(List<Product> products) //4.
        {
            var mostExpensiveProduct = products.Aggregate((expensive, next) => expensive._ProductPrice < next._ProductPrice ? next : expensive);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n4. Найдорожчий товар з колекцii: \n");
            Console.ResetColor();
            Console.WriteLine(mostExpensiveProduct.ToString());
        }

        static void getSortedProducts(List<Product> products, int storageID)   //5.
        {
            var selectedproducts = from p in products
                                   where p._productArrivalDates.Any(x => x._ProductStorage._StorageID == storageID)
                                   orderby p._ProductName        
                                   select new { p._ProductID, p._ProductName };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n5. Вiдсортованi товари по алфавiту за назвою на {0} складi: \n", storageID);
            Console.ResetColor();
            foreach (var row in selectedproducts)
            {
                Console.WriteLine("Товар: {0},  Номер={1}", row._ProductName, row._ProductID);
            }
        }

        static void getLargestProductsAmountAtStorage(List<Product> products, int storageID) //6.
        {
            var maxQuantityProduct = products.Where(p => p._productArrivalDates.Any(x => x._ProductStorage._StorageID == storageID)).
                               Aggregate((largest, next) => 
                               largest._productArrivalDates.Sum(x=>x._AmountOfProductPacks) 
                               < next._productArrivalDates.Sum(x => x._AmountOfProductPacks) ? next : largest);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n6. Товар, який поставлявся в найбiльшiй кiлькостi на складi №{0} : ", storageID);
            Console.ResetColor();
            Console.WriteLine(maxQuantityProduct.ToString());
            Console.WriteLine("Його кiлькiсть на складу {0}: {1}",storageID, maxQuantityProduct._productArrivalDates.Sum(x => x._AmountOfProductPacks));
        }

        static void getDesiredProduct(List<Product> products, string productName)     //7. 
        {
            var selectedproducts = from p in products
                                   where p._ProductName.Contains(productName)
                                   select new { p._ProductID, p._ProductName, p._ManufacturerName };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n7. Товари, якi мають в назвi {0} : ",productName);
            Console.ResetColor();
            foreach (var row in selectedproducts)
            {
                Console.WriteLine("Товар: №{0},  {1}\nВиробник: {2}\n",row._ProductID, row._ProductName,row._ManufacturerName);
            }
        }

        static void getGroupedProducts(List<Product> products)    //8.
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n8. Товари, згрупованi по виробникам:");
            Console.ResetColor();
            var selectedproducts = products.GroupBy(g => g._ManufacturerName);
            foreach (var group in selectedproducts)
            {
                Console.WriteLine("Виробник: {0}", group.Key);
                foreach (var row in group)
                {
                    Console.WriteLine("     {0}", row.ToString());
                }
            }
        }

        static void getProductsWithStorages(List<Product> products, List<Storage> storages)     //9.
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n9. Вивiд товарiв з вказанням складiв, на яких вони зберiгаються:");
            Console.ResetColor();

            foreach (var p in products)
            {
                var productsAtStorages = from arrivalDate in p._productArrivalDates
                          join storage in storages on arrivalDate._ProductStorage._StorageID equals storage._StorageID 
                          select new
                          {
                              ProductName = p._ProductName,
                              StorageName = storage._StorageID,
                              ProductID = p._ProductID
                          };
                foreach (var row in productsAtStorages.Distinct())
                {
                    Console.WriteLine("Код товару: {0}          Склад:{2}             Назва товару: {1}", row.ProductID, 
                        row.ProductName, row.StorageName);
                }
            }
        }

        static void getAllProductPrice(List<Product> products)        //10.
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n10. Загальна цiна всiх партiй кожного з товарiв:");
            Console.ResetColor();

            foreach (var product  in products)
            {
                Console.WriteLine("На складi вартiсть всiх партiй товару {0}: ={1} грн",product._ProductName, 
                                                                                              product._productArrivalDates.Sum(x=>x._AmountOfProductPacks)*product._ProductPrice) ;
            }
        }

        static void getSelection(List<Product> products, double start, double end)       //11.
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n11. Використання SkipWhile и TakeWhile. Вивiд товарiв, в яких цiна знаходиться в промiжку ({0};{1}]",start,end);
            Console.ResetColor();

            var selectedProducts = products.OrderBy(x => x._ProductPrice)
                                           .SkipWhile(x => (x._ProductPrice < start))
                                           .TakeWhile(x => x._ProductPrice <= end);
            foreach (var product in selectedProducts)
                Console.WriteLine("Товар:  {0}    Цiна: {1} грн",product._ProductName, product._ProductPrice);
        }

        static void collectionToArray(List<Product> products)      //12.
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n12. Результат перетворюється в масив");
            Console.ResetColor();

            var productsArray = (from p in products select p._ProductName).ToArray();
            Console.WriteLine(productsArray.GetType().Name);
            foreach (var productString in productsArray)
                Console.WriteLine(productString);
        }

        static void collectionZIP(List<Storage> storages)       //13.
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n13. Використання Zip:");
            Console.ResetColor();
            List<Storage> storages2 = new List<Storage>
            {
                   new Storage { _StorageID =  5,
                            _CurrentWeight = 0,
                            _MaxWeight = 2400.88 },

                   new Storage { _StorageID =  6,
                            _CurrentWeight = 0,
                            _MaxWeight = 30100.54 },

                   new Storage { _StorageID =  7,
                            _CurrentWeight = 0,
                            _MaxWeight = 18934.4 },

                   new Storage { _StorageID =  8,
                            _CurrentWeight = 0,
                            _MaxWeight = 100500.2 },
            };

            var ZIPstorages = storages.Zip(storages2, (first, second) => "Номер складiв:                " + first._StorageID+ "        " + second._StorageID+"\n"+
                                                                         "Максимальна наповненiсть: "+first._MaxWeight+"   "+second._MaxWeight + "\n");
            foreach (var row in ZIPstorages)
                Console.WriteLine(row);
        }

        static void collectionsUnion(List<Storage> storages)       //14.
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n14. Union - об'єднання для об'єктiв з виключенням дублiкатiв:");
            Console.ResetColor();
        
            List<Storage> storages2 = new List<Storage>
            {
                   new Storage { _StorageID =  1,
                            _CurrentWeight = 575,
                            _MaxWeight = 1000.88 },

                   new Storage { _StorageID =  2,
                            _CurrentWeight = 18787,
                            _MaxWeight = 20000.54 },

                   new Storage { _StorageID =  5,
                            _CurrentWeight = 0,
                            _MaxWeight = 18934.4 },

                   new Storage { _StorageID =  6,
                            _CurrentWeight = 0,
                            _MaxWeight = 100500.2 },
            };
   
            foreach (var storage in storages.Union(storages2, new StorageEqualityComparer()))
            {
                Console.WriteLine(storage.ToString());
            }
        }
        static void collectionIntersect(List<Storage> storages)    //15. 
        {
            List<Storage> storages2 = new List<Storage>
            {
                   new Storage { _StorageID =  1,
                            _CurrentWeight = 575,
                            _MaxWeight = 1000.88 },

                   new Storage { _StorageID =  2,
                            _CurrentWeight = 18787,
                            _MaxWeight = 20000.54 },

                   new Storage { _StorageID =  5,
                            _CurrentWeight = 0,
                            _MaxWeight = 18934.4 },

                   new Storage { _StorageID =  6,
                            _CurrentWeight = 0,
                            _MaxWeight = 100500.2 },
            };
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n15. Intersect - перетин множин для об'єктiв ");
            Console.ResetColor();

            foreach (var storage in storages.Intersect(storages2, new StorageEqualityComparer()))
            {
                Console.WriteLine(storage.ToString());
            }
        }
    }
}


