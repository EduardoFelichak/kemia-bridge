﻿using KemiaBridge.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KemiaBridge.Domain.Entities
{
    [Table("user")]
    public class User
    {
        [Key]
        public int UserId { get; private set; }
        public UserType Type { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Phone { get; private set; }

        public ICollection<Activity> Activities { get; set; }
        public ICollection<SensorReading> SensorReadings { get; set; }

#pragma warning disable CS8618
        public User() { }

        public User(int userId, UserType type, string name, string email, string password, string phone)
        {
            UserId = userId;
            Type = type;
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
        }
    }
}
