using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace lab2
{
    public class Program
    {
        public static List<Employee> ReadFile()
        {
            List<Employee> employees = new List<Employee>();

            string line;
            try
            {
                StreamReader sr = new StreamReader("..\\..\\..\\res\\employees.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    string[] attr = line.Split(':');
                    char firstIdDigit = attr[0][0];
                    if (firstIdDigit >= '0' && firstIdDigit <= '4')
                    {
                        Salaried salaried = new Salaried(attr[0], attr[1], attr[2], attr[3], (long)Convert.ToDouble(attr[4]), attr[5], attr[6], Convert.ToDouble(attr[7]));
                        employees.Add(salaried);
                    }
                    else if (firstIdDigit >= '5' && firstIdDigit <= '7')
                    {
                        Wages wages = new Wages(attr[0], attr[1], attr[2], attr[3], (long)Convert.ToDouble(attr[4]), attr[5], attr[6], Convert.ToDouble(attr[7]), Convert.ToDouble(attr[8]));
                        employees.Add(wages);
                    }
                    else if (firstIdDigit >= '8' && firstIdDigit <= '9')
                    {
                        PartTime partTime = new PartTime(attr[0], attr[1], attr[2], attr[3], (long)Convert.ToDouble(attr[4]), attr[5], attr[6], Convert.ToDouble(attr[7]), Convert.ToDouble(attr[8]));
                        employees.Add(partTime);
                    }

                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return employees;
        }
        public static double AvgPay(List<Employee> employees)
        {      
            List<Wages> wageEmp = employees.OfType<Wages>().ToList();
            List<Salaried> salariedEmp = employees.OfType<Salaried>().ToList();
            List<PartTime> partTimeEmp = employees.OfType<PartTime>().ToList();

            double wageSum = 0;
            foreach (var employee in wageEmp)
            {
                wageSum += employee.getPay();
            }
            
            double salariedSum = 0;
            foreach (var employee in salariedEmp)
            {
                salariedSum += employee.getPay();
            }

            double partSum = 0;
            foreach (var employee in partTimeEmp)
            {
                partSum += employee.getPay();
            }

            double avg = (wageSum + salariedSum + partSum) / employees.Count;
            return avg;
        }
        public static string HighestWageEmp(List<Employee> employees)
        {
            List<Wages> wageEmp = employees.OfType<Wages>().ToList();

            Wages highestEmp = new Wages();
            double highestWage = 0;
            foreach (var employee in wageEmp) 
            {
                if (employee.getPay() >= highestWage) 
                { 
                    highestWage = employee.getPay();
                    highestEmp = employee;
                }
            }

            return $"{highestEmp.Name}: {highestWage:c}";
        }
        public static string LowestSalariedEmp(List<Employee> employees)
        {
            List<Salaried> salariedEmp = employees.OfType<Salaried>().ToList();

            Salaried lowestEmp = new Salaried();
            double lowest = salariedEmp[0].getPay();
            foreach (var employee in salariedEmp)
            {
                if (employee.getPay() <= lowest)
                {
                    lowest = employee.getPay();
                    lowestEmp = employee;
                }
            }

            return $"{lowestEmp.Name}: {lowest:c}";
        }
        public static string empCategory(List<Employee> employees)
        {
            List<Wages> wageEmp = employees.OfType<Wages>().ToList();
            List<Salaried> salariedEmp = employees.OfType<Salaried>().ToList();
            List<PartTime> partTimeEmp = employees.OfType<PartTime>().ToList();

            return $"Wages: {(double)wageEmp.Count/employees.Count:p}\nSalaried: {(double)salariedEmp.Count/employees.Count:p}\nPart time: {(double)partTimeEmp.Count/employees.Count:p}";
        }
        public static void Main(string[] args)
        {
            List<Employee> employees = ReadFile();

            Console.WriteLine("Average Weekly Pay: {0:c}", AvgPay(employees));
            Console.WriteLine("Highest weekly wage employee is " + HighestWageEmp(employees));
            Console.WriteLine("Lowest weekly salaried employee is " + LowestSalariedEmp(employees));
            Console.WriteLine("\nEmployee Categories:\n" + empCategory(employees));
        }
    }
}
