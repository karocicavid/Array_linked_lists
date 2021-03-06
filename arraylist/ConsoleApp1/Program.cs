using System;
using System.Collections;
using System.Collections.Generic;

namespace cavka
{
    abstract class Person
    {
        public string name;
        public string surname;
        public Person(string Name, string Surname)
        {
            name = Name; surname = Surname;
        }
    }
    class Student : Person
    {
        public int course;
        public int codebook;
        public Student(string Name, string Surname, int Course, int Codebook)
            : base(Name, Surname)
        {
            course = Course; codebook = Codebook;
        }
    }
    class Aspirant : Person
    {
        public int course;
        public int codebook;
        public string disertation;
        public Aspirant(string Name, string Surname, int Course, int Codebook, string Disertation)
            : base(Name, Surname)
        {
            course = Course; codebook = Codebook; disertation = Disertation;
        }
    }
    class Program
    {
        static void Main()
        {
            ArrayList aspirantlist = new ArrayList();
            ArrayList studentlist = new ArrayList();
            bool check = true;
            do
            {
                Console.Write("If you wanna register as student press - 1 :\nIf you wanna register as aspirant press - 2 : ");
                int press12 = TryPress12();
                switch (press12)
                {
                    case 1:
                        {
                            Console.Write("\nInput name of student : "); string name = Alphabet_chechker();
                            Console.Write("Input surname of student : "); string surname = Alphabet_chechker();
                            Console.Write("Input course of student : "); int course = TryPress();
                            Console.Write("Input codebook of student : "); int codebook = TryPress();
                            Student student = new Student(name, surname, course, codebook);
                            studentlist.Add(student);
                            break;
                        }
                    case 2:
                        {
                            Console.Write("\nInput name of aspirant : "); string name = Alphabet_chechker();
                            Console.Write("Input surname of aspirant : "); string surname = Alphabet_chechker();
                            Console.Write("Input course of aspirant : "); int course = TryPress();
                            Console.Write("Input codebook of aspirant : "); int codebook = TryPress();
                            Console.Write("Input disertation of aspirant : "); string disertation = Console.ReadLine();
                            Aspirant aspirant = new Aspirant(name, surname, course, codebook, disertation);
                            aspirantlist.Add(aspirant);
                            break;
                        }
                }
                Console.Write("\nFor continue press - 1 :\nFor see all users registered list and exit press - 2 : ");
                int menu = TryPress12();
                switch (menu)
                {
                    case 1:
                        {
                            check = true;
                            break;
                        }
                    case 2:
                        {
                            check = false;
                            break;
                        }
                }

            } while (check == true);
           
          

            foreach (Aspirant each in aspirantlist)
            {
                Console.WriteLine("\nYour aspirant : ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Name of aspirant - " + each.name + ",surname - " + each.surname + ",course - " + each.course + ",codebook - " + each.codebook + ",disertation - " + each.disertation);
                Console.ResetColor();
            }

            foreach (Student each in studentlist)
            {
                Console.WriteLine("\nYour student : ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Name of student - " + each.name + ",surname - " + each.surname + ",course - " + each.course + ",codebook - " + each.codebook);
                Console.ResetColor();
            }
            Console.Read();

        }
        public static int TryPress12()
        {
            int presskey = 0;
            if (int.TryParse(Console.ReadLine(), out presskey)) { if (presskey == 1) { return presskey; } else if (presskey == 2) { return presskey; } else { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Wrong input try again!"); Console.ResetColor(); return TryPress12(); } }
            else { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Wrong input try again!");Console.ResetColor(); return TryPress12(); }
        }
        public static int TryPress()
        {
            int presskey = 0;
            if (int.TryParse(Console.ReadLine(), out presskey)) { return presskey; }
            else { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Wrong input try again!"); Console.ResetColor(); return TryPress12(); }
        }
        public static string Alphabet_chechker()
        {
            bool check = true;
            string input;
            do
            {
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Empty input!"); check = false; Console.ResetColor(); return Alphabet_chechker(); }
                }
                foreach (char i in input)
                {

                    if (i < '0' || i > '9')
                    {
                        foreach (char a in "thequickbrownfoxjumpsoverthelazydogTHEQUICKBROWNFOXJUMPSOVERTHELAZYDOG")
                        {
                            if (a == i) { check = true; break; }
                            else { check = false; }
                        }
                    }
                    else { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("input again!"); check = false; Console.ResetColor(); break; }
                    if (check == false) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("input again!"); Console.ResetColor(); break; }
                }
            } while (check == false);
            return input;
        }
    }
}
