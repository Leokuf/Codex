## LINQ: Language Integrated Query
LINQ can be used for MongoDB, SQL, File System, JSON

~~~
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction 
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\windows";
            ShowLargeFilesWIthoutLinq(path);
        }

        private static void ShowLargeFilesWithLinq(string path)
        {
            var query = from file in new DirectoryInfo(path).GetFiles()
                        orderby file.Length descending
                        select file;
            foreach (var file in query.Take(5))
            {
                Console.WriteLine($"{file.Name,-20} : {file.Length,10:N0}"); 
            }
        }

        private static void ShowLargeFilesWIthoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path");
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileInfoComparer());
            for(int i = 0; i < 5; i++>)
            {
                FileInfo file = files[i];
                Console.WriteLine($"{file.Name,-20} : {file.Length,10:N0}"); 
            }
        }
    }

    public class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}

~~~

## Creating Extension Methods

- First parameter of an extension method uses 'this' modifier.
- Below parameter is custom extension method.

~~~
public static class StringExtensions
{
    static public double ToDouble(this string data)
    {
        double result = double.Parse(data);
        return result;
    }
}
~~~

Importing 'using System.Linq;' into project allows you access <Count>, <OrderBy>, and dozens more extension methods that LINQ defines.


## Lambda Expressions

~~~
// Named Method
IEnumerable<string> filteredList = 
            cities.Where(StartsWithL);

public bool StartsWithL(string name)
{
    return name.StartsWith("L");
}

// Anonymous Method
IEnumerable<string> filteredList =
    cities.Where(delegate(string s))
            { return s.StartsWith("L"); });

// Lambda Expression ( an eveolution of Named Methods and Anonymous methods)
IEnumerable<string> filteredList =
    cities.Where(s => s.StartsWith("L"));


// Example Lambda Expression in use
foreach (var employee in developers.Where(
                e => e.Name.StartsWith("S");))
{
    Console.WriteLine(employee.Name);
}

~~~

- Func<> type introduced as an easy way to work with Delegates.
- Delegates are types that allow you to create variables that point to methods.

~~~
Func<int, int> f = x => x * x;
// Above takes an int and returns an int squared.
Func<int, int, int> add = (int x, int y) => x + y;
// Above takes two int parameters and adds them

~~~

## Query Syntax
- Query syntax starts with from
- Query ends with select or group
~~~
string[] cities = {
    "Boston", "Los Angeles", "Seattle", "London", "Hyderabad" };
}

IEnumerable<string> filteredCities =
    from city in cities
    where city.StartsWith("L") && city.Length < 15
    orderby city
    select city;

~~~

## Query Syntax vs Method Syntax
- There are benefits to both regarding maintainability and user preference.

~~~
// Method Syntax
var query = developers.Where(e => e.Name.Length == 5)
                      .OrderBy(e => e.Name)
                      .Select(e => e);
// Query Syntax
var query 2 = from developer in developers
              where developer.Name.Length == 5
              orderby develoepr.Name
              select developer;
~~~

## LINQ Queries
~~~

// Movie.cs
namespace Queries
{
    public class Movie
    {
        public string Title { get; set; }
        public float Rating { get; set; }

        // property is private
        int _year;
        public int Year 
        {   get
            {
                Console.WriteLine($"Returning {_year} for {Title}");w
                return _year;
            }
        
            }
            set
            {
                _year = value;
            }
    }
}

// Program.cs
using System;
using System.Collections.Generic;
using System.Linq;


namespace Queries 
{
    class Program 
    {
        static void Main(string[] args)
        {
            var movies = new List<Movie>
            {
                new Movie { Title = "The Dark Knight", Rating = 8.9f, Year = 2001 }
                new Movie { Title = "The Matrix", Rating = 8.9f, Year = 1999 }
            };

            var query = movies.Filter(m => m.Year > 2000);

            foreach (var movie in query)
            {
                Console.WriteLine(movie.Title);
            }
        }
    }
}

// MyLinq.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries 
{
    public static class MyLinq
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)

        {
            var result = new List<T>();

            foreach (var item in source)
            {
                if(predicate(item))
                {
                    // yield help builds an IEnumerable
                    // execution starts in this filter method, yield yields control back to the caller
                    yield return item;
                }
            }
            return result;
        }
    }
}

~~~


## Deferred Execution
- LINQ is as lazy as possible and does the least amouunt of work possible.
- Query does no real work until we fortce the query to produce a result.
- We define a query and then execute the query with an operation.

## Implementing a file processor

~~~
// Program.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessFile("fuel.csv");

            var query = 
                from car in cars
                where car.Manufacturer == "BMW" && car.Year == 2016
                orderby car.Combined descending, car.Name ascending
                select car;

            var top = 
                cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                    .OrderByDescending(c => c.Combined)
                    .ThenBy(c => c.Name)
                    .Select(c => c)
                    .First();

            foreach(var car in query.Take(10))
            {
                Console.WriteLine($"{car.Name} : {car.Combined}");
            }
        }

        private static List<Car> ProcessFile(string path)
        {
            var query =
                from line in File.ReadAllLines(path).Skip(1)
                where line.Length > 1
                select Car.ParseFromCsv(line);
            
            return query.ToList();
        }
    }
}


// Car.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Car
    {
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Displacement { get; set; }
        public int Combined { get; set; }

        internal static Car ParseFromCsv(string line)
        {
            var columns = line.Split(',');
            return new Car
            {
                Year = int.Parse(columns[0]),
                Manufacturer = columns[1],
                Name = columns[2],
                Displacement = double.Parse(columns[3]),
                Combined = int.Parse(columns[4])
            }
        }
    }
}

~~~
