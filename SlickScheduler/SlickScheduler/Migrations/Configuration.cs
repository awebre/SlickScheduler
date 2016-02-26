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
                  new Models.Course { Id = 17, Name = "Current Trends in Computer Science", Subject = "CMPS", Number = 482, CreditHours = 3 },
                  new Models.Course { Id = 18, Name = "Freshman Composition", Subject = "ENGL", Number = 101, CreditHours = 3},
                  new Models.Course { Id = 19, Name = "Critical Reading and Writing", Subject = "ENGL", Number = 102, CreditHours = 3},
                  new Models.Course { Id = 20, Name = "World Literature", Subject = "ENGL", Number = 230, CreditHours = 3},
                  new Models.Course { Id = 21, Name = "English Literature", Subject = "ENGL", Number = 231, CreditHours = 3},
                  new Models.Course { Id = 22, Name = "American Literature", Subject = "ENGL", Number = 232, CreditHours = 3},
                  new Models.Course { Id = 23, Name = "Intro to Prof and Technical Writing", Subject = "ENGL", Number = 322, CreditHours = 3},
                  new Models.Course { Id = 24, Name = "General Biology I", Subject = "GBIO", Number = 151, CreditHours = 3},
                  new Models.Course { Id = 25, Name = "General Biology Lab I", Subject = "BIOL", Number = 152, CreditHours = 1},
                  new Models.Course { Id = 26, Name = "General Biology II", Subject = "GBIO", Number = 153, CreditHours = 3},
                  new Models.Course { Id = 27, Name = "General Biology Lab II", Subject = "BIOL", Number = 154, CreditHours = 1},
                  new Models.Course { Id = 28, Name = "General Physics I", Subject = "PHYS", Number = 191, CreditHours = 3},
                  new Models.Course { Id = 29, Name = "General Physics II", Subject = "PHYS", Number = 192, CreditHours = 3},
                  new Models.Course { Id = 30, Name = "General Physics Lab I", Subject = "PLAB", Number = 193, CreditHours = 1},
                  new Models.Course { Id = 31, Name = "General Physics Lab II", Subject = "PLAB", Number = 194, CreditHours = 1},
                  new Models.Course { Id = 32, Name = "General Physics I", Subject = "PHYS", Number = 221, CreditHours = 3},
                  new Models.Course { Id = 33, Name = "General Physics II", Subject = "PHYS", Number = 222, CreditHours = 3},
                  new Models.Course { Id = 34, Name = "General Physics Lab I", Subject = "PLAB", Number = 223, CreditHours = 1},
                  new Models.Course { Id = 35, Name = "General Physics Lab II", Subject = "PLAB", Number = 224, CreditHours = 1},
                  new Models.Course { Id = 36, Name = "General Chemistry I for Science Majors", Subject = "CHEM", Number = 121, CreditHours = 3},
                  new Models.Course { Id = 37, Name = "General Chemistry II for Science Majors", Subject = "CHEM", Number = 122, CreditHours = 3},
                  new Models.Course { Id = 38, Name = "General Chemistry Lab I for Science Majors", Subject = "CLAB", Number = 123, CreditHours = 1},
                  new Models.Course { Id = 39, Name = "General Chemistry Lab II for Science Majors", Subject = "CLAB", Number = 124, CreditHours = 1},
                  new Models.Course { Id = 40, Name = "Computer Graphics", Subject = "CMPS", Number = 389, CreditHours = 3 },
                  new Models.Course { Id = 41, Name = "Web Systems and Technologies", Subject = "CMPS", Number = 394, CreditHours = 3 },
                  new Models.Course { Id = 42, Name = "Advanced Computer Networking", Subject = "CMPS", Number = 409, CreditHours = 3 },
                  new Models.Course { Id = 43, Name = "Computational Aspects of Game Programming", Subject = "CMPS", Number = 455, CreditHours = 3 },
                  new Models.Course { Id = 44, Name = "Topics in Information Technology", Subject = "CMPS", Number = 494, CreditHours = 3 },
                  new Models.Course { Id = 45, Name = "Numerical Methods", Subject = "CMPS", Number = 391, CreditHours = 3 },
                  new Models.Course { Id = 46, Name = "Survey of Programming Languages", Number = 401, CreditHours = 3 },
                  new Models.Course { Id = 47, Name = "Fundamental Algorithms", Subject = "CMPS", Number = 434, CreditHours = 3 },
                  new Models.Course { Id = 48, Name = "Artificial Intelligence", Subject = "CMPS", Number = 441, CreditHours = 3 },
                  new Models.Course { Id = 49, Name = "Simulation and Modeling", Subject = "CMPS", Number = 443, CreditHours = 3 },
                  new Models.Course { Id = 50, Name = "Machine Learning", Subject = "CMPS", Number = 470, CreditHours = 3 },
                  new Models.Course { Id = 51, Name = "Automata and Formal Languages", Subject = "CMPS", Number = 479, CreditHours = 3 },
                  new Models.Course { Id = 52, Name = "Special Topics in Computer Science Theory", Subject = "CMPS", Number = 493, CreditHours = 3 },
                  new Models.Course { Id = 53, Name = "Introduction to Public Speaking", Subject = "COMM", Number = 211, CreditHours = 3 },
                  new Models.Course { Id = 54, Name = "Southeastern 101", Subject = "DUMB", Number = 101, CreditHours = 2 },
                  new Models.Course { Id = 55, Name = "Precalculus with Trigonometry", Subject = "MATH", Number = 165, CreditHours = 3},
                  new Models.Course { Id = 56, Name = "Elementary Statistics", Subject = "MATH", Number = 241, CreditHours = 3},
                  new Models.Course { Id = 57, Name = "Free Elective", Subject = "ELEC", CreditHours = 3},
                  new Models.Course { Id = 58, Name = "Free Elective", Subject = "ELEC", CreditHours = 1},
                  new Models.Course { Id = 59, Name = "Art Elective", Subject = "ART", CreditHours = 3},
                  new Models.Course { Id = 60, Name = "Dance Elective", Subject = "DNCE", CreditHours = 3},
                  new Models.Course { Id = 61, Name = "Music Elective", Subject = "MUS", CreditHours = 3},
                  new Models.Course { Id = 62, Name = "Theatre Elective", Subject = "THEA", CreditHours = 3},
                  new Models.Course { Id = 63, Name = "History Elective", Subject = "HIST", CreditHours = 3 },
                  new Models.Course { Id = 64, Name = "Free Elective", Subject = "ELEC", CreditHours = 2 },
                  new Models.Course { Id = 65, Name = "Anthropology Elective", Subject = "ANTH", CreditHours = 3 },
                  new Models.Course { Id = 66, Name = "Economic Elective", Subject = "ECON", CreditHours = 3 },
                  new Models.Course { Id = 67, Name = "Geography Elective", Subject = "GEOG", CreditHours = 3 },
                  new Models.Course { Id = 68, Name = "Psychology Elective", Subject = "PSYC", CreditHours = 3 },
                  new Models.Course { Id = 69, Name = "Political Science Elective", Subject = "POLI", CreditHours = 3 },
                  new Models.Course { Id = 70, Name = "Sociology Elective", Subject = "SOCI", CreditHours = 3 },
                  new Models.Course { Id = 71, Name = "Database Administration", Subject = "CMPS", Number = 339, CreditHours = 3 },
                  new Models.Course { Id = 72, Name = "Intro of Financial Accounting", Subject = "ACCT", Number = 200, CreditHours = 3},
                  new Models.Course { Id = 73, Name = "Macroeconomics", Subject = "ECON", Number = 201, CreditHours = 3},
                  new Models.Course { Id = 74, Name = "Microeconomics", Subject = "ECON", Number = 202, CreditHours = 3},
                  new Models.Course { Id = 75, Name = "Business Finance", Subject = "FIN", Number = 381, CreditHours = 3},
                  new Models.Course { Id = 76, Name = "Management Science", Subject = "OMIS", Number = 310, CreditHours = 3},
                  new Models.Course { Id = 80, Name = "Principles of Management" , Subject = "MGMT", Number = 351, CreditHours = 3},
                  new Models.Course { Id = 81, Name = "Principles of Marketing", Subject = "MRKT", Number = 303, CreditHours = 3},
                  new Models.Course { Id = 82, Name = "Project Management", Subject = "OMIS", Number = 435, CreditHours = 3},
                  new Models.Course { Id = 83, Name = "Calculus I", Subject = "MATH", Number = 200, CreditHours = 5 },
                  new Models.Course { Id = 84, Name = "Calculus II", Subject = "MATH", Number = 201, CreditHours = 5 },
                  new Models.Course { Id = 85, Name = "Applied Statistics with Probability", Subject = "MATH", Number = 380, CreditHours = 3 },
                  new Models.Course { Id = 86, Name = "Calculus III", Subject = "MATH", Number = 312, CreditHours = 3 },
                  new Models.Course { Id = 87, Name = "Applied Differential Equations", Subject = "MATH", Number = 350, CreditHours = 3 },
                  new Models.Course { Id = 88, Name = "Applied Linear Algebra", Subject = "MATH", Number = 360, CreditHours = 3 },
                  new Models.Course { Id = 89, Name = "Intro to Abstract Algebra", Subject = "MATH", Number = 370, CreditHours = 3 },
                  new Models.Course { Id = 90, Name = "Theory of Numbers", Subject = "MATH", Number = 410, CreditHours = 3 },
                  new Models.Course { Id = 91, Name = "Fundamental Concepts of Geometry", Subject = "MATH", Number = 414, CreditHours = 3 },
                  new Models.Course { Id = 92, Name = "Visual Programming", Subject = "CMPS", Number = 120, CreditHours = 3 },
                  new Models.Course { Id = 93, Name = "300-400 Level Elective", Subject = "CMPS", CreditHours = 3 }
                );

            context.CMPS_IT_2013.AddOrUpdate(
                new Models.Plan { }
                );
        }
    }
}
