﻿namespace CS.Core;

public class Supplier 
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = String.Empty;
    public string? ContactName { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
}