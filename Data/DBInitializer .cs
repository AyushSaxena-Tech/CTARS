using MVCApplication.Data;
using MVCApplication.Models;
using System;
using System.Linq;

namespace ContosoUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ClientGoalsContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Clients.Any())
            {
                return;   // DB has been seeded
            }

            var clients = new Client[]
            {
            new Client{FirstName="Test",LastName="One",DateCreated=DateTime.Parse("2021-09-01")},
            new Client{FirstName="Test",LastName="Two",DateCreated=DateTime.Parse("2021-09-01")},
            new Client{FirstName="Test",LastName="Three",DateCreated=DateTime.Parse("2022-01-01")},
            new Client{FirstName="Test",LastName="Four",DateCreated=DateTime.Parse("2022-02-12")},
            new Client{FirstName="Test",LastName="Five",DateCreated=DateTime.Parse("2022-03-23")},
            new Client{FirstName="Test",LastName="Six",DateCreated=DateTime.Parse("2022-04-16")}
            };
            foreach (Client c in clients)
            {
                context.Clients.Add(c);
            }
            context.SaveChanges();

            var clientGoals = new ClientGoal[]
            {
            new ClientGoal{ClientID=1,Title="Fitness",Details="To be Fit",DateCreated=DateTime.Parse("2021-09-01")},
            new ClientGoal{ClientID=1,Title="Fat Loss",Details="To Lose Fat",DateCreated=DateTime.Parse("2021-09-01")},
            new ClientGoal{ClientID=1,Title="Stamina",Details="To Increase Stamina",DateCreated=DateTime.Parse("2021-09-01")},
            new ClientGoal{ClientID=1,Title="Muscle",Details="To build muscles",DateCreated=DateTime.Parse("2021-09-01")},
            new ClientGoal{ClientID=2,Title="Fitness",Details="To be Fit",DateCreated=DateTime.Parse("2021-09-01")},
            new ClientGoal{ClientID=2,Title="Fat Loss",Details="To Lose Fat",DateCreated=DateTime.Parse("2021-09-01")},
            new ClientGoal{ClientID=3,Title="Stamina",Details="To Increase Stamina",DateCreated=DateTime.Parse("2021-09-01")},
            new ClientGoal{ClientID=3,Title="Muscle",Details="To build muscles",DateCreated=DateTime.Parse("2021-09-01")},
            new ClientGoal{ClientID=4,Title="Fat Loss",Details="To Lose Fat",DateCreated=DateTime.Parse("2022-02-12")},
            new ClientGoal{ClientID=4,Title="Stamina",Details="To Increase Stamina",DateCreated=DateTime.Parse("2022-02-12")},
            new ClientGoal{ClientID=5,Title="Muscle",Details="To build muscles",DateCreated=DateTime.Parse("2022-03-23")},
            new ClientGoal{ClientID=5,Title="Fitness",Details="To be Fit",DateCreated=DateTime.Parse("2022-03-23")},
            new ClientGoal{ClientID=6,Title="Muscle",Details="To build muscles",DateCreated=DateTime.Parse("2022-04-16")},
            };
            foreach (ClientGoal C in clientGoals)
            {
                context.ClientGoals.Add(C);
            }
            context.SaveChanges();
        }
    }
}