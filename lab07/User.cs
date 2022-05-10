using System;
using System.Data.Linq.Mapping;

namespace lab07
{
    [Table(Name = "User")]
    public class UserEntity
    {
        [Column(IsPrimaryKey = true, Name = "Id")]
        public long Id { get; set; }

        [Column(Name = "Name")] public string Name { get; set; }

        [Column(Name = "Role")] public string Role { get; set; } // ADMIN, MODERATOR, TEACHER, STUDENT

        [Column(Name = "CreatedAt")] public DateTime? CreatedAt { get; set; }

        [Column(Name = "RemovedAt")] public DateTime? RemovedAt { get; set; }
    }
}