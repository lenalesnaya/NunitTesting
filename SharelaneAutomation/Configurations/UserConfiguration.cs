﻿using Core.Configurations.Abstractions;

namespace SharelaneAutomation.Configurations
{
    internal class UserConfiguration : IConfiguration
    {
        public string SectionName => "StandartUser";
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ZipCode { get; set; }
    }
}