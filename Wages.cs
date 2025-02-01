using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class Wages : Employee
    {
        double rate;
        double hours;
        public double Rate { get => rate; set => rate = value; }
        public double Hours { get => hours; set => hours = value; }

        public Wages() { }
        public Wages(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : base(id, name, address, phone, sin, dob, dept)
        {
            this.rate = rate;
            this.hours = hours;
        }

        public double getPay()
        {
            if (hours > 40)
            {
                double ot = (hours - 40) * (rate * 1.5);
                double pay = (40 * rate) + ot;
                return pay;
            }
            else { return hours * rate; }
        }
        public override string ToString()
        {
            return $"ID:{Id} Name:{Name} Address:{Address} Phone #:{Phone} SIN:{Sin} DoB:{Dob} Department:{Dept} Rate:{rate:c}/hr Hours:{hours}";
        }
    }
}
