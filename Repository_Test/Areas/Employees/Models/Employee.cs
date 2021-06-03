using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Repository_Test.Areas.Employees.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        public string EmpName { get; set; }

        public string EmpDesignation { get; set; }

        public string EmpSalary { get; set; }

    }
}
