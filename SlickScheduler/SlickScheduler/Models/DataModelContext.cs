using System.Data.Entity;
using SlickScheduler.Models;

namespace SlickScheduler.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
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
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Advisor> Advisors { get; set; }

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
        public virtual List<Student> Students { get; set; }
    }

    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Display(Name ="W Number")]
        public String WNumber { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{3,40}$", ErrorMessage ="First Name must be between 3 and 40 characters.")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{3,40}$", ErrorMessage = "Last Name must be between 3 and 40 characters.")]
        public String LastName { get; set; }

        [Required(ErrorMessage ="Enter a valid Email.")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage ="Invalid Email.")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Required(ErrorMessage="Password is required.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public String Password { get; set; }

        
        [NotMapped]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [DataType(DataType.Password)]
        public String ConfirmPassword { get; set; }
        

        public String PasswordSalt { get; set; }

        public String UserName { get; set; }

        public virtual List<Role> Roles { get; set; }
        public virtual Student Student { get; set; }
        public virtual Advisor Advisor { get; set; }
    }

    public class Role
    {
        public int RoleID { get; set; }
        public String RoleName { get; set; }
    }

    public class Student
    {
        [Key, ForeignKey("User")]
        public int StudentID { get; set; }
        
        public virtual Plan Plan { get; set; }
        public virtual User User { get; set; }
        public virtual Advisor Advisor { get; set; }
    }

    public class Advisor
    {
        [Key, ForeignKey("User")]
        public int AdvisorID { get; set; }
        public virtual User User { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}