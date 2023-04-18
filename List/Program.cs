using System.Threading.Channels;

namespace List
{
    internal class Program
    {
        void Array()
        {
            int[] intArray = new int[100];

            intArray[0] = 10;
            int value = intArray[0];
        }

        void List()
        {
            List<string> list = new List<string>();

            list.Add("0번 데이터");
            list.Add("1번 데이터");
            list.Add("2번 데이터");

            list.Remove("1번 데이터");
  
            list[0] = "데이터0";
            string value = list[0];
  
            string? findValue = list.Find(x => x.Contains('2'));
            int findIndex = list.FindIndex(x => x.Contains('0'));
        }

        static void Main(string[] args)
        {
            List<string> list = new List<string>();

            list.Add("1번 데이터");
            list.Add("2번 데이터");
            list.Add("3번 데이터");
            list.Add("4번 데이터");
            list.Add("5번 데이터");

            string value;
            value = list[0];
            value = list[1];
            value = list[2];
            value = list[3];
            value = list[4];

            list[0] = "5번 데이터";
            list[1] = "4번 데이터";
            list[2] = "3번 데이터";
            list[3] = "2번 데이터";
            list[4] = "1번 데이터";

            list.Remove("3번 데이터");
            list.Remove("2번 데이터");

            string? findValue = list.Find(x => x.Contains('4'));
            int findIndex = list.FindIndex(x => x.Contains('1'));
        }
    }
}





