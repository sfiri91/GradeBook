﻿using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // var book = new InMemoryBook("Scott's Grade Book");
            IBook book = new DiskBook("Scott's Grade Book");
            // var book = new Book("");
            book.GradeAdded += OnGradeAdded;
            
            EnterGrades(book);

            var stats = book.GetStatistics();
            // book.Name = "";

            Console.WriteLine($"For the book named: {book.Name}");
            Console.WriteLine($"The average grade is: {stats.Average:N1}");
            Console.WriteLine($"The lowest grade is: {stats.Low}");
            Console.WriteLine($"The highest grade is: {stats.High}");
            Console.WriteLine($"The letter grade is: {stats.Letter}");

            static void OnGradeAdded(object sender, EventArgs e)
            {
                Console.WriteLine("A grade was added!");
            }
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Please enter a grade or press 'q' to exit: ");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("***");
                }
            }
        }
    }
}
