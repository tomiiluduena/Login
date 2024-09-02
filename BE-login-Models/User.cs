using System;
using System.ComponentModel.DataAnnotations;

namespace BE_login_Common
{
    public class User
    {
        [Key]
        public int IdUsers { get; set; }
        public string? Name { get; set; }
        public string? Service { get; set; }
        public DateTime? Date { get; set; }
    }
}
