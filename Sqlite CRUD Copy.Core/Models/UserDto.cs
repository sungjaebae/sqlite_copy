using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sqlite_CRUD_Copy.Core.Models
{
    
    [Table("Users")]
    public class UserDto
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
