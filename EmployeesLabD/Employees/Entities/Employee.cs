using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Entities
{
    /// <summary>
    /// Represents an Employee
    /// </summary>
    
    internal class Employee
    {
		// TODO: Add remaining fields, properties, and constructor parameters for general employee.
        protected string id;
        protected string name;
        protected string address;

        public string ID { get { return id; } }
        public string Name { get { return name; } }
        public string Address { get { return address; } }

        /// <summary>
        /// No-arg constructor
        /// </summary>
        public Employee() { }

        /// <summary>
        /// User-defined constructor
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <param name="name">Name of employee</param>
        /// <param name="address">Employee's address</param>
        public Employee(string id, string name, string address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
        }
        public virtual double CalcWeeklyPay()
        {
            return 0;
        }
    }
}
