﻿using KnivesStore.DAL.Models;

namespace KnivesStore.PL.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        //public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}