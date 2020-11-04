﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnivesStore.DAL.Models
{
    public enum UserRole : byte
    {
        Default = 0,
        Moderator = 1,
        Admin = 2
    }

    public class User : IEquatable<User>
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Password")]
        public string Password { get; set; }
        [Column("Role")]
        public UserRole Role { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Email)}: {Email}, {nameof(Name)}: {Name}, {nameof(Password)}: {Password}, {nameof(Role)}: {Role}";
        }

        public bool Equals(User other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Email, other.Email) && string.Equals(Name, other.Name) && string.Equals(Password, other.Password);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User) obj);
        }
    }
}