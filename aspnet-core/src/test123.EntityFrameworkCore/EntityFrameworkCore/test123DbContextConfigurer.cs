using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace test123.EntityFrameworkCore
{
    public static class test123DbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<test123DbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<test123DbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
