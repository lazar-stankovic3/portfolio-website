using System.Runtime.InteropServices;
using Portfolio.Data;

namespace Portfolio.Services;

public sealed class TerminalCommandService
{
    private static readonly DateTime ProcessStartUtc = DateTime.UtcNow;

    private static readonly string[] Jokes =
    {
        "Why do programmers prefer dark mode? Because light attracts bugs.",
        "There are 10 types of people: those who understand binary and those who don't.",
        "A SQL query walks into a bar, walks up to two tables and asks: \"Can I join you?\"",
        "It's not a bug, it's an undocumented feature.",
        "In case of fire: git commit, git push, leave building.",
    };

    private long _commandsExecuted;
    private int _activeSessions;
    private readonly Random _random = new();

    public int RegisterSession() => Interlocked.Increment(ref _activeSessions);

    public void UnregisterSession() => Interlocked.Decrement(ref _activeSessions);

    public IReadOnlyList<string> Execute(string rawInput, string language)
    {
        Interlocked.Increment(ref _commandsExecuted);

        var input = rawInput.Trim();
        if (input.Length == 0)
        {
            return Array.Empty<string>();
        }

        var parts = input.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
        var command = parts[0].ToLowerInvariant();
        var arg = parts.Length > 1 ? parts[1].Trim() : "";

        return command switch
        {
            "help" => Help(),
            "about" => new[] { Translations.Get("about.body", language) },
            "skills" => Skills(),
            "projects" or "ls" => Projects(arg),
            "contact" => Contact(),
            "whoami" => WhoAmI(),
            "status" or "stats" => Status(),
            "neofetch" => Neofetch(),
            "date" => new[] { $"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC (real server clock)" },
            "joke" => new[] { Jokes[_random.Next(Jokes.Length)] },
            "sudo" => new[] { "Nice try. Permission denied — this circuit runs as 'guest'. 😏" },
            "exit" or "quit" => new[] { "You can't exit real life that easily. 😄" },
            _ => new[] { $"command not found: {command} — type 'help' for a list of commands" },
        };
    }

    private static IReadOnlyList<string> Help() => new[]
    {
        "Available commands:",
        "  help       show this list",
        "  about      who I am",
        "  skills     tech I use",
        "  projects   list my projects (or 'projects <name>' for details)",
        "  contact    how to reach me",
        "  whoami     info about this session",
        "  status     live backend stats (uptime, memory, active sessions...)",
        "  neofetch   the classic sysadmin flex",
        "  date       current server time (UTC)",
        "  joke       a programmer joke",
        "  clear      clear the screen",
        "",
        "Every command is sent over a real SignalR connection and executed",
        "by the ASP.NET Core backend behind this site — not a JS simulation.",
    };

    private static IReadOnlyList<string> Skills() => new[]
    {
        "Languages : C#, JavaScript, TypeScript",
        "Frontend  : React, Angular, HTML/CSS",
        "Backend   : ASP.NET Core, Node.js/Express, SignalR",
        "Data/Tools: PostgreSQL, SQL, Docker, EF Core, JWT/OAuth, Git",
    };

    private static IReadOnlyList<string> Projects(string filter)
    {
        var projects = ProjectCatalog.All;

        if (!string.IsNullOrWhiteSpace(filter))
        {
            var match = projects.FirstOrDefault(p =>
                p.Name.Contains(filter, StringComparison.OrdinalIgnoreCase));

            if (match is null)
            {
                return new[] { $"no project matching '{filter}' — try 'projects' with no arguments" };
            }

            return new[]
            {
                $"{match.Emoji} {match.Name}",
                match.DescriptionEn,
                $"tech: {string.Join(", ", match.Tech)}",
                match.GithubUrl,
            };
        }

        var lines = new List<string> { "Projects (type 'projects <name>' for details):" };
        lines.AddRange(projects.Select(p => $"  {p.Emoji} {p.Name} — {string.Join(", ", p.Tech.Take(3))}"));
        return lines;
    }

    private static IReadOnlyList<string> Contact() => new[]
    {
        "email  : lazar.stanko1@gmail.com",
        "github : github.com/lazar-stankovic3",
    };

    private static IReadOnlyList<string> WhoAmI() => new[]
    {
        "You're an anonymous guest — nothing you type here is stored.",
        "Your browser is connected to this server through a live SignalR circuit.",
    };

    private IReadOnlyList<string> Status()
    {
        var uptime = DateTime.UtcNow - ProcessStartUtc;
        var managedMemoryMb = GC.GetTotalMemory(forceFullCollection: false) / 1024.0 / 1024.0;

        return new[]
        {
            "Server status",
            "-------------",
            $"Uptime          : {FormatUptime(uptime)}",
            $"Server time     : {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC",
            $".NET runtime    : {RuntimeInformation.FrameworkDescription}",
            $"OS              : {RuntimeInformation.OSDescription}",
            $"Managed memory  : {managedMemoryMb:F1} MB",
            $"Commands run    : {Interlocked.Read(ref _commandsExecuted)} (since last deploy)",
            $"Active sessions : {_activeSessions} (including you)",
        };
    }

    private IReadOnlyList<string> Neofetch()
    {
        var uptime = DateTime.UtcNow - ProcessStartUtc;
        return new[]
        {
            "guest@lazar-portfolio",
            "---------------------",
            "OS      : ASP.NET Core Blazor Server",
            $"Uptime  : {FormatUptime(uptime)}",
            $"Runtime : {RuntimeInformation.FrameworkDescription}",
            "Stack   : C# · SignalR · EF Core · PostgreSQL",
            "Editor  : whatever gets the job done",
            "Status  : always shipping",
        };
    }

    private static string FormatUptime(TimeSpan span) =>
        span.TotalDays >= 1
            ? $"{(int)span.TotalDays}d {span.Hours}h {span.Minutes}m {span.Seconds}s"
            : $"{span.Hours}h {span.Minutes}m {span.Seconds}s";
}
