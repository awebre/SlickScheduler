namespace SlickScheduler.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
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
            var courses = new List<Course>
            {
                  new Models.Course { CourseId = 0, Name = "Algorithm Design & Implementation I", Subject = "CMPS", Number = 161, CreditHours = 3 },
                  new Models.Course { CourseId = 1, Name = "Discrete Structures", Subject = "CMPS", Number = 257, CreditHours = 3 },
                  new Models.Course { CourseId = 2, Name = "Algorithm Design & Implementation II", Subject = "CMPS", Number = 280, CreditHours = 3 },
                  new Models.Course { CourseId = 3, Name = "Software Engineering", Subject = "CMPS", Number = 285, CreditHours = 3 },
                  new Models.Course { CourseId = 4, Name = "Computer Organization", Subject = "CMPS", Number = 290, CreditHours = 3 },
                  new Models.Course { CourseId = 5, Name = "Assembly Language", Subject = "CMPS", Number = 293, CreditHours = 3 },
                  new Models.Course { CourseId = 6, Name = "Internet Programming", Subject = "CMPS", Number = 294, CreditHours = 3 },
                  new Models.Course { CourseId = 7, Name = "System Administration", Subject = "CMPS", Number = 315, CreditHours = 3 },
                  new Models.Course { CourseId = 8, Name = "Computer Networking and Security", Subject = "CMPS", Number = 329, CreditHours = 3 },
                  new Models.Course { CourseId = 9, Name = "Computer Architecture", Subject = "CMPS", Number = 375, CreditHours = 3 },
                  new Models.Course { CourseId = 10, Name = "Information Systems", Subject = "CMPS", Number = 383, CreditHours = 3 },
                  new Models.Course { CourseId = 11, Name = "Data Structures", Subject = "CMPS", Number = 390, CreditHours = 3 },
                  new Models.Course { CourseId = 12, Name = "Capstone I", Subject = "CMPS", Number = 411, CreditHours = 3 },
                  new Models.Course { CourseId = 13, Name = "Integrated Technologies for Enterprise Systems", Subject = "CMPS", Number = 415, CreditHours = 3 },
                  new Models.Course { CourseId = 14, Name = "Human Computer Interaction", Subject = "CMPS", Number = 420, CreditHours = 3 },
                  new Models.Course { CourseId = 15, Name = "Operating Systems", Subject = "CMPS", Number = 431, CreditHours = 3 },
                  new Models.Course { CourseId = 16, Name = "Database Systems", Subject = "CMPS", Number = 439, CreditHours = 3 },
                  new Models.Course { CourseId = 17, Name = "Current Trends in Computer Science", Subject = "CMPS", Number = 482, CreditHours = 3 },
                  new Models.Course { CourseId = 18, Name = "Freshman Composition", Subject = "ENGL", Number = 101, CreditHours = 3},
                  new Models.Course { CourseId = 19, Name = "Critical Reading and Writing", Subject = "ENGL", Number = 102, CreditHours = 3},
                  new Models.Course { CourseId = 20, Name = "World Literature", Subject = "ENGL", Number = 230, CreditHours = 3},
                  new Models.Course { CourseId = 21, Name = "English Literature", Subject = "ENGL", Number = 231, CreditHours = 3},
                  new Models.Course { CourseId = 22, Name = "American Literature", Subject = "ENGL", Number = 232, CreditHours = 3},
                  new Models.Course { CourseId = 23, Name = "Intro to Prof and Technical Writing", Subject = "ENGL", Number = 322, CreditHours = 3},
                  new Models.Course { CourseId = 24, Name = "General Biology I", Subject = "GBIO", Number = 151, CreditHours = 3},
                  new Models.Course { CourseId = 25, Name = "General Biology Lab I", Subject = "BIOL", Number = 152, CreditHours = 1},
                  new Models.Course { CourseId = 26, Name = "General Biology II", Subject = "GBIO", Number = 153, CreditHours = 3},
                  new Models.Course { CourseId = 27, Name = "General Biology Lab II", Subject = "BIOL", Number = 154, CreditHours = 1},
                  new Models.Course { CourseId = 28, Name = "General Physics I", Subject = "PHYS", Number = 191, CreditHours = 3},
                  new Models.Course { CourseId = 29, Name = "General Physics II", Subject = "PHYS", Number = 192, CreditHours = 3},
                  new Models.Course { CourseId = 30, Name = "General Physics Lab I", Subject = "PLAB", Number = 193, CreditHours = 1},
                  new Models.Course { CourseId = 31, Name = "General Physics Lab II", Subject = "PLAB", Number = 194, CreditHours = 1},
                  new Models.Course { CourseId = 32, Name = "General Physics I", Subject = "PHYS", Number = 221, CreditHours = 3},
                  new Models.Course { CourseId = 33, Name = "General Physics II", Subject = "PHYS", Number = 222, CreditHours = 3},
                  new Models.Course { CourseId = 34, Name = "General Physics Lab I", Subject = "PLAB", Number = 223, CreditHours = 1},
                  new Models.Course { CourseId = 35, Name = "General Physics Lab II", Subject = "PLAB", Number = 224, CreditHours = 1},
                  new Models.Course { CourseId = 36, Name = "General Chemistry I for Science Majors", Subject = "CHEM", Number = 121, CreditHours = 3},
                  new Models.Course { CourseId = 37, Name = "General Chemistry II for Science Majors", Subject = "CHEM", Number = 122, CreditHours = 3},
                  new Models.Course { CourseId = 38, Name = "General Chemistry Lab I for Science Majors", Subject = "CLAB", Number = 123, CreditHours = 1},
                  new Models.Course { CourseId = 39, Name = "General Chemistry Lab II for Science Majors", Subject = "CLAB", Number = 124, CreditHours = 1},
                  new Models.Course { CourseId = 40, Name = "Computer Graphics", Subject = "CMPS", Number = 389, CreditHours = 3 },
                  new Models.Course { CourseId = 41, Name = "Web Systems and Technologies", Subject = "CMPS", Number = 394, CreditHours = 3 },
                  new Models.Course { CourseId = 42, Name = "Advanced Computer Networking", Subject = "CMPS", Number = 409, CreditHours = 3 },
                  new Models.Course { CourseId = 43, Name = "Computational Aspects of Game Programming", Subject = "CMPS", Number = 455, CreditHours = 3 },
                  new Models.Course { CourseId = 44, Name = "Topics in Information Technology", Subject = "CMPS", Number = 494, CreditHours = 3 },
                  new Models.Course { CourseId = 45, Name = "Numerical Methods", Subject = "CMPS", Number = 391, CreditHours = 3 },
                  new Models.Course { CourseId = 46, Name = "Survey of Programming Languages", Number = 401, CreditHours = 3 },
                  new Models.Course { CourseId = 47, Name = "Fundamental Algorithms", Subject = "CMPS", Number = 434, CreditHours = 3 },
                  new Models.Course { CourseId = 48, Name = "Artificial Intelligence", Subject = "CMPS", Number = 441, CreditHours = 3 },
                  new Models.Course { CourseId = 49, Name = "Simulation and Modeling", Subject = "CMPS", Number = 443, CreditHours = 3 },
                  new Models.Course { CourseId = 50, Name = "Machine Learning", Subject = "CMPS", Number = 470, CreditHours = 3 },
                  new Models.Course { CourseId = 51, Name = "Automata and Formal Languages", Subject = "CMPS", Number = 479, CreditHours = 3 },
                  new Models.Course { CourseId = 52, Name = "Special Topics in Computer Science Theory", Subject = "CMPS", Number = 493, CreditHours = 3 },
                  new Models.Course { CourseId = 53, Name = "Introduction to Public Speaking", Subject = "COMM", Number = 211, CreditHours = 3 },
                  new Models.Course { CourseId = 54, Name = "Southeastern 101", Subject = "DUMB", Number = 101, CreditHours = 2 },
                  new Models.Course { CourseId = 55, Name = "Precalculus with Trigonometry", Subject = "MATH", Number = 165, CreditHours = 3},
                  new Models.Course { CourseId = 56, Name = "Elementary Statistics", Subject = "MATH", Number = 241, CreditHours = 3},
                  new Models.Course { CourseId = 57, Name = "Free Elective", Subject = "ELEC", CreditHours = 3},
                  new Models.Course { CourseId = 58, Name = "Free Elective", Subject = "ELEC", CreditHours = 1},
                  new Models.Course { CourseId = 59, Name = "Art Elective", Subject = "ART", CreditHours = 3},
                  new Models.Course { CourseId = 60, Name = "Dance Elective", Subject = "DNCE", CreditHours = 3},
                  new Models.Course { CourseId = 61, Name = "Music Elective", Subject = "MUS", CreditHours = 3},
                  new Models.Course { CourseId = 62, Name = "Theatre Elective", Subject = "THEA", CreditHours = 3},
                  new Models.Course { CourseId = 63, Name = "History Elective", Subject = "HIST", CreditHours = 3 },
                  new Models.Course { CourseId = 64, Name = "Free Elective", Subject = "ELEC", CreditHours = 2 },
                  new Models.Course { CourseId = 65, Name = "Anthropology Elective", Subject = "ANTH", CreditHours = 3 },
                  new Models.Course { CourseId = 66, Name = "Economic Elective", Subject = "ECON", CreditHours = 3 },
                  new Models.Course { CourseId = 67, Name = "Geography Elective", Subject = "GEOG", CreditHours = 3 },
                  new Models.Course { CourseId = 68, Name = "Psychology Elective", Subject = "PSYC", CreditHours = 3 },
                  new Models.Course { CourseId = 69, Name = "Political Science Elective", Subject = "POLI", CreditHours = 3 },
                  new Models.Course { CourseId = 70, Name = "Sociology Elective", Subject = "SOCI", CreditHours = 3 },
                  new Models.Course { CourseId = 71, Name = "Database Administration", Subject = "CMPS", Number = 339, CreditHours = 3 },
                  new Models.Course { CourseId = 72, Name = "Intro of Financial Accounting", Subject = "ACCT", Number = 200, CreditHours = 3},
                  new Models.Course { CourseId = 73, Name = "Macroeconomics", Subject = "ECON", Number = 201, CreditHours = 3},
                  new Models.Course { CourseId = 74, Name = "Microeconomics", Subject = "ECON", Number = 202, CreditHours = 3},
                  new Models.Course { CourseId = 75, Name = "Business Finance", Subject = "FIN", Number = 381, CreditHours = 3},
                  new Models.Course { CourseId = 76, Name = "Management Science", Subject = "OMIS", Number = 310, CreditHours = 3},
                  new Models.Course { CourseId = 77, Name = "Principles of Management" , Subject = "MGMT", Number = 351, CreditHours = 3},
                  new Models.Course { CourseId = 78, Name = "Principles of Marketing", Subject = "MRKT", Number = 303, CreditHours = 3},
                  new Models.Course { CourseId = 79, Name = "Project Management", Subject = "OMIS", Number = 435, CreditHours = 3},
                  new Models.Course { CourseId = 80, Name = "Calculus I", Subject = "MATH", Number = 200, CreditHours = 5 },
                  new Models.Course { CourseId = 81, Name = "Calculus II", Subject = "MATH", Number = 201, CreditHours = 5 },
                  new Models.Course { CourseId = 82, Name = "Applied Statistics with Probability", Subject = "MATH", Number = 380, CreditHours = 3 },
                  new Models.Course { CourseId = 83, Name = "Calculus III", Subject = "MATH", Number = 312, CreditHours = 3 },
                  new Models.Course { CourseId = 84, Name = "Applied Differential Equations", Subject = "MATH", Number = 350, CreditHours = 3 },
                  new Models.Course { CourseId = 85, Name = "Applied Linear Algebra", Subject = "MATH", Number = 360, CreditHours = 3 },
                  new Models.Course { CourseId = 86, Name = "Intro to Abstract Algebra", Subject = "MATH", Number = 370, CreditHours = 3 },
                  new Models.Course { CourseId = 87, Name = "Theory of Numbers", Subject = "MATH", Number = 410, CreditHours = 3 },
                  new Models.Course { CourseId = 88, Name = "Fundamental Concepts of Geometry", Subject = "MATH", Number = 414, CreditHours = 3 },
                  new Models.Course { CourseId = 89, Name = "Visual Programming", Subject = "CMPS", Number = 120, CreditHours = 3 },
                  new Models.Course { CourseId = 90, Name = "300-400 Level Elective", Subject = "CMPS", CreditHours = 3 }
            };
            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.CourseId, s));
            context.SaveChanges();

            var semesters = new List<Semester>
            {
                new Models.Semester
                {
                    SemesterId = 1,
                    SemesterNum =1,
                    Courses = new List<Course>()
                    {
                        courses.Single(c => c.CourseId == 18),
                        courses.Single(c => c.CourseId == 54),
                        courses.Single(c => c.CourseId == 63),
                        courses.Single(c => c.CourseId == 0),
                        courses.Single(c => c.CourseId == 80)
                    }
                },

                new Models.Semester
                {
                    SemesterId = 2,
                    SemesterNum = 2,
                    Courses = new List<Course>()
                    {
                        courses.Single(c => c.CourseId == 81),
                        courses.Single(c => c.CourseId == 19),
                        courses.Single(c => c.CourseId == 1),
                        courses.Single(c => c.CourseId == 2)
                    }
                },

                new Models.Semester
                {
                    SemesterId = 3,
                    SemesterNum = 3,
                    Courses = new List<Course>(courses.Single(89), courses.Single(3), courses.Single(4), courses.Single(53), courses.Single(24), courses.Single(25))
                },

                new Models.Semester
                {
                    SemesterId = 4,
                    SemesterNum = 4,
                    Courses = new List<Course>(courses.Single(9), courses.Single(11), courses.Single(20), courses.Single(26), courses.Single(27), courses.Single(68))
                },

                new Models.Semester
                {
                    SemesterId = 5,
                    SemesterNum = 5,
                    Courses = new List<Course>(courses.Single(46))
                }

            };

            semesters.ForEach(s => context.Semesters.AddOrUpdate(p => p.SemesterId, s));
            context.SaveChanges();

            /*context.Plans.AddOrUpdate(
                //Array holding the course ID first array index. Second array index holds semester number. 
                new Models.Plan
                {
                    IdSemester = new int[,]
                { {18,1}, {54,1}, {63,1}, {0,1}, {80,1}, {81,2}, {19,2}, {1,2}, {2,2}, {89,3},
                  {3,3}, {4,3}, {53,3}, {24,3}, {25,3}, {9,4}, {11,4}, {20,4}, {26,4}, {27,4}, {68,4},
                  {46,5}, {90,5}, {23,5}, {72,5}, {28,5}, {30,5}, {10,6}, {15,6}, {73,6}, {59,6},
                  {13,6}, {12,7}, {90,7}, {29,7}, {75,7}, {82,7}, {16,8}, {17,8}, {83,8}, {76,8}
                },
                    Name = "CMPS_MBA_2013"
                },

                new Models.Plan
                {
                    IdSemester = new int[,]
                { {18,1}, {54,1}, {63,1}, {0,1}, {55,1}, {68,1}, {56,2}, {19,2}, {1,2}, {2,2}, {59,2}, {20,3},
                  {24,3}, {25,3}, {53,3}, {3,3}, {4,3}, {6,4}, {9,4}, {11,4}, {23,4}, {26,4}, {27,4},
                  {7,5}, {68,5}, {28,5}, {29,5}, {57,5}, {58,5}, {10,6}, {15,6}, {8,6},
                  {30,6}, {13,6}, {12,7}, {14,7}, {41,7}, {57,7}, {16,8}, {17,8}, {42,8}, {57,8}, {57,8}
                },
                    Name = "CMPS_IT_2013"
                },

                new Models.Plan
                {
                    IdSemester = new int[,]
                { {18,1}, {54,1}, {63,1}, {0,1}, {55,1}, {68,1}, {56,2}, {19,2}, {1,2}, {2,2}, {59,2}, {3,3},
                  {4,3}, {53,3}, {73,3}, {24,3}, {25,3}, {6,4}, {9,4}, {11,4}, {23,4}, {26,4}, {27,4},
                  {46,5}, {90,5}, {23,5}, {82,5}, {28,5}, {15,6}, {90,6}, {83,6}, {59,6},
                  {13,6}, {45,7}, {12,7}, {57,7}, {57,7}, {57,7}, {51,8}, {17,8}, {84,8}, {29,8}, {31,8}
                },
                    Name = "CMPS_SCI_2013"
                }
                
                );
    
            context.CMPS_IT_2013.AddOrUpdate(
                //Array holding the course ID first array index. Second array index holds semester number. 
                new Models.Plan
                {
                    IdSemester = new int[,]
                { {18,1}, {54,1}, {63,1}, {0,1}, {55,1}, {68,1}, {56,2}, {19,2}, {1,2}, {2,2}, {59,2}, {20,3},
                  {24,3}, {25,3}, {53,3}, {3,3}, {4,3}, {6,4}, {9,4}, {11,4}, {23,4}, {26,4}, {27,4},
                  {7,5}, {68,5}, {28,5}, {29,5}, {57,5}, {58,5}, {10,6}, {15,6}, {8,6}, 
                  {30,6}, {13,6}, {12,7}, {14,7}, {41,7}, {57,7}, {16,8}, {17,8}, {42,8}, {57,8}, {57,8}
                }
                }

                );

            context.CMPS_SCI_2013.AddOrUpdate(
               //Array holding the course ID first array index. Second array index holds semester number. 
               new Models.Plan
               {
                   IdSemester = new int[,]
               { {18,1}, {54,1}, {63,1}, {0,1}, {55,1}, {68,1}, {56,2}, {19,2}, {1,2}, {2,2}, {59,2}, {3,3},
                  {4,3}, {53,3}, {73,3}, {24,3}, {25,3}, {6,4}, {9,4}, {11,4}, {23,4}, {26,4}, {27,4},
                  {46,5}, {90,5}, {23,5}, {82,5}, {28,5}, {15,6}, {90,6}, {83,6}, {59,6},
                  {13,6}, {45,7}, {12,7}, {57,7}, {57,7}, {57,7}, {51,8}, {17,8}, {84,8}, {29,8}, {31,8}
               }
               }

               );
               */
        }
        
    }
}
