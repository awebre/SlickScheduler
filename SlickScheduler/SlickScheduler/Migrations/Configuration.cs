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
                  new Models.Course { CourseId = 1, Name = "Algorithm Design & Implementation I", Subject = "CMPS", Number = 161, CreditHours = 3, Description = "Credit 3 hours. Prerequisite: Registration in or prior credit for Mathematics 155 or 161, or permission of the Department Head. Basic concepts of computer programming, problem solving, algorithm development, and program coding using a high-level, block-structured language. Credit may be given for both Computer Science 110 and 161."

                  },
                  new Models.Course { CourseId = 2, Name = "Discrete Structures", Subject = "CMPS", Number = 257, CreditHours = 3, Description = "Class no longer available. Ask your advisor for more information."
                    
                  },
                  new Models.Course { CourseId = 3, Name = "Algorithm Design & Implementation II", Subject = "CMPS", Number = 280, CreditHours = 3, Description = "Credit 3 hours. Prerequisite: Computer Science 161 and a C or better in Math 155 or 161.An intensive capstone of the material covered in Computer Science 161 and an introduction to elementary data structures, searches, simple and complex sorts, and objects."
                    
                  },
                  new Models.Course { CourseId = 4, Name = "Software Engineering", Subject = "CMPS", Number = 285, CreditHours = 3, Description = "Credit 3 hours.  Prerequisites:  CMPS 280 or permission of the department head.  Introduction to the methods used for specifying, designing, implementing, and testing medium and large - scale software systems; methods for organizing and managing software development projects, professionalism and ethical resposibilities in software development."
                    
                  },
                  new Models.Course { CourseId = 5, Name = "Computer Organization", Subject = "CMPS", Number = 290, CreditHours = 3, Description = "Credit 3 hours.  Prerequisite:  Computer Science 120 or Computer Science 161 or Engineering Technology 212.  An introduction to the structure and function of computing machines.  The primary components of the computer are examined from an organizational and logical standpoint.  Topics include introduction to digital systems; machine level representation of data; assembly level machine organization; memory system organization and architectures; and introduction to language translation.  Credit toward the degree will not be granted for both Computer Science 290 and Computer Science 293."
                    
                  },
                  new Models.Course { CourseId = 6, Name = "Assembly Language", Subject = "CMPS", Number = 293, CreditHours = 3, Description = "Class no longer available. Ask your advisor for more information."
                    
                  },
                  new Models.Course { CourseId = 7, Name = "Internet Programming", Subject = "CMPS", Number = 294, CreditHours = 3, Description = "Credit 3 hours.  Prerequisite:  Computer Science 280.  This course concerns the art and science of programming for WWW Internet applications from a client-side perspective.  Basic and advanced HTML will be covered, with emphasis on current scripting technologies."
                    
                  },
                  new Models.Course { CourseId = 8, Name = "System Administration", Subject = "CMPS", Number = 315, CreditHours = 3, Description = "Credit 3 hours. A course to learn the administration of systems."
                                      
                  },
                  new Models.Course { CourseId = 9, Name = "Computer Networking and Security", Subject = "CMPS", Number = 329, CreditHours = 3, Description = "Credit 3 hours.  Prerequisite: Computer Science 285.Topics include computer networking and protocols used in local and wide area networks, network administration, and the conceptual and technical aspects of computer security and information assurance, especially as it impacts networks and the Internet."
                    
                  },
                  new Models.Course { CourseId = 10, Name = "Computer Architecture", Subject = "CMPS", Number = 375, CreditHours = 3, Description = "Credit 3 hours. Prerequisite: Computer Science 293 or Computer Science 290.Hardware organization and implementation of computer architecture. Instruction set considerations and addressing modes. System control concepts.CPU control, microprogramming, I/ O interface and memory organization.Parallel and data flow architecture."

                  },
                  new Models.Course { CourseId = 11, Name = "Information Systems", Subject = "CMPS", Number = 383, CreditHours = 3, Description = "Credit 3 hours. Prerequisite: Computer Science 285.A study of file organization and management, analysis of the concept of information systems, approaches and techniques for evaluating information systems.Fourth generation languages will be explored."
                    
                  },
                  new Models.Course { CourseId = 12, Name = "Data Structures", Subject = "CMPS", Number = 390, CreditHours = 3, Description = "Credit 3 hours. Prerequisite: Computer Science 257 and 280 and registration in of prior credit for CMPS 285. Further study of trees, including: balanced trees, B-trees, 2-3 trees, and tries; external sorting, symbol tables, and file structures."

                  },
                  new Models.Course { CourseId = 13, Name = "Capstone I", Subject = "CMPS", Number = 411, CreditHours = 3, Description = "Credit 3 hours. Prerequisite: Computer Science 390.This course must be taken in the academic year in which the student intends to graduate. Through participation in a major capstone project, this course presents a formal approach to the top-down design, development, and maintenance of software systems.Topics include organization and management of software projects, security, programmer teams, validation and verification."
                    
                  },
                  new Models.Course { CourseId = 14, Name = "Integrated Technologies for Enterprise Systems", Subject = "CMPS", Number = 415, CreditHours = 3, Description = "Credit 3 hours. Prerequisite: Computer Science 390.This course provides an introduction to several current technologies, and how they can be used to integrate software solutions into a functional large interconnected system.The course will focus on contemporary technologies used for enterprise software development."
                    
                  },
                  new Models.Course { CourseId = 15, Name = "Human Computer Interaction", Subject = "CMPS", Number = 420, CreditHours = 3, Description = "Credit 3 hour Prerequisite: Computer Science 320. Designing, implementing and evaluating computer systems. Task analysis prototyping, usability evaluation, dialouge specification, interaction styles and techniques, human factors, virtual reality, multimedia, and hypermedia systems."
                    
                  },
                  new Models.Course { CourseId = 16, Name = "Operating Systems", Subject = "CMPS", Number = 431, CreditHours = 3, Description = "Credit 3 hours. Prerequisite: Computer Science 375 and 390.Design and implementation of operating systems.Topics include process management, processor management, memory management, device management, file management, process synchronization and interprocess communication, and user interface. Other issues such as distributed computing and system performance may be discussed."

                  },
                  new Models.Course { CourseId = 17, Name = "Database Systems", Subject = "CMPS", Number = 439, CreditHours = 3, Description = "Credit 3 hours. Prerequisite: Computer Science 390.Design and implementation of database systems.Topics include hierarchical, relational, and network models, normalization of relations, data integrity and security, and database administration. A programming project using a relational DBMS is required."
                    
                  },
                  new Models.Course { CourseId = 18, Name = "Current Trends in Computer Science", Subject = "CMPS", Number = 482, CreditHours = 3, Description = "Credit:  3 hours.Prerequisite: Senior Classification and registration in or prior credit for CMPS 411.Topics include computer and information ethics, social implications of technology, current trends in computer science and information technology applications and development, professional issues, and emerging trends and current topics in computer science research."
                    
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
                  new Models.Course { CourseId = 41, Name = "Computer Graphics", Subject = "CMPS", Number = 389, CreditHours = 3, Description = "Credit 3 hours. Prerequisites: Mathematics 200 and Computer Science 270 or 280. Introduction and techniques of computer graphics. Topics include interactive versus passive graphics, input-output devices, and programming techniques suitable for the visual representation of data and images."

                  },
                  new Models.Course { CourseId = 42, Name = "Web Systems and Technologies", Subject = "CMPS", Number = 394, CreditHours = 3, Description = "Credit 3 hours. Prerequisite: Computer Science 294. This course covers the setup and management of important web-based services, server-supported programming technologies, and some other host-management issues such as user support, security, staffing, and purchasing."

                  },
                  new Models.Course { CourseId = 43, Name = "Advanced Computer Networking", Subject = "CMPS", Number = 409, CreditHours = 3, Description = "Credit 3 hours. Prerequisite: Computer Science 329. Advanced computer networking. Topics include security, optimization, custom modules, protocols, information flow management, disaster recovery, wireless applications, and legal and ethical issues."

                  },
                  new Models.Course { CourseId = 44, Name = "Computational Aspects of Game Programming", Subject = "CMPS", Number = 455, CreditHours = 3, Description = "Credit 3 hours. Prerequisite: Math 200 and Computer Science 280. This course will investigate computational aspects of game programming, and students completing the course will have sufficient technical background, well founded in science, to be able to successfully develop computer video games.  Topics covered include coordinate systems, geometric elements, transformations, hyperspace, numerical analysis, rendering, graphics, lighting, code optimization, and other system design and programming issues related to game programming."

                  },
                  new Models.Course { CourseId = 45, Name = "Topics in Information Technology", Subject = "CMPS", Number = 494, CreditHours = 3, Description = "Credit 1-3 hours. Prerequisite: Permission of the Department Head. Special topics in computer science that are appropriate for an Information Technology elective in the Information Technology concentration. Any combination of 491/591, 493/593, and 494/594 may be taken for up to 9 hours of credit, provided that the specific topics are different."

                  },
                  new Models.Course { CourseId = 46, Name = "Numerical Methods", Subject = "CMPS", Number = 391, CreditHours = 3, Description = "Credit 3 hours. Prerequisites: Computer Science 280 and Mathematics 360. Computer-oriented numerical methods for scientific problems. Topics include error analysis, Taylor series, solutions of equations, linear simultaneous equations, and interpolation."

                  },
                  new Models.Course { CourseId = 47, Name = "Survey of Programming Languages", Subject = "CMPS", Number = 401, CreditHours = 3, Description = "Credit 3 hours. Prerequisite: Computer Science 390. Involves the formal study of programming languages, specification, and analysis in terms of data types and structures."

                  },
                  new Models.Course { CourseId = 48, Name = "Fundamental Algorithms", Subject = "CMPS", Number = 434, CreditHours = 3, Description = "Credit 3 hours. Prerequisites: Computer Science 257, 390 and Mathematics 201. The design, implementation, and complexity of algorithms analysis."

                  },
                  new Models.Course { CourseId = 49, Name = "Artificial Intelligence", Subject = "CMPS", Number = 441, CreditHours = 3, Description = "Credit 3 hours. Prerequisites: Mathematics 241 or Mathematics 380 and Computer Science 390. Introduction to intelligent processes and their performance by a computer. Topics include computer representation of knowledge, problem solving, game playing, theorem proving, natural language understanding, computer vision, and robotics."

                  },
                  new Models.Course { CourseId = 50, Name = "Simulation and Modeling", Subject = "CMPS", Number = 443, CreditHours = 3, Description = "Credit 3 hours. Prerequisite: Computer Science 390 and Mathematics 380. Construction and use of computer and mathematical models, parameter estimation, simulation techniques, applications of simulation, examples, and cases and studies taken from physical, social and life sciences, engineering, business and information sciences."

                  },
                  new Models.Course { CourseId = 51, Name = "Machine Learning", Subject = "CMPS", Number = 470, CreditHours = 3, Description = "Credit 3 hours. Prerequisites: Computer Science 390 and Mathematics 241. Introduction to machine learning. Topics include genetic algorithms, inductive learning, statistical learning methods, reinforcement learning, neural networks, decision trees, analytical learning, and Bayesian learning."

                  },
                  new Models.Course { CourseId = 52, Name = "Automata and Formal Languages", Subject = "CMPS", Number = 479, CreditHours = 3, Description = "Credit 3 hours. Prerequisites: Computer Science 257 or Mathematics 223 and senior standing. Introduction to computing device capabilities through study of abstract machines and corresponding formal languages. Topics include Turing machines, recursion, Chomsky grammars, context-free languages, regular languages, and finite automata."

                  },
                  new Models.Course { CourseId = 53, Name = "Special Topics in Computer Science Theory", Subject = "CMPS", Number = 493, CreditHours = 3, Description = "Credit 1-3 hours. Prerequisite: Permission of the Department Head. Special topics in computer science that are appropriate for a Theory elective in the Information Technology concentration. Any combination of 491/591, 493/593, and 494/594 may be taken for up to 9 hours of credit, provided that the specific topics are different."

                  },
                  new Models.Course { CourseId = 54, Name = "Introduction to Public Speaking", Subject = "COMM", Number = 211, CreditHours = 3,
                    
                  },
                  new Models.Course { CourseId = 55, Name = "Southeastern 101", Subject = "SE", Number = 101, CreditHours = 2,
                    
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
                  new Models.Course { CourseId = 72, Name = "Database Administration", Subject = "CMPS", Number = 339, CreditHours = 3, Description = "Credit 3 hours. Prerequisite: CMPS 280. A hands-on comprehensive study of database administration and applications to include selecting, installing, configuring, tuning, maintaining, and reviewing modern database systems."

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
                  new Models.Course { CourseId = 90, Name = "Visual Programming", Subject = "CMPS", Number = 120, CreditHours = 3, Description = "Credit 3 hours. Prerequisite: Registration in or prior credit for Mathematics 155 or 161 or 165. An introduction to visual programming using a modern visual programming language. Topics include programming fundamentals, such as variables, looping, and arrays, as well as graphical user interface (GUI), design and event driven programming."

                  },
                  new Models.Course { CourseId = 91, Name = "300-400 Level Elective", Subject = "CMPS", CreditHours = 3, Description = "Any 300-400 level elective worth 3 credit hours."
                    
                  },
                  new Models.Course { CourseId = 92, Name = "Foundations of Discrete Math", Subject = "MATH", Number = 223, CreditHours = 3,
                  }
            };

            //Adds courses to the database
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
                        //CMPS_MBA_2013_1
                        courses.Single(c => c.Name == "Freshman Composition"),
                        courses.Single(c => c.Name == "Southeastern 101"),
                        courses.Single(c => c.Name == "History Elective"),
                        courses.Single(c => c.Name == "Algorithm Design & Implementation I"),
                        courses.Single(c => c.Name == "Calculus I")
                    },
                    
                },

                new Models.Semester
                {
                    SemesterId = 2,
                    SemesterNum = 2,
                    Courses = new List<Course>()
                    {
                        //CMPS_MBA_2013_2 && CMPS_MBA_2014_2
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
                        //CMPS_MBA_2013_3 && CMPS_MDA_2014_3
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
                        //CMPS_IT_2013_2 && CMPS_SCI_2013_2 && CMPS IT 2014 2
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
                        //CMPS_IT_2013_3 && CMPS IT 2014 3
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
                        //CMPS_IT_2013_6 && CMPS IT 2014 6
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
                        //CMPS_IT_2013_7 && CMPS IT 2014 7
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
                    
                },

                 new Models.Semester
                {
                    SemesterId = 19,
                    SemesterNum = 6,
                    Courses = new List<Course>()
                    {
                        //CMPS_SCI_2013_6
                        courses.Single(c => c.CourseId == 16),
                        courses.Single(c => c.CourseId == 91),
                        courses.Single(c => c.CourseId == 84),
                        courses.Single(c => c.CourseId == 60),
                        courses.Single(c => c.CourseId == 14)
                    },

                },
                 
                new Models.Semester
                {
                    SemesterId = 20,
                    SemesterNum = 7,
                    Courses = new List<Course>()
                    {
                        //CMPS_SCI_2013_7
                        courses.Single(c => c.CourseId == 13),
                        courses.Single(c => c.CourseId == 58),
                        courses.Single(c => c.CourseId == 58),
                        courses.Single(c => c.CourseId == 58)
                    },

                },

                 new Models.Semester
                {
                    SemesterId = 21,
                    SemesterNum = 8,
                    Courses = new List<Course>()
                    {
                        //CMPS_SCI_2013_8
                        courses.Single(c => c.CourseId == 52),
                        courses.Single(c => c.CourseId == 18),
                        courses.Single(c => c.CourseId == 85),
                        courses.Single(c => c.CourseId == 30),
                        courses.Single(c => c.CourseId == 32)
                    },

                },

                  new Models.Semester
                {
                    SemesterId = 22,
                    SemesterNum = 1,
                    Courses = new List<Course>()
                    {
                        //CMPS_MBA_2014_1
                        courses.Single(c => c.CourseId == 81),
                        courses.Single(c => c.CourseId == 19),
                        courses.Single(c => c.CourseId == 64),
                        courses.Single(c => c.CourseId == 1),
                        courses.Single(c => c.CourseId == 55)
                    },

                },

                   new Models.Semester
                {
                    SemesterId = 23,
                    SemesterNum = 4,
                    Courses = new List<Course>()
                    {
                        //CMPS_MBA_2014_4
                        courses.Single(c => c.CourseId == 10),
                        courses.Single(c => c.CourseId == 12),
                        courses.Single(c => c.CourseId == 74),
                        courses.Single(c => c.CourseId == 21),
                        courses.Single(c => c.CourseId == 27),
                        courses.Single(c => c.CourseId == 28)
                    },

                },

                    new Models.Semester
                {
                    SemesterId = 24,
                    SemesterNum = 5,
                    Courses = new List<Course>()
                    {
                        //CMPS_MBA_2014_5
                        courses.Single(c => c.CourseId == 47),
                        courses.Single(c => c.CourseId == 78),
                        courses.Single(c => c.CourseId == 24),
                        courses.Single(c => c.CourseId == 73),
                        courses.Single(c => c.CourseId == 29)
                    },

                },

                     new Models.Semester
                {
                    SemesterId = 25,
                    SemesterNum = 6,
                    Courses = new List<Course>()
                    {
                        //CMPS_MBA_2014_6
                        courses.Single(c => c.CourseId == 11),
                        courses.Single(c => c.CourseId == 16),
                        courses.Single(c => c.CourseId == 75),
                        courses.Single(c => c.CourseId == 83),
                        courses.Single(c => c.CourseId == 14)
                    },

                },

                      new Models.Semester
                {
                    SemesterId = 26,
                    SemesterNum = 7,
                    Courses = new List<Course>()
                    {
                        //CMPS_MBA_2014_7
                        courses.Single(c => c.CourseId == 13),
                        courses.Single(c => c.CourseId == 60),
                        courses.Single(c => c.CourseId == 30),
                        courses.Single(c => c.CourseId == 76),
                        courses.Single(c => c.CourseId == 77)
                    },

                },

                       new Models.Semester
                {
                    SemesterId = 27,
                    SemesterNum = 8,
                    Courses = new List<Course>()
                    {
                        //CMPS_MBA_2014_8
                        courses.Single(c => c.CourseId == 17),
                        courses.Single(c => c.CourseId == 18),
                        courses.Single(c => c.CourseId == 79),
                        courses.Single(c => c.CourseId == 80),
                    },

                },

                        new Models.Semester
                {
                    SemesterId = 28,
                    SemesterNum = 1,
                    Courses = new List<Course>()
                    {
                        //CMPS_IT_2014_1
                        courses.Single(c => c.CourseId == 56),
                        courses.Single(c => c.CourseId == 19),
                        courses.Single(c => c.CourseId == 64),
                        courses.Single(c => c.CourseId == 1),
                        courses.Single(c => c.CourseId == 69),
                        courses.Single( c => c.CourseId == 55)
                    },

                },

                 new Models.Semester
                {
                    SemesterId = 29,
                    SemesterNum = 4,
                    Courses = new List<Course>()
                    {
                        //CMPS_IT_2014_4
                        courses.Single(c => c.CourseId == 7),
                        courses.Single(c => c.CourseId == 10),
                        courses.Single(c => c.CourseId == 12),
                        courses.Single(c => c.CourseId == 24),
                        courses.Single(c => c.CourseId == 33)
                    },

                },

                  new Models.Semester
                {
                    SemesterId = 30,
                    SemesterNum = 5,
                    Courses = new List<Course>()
                    {
                        //CMPS_IT_2014_5
                        courses.Single(c => c.CourseId == 8),
                        courses.Single(c => c.CourseId == 71),
                        courses.Single(c => c.CourseId == 27),
                        courses.Single(c => c.CourseId == 28),
                        courses.Single(c => c.CourseId == 58),
                        courses.Single(c => c.CourseId == 59)
                    },
                },

                   new Models.Semester
                {
                    SemesterId = 31,
                    SemesterNum = 8,
                    Courses = new List<Course>()
                    {
                        //CMPS_IT_2014_8
                        courses.Single(c => c.CourseId == 17),
                        courses.Single(c => c.CourseId == 18),
                        courses.Single(c => c.CourseId == 58),
                        courses.Single(c => c.CourseId == 6)
                    },

                },

                    new Models.Semester
                {
                    SemesterId = 32,
                    SemesterNum = 4,
                    Courses = new List<Course>()
                    {
                        //CMPS_SCI_2014_4
                        courses.Single(c => c.CourseId == 10),
                        courses.Single(c => c.CourseId == 12),
                        courses.Single(c => c.CourseId == 69),
                        courses.Single(c => c.CourseId == 21),
                        courses.Single(c => c.CourseId == 27),
                        courses.Single(c => c.CourseId == 28)
                    },
                },

                     new Models.Semester
                {
                    SemesterId = 33,
                    SemesterNum = 7,
                    Courses = new List<Course>()
                    {
                        //CMPS_SCI_2014_7
                        courses.Single(c => c.CourseId == 46),
                        courses.Single(c => c.CourseId == 13),
                        courses.Single(c => c.CourseId == 58),
                        courses.Single(c => c.CourseId == 58),
                        courses.Single(c => c.CourseId == 58)
                    },
                },

                      new Models.Semester
                {
                    SemesterId = 34,
                    SemesterNum = 8,
                    Courses = new List<Course>()
                    {
                        //CMPS_SCI_2014_8
                        courses.Single(c => c.CourseId == 52),
                        courses.Single(c => c.CourseId == 18),
                        courses.Single(c => c.CourseId == 85),
                        courses.Single(c => c.CourseId == 30),
                        courses.Single(c => c.CourseId == 31)
                    },
                },

                       new Models.Semester
                {
                    SemesterId = 35,
                    SemesterNum = 8,
                    Courses = new List<Course>()
                    {
                        //CMPS_IT_2015_8
                        courses.Single(c => c.CourseId == 72),
                        courses.Single(c => c.CourseId == 18),
                        courses.Single(c => c.CourseId == 6),
                        courses.Single(c => c.CourseId == 58),
                    },

                }

            };

            //Adds semesters to the database
            semesters.ForEach(s => context.Semesters.AddOrUpdate(p => p.SemesterId, s));
            context.SaveChanges();


            context.Plans.AddOrUpdate(
                new Models.Plan
                {
                    PlanId = 1,
                    Major = "CMPS",
                    Concentration = "MBA",
                    CatalogYear = 2013,
                    Name = "CMPS Pre-MBA 2013-14",
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
                    Name = "CMPS IT 2013-14",
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
                    Name = "CMPS SCI 2013-14",
                    Semesters = new List<Semester>()
                    {
                        semesters.Single(s => s.SemesterId == 9),
                        semesters.Single(s => s.SemesterId == 10),
                        semesters.Single(s => s.SemesterId == 17),
                        semesters.Single(s => s.SemesterId == 12),
                        semesters.Single(s => s.SemesterId == 18),
                        semesters.Single(s => s.SemesterId == 19),
                        semesters.Single(s => s.SemesterId == 20),
                        semesters.Single(s => s.SemesterId == 21),
                    }
                },

                new Models.Plan
                {
                    PlanId = 4,
                    Major = "CMPS",
                    Concentration = "MBA",
                    CatalogYear = 2014,
                    Name = "CMPS Pre-MBA 2014-15",
                    Semesters = new List<Semester>()

                    {
                        semesters.Single(s => s.SemesterId == 22),
                        semesters.Single(s => s.SemesterId == 2),
                        semesters.Single(s => s.SemesterId == 3),
                        semesters.Single(s => s.SemesterId == 23),
                        semesters.Single(s => s.SemesterId == 24),
                        semesters.Single(s => s.SemesterId == 25),
                        semesters.Single(s => s.SemesterId == 26),
                        semesters.Single(s => s.SemesterId == 27)
                    }
                },

                new Models.Plan
                {
                    PlanId = 5,
                    Major = "CMPS",
                    Concentration = "IT",
                    CatalogYear = 2014,
                    Name = "CMPS IT 2014-15",
                    Semesters = new List<Semester>()

                    {
                        semesters.Single(s => s.SemesterId == 28),
                        semesters.Single(s => s.SemesterId == 10),
                        semesters.Single(s => s.SemesterId == 11),
                        semesters.Single(s => s.SemesterId == 29),
                        semesters.Single(s => s.SemesterId == 30),
                        semesters.Single(s => s.SemesterId == 14),
                        semesters.Single(s => s.SemesterId == 15),
                        semesters.Single(s => s.SemesterId == 31)
                    }

                },
                
                    new Models.Plan
                    {
                        PlanId = 6,
                        Major = "CMPS",
                        Concentration = "SCI",
                        CatalogYear = 2014,
                        Name = "CMPS SCI 2014-15",
                        Semesters = new List<Semester>()

                    {
                        semesters.Single(s => s.SemesterId == 22),
                        semesters.Single(s => s.SemesterId == 2),
                        semesters.Single(s => s.SemesterId == 17),
                        semesters.Single(s => s.SemesterId == 32),
                        semesters.Single(s => s.SemesterId == 18),
                        semesters.Single(s => s.SemesterId == 19),
                        semesters.Single(s => s.SemesterId == 33),
                        semesters.Single(s => s.SemesterId == 34)
                    }
                    },

                    new Models.Plan
                    {
                        PlanId = 7,
                        Major = "CMPS",
                        Concentration = "MBA",
                        CatalogYear = 2015,
                        Name = "CMPS Pre-MBA 2015-16",
                        Semesters = new List<Semester>()

                    {
                        semesters.Single(s => s.SemesterId == 22),
                        semesters.Single(s => s.SemesterId == 2),
                        semesters.Single(s => s.SemesterId == 3),
                        semesters.Single(s => s.SemesterId == 23),
                        semesters.Single(s => s.SemesterId == 24),
                        semesters.Single(s => s.SemesterId == 25),
                        semesters.Single(s => s.SemesterId == 26),
                        semesters.Single(s => s.SemesterId == 27)
                    }
                    },
                    
                    new Models.Plan
                    {
                        PlanId = 8,
                        Major = "CMPS",
                        Concentration = "IT",
                        CatalogYear = 2015,
                        Name = "CMPS IT 2015-16",
                        Semesters = new List<Semester>()

                    {
                        semesters.Single(s => s.SemesterId == 28),
                        semesters.Single(s => s.SemesterId == 10),
                        semesters.Single(s => s.SemesterId == 11),
                        semesters.Single(s => s.SemesterId == 29),
                        semesters.Single(s => s.SemesterId == 30),
                        semesters.Single(s => s.SemesterId == 14),
                        semesters.Single(s => s.SemesterId == 15),
                        semesters.Single(s => s.SemesterId == 35)
                    }
                    },

                    new Models.Plan
                    {
                        PlanId = 9,
                        Major = "CMPS",
                        Concentration = "SCI",
                        CatalogYear = 2015,
                        Name = "CMPS SCI 2015-16",
                        Semesters = new List<Semester>()

                    {
                        semesters.Single(s => s.SemesterId == 22),
                        semesters.Single(s => s.SemesterId == 2),
                        semesters.Single(s => s.SemesterId == 17),
                        semesters.Single(s => s.SemesterId == 32),
                        semesters.Single(s => s.SemesterId == 18),
                        semesters.Single(s => s.SemesterId == 19),
                        semesters.Single(s => s.SemesterId == 33),
                        semesters.Single(s => s.SemesterId == 34)
                    }
                    }

                );

            context.SaveChanges();
/*The Following can be used to seed an admin user. This will create duplicates if run more than once.
            var crypto = new SimpleCrypto.PBKDF2();
            var password = crypto.Compute("Password!");
            context.Users.AddOrUpdate(
                new User
                {
                    WNumber = "W1234321",
                    FirstName = "Austin",
                    LastName = "Webre",
                    Email = "austin.webre@selu.edu",
                    Password = password,
                    ConfirmPassword = password,
                    PasswordSalt = crypto.Salt,
                    Admin = new Admin
                    {
                        AdminId = 1
                    }
                }
                );
            context.SaveChanges();
*/

            



        }
        
    }
}
