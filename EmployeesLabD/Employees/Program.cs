using Employees.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    /// <summary>
    /// CPRG211 - Lab Inheritance (Completed Version)
    /// </summary>
    /// <remarks>Author: Kevin Liu </remarks>
    /// <remarks>Date:Feb 2, 2023 </remarks>
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create list that holds Employee instances
            List<Employee> employees = new List<Employee>();

            // Must be a relative path
            string path = "employees.txt";

            // Converts lines in file into an array of strings
            string[] lines = File.ReadAllLines(path);

            // Loop through each line
            foreach (string line in lines)
            {
                // Split line into parts or cells.
                string[] cells = line.Split(':');

                // The first 3 cells are the ID, name, and address.
                string id = cells[0];
                string name = cells[1];
                string address = cells[2];
				
				// TODO: Get remaining employee info from cells

                // Extract the first digit of the ID.
                string firstDigit = id.Substring(0, 1);

                // Convert first digit from string to int.
                int firstDigitInt = int.Parse(firstDigit);

                // Check range of first digit
                if (firstDigitInt >= 0 && firstDigitInt <= 4)
                {
                    // Salaried
                    string salary = cells[7];

                    // Convert salary from string to double.
                    double salaryDouble = double.Parse(salary);

                    // Create Salaried instance
                    Salaried salaried = new Salaried(id, name, address, salaryDouble);

                    // Add to list of employees.
                    employees.Add(salaried);
                }
                else if (firstDigitInt >= 5 && firstDigitInt <= 7)
                {
                    // Wage
                    string rate = cells[7];
                    string hours = cells[8];

                    // Convert rate and hours from string to double
                    double rateDouble = double.Parse(rate);
                    double hoursDouble = double.Parse(hours);

                    // Create Wages instance
                    Waged wages = new Waged(id,name, address, rateDouble, hoursDouble);

                    // Add to list of employees.
                    employees.Add(wages);
                }
                else if (firstDigitInt >= 8 && firstDigitInt <= 9)
                {
                    // Part time
                    string rate = cells[7];
                    string hours = cells[8];

                    // Convert rate and hours from string to double
                    double rateDouble = double.Parse(rate);
                    double hoursDouble = double.Parse(hours);

                    // Create PartTime instance
                    PartTime partTime = new PartTime(id, name, address, rateDouble, hoursDouble);

                    // Add to list of employees
                    employees.Add(partTime);

                }     
             }
            /*if (firstDigit == "0" || firstDigit == "1" || firstDigit == "2" || firstDigit == "3" || firstDigit == "4")
                {

                }*/

            /**
             * TODO:
             *  - Determine average weekly pay of all employees.
             *  - Determine highest paid waged employee.
             *  - Determine lowest paid salaried employee.
             *  - Determine percentage of employees that are salaried, waged, and part-time.
             */
            double weeklyPaySum = 0;
            // It's okay to use loop through employees multiple times.
            //NOTE: Taking from Employee.cs so need to have CalcWeeklyPay() in Employee.cs with virutal method ,
            //      this in turn will make you add the override method to CalcWeeklyPay() in the inherited classes 
            foreach (Employee employee in employees)
            {
                double weeklyPay = employee.CalcWeeklyPay();

                weeklyPaySum += weeklyPay;

            }
            double averageWeeklyPay = weeklyPaySum / employees.Count;

            Console.WriteLine("Average Weekly pay: " + averageWeeklyPay);


            //Returning the highest weekly payed employee (waged)
            Waged highestPaidWaged = null;

            foreach (Employee employee in employees)
            {
                if (employee is Waged)
                {
                    Waged waged = (Waged)employee;
                    
                    if (highestPaidWaged == null || waged.CalcWeeklyPay() > highestPaidWaged.CalcWeeklyPay())
                    {
                        //Assigned
                        highestPaidWaged=waged;
                    }

                }
            }
            Console.WriteLine("Employee " + highestPaidWaged.Name + " is highest weekly paid ($" + highestPaidWaged.CalcWeeklyPay() + ")");

            //Returning the lowest weekly payed employee (Salaried)
            Salaried lowestPaidSalaried = null;
            foreach (Employee employee in employees)
            {
                if (employee is Salaried)
                {
                    Salaried salary = (Salaried)employee;
                    if (lowestPaidSalaried == null || salary.CalcWeeklyPay() < lowestPaidSalaried.CalcWeeklyPay())
                    {
                        lowestPaidSalaried = salary;
                    }
                }
            }
            Console.WriteLine("Employee " + lowestPaidSalaried.Name + " is lowest salaried paid ($" + lowestPaidSalaried.CalcWeeklyPay() + ")");

            //Returning percentage amount of employee in categories
            double totalEmployedSalaried = 0;
            double totalEmployedWaged = 0;
            double totalEmployedPartTime= 0;
            double totalEmployed = 0;
            foreach (Employee employee in employees) 
            {
                if (employee is Salaried) 
                {
                    totalEmployedSalaried += 1;
                }
                else if (employee is Waged)
                {
                    totalEmployedWaged += 1;
                }
                else if (employee is PartTime) 
                {
                    totalEmployedPartTime += 1;
                }
                
            }
            totalEmployed = totalEmployedSalaried + totalEmployedPartTime + totalEmployedWaged;
            Console.WriteLine("Percentage of waged employees is (" + ((totalEmployedWaged/totalEmployed)*100)+"%)");
            Console.WriteLine("Percentage of salaried employees is (" + ((totalEmployedSalaried / totalEmployed) * 100) + "%)");
            Console.WriteLine("Percentage of part-time employees is (" + ((totalEmployedPartTime / totalEmployed) * 100) + "%)");
        }
      }
    }

