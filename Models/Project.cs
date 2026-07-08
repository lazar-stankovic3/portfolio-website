namespace Portfolio.Models;

public sealed record Project(
    string Name,
    string Emoji,
    string DescriptionEn,
    string DescriptionSr,
    IReadOnlyList<string> Tech,
    string GithubUrl,
    string AccentVar);
