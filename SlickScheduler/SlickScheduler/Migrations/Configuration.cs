namespace SlickScheduler.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SlickScheduler.Models.DataModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SlickScheduler.Models.DataModelContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            //Creates local lists of variables
            var courses = new List<Course>
            {
                  new Models.Course { CourseId = 1, Name = "Algorithm Design & Implementation I", Subject = "CMPS", Number = 161, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 2, Name = "Discrete Structures", Subject = "CMPS", Number = 257, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 3, Name = "Algorithm Design & Implementation II", Subject = "CMPS", Number = 280, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 4, Name = "Software Engineering", Subject = "CMPS", Number = 285, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 5, Name = "Computer Organization", Subject = "CMPS", Number = 290, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 6, Name = "Assembly Language", Subject = "CMPS", Number = 293, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 7, Name = "Internet Programming", Subject = "CMPS", Number = 294, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 8, Name = "System Administration", Subject = "CMPS", Number = 315, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 9, Name = "Computer Networking and Security", Subject = "CMPS", Number = 329, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 10, Name = "Computer Architecture", Subject = "CMPS", Number = 375, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 11, Name = "Information Systems", Subject = "CMPS", Number = 383, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 12, Name = "Data Structures", Subject = "CMPS", Number = 390, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 13, Name = "Capstone I", Subject = "CMPS", Number = 411, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 14, Name = "Integrated Technologies for Enterprise Systems", Subject = "CMPS", Number = 415, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 15, Name = "Human Computer Interaction", Subject = "CMPS", Number = 420, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 16, Name = "Operating Systems", Subject = "CMPS", Number = 431, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 17, Name = "Database Systems", Subject = "CMPS", Number = 439, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 18, Name = "Current Trends in Computer Science", Subject = "CMPS", Number = 482, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 19, Name = "Freshman Composition", Subject = "ENGL", Number = 101, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 20, Name = "Critical Reading and Writing", Subject = "ENGL", Number = 102, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 21, Name = "World Literature", Subject = "ENGL", Number = 230, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 22, Name = "English Literature", Subject = "ENGL", Number = 231, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 23, Name = "American Literature", Subject = "ENGL", Number = 232, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 24, Name = "Intro to Prof and Technical Writing", Subject = "ENGL", Number = 322, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 25, Name = "General Biology I", Subject = "GBIO", Number = 151, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 26, Name = "General Biology Lab I", Subject = "BIOL", Number = 152, CreditHours = 1,
                    
                  },
                  new Models.Course { CourseId = 27, Name = "General Biology II", Subject = "GBIO", Number = 153, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 28, Name = "General Biology Lab II", Subject = "BIOL", Number = 154, CreditHours = 1,
                    
                  },
                  new Models.Course { CourseId = 29, Name = "General Physics I", Subject = "PHYS", Number = 191, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 30, Name = "General Physics II", Subject = "PHYS", Number = 192, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 31, Name = "General Physics Lab I", Subject = "PLAB", Number = 193, CreditHours = 1,
                    
                  },
                  new Models.Course { CourseId = 32, Name = "General Physics Lab II", Subject = "PLAB", Number = 194, CreditHours = 1,
                    
                  },
                  new Models.Course { CourseId = 33, Name = "General Physics I", Subject = "PHYS", Number = 221, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 34, Name = "General Physics II", Subject = "PHYS", Number = 222, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 35, Name = "General Physics Lab I", Subject = "PLAB", Number = 223, CreditHours = 1,
                    
                  },
                  new Models.Course { CourseId = 36, Name = "General Physics Lab II", Subject = "PLAB", Number = 224, CreditHours = 1,
                    
                  },
                  new Models.Course { CourseId = 37, Name = "General Chemistry I for Science Majors", Subject = "CHEM", Number = 121, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 38, Name = "General Chemistry II for Science Majors", Subject = "CHEM", Number = 122, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 39, Name = "General Chemistry Lab I for Science Majors", Subject = "CLAB", Number = 123, CreditHours = 1,
                    
                  },
                  new Models.Course { CourseId = 40, Name = "General Chemistry Lab II for Science Majors", Subject = "CLAB", Number = 124, CreditHours = 1,
                    
                  },
                  new Models.Course { CourseId = 41, Name = "Computer Graphics", Subject = "CMPS", Number = 389, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 42, Name = "Web Systems and Technologies", Subject = "CMPS", Number = 394, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 43, Name = "Advanced Computer Networking", Subject = "CMPS", Number = 409, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 44, Name = "Computational Aspects of Game Programming", Subject = "CMPS", Number = 455, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 45, Name = "Topics in Information Technology", Subject = "CMPS", Number = 494, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 46, Name = "Numerical Methods", Subject = "CMPS", Number = 391, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 47, Name = "Survey of Programming Languages", Number = 401, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 48, Name = "Fundamental Algorithms", Subject = "CMPS", Number = 434, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 49, Name = "Artificial Intelligence", Subject = "CMPS", Number = 441, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 50, Name = "Simulation and Modeling", Subject = "CMPS", Number = 443, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 51, Name = "Machine Learning", Subject = "CMPS", Number = 470, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 52, Name = "Automata and Formal Languages", Subject = "CMPS", Number = 479, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 53, Name = "Special Topics in Computer Science Theory", Subject = "CMPS", Number = 493, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 54, Name = "Introduction to Public Speaking", Subject = "COMM", Number = 211, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 55, Name = "Southeastern 101", Subject = "DUMB", Number = 101, CreditHours = 2,
                    
                  },
                  new Models.Course { CourseId = 56, Name = "Precalculus with Trigonometry", Subject = "MATH", Number = 165, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 57, Name = "Elementary Statistics", Subject = "MATH", Number = 241, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 58, Name = "Free Elective", Subject = "ELEC", CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 59, Name = "Free Elective", Subject = "ELEC", CreditHours = 1,
                    
                  },
                  new Models.Course { CourseId = 60, Name = "Art Elective", Subject = "ART", CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 61, Name = "Dance Elective", Subject = "DNCE", CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 62, Name = "Music Elective", Subject = "MUS", CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 63, Name = "Theatre Elective", Subject = "THEA", CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 64, Name = "History Elective", Subject = "HIST", CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 65, Name = "Free Elective", Subject = "ELEC", CreditHours = 2,
                    
                  },
                  new Models.Course { CourseId = 66, Name = "Anthropology Elective", Subject = "ANTH", CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 67, Name = "Economic Elective", Subject = "ECON", CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 68, Name = "Geography Elective", Subject = "GEOG", CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 69, Name = "Psychology Elective", Subject = "PSYC", CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 70, Name = "Political Science Elective", Subject = "POLI", CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 71, Name = "Sociology Elective", Subject = "SOCI", CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 72, Name = "Database Administration", Subject = "CMPS", Number = 339, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 73, Name = "Intro of Financial Accounting", Subject = "ACCT", Number = 200, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 74, Name = "Macroeconomics", Subject = "ECON", Number = 201, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 75, Name = "Microeconomics", Subject = "ECON", Number = 202, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 76, Name = "Business Finance", Subject = "FIN", Number = 381, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 77, Name = "Management Science", Subject = "OMIS", Number = 310, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 78, Name = "Principles of Management" , Subject = "MGMT", Number = 351, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 79, Name = "Principles of Marketing", Subject = "MRKT", Number = 303, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 80, Name = "Project Management", Subject = "OMIS", Number = 435, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 81, Name = "Calculus I", Subject = "MATH", Number = 200, CreditHours = 5,
                    
                  },
                  new Models.Course { CourseId = 82, Name = "Calculus II", Subject = "MATH", Number = 201, CreditHours = 5,
                    
                  },
                  new Models.Course { CourseId = 83, Name = "Applied Statistics with Probability", Subject = "MATH", Number = 380, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 84, Name = "Calculus III", Subject = "MATH", Number = 312, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 85, Name = "Applied Differential Equations", Subject = "MATH", Number = 350, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 86, Name = "Applied Linear Algebra", Subject = "MATH", Number = 360, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 87, Name = "Intro to Abstract Algebra", Subject = "MATH", Number = 370, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 88, Name = "Theory of Numbers", Subject = "MATH", Number = 410, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 89, Name = "Fundamental Concepts of Geometry", Subject = "MATH", Number = 414, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 90, Name = "Visual Programming", Subject = "CMPS", Number = 120, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 91, Name = "300-400 Level Elective", Subject = "CMPS", CreditHours = 3,
                    
                  }
            };


            var semesters = new List<Semester>
            {
                new Models.Semester
                {
                    SemesterId = 1,
                    SemesterNum =1,
                    Courses = new List<Course>()
                    {
                        //CMPS_MBA_2013_1
                        courses.Single(c => c.CourseId == 19),
                        courses.Single(c => c.CourseId == 55),
                        courses.Single(c => c.CourseId == 64),
                        courses.Single(c => c.CourseId == 1),
                        courses.Single(c => c.CourseId == 81)
                    },
                    
                },

                new Models.Semester
                {
                    SemesterId = 2,
                    SemesterNum = 2,
                    Courses = new List<Course>()
                    {
                        //CMPS_MBA_2013_2
                        courses.Single(c => c.CourseId == 82),
                        courses.Single(c => c.CourseId == 20),
                        courses.Single(c => c.CourseId == 2),
                        courses.Single(c => c.CourseId == 3)
                    },
                    
                },

                new Models.Semester
                {
                    SemesterId = 3,
                    SemesterNum = 3,
                    Courses = new List<Course>()
                    {
                        //CMPS_MBA_2013_3
                        courses.Single(c => c.CourseId == 90),
                        courses.Single(c => c.CourseId == 4),
                        courses.Single(c => c.CourseId == 5),
                        courses.Single(c => c.CourseId == 54),
                        courses.Single(c => c.CourseId == 25),
                        courses.Single(c => c.CourseId == 26)
                    },
                    
                },

                new Models.Semester
                {
                    SemesterId = 4,
                    SemesterNum = 4,
                    Courses = new List<Course>()
                    {
                        //CMPS_MBA_2013_4
                        courses.Single(c => c.CourseId == 10),
                        courses.Single(c => c.CourseId == 12),
                        courses.Single(c => c.CourseId == 21),
                        courses.Single(c => c.CourseId == 27),
                        courses.Single(c => c.CourseId == 28),
                        courses.Single(c => c.CourseId == 69)
                    },
                    
                },

                new Models.Semester
                {
                    SemesterId = 5,
                    SemesterNum = 5,
                    Courses = new List<Course>()
                    {
                        //CMPS_MBA_2013_5
                        courses.Single(c => c.CourseId == 47),
                        courses.Single(c => c.CourseId == 91),
                        courses.Single(c => c.CourseId == 24),
                        courses.Single(c => c.CourseId == 73),
                        courses.Single(c => c.CourseId == 29),
                        courses.Single(c => c.CourseId == 31)
                    },
                    
                },

                new Models.Semester
                {
                    SemesterId = 6,
                    SemesterNum = 6,
                    Courses = new List<Course>()
                    {
                        //CMPS_MBA_2013_6
                        courses.Single(c => c.CourseId == 11),
                        courses.Single(c => c.CourseId == 16),
                        courses.Single(c => c.CourseId == 74),
                        courses.Single(c => c.CourseId == 60),
                        courses.Single(c => c.CourseId == 14)
                    },
                    
                },

                new Models.Semester
                {
                    SemesterId = 7,
                    SemesterNum = 7,
                    Courses = new List<Course>()
                    {
                        //CMPS_MBA_2013_7
                        courses.Single(c => c.CourseId == 13),
                        courses.Single(c => c.CourseId == 91),
                        courses.Single(c => c.CourseId == 30),
                        courses.Single(c => c.CourseId == 76),
                        courses.Single(c => c.CourseId == 83)
                    },
                    
                },

                new Models.Semester
                {
                    SemesterId = 8,
                    SemesterNum = 8,
                    Courses = new List<Course>()
                    {
                        //CMPS_MBA_2013_8
                        courses.Single(c => c.CourseId == 17),
                        courses.Single(c => c.CourseId == 18),
                        courses.Single(c => c.CourseId == 84),
                        courses.Single(c => c.CourseId == 77)
                    },
                    
                },

                new Models.Semester
                {
                    SemesterId = 9,
                    SemesterNum = 1,
                    Courses = new List<Course>()
                    {
                        //CMPS_IT_2013_1 && CMPS_SCI_2013_1
                        courses.Single(c => c.CourseId == 19),
                        courses.Single(c => c.CourseId == 55),
                        courses.Single(c => c.CourseId == 64),
                        courses.Single(c => c.CourseId == 1),
                        courses.Single(c => c.CourseId == 56),
                        courses.Single(c => c.CourseId == 69),
                    },
                    
                },

                new Models.Semester
                {
                    SemesterId = 10,
                    SemesterNum = 2,
                    Courses = new List<Course>()
                    {
                        //CMPS_IT_2013_2 && CMPS_SCI_2013_2
                        courses.Single(c => c.CourseId == 57),
                        courses.Single(c => c.CourseId == 20),
                        courses.Single(c => c.CourseId == 2),
                        courses.Single(c => c.CourseId == 3),
                        courses.Single(c => c.CourseId == 60)
                    },
                    
                },
                
                new Models.Semester
                {
                    SemesterId = 11,
                    SemesterNum = 3,
                    Courses = new List<Course>()
                    {
                        //CMPS_IT_2013_3
                        courses.Single(c => c.CourseId == 21),
                        courses.Single(c => c.CourseId == 25),
                        courses.Single(c => c.CourseId == 26),
                        courses.Single(c => c.CourseId == 54),
                        courses.Single(c => c.CourseId == 4),
                        courses.Single(c => c.CourseId == 5)
                    },
                    
                },

                new Models.Semester
                {
                    SemesterId = 12,
                    SemesterNum = 4,
                    Courses = new List<Course>()
                    {
                        //CMPS_IT_2013_4 && CMPS_SCI_2013_4
                        courses.Single(c => c.CourseId == 7),
                        courses.Single(c => c.CourseId == 10),
                        courses.Single(c => c.CourseId == 12),
                        courses.Single(c => c.CourseId == 24),
                        courses.Single(c => c.CourseId == 27),
                        courses.Single(c => c.CourseId == 28)
                    },
                    
                },

                new Models.Semester
                {
                    SemesterId = 13,
                    SemesterNum = 5,
                    Courses = new List<Course>()
                    {
                        //CMPS_IT_2013_5
                        courses.Single(c => c.CourseId == 8),
                        courses.Single(c => c.CourseId == 69),
                        courses.Single(c => c.CourseId == 29),
                        courses.Single(c => c.CourseId == 30),
                        courses.Single(c => c.CourseId == 58),
                        courses.Single(c => c.CourseId == 59)
                    },
                    
                },

                new Models.Semester
                {
                    SemesterId = 14,
                    SemesterNum = 6,
                    Courses = new List<Course>()
                    {
                        //CMPS_IT_2013_6
                        courses.Single(c => c.CourseId == 11),
                        courses.Single(c => c.CourseId == 16),
                        courses.Single(c => c.CourseId == 9),
                        courses.Single(c => c.CourseId == 31),
                        courses.Single(c => c.CourseId == 14)
                    },
                    
                },

                new Models.Semester
                {
                    SemesterId = 15,
                    SemesterNum = 7,
                    Courses = new List<Course>()
                    {
                        //CMPS_IT_2013_7
                        courses.Single(c => c.CourseId == 13),
                        courses.Single(c => c.CourseId == 15),
                        courses.Single(c => c.CourseId == 42),
                        courses.Single(c => c.CourseId == 58)
                    },
                    
                },

                new Models.Semester
                {
                    SemesterId = 16,
                    SemesterNum = 8,
                    Courses = new List<Course>()
                    {
                        //CMPS_IT_2013_8
                        courses.Single(c => c.CourseId == 17),
                        courses.Single(c => c.CourseId == 18),
                        courses.Single(c => c.CourseId == 43),
                        courses.Single(c => c.CourseId == 58),
                        courses.Single(c => c.CourseId == 58)
                    },
                    
                },

                new Models.Semester
                {
                    SemesterId = 17,
                    SemesterNum = 3,
                    Courses = new List<Course>()
                    {
                        //CMPS_SCI_2013_3
                        courses.Single(c => c.CourseId == 4),
                        courses.Single(c => c.CourseId == 5),
                        courses.Single(c => c.CourseId == 54),
                        courses.Single(c => c.CourseId == 74),
                        courses.Single(c => c.CourseId == 25),
                        courses.Single(c => c.CourseId == 26)
                    },
                    
                },

                new Models.Semester
                {
                    SemesterId = 18,
                    SemesterNum = 5,
                    Courses = new List<Course>()
                    {
                        //CMPS_SCI_2013_5
                        courses.Single(c => c.CourseId == 47),
                        courses.Single(c => c.CourseId == 91),
                        courses.Single(c => c.CourseId == 24),
                        courses.Single(c => c.CourseId == 83),
                        courses.Single(c => c.CourseId == 29)
                    },
                    
                }

            };


            context.Plans.AddOrUpdate(
                new Models.Plan
                {
                    PlanId = 1,
                    Major = "CMPS",
                    Concentration = "MBA",
                    CatalogYear = 2013,
                    Name = "CMPS_MBA_2013",
                    Semesters = new List<Semester>()
                    
                    {
                        semesters.Single(s => s.SemesterId == 1),
                        semesters.Single(s => s.SemesterId == 2),
                        semesters.Single(s => s.SemesterId == 3),
                        semesters.Single(s => s.SemesterId == 4),
                        semesters.Single(s => s.SemesterId == 5),
                        semesters.Single(s => s.SemesterId == 6),
						semesters.Single(s => s.SemesterId == 7),
                        semesters.Single(s => s.SemesterId == 8)
                    },
                   
                },
                
                new Models.Plan
                {
                    PlanId = 2,
                    Major = "CMPS",
                    Concentration = "IT",
                    CatalogYear = 2013,
                    Name = "CMPS_IT_2013",
                    Semesters = new List<Semester>()
                    {
                        semesters.Single(s => s.SemesterId == 9),
                        semesters.Single(s => s.SemesterId == 10),
                        semesters.Single(s => s.SemesterId == 11),
                        semesters.Single(s => s.SemesterId == 12),
                        semesters.Single(s => s.SemesterId == 13),
                        semesters.Single(s => s.SemesterId == 14),
                        semesters.Single(s => s.SemesterId == 15),
                        semesters.Single(s => s.SemesterId == 16)
                    }
                },
                
                new Models.Plan
                {
                    PlanId = 3,
                    Major = "CMPS",
                    Concentration = "SCI",
                    CatalogYear = 2013,
                    Name = "CMPS_SCI_2013",
                    Semesters = new List<Semester>()
                    {
                        semesters.Single(s => s.SemesterId == 9),
                        semesters.Single(s => s.SemesterId == 10),
                        semesters.Single(s => s.SemesterId == 17),
                        semesters.Single(s => s.SemesterId == 12),
                        semesters.Single(s => s.SemesterId == 18)
                    }
                }
                );

            context.Roles.AddOrUpdate(
                new Models.Role
                {
                    RoleID = 1,
                    RoleName = "Admin"
                },

                new Models.Role
                {
                    RoleID = 2,
                    RoleName = "Advisor"
                },

                new Models.Role
                {
                    RoleID = 3,
                    RoleName = "Student"
                }
                );

            context.SaveChanges();

            //Adds courses to the database
            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.CourseId, s));
            context.SaveChanges();

            //Adds semesters to the database
            semesters.ForEach(s => context.Semesters.AddOrUpdate(p => p.SemesterId, s));
            context.SaveChanges();


        }
        
    }
}
