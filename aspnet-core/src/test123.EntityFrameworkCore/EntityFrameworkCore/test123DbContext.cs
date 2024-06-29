using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using test123.Authorization.Roles;
using test123.Authorization.Users;
using test123.MultiTenancy;
using test123.Courses;

namespace test123.EntityFrameworkCore
{
    public class test123DbContext : AbpZeroDbContext<Tenant, Role, User, test123DbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Course> Courses { get; set; }
        public test123DbContext(DbContextOptions<test123DbContext> options)
            : base(options)
        {
        }
    }
}
