using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using static Day1.ListGenerators;
namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Restriction Operators
            //1. Find all products that are out of stock.
            /*var q1 = ProductList.Where(n => n.UnitsInStock == 0);
            foreach (var n in q1) 
            {
                Console.WriteLine(n);
            }*/

            //2. Find all products that are in stock and cost more than 3.00 per unit.
            /*var q2 = ProductList.Where(n => n.UnitsInStock != 0 && n.UnitPrice > 3);
            foreach (var n in q2)
            {
                Console.WriteLine(n);
            }*/

            //. Returns digits whose name is shorter than their value
            /*string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var q3 = Arr.Where((n, index) => n.Length > index);
            foreach (var n in q3)
            {
                Console.WriteLine(n);
            }*/
            #endregion

            #region  Element Operators
            //1. Get first Product out of Stock 
            /*var q4 = ProductList.Where(n => n.UnitsInStock == 0).Take(1).Single();
            Console.WriteLine(q4);

            //2. Return the first product whose Price > 1000, unless there is no match,
            //in which case null is returned
            var q5 = ProductList.Where(n=>n.UnitPrice>1000).FirstOrDefault();
            Console.WriteLine(q5);

            //3. Retrieve the second number greater than 5 
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var q6 = Arr.Where(n=>n>5).Take(2).Skip(1).Single();
            Console.WriteLine(q6);*/
            #endregion

            #region Set Operators
            //1. Find the unique Category names from Product List
            /*var q7 = ProductList.Select(n => n.Category).Distinct();
          foreach (var q in q7) 
           {
               Console.WriteLine(q);
           }

            //2. Produce a Sequence containing the unique first letter 
            //from both product and customer names.
            var q8 = ProductList.Zip(CustomerList,
             (n1, n2) => $"{n1.ProductName[0]}{n2.CompanyName[0]}");

            foreach (var q in q8)
            {
                Console.WriteLine(q);
            }


            //3. Create one sequence that contains the common
            //first letter from both product and customer names.
            var q9 = ProductList.Select(n => n.ProductName[0])
                .Intersect(CustomerList.Select(n => n.CompanyName[0]));

            foreach (var q in q9) 
            {
                Console.WriteLine(q);
            }


            //Create one sequence that contains the first letters of product names
            //that are not also first letters of customer names.

            var q10 = ProductList.Select(n => n.ProductName[0])
                .Except(CustomerList.Select(n => n.CompanyName[0]));
            foreach (var q in q10) 
            {
                Console.WriteLine(q);
            }


            //5. Create one sequence that contains the last Three Characters
            //in each names of all customers and products, including any duplicates

            var q11 = ProductList.Select(n => n.ProductName.Substring(n.ProductName.Length - 3))
                .Concat(CustomerList.Select(n => n.CompanyName.Substring(n.CompanyName.Length - 3)));
            foreach (var q in q11) 
            {
                Console.WriteLine(q);
            }*/
            #endregion

            #region Aggregate Operators
            //1. Uses Count to get the number of odd numbers in the array
            /*int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var q12 = Arr.Where(n => n % 2 != 0);
            foreach (var q in q12) 
            {
                Console.WriteLine(q);
            }

            //2. Return a list of customers and how many orders each has.
            var q13 = CustomerList
               .Select(c => $"{c.CompanyName} {c.Orders.Length} ");

            foreach (var q in q13)
            {
                Console.WriteLine(q);
            }

            //3. Return a list of categories and how many products each has
            var q14 = ProductList.GroupBy(d => d.Category)
                .Select(p => new { Categories = p.Key , Product = p.Count()});
            foreach (var q in q14) 
            {
                Console.WriteLine(q);
            }

            //4. Get the total of the numbers in an array.
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var q15 = Arr.Sum();
            Console.WriteLine(q15);

            //5. Get the total number of characters of all words in
            //dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            string[] words = File.ReadAllLines("dictionary_english.txt");
            int q16 = words.Sum(w => w.Length);
            Console.WriteLine($"Total char = {q16}");

            //6. Get the total units in stock for each product category.
            var q17 = ProductList.GroupBy(g => g.Category)
                .Select(p => new { Category = p.Key, totalUnit = p.Sum(u=>u.UnitsInStock) });
            foreach (var q in q17)
            {
                Console.WriteLine(q);
            }

            //7. Get the length of the shortest word in dictionary_english.txt
            //(Read dictionary_english.txt into Array of String First).
            string[] words = File.ReadAllLines("dictionary_english.txt");
            var q18 = words.Min(x => x.Length);
            Console.WriteLine(q18);

            //. Get the cheapest price among each category's products
            var q19 = ProductList.GroupBy(g => g.Category)
                .Select(p => new
                {
                    Category = p.Key,
                    CheapestPrice = p.Min(c => c.UnitPrice)
                });
            foreach (var q in q19)
            {
                Console.WriteLine(q);
            }

            // Get the products with
            // the cheapest price in each category(Use Let)
            var q20 = from p in ProductList
                      group p by p.Category into g
                      let CheapestPrice = g.Min(c => c.UnitPrice)
                      select new { Cateogry = g.Key, CheapestPrice = CheapestPrice };
            foreach (var q in q20) 
            {
                Console.WriteLine(q);
            } 

            //10. Get the length of the longest word in dictionary_english.txt
            //(Read dictionary_english.txt into Array of String First).
            string[] words = File.ReadAllLines("dictionary_english.txt");
            var q21 = words.Max(x => x.Length);
            Console.WriteLine(q21);

            //11. Get the most expensive price among each category's products.
            var q21 = ProductList.GroupBy(g => g.Category)
                .Select(p => new { Category = p.Key, ExpensivePrice = p.Max(p => p.UnitPrice) });
            foreach (var q in q21)
            {
                Console.WriteLine(q);
            }

            //12. Get the products with the most expensive price in each category.
            var q22 = ProductList.GroupBy(g => g.Category)
                .SelectMany(g => g.Where(p => p.UnitPrice == g.Max(p => p.UnitPrice))
                .Select(c => new { catogry = g.Key, product = c }));
            foreach (var q in q22)
            {
                Console.WriteLine(q);
            }

            //13. Get the average length of the words in dictionary_english.txt
            //(Read dictionary_english.txt into Array of String First).
            string[] words = File.ReadAllLines("dictionary_english.txt");
            var q23 = words.Average(x => x.Length);
            Console.WriteLine(q23);

            //14. Get the average price of each category's products.
            var q24 = ProductList.GroupBy(g => g.Category)
                .Select(n => new
                {
                    Catogry = n.Key,
                    AvgPrice = n.Average(p => p.UnitPrice)
                });
            foreach (var q in q24)
            {
                Console.WriteLine(q);
            }*/
            #endregion

            #region Ordering Operators
            //1. Sort a list of products by name
            /*var q25 = ProductList.OrderBy(s => s.ProductName);
            foreach (var q in q25) 
            {
                Console.WriteLine(q);
            }

            //2. Uses a custom comparer
            //to do a case-insensitive sort of the words in an array.
            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var q26 = Arr.OrderBy(s => s, new CaseSentitveComparer());
            foreach (var q in q26) 
            {
                Console.WriteLine(q);
            }

            //3. Sort a list of products by units in stock from highest to lowest.
            var q27 = ProductList.OrderByDescending(p => p.UnitPrice);
            foreach (var q in q27)
            {
                Console.WriteLine(q);
            }

            //4. Sort a list of digits, first by length of their name
            //, and then alphabetically by the name itself
            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var q28 = Arr.OrderBy(a => a.Length).ThenBy(p => p); 
            foreach (var q in q28)
            {
                Console.WriteLine(q);
            }
            // 5.Sort first by word length and then by a case
            // -insensitive sort of the words in an array.
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var q29 = words.OrderBy(a => a.Length).ThenBy(p => p ,new CaseSentitveComparer());
            foreach (var q in q29)
            {
                Console.WriteLine(q);
            }

            //6. Sort a list of products, first by category,
            //and then by unit price, from highest to lowest.
            var q30 = ProductList.OrderBy(a => a.Category).ThenByDescending(p => p.UnitPrice);
            foreach (var q in q30)
            {
                Console.WriteLine(q);
            }

            //7. Sort first by word length and then by a case-insensitive descending
            //sort of the words in an array.

            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var q31 = Arr.OrderBy(a => a.Length).ThenByDescending(p => p, new CaseSentitveComparer());
            foreach (var q in q31)
            {
                Console.WriteLine(q);
            }

            //8. Create a list of all digits in the array whose second letter is 'i'
            //that is reversed from the order in the original array

            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var q32 = Arr.Where(p => p.Length > 1 && p[1] == 'i') 
                .Reverse();
            foreach (var q in q32) 
            {
                Console.WriteLine(q);
            }*/
            #endregion

            #region Partitioning Operators
            //1. Get the first 3 orders from customers in Washington
            /*var q33 = CustomerList.Where(p => p.City == "Washington").Take(3);
            foreach (var q in q33) 
            {
                Console.WriteLine(q);
            }

            //2. Get all but the first 2 orders from customers in Washington.
            var q34 = CustomerList.Where(p => p.City == "Washington").Skip(2);
            foreach (var q in q34)
            {
                Console.WriteLine(q);
            }

            //3. Return elements starting from the beginning of the array
            //until a number is hit that is less than its position in the array.

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var q35 = numbers.TakeWhile((item, index) => item > index);

            //4. Get the elements of the array starting
            //from the first element divisible by 3.
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var q36 = numbers.SkipWhile(item => item % 3 !=0);

            //5. Get the elements of the array starting from the first element less than its position.
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var q37 = numbers.SkipWhile((item, index )=>item>index); */
            #endregion

            #region Projection Operators

            //1. Return a sequence of just the names of a list of products.
            /*var q37 = ProductList.Select(p => p.ProductName);

            //2. Produce a sequence of the uppercase and
            //lowercase versions of each word in the original array (Anonymous Types).
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var q38 = words.Select(x => new
            {
                Lower = x.ToLower(),
                Upper = x.ToUpper()
            }).ToList();


            //3. Produce a sequence containing some properties of Products
            //, including UnitPrice which 

            var q39 = ProductList.Select(c => new { Name = c.ProductName, Price = c.UnitPrice });


            //4. Determine if the value of ints in an array match their position in the array.
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var q40 = Arr.Select((n, i) => new
            {
                Index = n,
                position = n == i
            });

            //5. Returns all pairs of numbers from both arrays such that the number from
            //numbersA is less than the number from numbersB.
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var q41 = numbersA.SelectMany(a => numbersB.Where(b => a < b)
                      .Select(b => new { A = a, B = b })
            );


            //6. Select all orders where the order total is less than 500.00.
            var q41 = CustomerList.SelectMany(p=>p.Orders).Where(c=>c.Total>500);


            //7. Select all orders where the order was made in 1998 or later.
            var q42 = CustomerList.SelectMany(p => p.Orders).Where(c => c.OrderDate.Year >= 1998); */
            #endregion

            #region Quantifiers
            //Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.
            /*string[] words = File.ReadAllLines("dictionary_english.txt");
            var q43 = words.Any(x => x.Contains("ei"));


            //2. Return a grouped a list of products only for categories
            //that have at least one product that is out of stock.

            var q44 = ProductList.GroupBy(p => p.Category)                   
                      .Where(g => g.Any(p => p.UnitsInStock == 0)).ToList();

            //3. Return a grouped a list of products only for categories that have all of their products in stock.
            var q45 = ProductList.GroupBy(p => p.Category)
                      .Where(g => g.All(p => p.UnitsInStock > 0)); */
            #endregion


           
        }
    }
}
