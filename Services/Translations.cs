namespace Portfolio.Services;

public static class Translations
{
    private static readonly Dictionary<string, (string En, string Sr)> Map = new()
    {
        ["nav.about"] = ("About", "O meni"),
        ["nav.skills"] = ("Skills", "Veštine"),
        ["nav.projects"] = ("Projects", "Projekti"),
        ["nav.contact"] = ("Contact", "Kontakt"),
        ["nav.terminal"] = ("Terminal", "Terminal"),
        ["nav.theme"] = ("Toggle theme", "Promeni temu"),

        ["hero.greeting"] = ("Hey, I'm", "Ćao, ja sam"),
        ["hero.role"] = ("Student & Aspiring Developer", "Student i budući programer"),
        ["hero.tagline"] = (
            "I build full-stack web apps — from real-time typing races to cinema booking platforms — and I'm always chasing the next fun bug to fix.",
            "Pravim full-stack veb aplikacije — od igara u kucanju uživo do platformi za rezervaciju karata — i uvek tražim sledeći zanimljiv bag da rešim."),
        ["hero.cta.projects"] = ("See my projects", "Pogledaj projekte"),
        ["hero.cta.contact"] = ("Let's talk", "Pošalji poruku"),
        ["hero.scroll"] = ("scroll", "skroluj"),

        ["about.heading"] = ("About Me", "O meni"),
        ["about.kicker"] = ("Who's this?", "Ko je ovo?"),
        ["about.body"] = (
            "I'm Lazar, a student who fell in love with building things that actually run — real-time apps, booking systems, and \"just for fun\" side projects that turned into serious learning experiences. I like clean APIs, databases that don't lie to me, and UIs that feel a little alive. Currently leveling up in .NET, React, and Angular.",
            "Ja sam Lazar, student koji je zavoleo da pravi stvari koje stvarno rade — aplikacije uživo, sisteme za rezervacije i projekte „za zabavu“ koji su postali ozbiljno iskustvo učenja. Volim čiste API-je, baze podataka kojima mogu da verujem i interfejse koji deluju pomalo živo. Trenutno usavršavam .NET, React i Angular."),
        ["about.card1.title"] = ("Full-Stack", "Full-Stack"),
        ["about.card1.text"] = ("Comfortable across the whole stack, from PostgreSQL to pixels.", "Snalazim se kroz ceo stek, od PostgreSQL-a do piksela."),
        ["about.card2.title"] = ("Real-time", "Real-time"),
        ["about.card2.text"] = ("SignalR, sockets and live data don't scare me.", "SignalR, socket-i i podaci uživo me ne plaše."),
        ["about.card3.title"] = ("Always learning", "Stalno učim"),
        ["about.card3.text"] = ("New framework? New database? Bring it on.", "Novi frejmvork? Nova baza? Slobodno."),

        ["skills.heading"] = ("Skills & Tools", "Veštine i alati"),
        ["skills.subtitle"] = ("The stack I reach for most", "Stek koji najčešće koristim"),
        ["skills.group.languages"] = ("Languages", "Jezici"),
        ["skills.group.frontend"] = ("Frontend", "Frontend"),
        ["skills.group.backend"] = ("Backend", "Backend"),
        ["skills.group.tools"] = ("Database & Tools", "Baze i alati"),

        ["projects.heading"] = ("Things I've Built", "Šta sam napravio"),
        ["projects.subtitle"] = ("A couple of projects I'm proud of — check the code on GitHub", "Par projekata na koje sam ponosan — pogledaj kod na GitHub-u"),
        ["projects.cta"] = ("View on GitHub", "Pogledaj na GitHub-u"),
        ["projects.viewProfile"] = ("See all repos on GitHub", "Svi repozitorijumi na GitHub-u"),

        ["terminal.heading"] = ("Poke the Backend", "Dirni backend"),
        ["terminal.subtitle"] = (
            "A real terminal wired straight into this site's ASP.NET Core server. Type 'help' to start.",
            "Pravi terminal povezan direktno na ASP.NET Core server ovog sajta. Ukucaj 'help' za početak."),

        ["contact.heading"] = ("Let's Build Something", "Hajde da napravimo nešto"),
        ["contact.subtitle"] = ("Got a project, an internship, or just want to say hi? My inbox is open.", "Imaš projekat, praksu, ili samo želiš da pozdraviš? Sanduče mi je otvoreno."),
        ["contact.form.name"] = ("Your name", "Ime"),
        ["contact.form.email"] = ("Your email", "Email"),
        ["contact.form.message"] = ("Message", "Poruka"),
        ["contact.form.submit"] = ("Send message 🚀", "Pošalji poruku 🚀"),
        ["contact.form.sending"] = ("Sending...", "Šalje se..."),
        ["contact.form.success"] = ("Thanks! Your message landed safely — I'll reply soon.", "Hvala! Poruka je stigla — odgovoriću uskoro."),
        ["contact.form.error"] = ("Hmm, something went wrong on my end. Try emailing me directly.", "Hmm, nešto nije uspelo. Probaj da mi pišeš direktno na mejl."),
        ["contact.info.emailLabel"] = ("Email", "Email"),
        ["contact.info.githubLabel"] = ("GitHub", "GitHub"),
        ["contact.validation.name"] = ("Please tell me your name.", "Reci mi kako se zoveš."),
        ["contact.validation.email"] = ("A valid email helps me reply.", "Potreban je ispravan email da bih ti odgovorio."),
        ["contact.validation.message"] = ("Don't leave me hanging — write something!", "Nemoj me ostaviti bez poruke — napiši nešto!"),

        ["footer.built"] = ("Built with ASP.NET Core Blazor, coffee, and a bit of chaos.", "Napravljeno uz ASP.NET Core Blazor, kafu i malo haosa."),
        ["footer.rights"] = ("All rights reserved.", "Sva prava zadržana."),
    };

    public static string Get(string key, string lang) =>
        Map.TryGetValue(key, out var pair)
            ? (lang == "sr" ? pair.Sr : pair.En)
            : key;
}
