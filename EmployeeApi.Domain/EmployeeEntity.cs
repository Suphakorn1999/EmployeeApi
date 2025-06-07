using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeApi.Domain.Entities;

public class Employee
{
    [Column("id")] [Key] public int Id { get; set; }
    [Column("emp_no")] public string? EmpNo { get; set; }
    [Column("first_name")] public string? FirstName { get; set; }
    [Column("last_name")] public string? LastName { get; set; }
    [Column("designation")] public string? Designation { get; set; }
    [Column("hire_date")] public DateTime HireDate { get; set; }
    [Column("salary")] public decimal Salary { get; set; }
    [Column("comm")] public decimal? Comm { get; set; }
    [Column("dept_no")] public int DeptNo { get; set; }
    [Column("is_deleted")] public bool IsDeleted { get; set; }
    [Column("delete_date")] public DateTime? deleteDate { get; set; }
}
