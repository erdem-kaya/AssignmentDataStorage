﻿namespace Business.Models.Employees;

public class EmployeeRegistrationForm
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int RoleId { get; set; }
}
