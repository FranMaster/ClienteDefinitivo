using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CargasNetClient.Model
{
    [Table("user")]
    public class Users
    {
        [PrimaryKey ,AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100),Unique]
        public string Usuario { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }
        [MaxLength(100), Unique]
        public string Email { get; set; }

    }
}
