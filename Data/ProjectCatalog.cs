using Portfolio.Models;

namespace Portfolio.Data;

public static class ProjectCatalog
{
    public static readonly IReadOnlyList<Project> All = new List<Project>
    {
        new(
            Name: "TypeRacerSrbija",
            Emoji: "⌨️",
            DescriptionEn: "A real-time multiplayer typing race for Serbian text. Players join a room, race live against each other over SignalR, and climb the leaderboard. JWT + Google auth backend, Vite-powered React frontend.",
            DescriptionSr: "Multiplejer takmičenje u kucanju uživo, na srpskom jeziku. Igrači se pridružuju sobi, takmiče se u realnom vremenu preko SignalR-a i penju se na rang listu. Backend sa JWT i Google prijavom, frontend u React-u uz Vite.",
            Tech: new[] { "ASP.NET Core", "C#", "SignalR", "PostgreSQL", "EF Core", "React", "JWT / OAuth", "Docker" },
            GithubUrl: "https://github.com/lazar-stankovic3/TypeRacerSrbija",
            AccentVar: "--accent"
        ),
        new(
            Name: "bnbCinema",
            Emoji: "🎬",
            DescriptionEn: "A cinema ticket-booking platform — browse showtimes, pick your seats, and lock in a movie night. Angular frontend talking to a Node/Express API, backed by a SQL database with its own auth system.",
            DescriptionSr: "Platforma za rezervaciju bioskopskih karata — pregled termina, biranje sedišta i zakazivanje filmske večeri. Angular frontend povezan sa Node/Express API-jem i SQL bazom sa sopstvenim sistemom prijave.",
            Tech: new[] { "Angular", "TypeScript", "Node.js", "Express", "SQL" },
            GithubUrl: "https://github.com/lazar-stankovic3/bnbCinema",
            AccentVar: "--primary"
        ),
    };
}
