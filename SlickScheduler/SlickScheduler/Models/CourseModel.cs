using System.Data.Entity;
using SlickScheduler.Models;

namespace SlickScheduler.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class CourseModel : DbContext
    {
        // If you wish to target a different database and/or database provider, modify the 'CourseModel' 
        // connection string in the application configuration file.
        public CourseModel()
            : base("name=ProjectDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CourseModel, SlickScheduler.Migrations.Configuration>("ProjectDB"));
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }
        /*
//public virtual DbSet<Plan> CMPS_MBA_2013 { get; set; }
//public virtual DbSet<Plan> CMPS_IT_2013 { get; set; }
//public virtual DbSet<Plan> CMPS_SCI_2013 { get; set; }
*/
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
        public String Name
        {
            get
            {
                Name = Major + "_" + Concentration + "_" + CatalogYear;
                return Name;
            }
            set
            {
                Name = Major + "_" + Concentration + "_" + CatalogYear;
            }
        }
        public virtual List<Semester> Semesters { get; set; }
        
    }
}