using System.Diagnostics.Metrics;
using L2O___D09;
using static L2O___D09.ListGenerators;

namespace TaskSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Restriction Operators
            //all products that are out of stock.

            var OutOfStock = ProductList.Where(x => x.UnitsInStock == 0);
            Console.WriteLine("\n\n out of stock Products are :\n");
            foreach (var Product in OutOfStock)
            {
                Console.WriteLine(Product);
            }




            // all products that are in stock and cost more than 3.00 per unit..


            var InStockProducts = ProductList.Where(x => x.UnitsInStock != 0 && x.UnitPrice > 3);
            Console.WriteLine("\n\n In stock Products  and cost more than 3.00 per unit are :\n");
            foreach (var Product in OutOfStock)
            {
                Console.WriteLine(Product);
            }


            // digits whose name is shorter than their value.


            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            IEnumerable<int> indecies = Enumerable.Range(0, 10);
            var myDigits = indecies.Where(x => Arr[x].Length >x);


            Console.WriteLine("\n\n\nDigits whose name is shorter than their value.\n");
            foreach (var digit in myDigits)
            {
                Console.WriteLine(digit);
            }

            #endregion

            #region - Element Operators:

            //  first Product out of Stock 

            Console.WriteLine("\n\nfirst Product out of Stock : \n");
            Console.WriteLine(OutOfStock.First());

            


            // first product whose Price > 1000 :
            Console.WriteLine("\n\n first product whose Price > 1000: \n");
            //var prod = ProductList.Where(x=> x.UnitPrice > 1000).First();  //Exception 
            var prod = ProductList.Where(x => x.UnitPrice > 1000).FirstOrDefault();
            if (prod == null) Console.WriteLine("No productmaches that ...");
            



            
            int[] Arr2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var num = Arr2.Where(x => x > 5 && x !=Arr2.Where(x => x > 5).Order().First()).Order().First();

            Console.WriteLine($"the second number greater than 5 in array {{ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }} is : {num}");


            #endregion



            #region - Set Operators
            Console.WriteLine("\n\nCategories : ");
            var catiguriesNames =ProductList.Select(p=>p.Category).Distinct();
            foreach(var cat in catiguriesNames) Console.WriteLine(cat);



            var uniqueFirstLetters = ProductList.Select(p => p.ProductName.FirstOrDefault())
                .Union(CustomerList.Select(c => c.CompanyName.FirstOrDefault()))
                .Where(c => c != '\0');

            Console.WriteLine("\n\nUnique first letters from Customer and Product names:");
            Console.WriteLine(string.Join(", ", uniqueFirstLetters));

            var CommonFirstLetters = ProductList.Select(p => p.ProductName.FirstOrDefault())
                .Intersect(CustomerList.Select(c => c.CompanyName.FirstOrDefault()))
                .Where(c => c != '\0');

            Console.WriteLine("\n\nThe common first letter from both product and customer names:");
            Console.WriteLine(string.Join(", ", CommonFirstLetters));


            var FirstLettersinProductNamesOnly = ProductList.Select(p => p.ProductName.FirstOrDefault())
                .Except(CustomerList.Select(c => c.CompanyName.FirstOrDefault()))
                .Where(c => c != '\0');

            Console.WriteLine("\n\nThe first letters of product names that are not also first letters of customer names:");
            Console.WriteLine(string.Join(", ", FirstLettersinProductNamesOnly));

            var LastThreeLetters = ProductList.Select(p => p.ProductName.Length > 3 ? p.ProductName[^3..] : p.ProductName)
                .Concat<string>(CustomerList.Select(c => c.CompanyName.Length > 3 ? c.CompanyName[^3..]:c.CompanyName))
                .Where(c => c != null);

            Console.WriteLine("\n\nThe last Three Characters in each names of all customers and products, including any duplicates:");
            Console.WriteLine(string.Join(", ", LastThreeLetters));
            #endregion

            #region - Aggregate Operators

            int[] Arr3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            Console.WriteLine($"\n\nWe have {Arr3.Count(a=>a%2==1)} Odd numbers\n");


            var CustomersOrders =CustomerList.Select(customer => new { 
                                        customer.CustomerID, 
                                        customer.CompanyName, 
                                        OrderCount = customer.Orders.Count() 
                                    }).ToList();

            Console.WriteLine("Customers and how many orders each has.");
            foreach (var customer in CustomersOrders)
            {
                Console.WriteLine($"{customer.CustomerID} - {customer.CompanyName} - has {customer.OrderCount} orders");
            }



            /**
             * . Return a list of categories and how many products each has
             */

            //Syntax Query:
            var CategoriesAndProducts = from p in ProductList
                                        group p by p.Category into categoryGroup
                                        select new
                                        {
                                            Category = categoryGroup.Key,
                                            ProductCount = categoryGroup.Count()
                                        };

            //Mehod Query :
            var CategoriesAndProducts2 = ProductList
                                        .GroupBy(p => p.Category)
                                        .Select(g => new 
                                        { 
                                            Category = g.Key, 
                                            ProductCount = g.Count() 
                                        });


            /**
             * 4. Get the total of the numbers in an array.
             */

            int[] Arr4 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            Console.WriteLine($"\n\nArray sum = {Arr4.Sum()}");





            /**
             * 5. Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
             */
            string[] dictionary_english = File.ReadAllLines("dictionary_english.txt");
            long totalCharacters = dictionary_english.Sum(x => x.Length);
            Console.WriteLine($"\n\nTotal number of characters in all words: {totalCharacters}");



            /**
             * 6. Get the total units in stock for each product category.
             */
            var TotalUnitsInStockPerCategory = ProductList.GroupBy(p => p.Category).Select(i => new { Category = i.Key , TotalUnits = i.Sum(p=>p.UnitsInStock) });

            Console.WriteLine("\n\nThe total units in stock for each product category:");
            foreach (var item in TotalUnitsInStockPerCategory)
            {
                Console.WriteLine($"Category: {item.Category}, Total Units in Stock: {item.TotalUnits}");
            }

            /**
             * 7. Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
             */

            string[] dictionary_english2 = File.ReadAllLines("dictionary_english.txt")
                                                .SelectMany(line => line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries))
                                                .ToArray();
            int shortestWordLength = dictionary_english2.Where(word => !string.IsNullOrWhiteSpace(word))
                                                  .Min(word => word.Length);
            Console.WriteLine($"\n\nThe length of shortest word in dictionary_english.txt: {shortestWordLength}");

            /**
             *             8. Get the cheapest price among each category's products
             */
            var CheapestPriceInCategory = ProductList.GroupBy(p=>p.Category)
                                                     .Select(i => new {
                                                         Category = i.Key , 
                                                         CheapestPrice = i.Min(prod=>prod.UnitPrice) 
                                                     });

            //Query syntax:
            var CheapestPriceInCategoryQuery = from pro in ProductList
                                               group pro by pro.Category into CProducts
                                               select new
                                               {
                                                   Category = CProducts.Key,
                                                   MinPrice = CProducts.Min(p => p.UnitPrice)
                                               };

            Console.WriteLine("\n\n The cheapest price among each category's products:");
            foreach(var item in CheapestPriceInCategory) 
                Console.WriteLine($"In {item.Category} the Cheapest Price is {item.CheapestPrice}");



            /**
             * 9. Get the products with the cheapest price in each category (Use Let)
             */
            var CheapestProductInCategoryQuery =from pro in ProductList
                                                group pro by pro.Category into CProducts
                                                let minPrice = CProducts.Min(p => p.UnitPrice)
                                                from _prod in CProducts
                                                where _prod.UnitPrice == minPrice
                                                select new
                                                {
                                                    Category = _prod.Category,
                                                    ProductName = _prod.ProductName,
                                                    Price = _prod.UnitPrice
                                                };

            Console.WriteLine("\n\nProducts with the cheapest price in each category:");
            foreach (var item in CheapestProductInCategoryQuery)
                Console.WriteLine($"Category: {item.Category}, Product: {item.ProductName}, Price: {item.Price}");


            /**
             *             10. Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
             */

            string[] Words = File.ReadAllLines("dictionary_english.txt")
                                                .SelectMany(line => line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries))
                                                .ToArray();
            int LengthOfLongestWord = Words.Where(word => !string.IsNullOrWhiteSpace(word))
                                                  .Max(word => word.Length);
            Console.WriteLine($"\n\nThe length of Longest word in dictionary_english.txt: {LengthOfLongestWord}");



            /*
            Use ListGenerators.cs & Customers.xml
            11. Get the most expensive price among each category's products.
            12. Get the products with the most expensive price in each category.
            13. Get the average length of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            14. Get the average price of each category's products.

         //// LINQ - Ordering Operators
            Use ListGenerators.cs & Customers.xml
            1. Sort a list of products by name
            2. Uses a custom comparer to do a case-insensitive sort of the words in an array.
            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            Use ListGenerators.cs & Customers.xml
            3. Sort a list of products by units in stock from highest to lowest.
            4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            5. Sort first by word length and then by a case-insensitive sort of the words in an array.
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            Use ListGenerators.cs & Customers.xml
            6. Sort a list of products, first by category, and then by unit price, from highest to lowest.
            7. Sort first by word length and then by a case-insensitive descending sort of the words in an array.
            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            8. Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };


         ////LINQ - Partitioning Operators

            Use ListGenerators.cs & Customers.xml
            1. Get the first 3 orders from customers in Washington
            2. Get all but the first 2 orders from customers in Washington.
            3. Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.
              int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            4. Get the elements of the array starting from the first element divisible by 3.
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            5. Get the elements of the array starting from the first element less than its position.
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

         ////LINQ - Projection Operators

            Use ListGenerators.cs & Customers.xml
            1. Return a sequence of just the names of a list of products.
            2. Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).
              string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            Use ListGenerators.cs & Customers.xml
            3. Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.
            4. Determine if the value of ints in an array match their position in the array.
                int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            Result
            Number: In-place?
            5: False
            4: False
            1: False
            3: True
            9: False
            8: False
            6: True
            7: True
            2: False
            0: False

            5. Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            Result
            Pairs where a < b:
            0 is less than 1
            0 is less than 3
            0 is less than 5
            0 is less than 7
            0 is less than 8
            2 is less than 3
            2 is less than 5
            2 is less than 7
            2 is less than 8
            4 is less than 5
            4 is less than 7
            4 is less than 8
            5 is less than 7
            5 is less than 8
            6 is less than 7
            6 is less than 8

            Use ListGenerators.cs & Customers.xml
            6. Select all orders where the order total is less than 500.00.
            7. Select all orders where the order was made in 1998 or later.


         ////LINQ - Quantifiers

            1. Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.

            Use ListGenerators.cs & Customers.xml
            2. Return a grouped a list of products only for categories that have at least one product that is out of stock.
            3. Return a grouped a list of products only for categories that have all of their products in stock.

         ////LINQ - Grouping Operators
            1. Use group by to partition a list of numbers by their remainder when divided by 5
            Output: 
            Numbers with a remainder of 0 when divided by 5:
            0
            5
            10
            Numbers with a remainder of 1 when divided by 5:
            1
            6
            11
            Numbers with a remainder of 2 when divided by 5:
            7
            2
            12
            Numbers with a remainder of 3 when divided by 5:
            3
            8
            13
            Numbers with a remainder of 4 when divided by 5:
            4
            9
            14

            2. Uses group by to partition a list of words by their first letter.
            Use dictionary_english.txt for Input

            3. Consider this Array as an Input 
            string[] Arr = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };

            Use Group By with a custom comparer that matches words that are consists of the same Characters Together
            Result
            ...
            from 
            form 
            ...
            salt
            last 
            ...
            earn 
            near


             */


            #endregion







        }
    }
}
