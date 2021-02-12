using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            var sum = numbers.Sum();
            var avg = numbers.Average();

            Console.WriteLine($"sum = {sum}, avg = {avg}");

            //Order numbers in ascending order and decsending order. Print each to console.

            /*
            IEnumerable<int> orderNumbersASC = numbers.OrderBy(x => x);
            IEnumerable<int> orderNumbersDESC = numbers.OrderByDescending(x => x);
            Console.WriteLine("ASC and DESC");
            foreach (int item in orderNumbersASC)
                Console.WriteLine(item);
            foreach (int item in orderNumbersDESC)
                Console.WriteLine(item);
            */

            var asc = numbers.OrderBy(x => x);
            var desc = numbers.OrderByDescending(x => x);
            Console.WriteLine("Ascending:");
            foreach (var num in asc)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("Descending:");

            foreach (var num in desc)
            {
                Console.WriteLine(num);
            }
            //Print to the console only the numbers greater than 6
            Console.WriteLine("Greater than 6");
            var greaterThan6 = numbers.Where(x => x > 6);


            foreach (var item in greaterThan6)
            {
                Console.WriteLine(item);
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Take 4");
            //IEnumerable<int> orderNumbersTake4 = numbers.OrderBy(x => x).Take(4);
            
            foreach (var item in asc.Take(4))
            {
                Console.WriteLine(item);
            }

            //Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("Index 4 = Age");
            numbers[4] = 26;
            foreach (var item in numbers.OrderByDescending(num => num))
            {
                Console.WriteLine(item);
            }
            

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            Console.WriteLine("Starts with C or S");
            var filtered = employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S')).OrderBy(person => person.FirstName);
            foreach (var employee in filtered)
            {
                Console.WriteLine(employee.FullName);
            }

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Over age 26");
            foreach (var employee in employees.Where(person => person.Age > 26).OrderBy(person => person.Age).ThenBy(person => person.FirstName).ThenBy(person => person.YearsOfExperience))
            {
                Console.WriteLine($"{employee.FullName} is {employee.Age} years old.");
            }


            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            Console.WriteLine("Experience");
            var totalYOE = employees.Where(person => person.YearsOfExperience <= 10 && person.Age > 35);
            foreach (var item in totalYOE)
            {

                Console.WriteLine($"{item.FullName}: Sum of YOE is: {totalYOE.Sum(employee => employee.YearsOfExperience)}, AVG of YOE is: {totalYOE.Average(employee => employee.YearsOfExperience)}");
            }

            //Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("Add someone");

            employees = employees.Append(new Employee("first", "last", 30, 10)).ToList();

            foreach (var emp in employees)
            {
                Console.WriteLine($"{ emp.FirstName}, {emp.LastName}, {emp.Age}, {emp.YearsOfExperience}");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
