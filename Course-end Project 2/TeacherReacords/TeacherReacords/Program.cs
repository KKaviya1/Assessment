using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherReacords;

namespace TeacherRecords
{
    internal class Program
    {
        static string filePath = "F:\\Assessment\\Course-end Project 2\\TeacherRecords.txt";
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("**Storing and Updating Teacher Records**");
                Console.WriteLine("\n1. Add Teacher\n2. Update Teacher\n3. Retrieve Teacher\n4. Exit");
                Console.Write("\nEnter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddTeacher();
                        break;
                    case 2:
                        UpdateTeacher();
                        break;
                    case 3:
                        RetrieveTeacher();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddTeacher()
        {
            Console.Write("Enter Teacher ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Teacher Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Teacher Class and Section: ");
            string classAndSection = Console.ReadLine();

            Teacher teacher = new Teacher
            {
                ID = id,
                Name = name,
                ClassAndSection = classAndSection
            };

            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine($"{teacher.ID},{teacher.Name},{teacher.ClassAndSection}");
            }

            Console.WriteLine("Teacher added successfully.");
        }

        static void UpdateTeacher()
        {
            Console.Write("Enter Teacher ID to update: ");
            int targetID = int.Parse(Console.ReadLine());

            List<string> lines = new List<string>(File.ReadAllLines(filePath));

            for (int i = 0; i < lines.Count; i++)
            {
                string[] parts = lines[i].Split(',');
                int id = int.Parse(parts[0]);

                if (id == targetID)
                {
                    Console.Write("Enter updated Teacher Name: ");
                    parts[1] = Console.ReadLine();

                    Console.Write("Enter updated Teacher Class and Section: ");
                    parts[2] = Console.ReadLine();

                    lines[i] = string.Join(",", parts);
                    File.WriteAllLines(filePath, lines);

                    Console.WriteLine("Teacher updated successfully.");
                    return;
                }
            }

            Console.WriteLine("Teacher not found.");
        }

        static void RetrieveTeacher()
        {
            Console.Write("Enter Teacher ID to retrieve: ");
            int targetID = int.Parse(Console.ReadLine());

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                int id = int.Parse(parts[0]);

                if (id == targetID)
                {
                    Console.WriteLine($"ID: {parts[0]}\nName: {parts[1]}\nClass and Section: {parts[2]}");
                    return;
                }
            }

            Console.WriteLine("Teacher not found.");
        }
    }
}
    