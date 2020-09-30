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
            LinkedList<Student> studentlinked = new LinkedList<Student>();
            LinkedList<Aspirant> aspirantlinked = new LinkedList<Aspirant>();
            Console.Write("If you wanna register as student press - 1 , as aspirant press - 2 : ");
            int press12 = TryPress12();
            switch (press12)
            {
               case 1:
                   {
                       Console.Write("Input name of student : "); string name = Alphabet();
                       Console.Write("Input surname of student : "); string surname = Alphabet();
                       Console.Write("Input course of student : "); int course = TryPress();
                       Console.Write("Input codebook of student : "); int codebook = TryPress();
                       Student student = new Student(name, surname, course, codebook);
                        studentlinked.AddFirst(student);
                       break;
                   }
               case 2:
                   {
                       Console.Write("Input name of aspirant : "); string name = Alphabet();
                       Console.Write("Input surname of aspirant : "); string surname = Alphabet();
                       Console.Write("Input course of aspirant : "); int course = TryPress();
                       Console.Write("Input codebook of aspirant : "); int codebook = TryPress();
                       Console.Write("Input disertation of aspirant : "); string disertation = Console.ReadLine();
                       Aspirant aspirant = new Aspirant(name, surname, course, codebook, disertation);
                        aspirantlinked.AddFirst(aspirant);
                       break;
                   }
            }
            Console.Write("\nFor continue press - 1 , for see all users registered list and exit press - 2 : ");
            int menu = TryPress12();
            switch (menu)
            {
                case 1:
                    {
                        Main();
                        break;
                    }
                case 2:
                    { 
                        break;
                    }
            }
            Console.WriteLine("\nName of aspirant - " + aspirantlinked.First.Value.name + ",surname - " + aspirantlinked.First.Value.surname + ",course - " + aspirantlinked.First.Value.course +
                ",codebook - " + aspirantlinked.First.Value.name + ",disertation - " + aspirantlinked.First.Value.disertation);
            
        }
        public static int TryPress12()
        {
            int presskey = 0;
            if (int.TryParse(Console.ReadLine(), out presskey)) { if (presskey == 1) { return presskey; } else if (presskey == 2) { return presskey; } else { Console.WriteLine("Wrong input try again!"); return TryPress12(); } }
            else { Console.WriteLine("Wrong input try again!"); return TryPress12(); }
        }
        public static int TryPress()
        {
            int presskey = 0;
            if (int.TryParse(Console.ReadLine(), out presskey)) { return presskey; }
            else { Console.WriteLine("Wrong input try again!"); return TryPress12(); }
        }
        public static string Alphabet()
        {
            string x;
            bool check = true;
            do
            {
                x = Console.ReadLine();
                foreach (char i in x)
                {

                    if (i < '0' || i > '9')
                    {
                        foreach (char a in "the quick brown fox jumps over the lazy dog THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG")
                        {
                            if (a == i) { check = true; break; }
                            else { check = false; }
                        }
                    }
                    else { Console.WriteLine("Wrong name input again!"); check = false; break; }
                    if (check == false) { Console.WriteLine("Wrong name input again!"); break; }
                }
            } while (check == false);
            return x;
        }

    }
}