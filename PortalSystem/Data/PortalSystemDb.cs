using Microsoft.EntityFrameworkCore;
using PortalSystem.Models;

namespace PortalSystem.Data
{
    public class PortalSystemDb : DbContext
    {
        public PortalSystemDb(DbContextOptions<PortalSystemDb> options)
            : base(options)
        {
             
        }
        public DbSet<Users> TblUsers { get; set; }
        public DbSet<RolesName> TblRolesNames { get; set; }
        public DbSet<Roles> TblRoles { get; set; }
        public DbSet<EnrolledUsers> TblEnrolledUsers { get; set; }
        public DbSet<TblClass> TblClasses { get; set; }
    }
}
