using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    static void Main1()
    {
        List<int> list = new List<int>();

        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(7);

        foreach (int prime in list)
        {
            Console.WriteLine(prime);
        }
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list[i]);
        }
    }
    void main2()
    {
        List<bool> list = new List<bool>();
        list.Add(true);
        list.Add(false);
        list.Add(true);
        Console.WriteLine(list.Count);

        list.Clear();
        Console.WriteLine(list.Count);
    }
    internal class List_2
    {
    }
}
