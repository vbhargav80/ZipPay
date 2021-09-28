using System;

namespace TestProject.WebAPI.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTimeOffset DateAdded { get; set; }
        public DateTimeOffset DateModified { get; set; }
    }
}
