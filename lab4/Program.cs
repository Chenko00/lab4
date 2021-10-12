using System;

namespace lab4
{
    class Account
    {
        public delegate void AccountHandler(string message);
        public event AccountHandler Notify;              
        public Account(int sum)
        {
            Sum = sum;
        }
        public int Sum { get; private set; }
        public void Put(int sum)
        {
            Sum += sum;
            Notify?.Invoke($"На счет поступило: {sum}");  
        }
        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                Notify?.Invoke($"Со счета снято: {sum}");   
            }
            else
            {
                Notify?.Invoke($"Недостаточно денег на счете. Текущий баланс: {Sum}"); ;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Account acc = new Account(100);
            acc.Notify += DisplayMessage;   
            acc.Put(20);   
            Console.WriteLine($"Сумма на счете: {acc.Sum}");
            acc.Take(70);  
            Console.WriteLine($"Сумма на счете: {acc.Sum}");
            acc.Take(180);
            Console.WriteLine($"Сумма на счете: {acc.Sum}");
            Console.Read();
        }
        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}

