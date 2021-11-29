using System;
using System.Collections.Generic;
using System.Text;

namespace aYo.Database.Entities
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            Updated = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
