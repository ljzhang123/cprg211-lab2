using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace lab2
{
    public class Employee
    {
        string id;
        string name;
        string address;
        string phone;
        long sin;
        string dob;
        string dept;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public long Sin { get => sin; set => sin = value; }
        public string Dob { get => dob; set => dob = value; }
        public string Dept { get => dept; set => dept = value; }

        public Employee() { }

        public Employee(string id, string name, string address, string phone, long sin, string dob, string dept)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.sin = sin;
            this.dob = dob;
            this.dept = dept;
        }

        public override string ToString()
        {
            return $"ID:{id} Name:{name} Address:{address} Phone #:{phone} SIN:{sin} DoB:{dob} Department:{dept}";
        }
    }
}
