﻿namespace Business.Dtos;

public class ServiceRegistrationForm
{
    public string ServiceName { get; set; } = null!;
    public decimal Price { get; set; }
    public int UnitId { get; set; }
}
