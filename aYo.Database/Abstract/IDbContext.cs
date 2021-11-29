using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace aYo.Database.Abstract
{
    public interface IDbContext
    {
        DbSet<T> GetEntity<T>() where T : class, new();
    }
}
