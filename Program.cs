using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Cross(string[,] field)
        {
            bool engaged = false;
            Console.WriteLine("Игрок 1 сделайте свой ход.");
            do
            {
                int i, j;
                Console.WriteLine("Введите № строки, где хотите поставить крестик.");
                do
                {                    
                    i = int.Parse(Console.ReadLine()) - 1;
                }
                while (i > 3 || i < 0);
                Console.WriteLine("Введите № столбика, где хотите поставить крестик.");
                do
                {                    
                    j = int.Parse(Console.ReadLine()) - 1;
                }
                while (j > 3 || j < 0);                
                if (field[i, j] == "_")
                {
                    field[i, j] = "X";
                    engaged = true;
                }
                else
                {
                    Console.WriteLine("!!! Вы выбрали поле, которое уже занято. Выберите другое поле. !!!");
                    Console.WriteLine("!!! Повторите выбор. !!!");
                }
            }
            while (!engaged);
            Screen(field);
        }
        static void Naught(string[,] field)
        {
            bool engaged = false;
            Console.WriteLine("Игрок 2 сделайте свой ход.");
            do
            {
                int i, j;
                Console.WriteLine("Введите № строки, где хотите поставить нолик.");
                do
                {
                    i = int.Parse(Console.ReadLine()) - 1;
                }
                while (i > 3 || i < 0);
                Console.WriteLine("Введите № столбика, где хотите поставить нолик.");
                do
                {
                    j = int.Parse(Console.ReadLine()) - 1;
                }
                while (j > 3 || j < 0);                
                if (field[i, j] == "_")
                {
                    field[i, j] = "O";
                    engaged = true;
                }
                else
                {
                    Console.WriteLine("!!! Вы выбрали поле, которое уже занято. Выберите другое поле. !!!");
                    Console.WriteLine("!!! Повторите выбор. !!!");
                }
            }
            while (!engaged);
            Screen(field);
        }
        static void Screen(string[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (j != 2)
                    {
                        Console.Write($"{field[i, j]}|");
                    } else
                    {
                        Console.Write($"{field[i, j]}");
                    }                    
                }
                Console.WriteLine();
                if (i != 2)
                {
                    Console.WriteLine("-----");
                }
            }
        }
        static bool CheckingVictory(string[,] field, string value)
        {
            bool victory = false;
            for (int i = 0; i < 3; i++)
            {
                int j = 0;
                if (field[i, j] == value && field[i, j + 1] == value && field[i, j + 2] == value)
                {
                    victory = true;
                    break;
                }
            }
            if (!victory)
            {
                for (int j = 0; j < 3; j++)
                {
                    int i = 0;
                    if (field[i, j] == value && field[i + 1, j] == value && field[i + 2, j] == value)
                    {
                        victory = true;
                        break;
                    }
                }
            }            
            int a = 0, b = 0;
            if (!victory)
            {
                if (field[a, b] == value && field[a + 1, b + 1] == value && field[a + 2, b + 2] == value)
                {
                    victory = true;
                }
            }
            if (!victory)
            {
                if (field[a, b + 2] == value && field[a + 1, b + 1] == value && field[a + 2, b] == value)
                {
                    victory = true;
                }
            }            
            return victory;
        }
        static void Main(string[] args)
        {
            int count = 0;
            string[,] field = new string[3, 3];
            for(int i = 0; i < field.GetLength(0); i++)
            {
                for(int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = "_";
                }
            }
            Console.WriteLine("Добро пожаловать в игру крестики-нолики!");
            Console.WriteLine("Правила игры: Игроки по очереди ставят на свободные клетки поля 3х3 знаки (один всегда крестики, другой всегда нолики). Первый, выстроивший в ряд 3 своих фигуры по вертикали, горизонтали или диагонали, выигрывает. Первый ход делает игрок, ставящий крестики.");
            Console.WriteLine("Игрок 1 ставит крестики, Игрок 2 - нолики.");
            Console.WriteLine("Да начнётся весельё!!!");
            Screen(field);
            Cross(field);
            Naught(field);
            Cross(field);
            for (int i = 0; i < 3; i++)
            {                
                Naught(field);
                if (CheckingVictory(field, "O"))
                {
                    Console.WriteLine("Игрок 2 одержал победу! Грац!!!");
                    break;
                }
                Cross(field);
                if (CheckingVictory(field, "X"))
                {
                    Console.WriteLine("Игрок 1 одержал победу! Грац!!!");
                    break;
                }
                count++;
            }         
            if(count == 3)
            {
                Console.WriteLine("Ничья!");
                Console.WriteLine("Конец игры!");
            } else
            {
                Console.WriteLine("Конец игры!");
            }
            Console.ReadKey();
        }
    }
}