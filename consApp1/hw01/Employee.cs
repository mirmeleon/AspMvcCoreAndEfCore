namespace hw01
{
    using System.ComponentModel.DataAnnotations;
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
