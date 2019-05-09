using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using MVCgame.Models;
using System.Data.Entity;

namespace MVCgame.DAL
{
    public class GameInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GameContext>
    {
        protected override void Seed(GameContext context)
        {

            var genres = new List<Genre> {
            new Genre {GenreID = 1, Name = "Strategy"},
            new Genre {GenreID = 2, Name = "Adventure"},
            new Genre {GenreID = 3, Name = "Action"},
            new Genre {GenreID = 4, Name = "Role-Playing"},
            new Genre {GenreID = 5, Name = "Simulation"},
            new Genre {GenreID = 6, Name = "Sports"},
            new Genre {GenreID = 7, Name = "Racing"},
            new Genre {GenreID = 8, Name = "First-person shooter"},

            };
                genres.ForEach(s => context.Genres.Add(s));
                context.SaveChanges();
            
                var platform = new List<Platform>()
            {
                new Platform {PlatformID = 1, System = "Nintendo Switch"},
                new Platform {PlatformID = 2, System = "Windows"},
                new Platform {PlatformID = 3, System = "Mac"},
                new Platform {PlatformID = 4, System = "Xbox"},
                new Platform {PlatformID = 5, System = "Playstation 4"},
                new Platform {PlatformID = 6, System = "Linux"},
            };
                platform.ForEach(s => context.Platforms.Add(s));
                context.SaveChanges();

                List<Game> games = new List<Game>
            {

                new Game{GameID = 1, Title = "The Escapists 2", ReleaseDate = 11, ReleaseMonth = "January", GenreID = 4, PlatformID = 1},
                new Game{GameID = 2, Title = "Shadow of the Colossus", ReleaseDate = 6, ReleaseMonth = "February", GenreID = 3, PlatformID = 5},
                new Game{GameID = 3, Title = "Rust", ReleaseDate = 6, ReleaseMonth = "February", GenreID = 2, PlatformID = 2},
                new Game{GameID = 4, Title = "God of War", ReleaseDate = 20, ReleaseMonth = "April", GenreID= 3, PlatformID = 5},
                new Game{GameID = 5, Title = "Conan Exiles", ReleaseDate = 8, ReleaseMonth = "May", GenreID = 3, PlatformID = 2},
                new Game{GameID = 6, Title = "The Crew 2", ReleaseDate = 29, ReleaseMonth = "June", GenreID = 7, PlatformID = 2},
                new Game{GameID = 7, Title = "No Man's Sky", ReleaseDate = 24, ReleaseMonth = "July", GenreID = 3, PlatformID = 4},
                new Game{GameID = 8, Title = "Divinity: Original Sin II", ReleaseDate = 31, ReleaseMonth = "August", GenreID = 4, PlatformID = 5},
                new Game{GameID = 9, Title = "Surving Mars", ReleaseDate = 15, ReleaseMonth = "March", GenreID = 5, PlatformID = 1},
                new Game{GameID = 10, Title = "Detective Pikachu", ReleaseDate = 23, ReleaseMonth = "March", GenreID = 2, PlatformID = 1},
                new Game{GameID = 11, Title = "South Park: The Fractured but Whole", ReleaseDate = 24, ReleaseMonth = "April", GenreID = 4, PlatformID = 1},
                new Game{GameID = 12, Title = "Total War Saga: Thrones of Britannia ", ReleaseDate = 3, ReleaseMonth = "May", GenreID = 1, PlatformID = 2},
                new Game{GameID = 13, Title = "Insurgency: Sandstorm", ReleaseDate = 12, ReleaseMonth = "December", GenreID = 8, PlatformID = 2},
                new Game{GameID = 14, Title = "Mutant Football League: Dynasty Edition", ReleaseDate = 30, ReleaseMonth = "October", GenreID = 6, PlatformID = 2},
            };
                games.ForEach(s => context.Games.Add(s));
                context.SaveChanges();
        }

    }
}