using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SlickScheduler.Models
{
    public class PlanModel : DbContext
    {
        public PlanModel()
            : base("name=ProjectDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PlanModel, SlickScheduler.Migrations.Configuration>("ProjectDB"));
        }

        public virtual DbSet<Plan> CMPS_IT_2013 { get; set; }
    }

    public class Plan
    {
        public int Id { get; set; }
        public int Semester { get; set; }
    }
}