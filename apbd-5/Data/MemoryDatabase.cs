using RestApiApbdPjatkCw4.Models;

namespace RestApiApbdPjatkCw4.Data;

/// <summary>
/// Baza danych w pamięci.
/// </summary>
public class MemoryDatabase
{
    public static List<Animal> Animals { get; set; } = new List<Animal>
    {
        new Animal
        {
            Id = 1,
            Name = "Kot",
            Category = "Ssaki",
            Mass = 3.20,
            HairColor = "Czarny",
            Visits = new List<Visit>
            {
                new Visit
                {
                    Id = 1,
                    Date = DateTime.Now.AddDays(-15),
                    Description = "Wizyta kontrolna."
                },
                new Visit
                {
                    Id = 2,
                    Date = DateTime.Now.AddDays(-30),
                    Description = "Szczepienie."
                },
                new Visit
                {
                    Id = 3,
                    Date = DateTime.Now.AddDays(-60),
                    Description = "Badanie krwi."
                }
            }
        },
        new Animal
        {
            Id = 2,
            Name = "Pies",
            Category = "Ssaki",
            Mass = 6.50,
            HairColor = "Brązowy",
            Visits = new List<Visit>
            {
                new Visit
                {
                    Id = 4,
                    Date = DateTime.Now.AddDays(-10),
                    Description = "Wizyta kontrolna."
                },
                new Visit
                {
                    Id = 5,
                    Date = DateTime.Now.AddDays(-20),
                    Description = "Szczepienie."
                },
                new Visit
                {
                    Id = 6,
                    Date = DateTime.Now.AddDays(-40),
                    Description = "Badanie krwi."
                }
            }
        },
        new Animal
        {
            Id = 3,
            Name = "Kruk",
            Category = "Ptaki",
            Mass = 0.50,
            HairColor = "Czarny",
            Visits = new List<Visit>
            {
                new Visit
                {
                    Id = 7,
                    Date = DateTime.Now.AddDays(-5),
                    Description = "Wizyta kontrolna."
                },
                new Visit
                {
                    Id = 8,
                    Date = DateTime.Now.AddDays(-10),
                    Description = "Szczepienie."
                },
                new Visit
                {
                    Id = 9,
                    Date = DateTime.Now.AddDays(-20),
                    Description = "Badanie krwi."
                }
            }
        },
        new Animal
        {
            Id = 4,
            Name = "Karp",
            Category = "Ryby",
            Mass = 2.00,
            HairColor = "Brak",
            Visits = new List<Visit>
            {
                new Visit
                {
                    Id = 10,
                    Date = DateTime.Now.AddDays(-100),
                    Description = "Kontrola stanu zdrowia."
                },
               
            }
        },
        new Animal
        {
            Id = 5,
            Name = "Rekin",
            Category = "Ryby",
            Mass = 500.00,
            HairColor = "Szary",
            Visits = new List<Visit>
            {
                new Visit
                {
                    Id = 11,
                    Date = DateTime.Now.AddDays(-200),
                    Description = "Kontrola stanu zdrowia."
                },
               
            }
        }
    };

}