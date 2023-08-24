using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using TaskBoardWebApp.Models;

namespace TaskBoardWebApp.Infrastructure
{
    public class SeedData
    {
        private User _user1;
        private User _user2;

        public SeedData()
        {
            _user1 = new User
            {
                Name = "Rorshah",
                Email = "mrsharik213@gmail.com",
                Password = "147258369",
                Image = "avatar.jpg"
            };

            _user2 = new User
            {
                Name = "Jane Doe",
                Email = "janedoe@example.com",
                Password = "password123",
                Image = "jane-doe.jpg"
            };
        }

        public static SeedData GetInstance()
        {
            // Singleton pattern
            if (_instance == null)
            {
                _instance = new SeedData();
            }

            return _instance;
        }

        public static void SeedDatabase(DataContext context)
        {
            // Get an instance of SeedData
            var seedData = SeedData.GetInstance();

            context.Database.Migrate();

            if (!context.Users.Any())
            {
                // Add the users to the database
                context.Users.Add(seedData._user1);
                context.Users.Add(seedData._user2);
                context.SaveChanges();
            }

            if (!context.Characters.Any())
            {
                // Create two characters
                var character1 = new Character
                {
                    Name = "John Doe's Character",
                    Image = "john-doe-character.jpg",
                    Level = 1,
                    Experience = 0,
                    CreateDate = DateTime.Now
                };

                var character2 = new Character
                {
                    Name = "Jane Doe's Character",
                    Image = "jane-doe-character.jpg",
                    Level = 2,
                    Experience = 100,
                    CreateDate = DateTime.Now
                };

                // Assign the characters to the users
                character1.User = seedData._user1;
                character2.User = seedData._user2;

                // Add the characters to the database
                context.Characters.Add(character1);
                context.Characters.Add(character2);
                context.SaveChanges();
            }
            if (!context.Categories.Any())
            {
                // Add the users to the database
                context.Categories.AddRange(
                    new TaskCategory
                    {
                        Category = "Python"
                    },

                    new TaskCategory
                    {
                        Category = "HomeWork"
                    },

                    new TaskCategory
                    {
                        Category = "C#"
                    },

                    new TaskCategory
                    {
                        Category = "Java"
                    },

                    new TaskCategory
                    {
                        Category = "Language"
                    },

                    new TaskCategory
                    {
                        Category = "C++"
                    }

                );

                context.SaveChanges();
            }

            if (!context.Tasks.Any())
            {
                context.Tasks.AddRange(
                    new Models.Task
                    {
                        Name = "MVC",
                        Description = "Learn the pattern Mvc",
                        CreateDate = DateTime.Now,
                        EndDate = DateTime.Now + TimeSpan.FromDays(1),
                        IsExecute = false,
                        Experience = 10,
                        Rating = 0,
                        Character = context.Characters.FirstOrDefault(x => x.Id == 1),
                        Category = context.Categories.FirstOrDefault(x => x.Category == "C#")
                    },
                    
                    new Models.Task
                    {
                        Name = "Parser",
                        Description = "Create a parser in python",
                        CreateDate = DateTime.Now,
                        EndDate = DateTime.Now + TimeSpan.FromDays(2),
                        IsExecute = false,
                        Experience = 5,
                        Rating = 0,
                        Character = context.Characters.FirstOrDefault(x => x.Id == 1),
                        Category = context.Categories.FirstOrDefault(x => x.Category == "Python")
                    },
                    
                    new Models.Task
                    {
                        Name = "Floristry",
                        Description = "Water the flowers",
                        CreateDate = DateTime.Now,
                        EndDate = DateTime.Now + TimeSpan.FromHours(2),
                        IsExecute = false,
                        Experience = 2,
                        Rating = 0,
                        Character = context.Characters.FirstOrDefault(x => x.Id == 2),
                        Category = context.Categories.FirstOrDefault(x => x.Category == "HomeWork")
                    }

                    );

                context.SaveChanges();

            } 
        }

        private static SeedData _instance;
    }
}