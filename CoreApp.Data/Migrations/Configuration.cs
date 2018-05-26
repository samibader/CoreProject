namespace CoreApp.Data.Migrations
{
    using CoreApp.Common;
    using CoreApp.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            // USERNAME : Admin
            // PASSWORD : 1q2w!Q@W
            SeedAdminUserAndRole(context);

        }

        private Guid ADMIN_ROLE_ID = Guid.Parse("aaaaaaaa-555d-40ff-85d5-8342ebc5f32c");
        private Guid ADMIN_USER_ID = Guid.Parse("00000000-555d-40ff-85d5-8342ebc5f32c");
        private void SeedAdminUserAndRole(ApplicationDbContext context)
        {
            if(!context.Roles.Where(r=>r.RoleId==ADMIN_ROLE_ID).Any())
            { 
            var AdminRole=new Role { RoleId = ADMIN_ROLE_ID, Name = "AdminRole" };
            context.Roles.AddOrUpdate(
                    r => r.Name,
                    AdminRole
                );
            context.SaveChanges();

            context.Users.AddOrUpdate(
                u => u.UserName,
                new User { UserId = ADMIN_USER_ID, UserName = "Admin", Email = "admin@core.com", CreationDate = Utils.ServerNow, FullName = "Administrator", PasswordHash = "AAhJLnBd0DCF7ZEABUCeih2bWJNRSM3eJ+kVCSdEcjM7TpwibUTfc4Ukssv9uxKrdw==", SecurityStamp = "75a7bfb7-9db7-44dd-a2c0-c1857ebc9f67" }
            );
            context.SaveChanges();

            context.Users.Where(u => u.UserId.ToString() == ADMIN_USER_ID.ToString()).SingleOrDefault().Roles.Add(AdminRole);
            context.SaveChanges();
            }
            
        }
    }
}
