using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HW_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task_1();
            Task_2();
            Task_3();
            Task_4();
            Task_5();
            Task_6();
        }

        public static void PrintIntArray(int[] array)
        {
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        public static void Task_1()
        {
            Console.WriteLine("Задача 1.");
            /*
             Напишите метод, который отображает квадрат из
            некоторого символа. Метод принимает в качестве 
            параметра: длину стороны квадрата, символ.
            */
            int width = 0;
            char ch = ' ';
            Console.Write("Введите размер квадрата: ");
            width = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите символ: ");
            ch = Convert.ToChar(Console.ReadLine());
            PrintSquare(width, ch);
            Console.WriteLine();    
        }

        public static void Task_2()
        {
            Console.WriteLine("Задача 2.");
            /*
            Напишите метод, который проверяет является ли
           переданное число «палиндромом». Число передаётся в
           качестве параметра. Если число палиндром нужно 
           вернуть из метода true, иначе false.
           Палиндром — число, которое читается одинаково как
           справа налево, так и слева направо. Например:
           1221 — палиндром;
           3443 — палиндром;
           7854 — не палиндром.
           */
            Console.Write("Введите число: ");
            int number = Convert.ToInt32(Console.ReadLine());
            if (IsPalinrom(number))
            {
                Console.WriteLine(number + " - палиндром");
            }
            else
            {
                Console.WriteLine(number + " - не палиндром");
            }
            Console.WriteLine();
        }

        public static void Task_3()
        {
            /*
             Напишите метод, фильтрующий массив на основании
            переданных параметров. Метод принимает параметры:
            оригинальный_массив, массив_с_данными_для_фильтрации. 
            Метод возвращает оригинальный массив без элементов, 
            которые есть в массиве для фильтрации.
            Например:
            1 2 6 -1 88 7 6 — оригинальный массив;
            6 88 7 — массив для фильтрации;
            1 2 -1 — результат работы метода.
            */
            Console.WriteLine("Задача 3.");
            Console.Write("Введите ряд чисел через пробел: ");
            string strArr = Console.ReadLine();
            string[] arrOfString = strArr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] arrOfInt = new int[arrOfString.Length];
            for (int i = 0; i < arrOfString.Length; i++)
            {
                arrOfInt[i] = Convert.ToInt32(arrOfString[i]);
            }

            Console.Write("Введите ряд чисел, которые надо исключить из предыдущего ряда: ");
            string str = Console.ReadLine();
            string[] arrOfStr = str.Split(' ');
            int[] arrInt = new int[arrOfStr.Length];
            for (int i = 0; i < arrOfStr.Length; i++)
            {
                arrInt[i] = Convert.ToInt32(arrOfStr[i]);
            }
            int[] finalArray = CleanArray(arrOfInt, arrInt);
            PrintIntArray(finalArray);
            Console.WriteLine();
        }

        static void PrintSquare(int width, char ch)
        {
            for (int i = 0; i < width; i++)
            {
                Console.Write("\t");
                for(int j = 0; j < width; j++)
                {
                    if (i == 0)
                    {
                        Console.Write(ch);
                        Console.Write(' ');
                    }
                    else if(j == 0 || j == width - 1)
                    {
                        Console.Write(ch);
                        Console.Write(' ');
                    }
                    else if (i == width - 1)
                    {
                        Console.Write(ch);
                        Console.Write(' ');
                    }
                    else
                    {
                        Console.Write(' ');
                        Console.Write(' ');
                    }
                    
                }
                Console.WriteLine();
            }
        }

        public static bool IsPalinrom(int number)
        {
            string num = Convert.ToString(number);
            int numLength = num.Length;
            for(int i = 0; i < numLength/2; i++)
            {
                if (num[i] != num[numLength-1-i])
                {
                    return false;
                }
            }
            return true;
        }


        public static int[] CleanArray(int[] arrToClean, int[] unnecessaryNumbers)
        {
            
            int countOfUnnesNumbers = 0;
            for(int i = 0; i < arrToClean.Length; i++)
            {
                for(int j = 0; j < unnecessaryNumbers.Length; j++)
                {
                    if (arrToClean[i] == unnecessaryNumbers[j])
                    {
                        countOfUnnesNumbers++;
                        continue;
                    }
                }
            }

            int[] arrToReturn = new int[arrToClean.Length - countOfUnnesNumbers];
            bool checkNumber = true;
            int k = 0;
            for (int i = 0; i < arrToClean.Length; i++)
            {
                for (int j = 0; j < unnecessaryNumbers.Length; j++)
                {
                    if (arrToClean[i] == unnecessaryNumbers[j])
                    {
                        checkNumber = false;
                    }
                }
                if (checkNumber)
                {
                    arrToReturn[k++] = arrToClean[i];
                }
                checkNumber = true;
            }
            return arrToReturn;
        }

        public static void Task_4()
        {
            /*
             Создайте класс «Веб-сайт». Необходимо хранить в
            полях класса: название сайта, путь к сайту, описание
            сайта, ip адрес сайта. Реализуйте методы класса для ввода
            данных, вывода данных, реализуйте доступ к отдельным
            полям через методы класса.
            */
            Console.WriteLine("Задача 4.");
            WebSite webSite = new WebSite();
            webSite.InitWebSite();
            Console.WriteLine();
            webSite.PrintWebSite();
            webSite.ip = "127.0.0.1";
            webSite.name = "testSite";
            webSite.url = "/";
            webSite.description = "описание сайта";
            webSite.PrintWebSite();
            Console.WriteLine();
            string name = webSite.name;
            string ip = webSite.ip;
            string url = webSite.url;
            string description = webSite.description;
            Console.WriteLine("Название сайта: " + name);
            Console.WriteLine("Путь к сайту: " + url);
            Console.WriteLine("ip адрес сайта: " + ip);
            Console.WriteLine("Описание сайта: " + description);
        }

        public static void Task_5()
        {
            /*
             Создайте класс «Журнал». Необходимо хранить в
            полях класса: название журнала, год основания, 
            описание журнала, контактный телефон, контактный e-mail.
            Реализуйте методы класса для ввода данных, вывода
            данных, реализуйте доступ к отдельным полям через
            методы класса.
            */
            Console.WriteLine("Задача 5.");
            Journal journal = new Journal();
            journal.Init();
            journal.Print();
            Console.WriteLine();
            journal.name="За рулём";
            journal.sinceYear="23 февраля 1928 года";
            journal.phoneNumber="+7 (495) 363-47-27";
            journal.email="https://www.zr.ru";
            journal.description="«За рулём» — советский и российский русскоязычный журнал об автомобилях и автомобилестроении. Издаётся раз в месяц. До 1989 года был единственным в СССР периодическим изданием на автомобильную тематику, рассчитанным на широкий круг читателей. К концу 1980-х тираж журнала достигал 4,85 млн экземпляров.";
            Console.WriteLine("Название журнала: " + journal.name);
            Console.WriteLine("Дата основания журнала: " + journal.sinceYear);
            Console.WriteLine("Контактный телефон журнала: " + journal.phoneNumber);
            Console.WriteLine("Контактный электронный адрес журнала: " + journal.email);
            Console.WriteLine("Описание журнала: " + journal.description);

        }

        public static void Task_6()
        {
            /*
             Создайте класс «Магазин». Необходимо хранить в
            полях класса: название магазина, адрес, описание 
            профиля магазина, контактный телефон, контактный e-mail.
            Реализуйте методы класса для ввода данных, вывода
            данных, реализуйте доступ к отдельным полям через
            методы класса.
            */
            Console.WriteLine("Задача 6.");
            Shop shop = new Shop();
            shop.Init();
            shop.Print();
            Console.WriteLine();
            shop.name = "Магнит";
            shop.adress = "ул. Победы д. 54";
            shop.phoneNumber="8 800 200-90-02";
            shop.email="https://magnit.ru";
            shop.description="Покупайте любимые продукты";
            Console.WriteLine("Название магазина: " + shop.name);
            Console.WriteLine("Адрес магазина: " + shop.adress);
            Console.WriteLine("Контактный телефон магазина: " + shop.phoneNumber);
            Console.WriteLine("Контактный электронный адрес: " + shop.email);
            Console.WriteLine("Описание: " + shop.description);

        }

    }

    class WebSite
    {
        private string name_;
        private string url_;
        private string description_;
        private string ip_;
        public WebSite() { }
        public WebSite(string name, string url, string description, string ip)
        {
            this.name_ = name;
            this.url_ = url;
            this.description_ = description;
            this.ip_ = ip;
        }
        public string name
        {
            set { this.name_ = value; }
            get { return this.name_; }
        }

        public string url
        {
            set { this.url_= value; }
            get { return this.url_; }
        }

        public string description
        { 
            set { this.description_ = value; }
            get { return this.description_; }
        }

        public string ip
        {
            set { this.ip_ = value; }
            get { return this.ip_; }
        }

        public void InitWebSite()
        {
            Console.Write("Введите название сайта: ");
            name_ = Console.ReadLine();
            Console.Write("Введите путь к сайту: ");
            url_ = Console.ReadLine();
            Console.Write("Введите описание сайта: ");
            description_ = Console.ReadLine();
            Console.Write("Введите ip адрес сайта: ");
            ip_ = Console.ReadLine();
        }

        public void PrintWebSite()
        {
            Console.WriteLine("Название сайта: " + name_);
            Console.WriteLine("Url сайта: " + url_);
            Console.WriteLine("Описание сайта: " + description_);
            Console.WriteLine("ip адрес сайта: " + ip_);
        }

    }


    class Journal
    {
        private string name_;
        private string sinceYear_;
        private string description_;
        private string phoneNumber_;
        private string email_;
        public Journal() { }
        public Journal(string name, string sinceYear, string description, string phoneNumber, string email) 
        {
            this.name_ = name;
            this.sinceYear_ = sinceYear;
            this.description_ = description;
            this.phoneNumber_ = phoneNumber;
            this.email_ = email;
        }

        public string name
        {
            get { return name_; }
            set { name_ = value; }
        }

        public string sinceYear
        {
            get { return sinceYear_; }
            set { sinceYear_ = value; }
        }

        public string description
        {
            get { return description_; }
            set { description_ = value; }
        }

        public string phoneNumber
        {
            get { return phoneNumber_; }
            set { phoneNumber_ = value; }
        }

        public string email
        {
            get { return email_; }
            set { email_ = value; }
        }

        public void Init()
        {
            Console.Write("Введите название журнала: ");
            name_ = Console.ReadLine();
            Console.Write("Введите год основания: ");
            sinceYear_ = Console.ReadLine();
            Console.Write("Введите описание журнала: ");
            description_ = Console.ReadLine();
            Console.Write("Введите контактный телефон: ");
            phoneNumber_ = Console.ReadLine();
            Console.Write("Введите контактный электронный адрес: ");
            email_ = Console.ReadLine();
        }

        public void Print()
        {
            Console.WriteLine("Название журнала: " + name_);
            Console.WriteLine("Год основания: " + sinceYear_);
            Console.WriteLine("Описание: " + description_);
            Console.WriteLine("Контактный телефон: " + phoneNumber_);
            Console.WriteLine("Контактный электронный адрес: " + email_);
        }

    }

    class Shop
    {
        private string name_;
        private string adress_;
        private string description_;
        private string phoneNumber_;
        private string email_;
        public Shop() { }
        public Shop(string name, string adress, string description, string phoneNumber, string email)
        {
            this.name_ = name;
            this.adress_ = adress;
            this.description_ = description;
            this.phoneNumber_ = phoneNumber;
            this.email_ = email;
        }

        public string name
        {
            get { return name_; }
            set { name_ = value; }
        }

        public string adress
        {
            get { return adress_; }
            set { adress_ = value; }
        }

        public string description
        {
            get { return description_; }
            set { description_ = value; }
        }

        public string phoneNumber
        {
            get { return phoneNumber_; }
            set { phoneNumber_ = value; }
        }

        public string email
        {
            get { return email_; }
            set { email_ = value; }
        }

        public void Init()
        {
            Console.Write("Введите название магазина: ");
            name_ = Console.ReadLine();
            Console.Write("Введите адрес магазина: ");
            adress_ = Console.ReadLine();
            Console.Write("Введите описание магазина: ");
            description_ = Console.ReadLine();
            Console.Write("Введите контактный телефон: ");
            phoneNumber_ = Console.ReadLine();
            Console.Write("Введите контактный электронный адрес: ");
            email_ = Console.ReadLine();
        }

        public void Print()
        {
            Console.WriteLine("Название магазина: " + name_);
            Console.WriteLine("Адрес: " + adress_);
            Console.WriteLine("Описание профиля магазина: " + description_);
            Console.WriteLine("Контактный телефон: " + phoneNumber_);
            Console.WriteLine("Контактный электронный адрес: " + email_);
        }
    }



}
