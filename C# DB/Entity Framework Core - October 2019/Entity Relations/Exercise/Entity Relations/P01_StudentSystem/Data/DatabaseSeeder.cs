namespace P01_StudentSystem.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;

    using P01_StudentSystem.Data.Models;

    public class DatabaseSeeder
    {
        public static void CoursesSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasData(new Course()
                {
                    CourseId = 1,
                    Name = "C# OOP",
                    Description = "In this course you will learn the principles of OOP",
                    StartDate = DateTime.Parse("10.11.2019"),
                    EndDate = DateTime.Now.AddDays(70),
                    Price = 399.00m
                },

                new Course()
                {
                    CourseId = 2,
                    Name = "Java Basics",
                    StartDate = DateTime.Parse("18.12.2019"),
                    EndDate = DateTime.Now.AddDays(90),
                    Price = 180.00m
                }
                );
        }

        public static void HomeworkSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Homework>()
                .HasData(new Homework()
                {
                    HomeworkId = 1,
                    Content = "testContent",
                    ContentType = Homework.CType.Pdf,
                    SubmissionTime = DateTime.UtcNow,
                    StudentId = 1,
                    CourseId = 1
                },

             new Homework()
             {
                 HomeworkId = 2,
                 Content = "testContent2",
                 ContentType = Homework.CType.Zip,
                 SubmissionTime = DateTime.UtcNow,
                 StudentId = 2,
                 CourseId = 2
             }
                );
        }

        public static void ResourceSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>()
                .HasData(new Resource()
                {
                    ResourceId = 1,
                    Name = "Documents",
                    Url = "https://testdocs.com/resources/docs",
                    ResourceType = Resource.Type.Document,
                    CourseId = 1
                },

                 new Resource()
                 {
                     ResourceId = 2,
                     Name = "Video",
                     Url = "https://testdocs.com/resources/video",
                     ResourceType = Resource.Type.Video,
                     CourseId = 2
                 }
                );
        }

        public static void StudentSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasData(new Student()
                {
                    StudentId = 1,
                    Name = "Gosho",
                    PhoneNumber = "0885444555",
                    RegisteredOn = DateTime.Today,
                    Birthday = DateTime.Now.AddYears(-20)
                },

                new Student()
                {
                    StudentId = 2,
                    Name = "Pesho",
                    PhoneNumber = "0885111222",
                    RegisteredOn = DateTime.Today.AddDays(4),
                    Birthday = DateTime.Now.AddYears(-18)
                }
                );
        }

        public static void StudentCourseSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasData(new StudentCourse()
                {
                    CourseId = 1,
                    StudentId = 1
                },

                    new StudentCourse()
                    {
                        CourseId = 2,
                        StudentId = 2
                    }

                );
        }
    }
}
