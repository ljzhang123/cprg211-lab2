using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab2
{
    public class PartTime : Employee
    {
        double rate;
        double hours;
        public double Rate { get => rate; set => rate = value; }
        public double Hours { get => hours; set => hours = value; }
        public PartTime() { }
        public PartTime(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : base(id, name, address, phone, sin, dob, dept)
        {
            this.rate = rate;
            this.hours = hours;
        }

        public double getPay()
        {
            return rate * hours;
        }

        public override string ToString()
        {
            return $"ID:{Id} Name:{Name} Address:{Address} Phone #:{Phone} SIN:{Sin} DoB:{Dob} Department:{Dept} Rate:{rate:c}/hr Hours:{hours}";
        }
    }
}
