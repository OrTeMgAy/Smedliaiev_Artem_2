using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace lab_2
{
    internal class Altitudes
    {
        public List<double> List = new List<double>();
        public double n { get; set; } //довжина проміжків між висотами
        public double maxdif = 0; //максимальний перепад висот
        public double st = 0; //найбільша крутизна
        public double max;//максимальна висота
        public double min;//мінімальна
        
      
        public void AddAlt()//додаємо висоти
        {
            Console.WriteLine("Введіть висоти");
            string a = Console.ReadLine();
            int[] arr = a.Split(' ').Select(int.Parse).ToArray();//розділяємо рядок по пробілам заносимо до масиву а потім переносимо в список
            foreach (int x in arr)
                List.Add(x);
        }

        public void MaxHeight()//максимальна висота
        {
            max = List[0];
            for (int i = 0; i < List.Count; i++)
            {
                if (max < List[i]) max = List[i];                
            }
            Console.WriteLine("Найбільша висота - " + max);
        }

        public void MinHeight()//мінімальна
        {
            min = List[0];
            for (int i = 0; i < List.Count; i++)
            {
                if (min > List[i]) min = List[i];                
            }
            Console.WriteLine("Найменша висота - " + min);
        }

        public void HeightDif()//знаходимо перепади висот
        {                       
            for(int i = 0; i < List.Count-1; i++)
            {                
                double a = List[i + 1] - List[i];
                if (a < 0) a = a * -1; //якщо вища вершина навпаки стоїть раніше
                if (a > maxdif) maxdif = a;
            }
            var sumdif = max - min;
            Console.WriteLine("Найбільший перепад висот - " + maxdif);
            Console.WriteLine("Сумарний перепад висот - " + sumdif);
        }

        public void Steepness()//знаходимо крутизну(в градусах відносно горизонту)
        {
            double[] arr = new double[List.Count];//масив в який будемо заносити всі крутизни щоб потім порахувати середню
            double avst = 0;//середня крутизна
           
            double a = 0;
            for (int i = 0; i < List.Count-1; i++)
            {
                if (List[i] < List[i + 1])
                {
                    a = Math.Atan((List[i + 1] - List[i]) / n);
                    arr[i] = a;
                }
                else if(List[i] > List[i + 1])
                {
                    a = Math.Atan((List[i] - List[i + 1]) / n);
                    arr[i] = a;
                }
                else if(List[i] == List[i + 1])//якщо дві вершини однакові то крутизни нема
                {
                    a = 0;
                    arr[i] = 0;
                }
                if(a > st) st = a;
            }
            double sum = arr[0];
            for(int i = 1; i < arr.Length; i++)//додаємо всі крутизни
            {
                sum += arr[i];
            }
            avst = sum/ n;//знаходимо середню
            Console.WriteLine("Найбльша крутизна - " + st);
            Console.WriteLine("Середня крутизна - " + avst);
        }

        public void Comparison()//зробив так щоб у цей самий клас можна типу бул записати два профілі
        {                       //потім робить все те саме для знаходження найбільшого перепаду висот та найбільшої крутизни
            try
            {               
                Console.WriteLine("Ви можете ввести другий профіль з такою ж довжиною для порівняння по їхніх перепадах та крутизнах");
                Console.WriteLine("Так - 1, ні - будь що інше");
                string c = Console.ReadLine();
                if (c == "1")
                {
                    List<int> List2 = new List<int>();
                    for (; ; )
                    {                        
                        Console.WriteLine("Введіть висоти");
                        string a = Console.ReadLine();
                        int[] arr = a.Split(' ').Select(int.Parse).ToArray();
                        if (arr.Length == List.Count)//перевірка на те що кількість висот в обох профілях однакова
                        {
                            foreach (int i in arr)
                            {
                                List2.Add(i);
                            }
                            int max2 = List2[0];
                            int min2 = List2[0];
                            int maxdif2 = 0;
                            double st2 = 0;
                            double[] arr2 = new double[List2.Count];
                            for (int i = 0; i < List2.Count; i++)
                            {
                                if (max2 < List2[i]) max2 = List2[i];
                            }
                            for (int i = 0; i < List2.Count; i++)
                            {
                                if (min2 > List2[i]) min2 = List2[i];
                            }
                            for (int i = 0; i < List2.Count - 1; i++)
                            {
                                int b = List2[i] - List2[i + 1];
                                if (b < 0) b = b * -1;
                                if (b > maxdif2) maxdif2 = b;
                            }
                            double p = 0;
                            for (int i = 0; i < List2.Count - 1; i++)
                            {
                                if (List2[i] < List2[i + 1])
                                {
                                    p = Math.Atan(Convert.ToDouble((List2[i + 1] - List2[i]) / n));
                                    arr2[i] = p;
                                }
                                if (List2[i] > List2[i + 1])
                                {
                                    p = Math.Atan(Convert.ToDouble((List2[i] - List2[i + 1]) / n));
                                    arr2[i] = p;
                                }
                                if (p > st2) st2 = p;
                            }
                            double difh;
                            if (maxdif > maxdif2) difh = maxdif2 - maxdif;
                            else difh = maxdif - maxdif2;
                            Console.WriteLine($"Найбільший перепад висот першого профілю - {maxdif}, другого - {maxdif2}, різниця - {difh}");
                            double difst;
                            if (st > st2) difst = st2 - st;
                            else difst = st - st2;
                            Console.WriteLine($"Нaйбільша крутизна першого профілю - {st}, другого - {st2}, різниця - {difst}");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Кількість введених вершин не відповідає кількості вершин першого профілю. Почнемо спочатку");
                        }
                    }
                }
                else
                {

                }
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }

    }
}
