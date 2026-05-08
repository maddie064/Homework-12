using System;
using System.Collections.Generic;

namespace StudentGradeCalculator
{
    // Part 1: Create a GradeCalculator Class
    public class GradeCalculator
    {
        // Properties
        public string StudentName { get; set; }
        public int[] Grades { get; set; }

        // Constructor to initialize the object easily
        public GradeCalculator(string studentName, int[] grades)
        {
            StudentName = studentName;
            Grades = grades;
        }

        // Calculates and returns the average grade
        public double CalculateAverage()
        {
            if (Grades == null || Grades.Length == 0)
                return 0;

            double sum = 0;
            // Using a foreach loop to iterate through the array
            foreach (int grade in Grades)
            {
                sum += grade;
            }
            return sum / Grades.Length;
        }

        // Returns the letter grade based on average
        public string GetLetterGrade()
        {
            double average = CalculateAverage();

            // Using conditional statements (if/else if) for grade conversion
            if (average >= 90) return "A";
            else if (average >= 80) return "B";
            else if (average >= 70) return "C";
            else if (average >= 60) return "D";
            else return "F";
        }

        // Returns the highest grade in the array
        public int GetHighestGrade()
        {
            int highest = Grades[0];
            for (int i = 1; i < Grades.Length; i++)
            {
                if (Grades[i] > highest)
                {
                    highest = Grades[i];
                }
            }
            return highest;
        }

        // Returns the lowest grade in the array
        public int GetLowestGrade()
        {
            int lowest = Grades[0];
            foreach (int grade in Grades)
            {
                if (grade < lowest)
                {
                    lowest = grade;
                }
            }
            return lowest;
        }

        // Prints a formatted report
        public void DisplayGradeReport()
        {
            Console.WriteLine("\n===== GRADE REPORT =====");
            Console.WriteLine($"\nStudent: {StudentName}");
            
            // Format all grades as a single string
            Console.WriteLine($"\nAll Grades: {string.Join(" ", Grades)}");
            
            // Output average formatted to 2 decimal places using "F2"
            Console.WriteLine($"\nAverage Grade: {CalculateAverage():F2}");
            Console.WriteLine($"Letter Grade: {GetLetterGrade()}");
            Console.WriteLine($"Highest Grade: {GetHighestGrade()}");
            Console.WriteLine($"Lowest Grade: {GetLowestGrade()}");
        }

        // === BONUS CHALLENGE METHODS ===
        
        // Returns true if average >= 70
        public bool IsPassingGrade()
        {
            return CalculateAverage() >= 70;
        }

        // Counts how many grades fall within a specific range
        public int CountGradesBetween(int min, int max)
        {
            int count = 0;
            foreach (int grade in Grades)
            {
                if (grade >= min && grade <= max)
                {
                    count++;
                }
            }
            return count;
        }
    }

    class Program
    {
        // Part 2: Create a Main Program
        static void Main(string[] args)
        {
            // Testing with at least 2 different students (Bonus List implementation)
            List<GradeCalculator> students = new List<GradeCalculator>();

            // 1. Create a GradeCalculator object for "John Smith"
            int[] johnGrades = { 85, 90, 78, 92, 88, 76, 95 };
            GradeCalculator student1 = new GradeCalculator("John Smith", johnGrades);
            students.Add(student1);

            // 2. Create a second test student
            int[] janeGrades = { 95, 98, 89, 100, 92 };
            GradeCalculator student2 = new GradeCalculator("Jane Doe", janeGrades);
            students.Add(student2);

            // Loop through our list of students to display reports and calculate statistics
            foreach (var student in students)
            {
                // 3. Display the basic grade report
                student.DisplayGradeReport();

                // 4. Calculate additional statistics in Main()
                double average = student.CalculateAverage();
                int aboveAverageCount = 0;
                int belowAverageCount = 0;

                // Determine how many grades are above or below the average
                foreach (int grade in student.Grades)
                {
                    if (grade > average)
                        aboveAverageCount++;
                    else if (grade < average)
                        belowAverageCount++;
                }

                // Calculate the range
                int range = student.GetHighestGrade() - student.GetLowestGrade();

                // Display the additional statistics
                Console.WriteLine("\nStatistics:");
                Console.WriteLine($"Grades Above Average: {aboveAverageCount}");
                Console.WriteLine($"Grades Below Average: {belowAverageCount}");
                Console.WriteLine($"Grade Range: {range} points");
                
                // Displaying bonus challenge passing status
                Console.WriteLine($"Passing Status: {(student.IsPassingGrade() ? "Pass" : "Fail")}");
                Console.WriteLine("========================");
            }

            // Keep the console window open
            Console.ReadLine();
        }
    }
}
