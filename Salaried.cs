using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lab2
{
    public class Salaried : Employee
    {
        double salary;
        public double Salary { get => salary; set => salary = value; }

        public Salaried() { }
        
        public Salaried(string id, string name, string address, string phone, long sin, string dob, string dept, double salary) : base(id, name, address, phone, sin, dob, dept)
        {
            this.salary = salary;   
        }
        public double getPay() 
        { 
            return salary;
        }

        public override string ToString()
        {
            return $"ID:{Id} Name:{Name} Address:{Address} Phone #:{Phone} SIN:{Sin} DoB:{Dob} Department:{Dept} Salary:{salary:c}";
        }
    }
}
