using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace StudentManagementSystem
{
    public enum MenuOption
    {
        AddStudent = 1,
        ViewAllStudents,
        SearchStudent,
        UpdateStudentGrade,
        Exit
    }

    class StudentManagementSystem
    {
        static void Main()
        {
            var students = LoadStudents(); 
            bool exit = false;

            while (!exit)
            {
                DisplayMenu();

                string input = Console.ReadLine();
                if (Enum.TryParse(input, out MenuOption choice) && Enum.IsDefined(typeof(MenuOption), choice))
                {
                    HandleMenuChoice(choice, students, ref exit);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose a valid option (1-5).");
                }
                SaveStudents(students);
            }

           
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\nStudent Management System");
            Console.WriteLine("1. Add New Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Search Student by Roll Number");
            Console.WriteLine("4. Update Student Grade");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option (1-5): ");
        }

        static void HandleMenuChoice(MenuOption choice, List<Student> students, ref bool exit)
        {
            switch (choice)
            {
                case MenuOption.AddStudent:
                    AddStudent(students);
                    break;
                case MenuOption.ViewAllStudents:
                    ViewAllStudents(students);
                    break;
                case MenuOption.SearchStudent:
                    SearchStudent(students);
                    break;
                case MenuOption.UpdateStudentGrade:
                    UpdateStudentGrade(students);
                    break;
                case MenuOption.Exit:
                    exit = true;
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;
            }
        }

        static void AddStudent(List<Student> students)
        {
            string name;
            while (true)
            {
                Console.Write("Enter Student Name: ");
                name = Console.ReadLine();

                if (!string.IsNullOrEmpty(name) && System.Text.RegularExpressions.Regex.IsMatch(name, @"^[a-zA-Z\s]+$"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid name. Please enter a name without numbers or special characters.");
                }
            }

                int rollNumber;
            while (true)
            {
                Console.Write("Enter Roll Number: ");
                if (int.TryParse(Console.ReadLine(), out rollNumber) && !students.Exists(s => s.RollNumber == rollNumber))
                    break;
                else
                    Console.WriteLine("Invalid or duplicate Roll Number. Please enter a valid and unique integer.");
            }

            char grade;
            while (true)
            {
                Console.Write("Enter Grade (A-F): ");
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && char.TryParse(input, out grade) && "ABCDEF".Contains(char.ToUpper(grade)))
                {
                    grade = char.ToUpper(grade);
                    break;
                }
                else
                    Console.WriteLine("Invalid Grade. Please enter a letter between A and F.");
            }

            students.Add(new Student(name, rollNumber, grade));
            Console.WriteLine("Student added successfully!");
        }

        static void ViewAllStudents(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            Console.WriteLine("\nList of Students:");
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Roll Number: {student.RollNumber}, Grade: {student.Grade}");
            }
        }

        static void SearchStudent(List<Student> students)
        {
            Console.Write("Enter Roll Number to search: ");
            if (int.TryParse(Console.ReadLine(), out int rollNumber))
            {
                var student = students.FirstOrDefault(s => s.RollNumber == rollNumber);
                if (student != null)
                {
                    Console.WriteLine("Student found:");
                    Console.WriteLine($"Name: {student.Name}, Roll Number: {student.RollNumber}, Grade: {student.Grade}");
                }
                else
                {
                    Console.WriteLine("No student found with the given Roll Number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Roll Number. Please enter a valid integer.");
            }
        }

        static void UpdateStudentGrade(List<Student> students)
        {
            Console.Write("Enter Roll Number to update grade: ");
            if (int.TryParse(Console.ReadLine(), out int rollNumber))
            {
                var student = students.Find(s => s.RollNumber == rollNumber);
                if (student != null)
                {
                    char grade;
                    while (true)
                    {
                        Console.Write("Enter New Grade (A-F): ");
                        string input = Console.ReadLine();
                        if (!string.IsNullOrEmpty(input) && char.TryParse(input, out grade) && "ABCDEF".Contains(char.ToUpper(grade)))
                        {
                            grade = char.ToUpper(grade);
                            break;
                        }
                        else
                            Console.WriteLine("Invalid Grade. Please enter a letter between A and F.");
                    }

                    student.Grade = grade;
                    Console.WriteLine("Student grade updated successfully!");
                }
                else
                {
                    Console.WriteLine("No student found with the given Roll Number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Roll Number. Please enter a valid integer.");
            }
        }

        static List<Student> LoadStudents()
        {
            const string filePath = @"C:\Users\LENOVO\Desktop\FINAL_PROJECT\StudentManagementSystem\Students.json";
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Student>>(json) ?? new List<Student>();
            }

            return new List<Student>();
        }

        static void SaveStudents(List<Student> students)
        {
            const string filePath = @"C:\Users\LENOVO\Desktop\FINAL_PROJECT\StudentManagementSystem\Students.json";
            var json = JsonConvert.SerializeObject(students, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }

}
