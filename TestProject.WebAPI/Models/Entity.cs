using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.WebAPI.Models
{
    public abstract class Entity
    {
        public long Id { get; set; }
        public DateTimeOffset DateAdded { get; set; }
        public DateTimeOffset DateModified { get; set; }
    }
}
