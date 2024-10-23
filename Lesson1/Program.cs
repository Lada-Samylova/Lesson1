using System;
namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) // Бесконечный цикл для работы программы, пока не будет выбрана команда выхода
            {
                Console.WriteLine("\nВыберите операцию:");
                Console.WriteLine("1. Присваивание");
                Console.WriteLine("2. Бинарные операции");

                // Чтение ввода пользователя с консоли
                Console.Write("Введите номер операции: ");
                string choice = Console.ReadLine();

                // Обработка выбора пользователя
                if (choice == "1")
                {
                    AssignmentOperation(); // Вызов функции для операции присваивания
                }
                else if (choice == "2")
                {
                    BinaryOperations(); // Вызов функции для бинарных операций
                }
                else
                {
                    Console.WriteLine("Неверный выбор."); // Вывод сообщения об ошибке
                }
            }
        }
        static void AssignmentOperation() // Функция для операции присваивания
        {
            Console.Write("Введите число: ");
            string variableName = Console.ReadLine(); // Ввод имени переменной
            Console.Write("Введите значение для присваивания: ");
            string valueStr = Console.ReadLine(); // Ввод значения

            // Попытка преобразования строкового значения в число с плавающей запятой
            if (double.TryParse(valueStr, out double value))
            {
                Console.WriteLine($"{variableName} = {value}");// Вывод результата
            }
            else
            {
                Console.WriteLine("Некорректное значение. Введите число."); // Вывод сообщения об ошибке
            }
        }
        static void BinaryOperations() // Функция для выполнения бинарных операций
        {
            Console.Write("Введите первое число: ");
            double num1 = double.Parse(Console.ReadLine()); // Ввод первого числа
            Console.Write("Введите второе число: ");
            double num2 = double.Parse(Console.ReadLine()); // Ввод второго числа 

            // Вывод меню с выбором бинарной операции
            Console.WriteLine("\nВыберите операцию:");
            Console.WriteLine("1. Сложение (+) ");
            Console.WriteLine("2. Вычитание (-) ");
            Console.WriteLine("3. Умножение (*) ");
            Console.WriteLine("4. Деление (/) ");
            Console.WriteLine("5. Модульное деление (%) ");
            Console.Write("Введите номер операции: ");

            string choice = Console.ReadLine(); // Ввод выбора операции

            double result = 0; // Инициализация переменной для результата

            // Выполнение выбранной операции
            switch (choice)
            {
                case "1":
                    result = num1 + num2;
                    break;
                case "2":
                    result = num1 - num2;
                    break;
                case "3":
                    result = num1 * num2;
                    break;
                case "4":
                    if (num2 == 0) // Проверка на деление на ноль
                    {
                        Console.WriteLine("Деление на ноль!");
                    }
                    else // Если делитель не равен нулю
                    {
                        result = num1 / num2;
                    }
                    break;
                case "5": // Обработка модульного деления
                    result = num1 % num2;

                    break;
                default: // Обработка неверного ввода
                    Console.WriteLine("Неверный выбор."); // Вывод сообщения об ошибке
                    return; // Выход из функции
            }
            // Проверка, что результат не равен нулю
            if (result != 0)
            {
                // Если результат не равен нулю, вывод на консоль строку с операцией и её результатом
                Console.WriteLine($"{num1} {GetOperator(choice)} {num2} = {result}");
            }
        }
        // Статический метод, который возвращает строковое представление оператора в зависимости от выбранного значения
        static string GetOperator(string choice)
        {
            // Определение оператора в зависимости от выбранного пользователем номера
            switch (choice)
            {
                case "1": return "+"; // Выбрано "1", возвращаем '+' для сложения
                case "2": return "-"; // Выбрано "2", возвращаем '-' для вычитания
                case "3": return "*"; // Выбрано "3", возвращаем '*' для умножения
                case "4": return "/"; // Выбрано "4", возвращаем '/' для деления
                case "5": return "%"; // Выбрано "5", возвращаем '%' для получения остатка от деления
                default: return ""; // Пустая строка,если выбрана неверная опция 
            }
        }
    }
}