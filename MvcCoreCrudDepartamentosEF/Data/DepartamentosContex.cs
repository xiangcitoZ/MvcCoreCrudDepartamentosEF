using Microsoft.EntityFrameworkCore;
using MvcCoreCrudDepartamentosEF.Models;

namespace MvcCoreCrudDepartamentosEF.Data
{
    public class DepartamentosContex: DbContext
    {
        public DepartamentosContex(DbContextOptions<DepartamentosContex> options)
            : base(options) { }

        public DbSet<Departamento> Departamentos { get; set; }


    }
}
