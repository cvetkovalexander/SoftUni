﻿

using System.ComponentModel.Design;
using System.Globalization;

class Program
    {
        static void Main()
        {
            string typeOfDay = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            var price = 0;

            switch (typeOfDay)
        {
            case "Weekday":
                if (age >= 0 && age <= 18)
                {
                    price = 12;
                }
                if (age > 18 && age <= 64)
                {
                    price = 18;
                }
                if (age > 64 && age <= 122)
                {
                    price = 12;
                }
                break;
            case "Weekend":
                if (age >= 0 && age <= 18)
                {
                    price = 15;
                }
                if (age > 18 && age <= 64)
                {
                    price = 20;
                }
                if (age > 64 && age <= 122)
                {
                    price = 15;
                }
                break;
            case "Holiday":
                if (age >= 0 && age <= 18)
                {
                    price = 5;
                }
                if (age > 18 && age <= 64)
                {
                    price = 12;
                }
                if (age > 64 && age <= 122)
                {
                    price = 10;
                }
                break;
        }
        if (price != 0)
        {
            if (age < 0 || age > 122)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                Console.WriteLine($"{price}$");
            }
        }
        else
        {
            Console.WriteLine("Error!");
        }
       
        
        
        
      
        
        }
    }

