using System.Data.Entity;
using SlickScheduler.Models;

namespace SlickScheduler.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class DataModelContext : DbContext
    {
        // If you wish to target a different database and/or database provider, modify the 'CourseModel' 
        // connection string in the application configuration file.
        public DataModelContext()
            : base("name=ProjectDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataModelContext, SlickScheduler.Migrations.Configuration>("ProjectDB"));
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }

    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public int Number { get; set; }
        public int CreditHours { get; set; }

        public virtual List<Semester> Semesters { get; set; }

    }

    public class Semester
    {
        public int SemesterId { get; set; }
        public int SemesterNum { get; set; }


        public virtual List<Course> Courses { get; set; }
        public virtual List<Plan> Plans { get; set; }
    }

    public class Plan
    {
        public int PlanId { get; set; }
        public String Major { get; set; }
        public String Concentration { get; set; }
        public int CatalogYear { get; set; }
        public String Name { get; set; }

        public virtual List<Semester> Semesters { get; set; }
    }

    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        public String PasswordSalt { get; set; }

        public String UserName { get; set; }
    }
}