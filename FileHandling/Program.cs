using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace FileHandling
{
    internal class Program
    {
        static string filepath = "students.txt";
        static void Main(string[] args)
        {

            Console.WriteLine("\n1:add student");
            Console.WriteLine("\n2:view students");
            Console.WriteLine("\n3:edit students");
            Console.WriteLine("\n4:exit the program");
            Console.WriteLine("\n:enter your choice :");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        Add_student();
                        break;
                    }
                case 2:
                    {
                        view_student();
                        break;
                    }
                case 3:
                    {
                        Edit_student();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("EXITING THE PROGRAM...");
                        break;
                    }
                default:
                    Console.WriteLine("invalid choice...");
                    break;

            }
        }
        static void Add_student()
        {
            Console.WriteLine("enter student name");
            string name = Console.ReadLine();
            Console.WriteLine("enter the student age");
            int age = Convert.ToInt32(Console.ReadLine());
            string student_data = $"Name:{name}, Age: {age}";
            File.AppendAllText(filepath, student_data + Environment.NewLine);
            Console.WriteLine("student added success");


        }
        static void view_student()
        {
            if (File.Exists(filepath))
            {
                string[] students = File.ReadAllLines(filepath);
                Console.WriteLine("\n------student list ------");
                foreach(string x in students)
                {
                    Console.WriteLine(x);
                }
            }
            else
            {
                Console.WriteLine("....ooopss...no students found ");
            }
        }
        static void Edit_student()
        {
            if (!File.Exists(filepath))
            {
                Console.WriteLine("no page found");
                return;
            }
            string[] lines = File.ReadAllLines(filepath);
            List<string> updated_list = new List<string>(lines);
            Console.WriteLine("Enter the student name to update");
            string name = Console.ReadLine();
            bool found = false;
            for(int i=0; i<updated_list.Count; i++)
            {
                if (updated_list[i].StartsWith($"Name:{name}"))
                {
                    Console.WriteLine("enter new age");
                    string new_age = Console.ReadLine();
                    updated_list[i] = $"Name:{name},Age:{new_age}";
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Student not found.");
            }
            else
            {
                File.WriteAllLines(filepath,updated_list);
                Console.WriteLine("student updated successfully");
            }

        }
    }
}
