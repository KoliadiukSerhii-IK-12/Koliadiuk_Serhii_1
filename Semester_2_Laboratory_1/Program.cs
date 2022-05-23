using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Semester_2_Laboratory_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Task_1();
            Task_2();
            Task_3();
        }

        static void Task_1()
        {
            List<int> list = new List<int>();
            bool isNumber = false;
            int switch_on;
            do
            {
                do
                {
                    Console.Write("Choose an action (0 - Exit, 1 - Add number, 2 - Show list): ");
                    isNumber = int.TryParse(Console.ReadLine(), out switch_on);
                } while (isNumber == false);


                switch (switch_on)
                {
                    case 0:
                        Console.WriteLine("Exit!\n");
                        break;
                    case 1:
                        int number;
                        do
                        {
                            Console.Write("Enter your number: ");
                            isNumber = int.TryParse(Console.ReadLine(), out number);
                        } while (isNumber == false);

                        if (number % 2 == 0)
                            list.Insert(0, number);
                        else
                            list.Add(number);
                        break;
                    case 2:
                        foreach (int element in list)
                            Console.Write(element + " ");

                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("No such variant! Try again.");
                        break;
                }
            } while (switch_on != 0);
        }
        static void Task_2()
        {
            Dictionary<string, double> initialDictionary = new Dictionary<string, double>() 
            {
                { "item_1", 45.50 },
                { "item_2", 35 },
                { "item_3", 41.30},
                { "item_4", 55},
                { "item_5", 24}
            };

            Dictionary<string, double> finalDictionary = new Dictionary<string, double>();

            foreach (KeyValuePair<string, double> item in initialDictionary.OrderByDescending(tmp => tmp.Value))
            {
                if (finalDictionary.Count < 3)
                    finalDictionary.Add(item.Key, item.Value);
            }

            Console.WriteLine("Final dictionary:");
            foreach (KeyValuePair<string, double> item in finalDictionary)
                Console.WriteLine(item.Key + " " + item.Value);

            string writeToJson = JsonSerializer.Serialize(finalDictionary);
            File.WriteAllText("finalDictionary.json", writeToJson);

            Console.WriteLine("\nFinal dictionary from json file:");

            string readFromJson = File.ReadAllText("finalDictionary.json");
            Dictionary<string, double>? dictionaryFromJson = JsonSerializer.Deserialize<Dictionary<string, double>>(readFromJson);
            
            foreach (KeyValuePair<string, double> item in dictionaryFromJson)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }
        static void Task_3()
        {
            int[] numbers = { -10, 21, -11, -46, 43, 26, 30, -2 };

            var selectedNumbers = numbers.Where(tmp => tmp < 0 && tmp % 2 == 0).Reverse();
            foreach (int item in selectedNumbers)
                Console.Write(item + " ");
        }
    }
}
