﻿namespace TaskManagement.Domain.User;

public class User
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Mobile { get; set; }
    public List<Role> Roles { get; set; }
}

public class Role
{
    public int ID { get; set; }
    public string Title { get; set; }
}