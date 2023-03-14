﻿using OasisSongbook.Business.Model.Enum;

namespace OasisSongbook.Business.Model.Dto
{
    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public UserRole Role { get; set; }
    }
}
