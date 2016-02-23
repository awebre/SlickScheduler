namespace SlickScheduler.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SlickScheduler.Models.CourseModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SlickScheduler.Models.CourseModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Courses.AddOrUpdate(
                  c => c.Id,
                  new Models.Course { Id = 0, Name = "Algorithm Design & Implementation I", Subject = "CMPS", Number = 161, CreditHours = 3 },
                  new Models.Course { Id = 1, Name = "Discrete Structures", Subject = "CMPS", Number = 257, CreditHours = 3 },
                  new Models.Course { Id = 2, Name = "Algorithm Design & Implementation II", Subject = "CMPS", Number = 280, CreditHours = 3 },
                  new Models.Course { Id = 3, Name = "Software Engineering", Subject = "CMPS", Number = 285, CreditHours = 3 },
                  new Models.Course { Id = 4, Name = "Computer Organization", Subject = "CMPS", Number = 290, CreditHours = 3 },
                  new Models.Course { Id = 5, Name = "Assembly Language", Subject = "CMPS", Number = 293, CreditHours = 3 },
                  new Models.Course { Id = 6, Name = "Internet Programming", Subject = "CMPS", Number = 294, CreditHours = 3 },
                  new Models.Course { Id = 7, Name = "System Administration", Subject = "CMPS", Number = 315, CreditHours = 3 },
                  new Models.Course { Id = 8, Name = "Computer Networking and Security", Subject = "CMPS", Number = 329, CreditHours = 3 },
                  new Models.Course { Id = 9, Name = "Computer Architecture", Subject = "CMPS", Number = 375, CreditHours = 3 },
                  new Models.Course { Id = 10, Name = "Information Systems", Subject = "CMPS", Number = 383, CreditHours = 3 },
                  new Models.Course { Id = 11, Name = "Data Structures", Subject = "CMPS", Number = 390, CreditHours = 3 },
                  new Models.Course { Id = 12, Name = "Capstone I", Subject = "CMPS", Number = 411, CreditHours = 3 },
                  new Models.Course { Id = 13, Name = "Integrated Technologies for Enterprise Systems", Subject = "CMPS", Number = 415, CreditHours = 3 },
                  new Models.Course { Id = 14, Name = "Human Computer Interaction", Subject = "CMPS", Number = 420, CreditHours = 3 },
                  new Models.Course { Id = 15, Name = "Operating Systems", Subject = "CMPS", Number = 431, CreditHours = 3 },
                  new Models.Course { Id = 16, Name = "Database Systems", Subject = "CMPS", Number = 439, CreditHours = 3 },
                  new Models.Course { Id = 17, Name = "Current Trends in Computer Science", Subject = "CMPS", Number = 482, CreditHours = 3 }
                );
        }
    }
}
