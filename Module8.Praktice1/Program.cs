using System;
using System.Collections.Generic;
using System.Linq;

class RangeOfArray
{
    int[] arr;

    public RangeOfArray(int range)
    {
        arr = new int[range];
        Random rnd = new Random();
        for (int i = 0; i < range; i++)
        {
            arr[i] = rnd.Next(1, 20);
        }
    }

    public int this[int i]
    {
        get
        {
            if (i < 1)
            {
                throw new IndexOutOfRangeException("Index out of range (<1)");
            }
            else if (i > arr.Length)
            {
                throw new IndexOutOfRangeException("Index out of range (>n)");
            }
            else
            {
                return arr[i - 1];
            }
        }
    }

    public override string ToString()
    {
        string res = null;
        for (int i = 0; i < arr.Length; i++)
        {
            res += arr[i] + " ";
        }
        return res;
    }
}

public class Product
{
    public double Price { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
}

public class SerivceProduct
{
    List<Product> products = null;

    public SerivceProduct()
    {
        products = new List<Product>();
        products.Add(new Product() { Price = 1000, Name = "Milk", Category = "Milk" });
        products.Add(new Product() { Price = 300, Name = "Cucumber", Category = "Ovoshi" });
        products.Add(new Product() { Price = 2000, Name = "Turkey", Category = "Meat" });
    }

    public double this[string Category]
    {
        get
        {
            double sum = 0;

            foreach (Product item in products.Where(w => w.Category == Category))
            {
                sum += item.Price;
            }
            TimeSpan StartTime = new TimeSpan(8, 0, 0);
            TimeSpan EndTime = new TimeSpan(9, 0, 0);
            if (DateTime.Now.TimeOfDay > StartTime & DateTime.Now.TimeOfDay < EndTime)
            {
                return sum * 0.95;
            }
            return sum;
        }
    }
}

class LinearRegressionCoefficients
{
    public double A { get; }
    public double B { get; }

    public LinearRegressionCoefficients(double a, double b)
    {
        A = a;
        B = b;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Пример использования RangeOfArray
        RangeOfArray rangeArray = new RangeOfArray(5);
        Console.WriteLine("RangeOfArray: " + rangeArray);

        // Пример использования SerivceProduct
        SerivceProduct sproduct = new SerivceProduct();
        Console.WriteLine("SerivceProduct (Milk): " + sproduct["Milk"]);

        // Пример использования прогнозирования объемов продаж
        double[] salesData = ReadSalesData("sales_data.txt");
        LinearRegressionCoefficients coefficients = CalculateLinearRegression(salesData);
        double[] forecast = ForecastNextMonths(coefficients);

        // Вывести результат прогноза
        Console.WriteLine("Прогноз объемов продаж на следующие три месяца:");
        for (int i = 0; i < forecast.Length; i++)
        {
            Console.WriteLine($"Месяц {i + 1}: {forecast[i]}");
        }

        Console.ReadKey();
    }

    static double[] ReadSalesData(string filePath)
    {
        return new double[] { 100, 120, 130, 140, 150 };
    }

    static LinearRegressionCoefficients CalculateLinearRegression(double[] yValues)
    {
        int n = yValues.Length;
        double xSum = Enumerable.Range(1, n).Sum();
        double ySum = yValues.Sum();
        double xySum = Enumerable.Range(1, n).Select((x, i) => x * yValues[i]).Sum();
        double xSquareSum = Enumerable.Range(1, n).Select(x => x * x).Sum();

        double a = (n * xySum - xSum * ySum) / (n * xSquareSum - xSum * xSum);
        double b = (ySum - a * xSum) / n;

        return new LinearRegressionCoefficients(a, b);
    }

    static double[] ForecastNextMonths(LinearRegressionCoefficients coefficients)
    {
        double[] forecast = new double[3];
        for (int i = 1; i <= 3; i++)
        {
            forecast[i - 1] = coefficients.A * (coefficients.B + i);
        }
        return forecast;
    }
}
