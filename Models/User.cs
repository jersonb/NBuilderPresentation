using System;

namespace Models
{
    public class User
    {
        public Guid ExternalId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}