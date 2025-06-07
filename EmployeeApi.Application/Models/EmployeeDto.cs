public class EmployeeDtoReq
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Designation { get; set; }
    public decimal Salary { get; set; }
    public decimal? Comm { get; set; }
    public int DeptNo { get; set; }
}

public class EmployeeDtoRes
{
    public int EmpNo { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Designation { get; set; }
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
    public decimal? Comm { get; set; }
    public int DeptNo { get; set; }
}