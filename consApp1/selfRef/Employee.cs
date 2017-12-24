using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace selfRef
{
  public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public int? ManagerId { get; set; }

        public Employee Manager { get; set; }

        public List<Employee> ManagedEmployees { get; set; } = new List<Employee>();
    }
}
