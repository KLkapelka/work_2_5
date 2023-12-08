// Выполните задание 4, используя Dictionary<key, value>. В качестве ключей используйте названия месяцев,
// в качестве значений – массив температур по дням. Напишите метод, который используя данные
// из словаря вычислит среднюю температуру для каждого месяца, и вернет словарь(Dictionary)
// средних температур (В качестве ключа название месяца, в качестве значения коллекция средних температура);

using System;
using System.Linq;
class work_2_5
{
  static void Main()
    {
        float[,] temperatures = new float[12, 30]; 
        Random rand = new Random(); 


        for (int iRow = 0; iRow < 12; iRow++)
        {
            
            if (iRow <= 2) 
                for (int iCol = 0; iCol < 30; iCol++) 
                {
                    temperatures[iRow, iCol] = rand.Next(-35, 1); 
                }
            else if (iRow <= 8) 
            { 
                for (int iCol = 0; iCol < 30; iCol++)
                {
                    temperatures[iRow, iCol] = rand.Next(-5, 15); 
                }
            }
            else
            {
                for (int iCol = 0; iCol < 30; iCol++) 
                {
                    temperatures[iRow, iCol] = rand.Next(10, 35); 
                }
            }
        }

        Dictionary<string, float[]> monthlyAverages = CalculateМedium(temperatures); 

        Console.WriteLine("Средние температуры по месяцам:");
        foreach (var kvp in monthlyAverages) 
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value[0]}"); 
        }
    } 

    static Dictionary<string, float[]> CalculateМedium(float[,] temperatures)
    {
        int months = temperatures.GetLength(0); 
        int days = temperatures.GetLength(1); 

        Dictionary<string, float[]> monthlyAverages = new Dictionary<string, float[]>(); 

        string[] monthNames = {"Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"}; 

        for (int iRow = 0; iRow < months; iRow++)
        {
            float sum = 0; 

            for (int iCol = 0; iCol < days; iCol++)
            {
                sum += temperatures[iRow, iCol]; 
            }

            float averageTemperature = sum / days; 
            monthlyAverages.Add(monthNames[iRow], new float[] { averageTemperature }); 
        }

        return monthlyAverages; 
    }
}
