using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ==================================================    3 лабораторная работа    ==================================================


/*
//  = = = = = =   3_2 : 3 лаба 2 задание   = = = = = = 
// Создать приложение, в котором в цикле создается 10 объектов класса.
// Поля только для чтения каждого экземпляра равны порядковому
// номеру, отражающего очередность создания объектов

namespace Laba3_2
{
    internal class Program
    {
        public class MyClass
        {
            public readonly int Id;
            public MyClass(int pered_i)
            {
                Id = pered_i;
            }
        }
        static void Main(string[] args)
        {


            for (int i = 0; i < 10; i++)
            {
                MyClass myClass = new MyClass(i);
                Console.WriteLine($"Порядковый номер: {myClass.Id}");
            }
        }
    }
}
*/


/*//  = = = = = =   3_9 : 3 лаба 9 задание   = = = = = =
namespace laba3_9
{
    internal class Program
    {
        public class Myclass
        {
            int[] Vnutr_Mas; // переменная для внутреннего массива

            public readonly int minel, maxel; // переменная для Минимального и Максимального элементов массива

            public void print_Vnutr_Mas() // функция. печать внутреннего массива
            {
                foreach (int el in Vnutr_Mas)
                {
                    Console.WriteLine($"Элемент внутреннего массива: {el}");
                }
            }

            public Myclass(int[] Vneshn_Mas)
            {
                Console.WriteLine($"Полученный массив: {string.Join(", ", Vneshn_Mas)} \nНачинается процесс копирования...");
                Vnutr_Mas = new int[Vneshn_Mas.Length];
                Console.WriteLine("Выделена память под новый массив длиною полученного");
                Console.WriteLine("Запускается дополнительный процесс: поиск min и max");
                int tempMax, tempMin = Vneshn_Mas[0];

                for (int i = 0; i<Vneshn_Mas.Length; i++)
                {
                    Console.Beep();
                    Vnutr_Mas[i] = Vneshn_Mas[i];
                    tempMax = Math.Max(tempMax, Vneshn_Mas[i]);
                    tempMin = Math.Min(tempMin, Vneshn_Mas[i]);
                }
                Console.WriteLine("Полученный массив скопирован в новый массив. Процесс завершён.");
                minel = tempMin;
                maxel = tempMax;
                Console.WriteLine("Минимальные и Максимальные элементы найдены");
            }

        }
    }
}

*/

// =============================       4   лабораторная работа       =============================

// = = = = = =   4_9 : 4 лаба 9 задание   = = = = = =
// Игрушка, продукт, товар, молочный продукт

/*
 * Товар
├── Игрушка
└── Продукт
    └── МолочныйПродукт
*/
namespace laba4_9
{
    public class Товар
    {
        // автосвойства
        public string Название { get; set; }
        public int Количество { get; set; }
        public int Цена { get; set; }

        // метод для печати информации о ТОВАР
        public void Print()
        {
            Console.WriteLine($"Товар  =>  \t\t\tНазвание: {Название}\tКоличество: {Количество}\tЦена: {Цена}");
        }
        public void PrintSumCost()
        {
            Console.WriteLine($"Общая стоимость товара {Название} = {Количество * Цена}");
        }
    }

    public class Игрушка : Товар
    {
        public string Материал { get; set; }
        public bool IsForChildren { get; set; }
        public new void Print()
        {
            base.Print(); // Вызов метода Print() базового класса Товар
            Console.WriteLine($"Игрушка : \tТовар  =>  \tМатериал: {Материал}\tДля детей: {(IsForChildren ? "Да" : "Нет")}");
        }
        public void Поиграть() => Console.WriteLine($"Вы играете с игрушкой {Название}"); 
    }

    public class Продукт : Товар
    {
        public int СрокГодности { get; set; }
        public bool IsOrganic { get; set; }
        public DateTime ДатаПроизводства { get; set; }
        public DateTime ДатаИстеченияСрокаГодности => ДатаПроизводства.AddDays(СрокГодности);

        public new void Print()
        {
            base.Print(); // Вызов метода Print() базового класса Товар
            Console.WriteLine($"Продукт : \tТовар  =>  \t Дата Истечения Срока Годности: {ДатаИстеченияСрокаГодности}\tОрганический: {(IsOrganic ? "Да" : "Нет")}");
        }
        public void ПроверитьСрокГодности()
        {
            if (ДатаИстеченияСрокаГодности < DateTime.Now)
                Console.WriteLine($"Срок годности продукта {Название} истёк!");
            else
                Console.WriteLine($"Срок годности продукта {Название} ещё не истёк.");
        }
    }

    public class МолочныйПродукт : Продукт
    {
        public double Жирность { get; set; }
        public string Тип { get; set; } // например, молоко, йогурт, сыр и т.д.
        public new void Print()
        {
            base.Print(); // Вызов метода Print() базового класса Товар
            Console.WriteLine($"МолочныйПродукт : \tПродукт  =>  \tЖирность: {Жирность}\tТип: {Тип}");
        }
        public void ПроверитьЖирность()
        {
            if (Жирность >= 1.5) Console.WriteLine($"Жирность молочного продукта {Название} нормальная.");
            else Console.WriteLine($"Жирность молочного продукта {Название} низкая.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n=\t=\t= Товар =\t=\t=");
            Товар товар = new Товар
            {
                Название = "хлеб",
                Количество = 5,
                Цена = 200
            };
            товар.Print();
            товар.PrintSumCost();
            Console.WriteLine("\n=\t=\t= Продукт =\t=\t=");
            Продукт продукт = new Продукт
            {
                Название = "коза",
                Количество = 5,
                Цена = 1337,
                ДатаПроизводства = DateTime.Now.AddDays(-40),
                СрокГодности = 100,
                IsOrganic = false
            };
            продукт.Print();
            продукт.ПроверитьСрокГодности();
            Console.WriteLine("\n=\t=\t= Игрушка =\t=\t=");
            Игрушка игрушка = new Игрушка
            {
                Название = "Мягкая игрушка",
                Количество = 10,
                Цена = 500,
                Материал = "Плюш",
                IsForChildren = true
            };
            игрушка.Print();
            игрушка.Поиграть();
            Console.WriteLine("\n=\t=\t= Молоко =\t=\t=");
            МолочныйПродукт молоко = new МолочныйПродукт
            {
                Название = "Молоко",
                Количество = 20,
                Цена = 100,
                СрокГодности = 7,
                ДатаПроизводства = DateTime.Now.AddDays(-40),
                IsOrganic = true,
                Жирность = 3.2,
                Тип = "Молоко"
            };
            молоко.Print();
            молоко.ПроверитьЖирность();

            // Для эксперимента
            Console.WriteLine("\nИзменяем название молочного продукта на молоко 2.0 для эксперимента\n");
            молоко.Название = "Молоко 2.0";
            молоко.Print();
        }
    }
}
