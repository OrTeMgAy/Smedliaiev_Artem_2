//28 завдання
//Скласти опис класу для опису профілю місцевості. Зберігає послідовність висот обчислених через рівні проміжки по горизонталі.
//Методи: найбільша висота, найменша висота, перепад висот (найбільший, сумарний), крутизна(найбільша, середня),
//порівняння двох профілів однакової довжини (по перепаду, по крутизні).


using Newtonsoft.Json;
using lab_2;

try
{
    Altitudes alt = new Altitudes();   
    Console.WriteLine("Введіть довжину проміжків");
    alt.n = Convert.ToInt32(Console.ReadLine());
    

    alt.AddAlt();       
    alt.MaxHeight();
    alt.MinHeight();
    alt.HeightDif();
    alt.Steepness();
    alt.Comparison();
    Console.WriteLine("_________________________");

    Serealizer();
    Deserializer();

    void Serealizer()
    {       
        string result = JsonConvert.SerializeObject(alt);
        File.WriteAllText("C:\\1\\json.txt", result);
    }
    void Deserializer()
    {
        var i = JsonConvert.DeserializeObject<Altitudes>(File.ReadAllText("C:\\1\\json.txt"));
        Console.WriteLine($"Довжина проміжків - {i.n}");
        Console.Write("Висоти: ");
        foreach(double a in i.List)
        {
            Console.Write(a + " ");
        }
    }
}
catch
{
    Console.WriteLine("Error");
}

