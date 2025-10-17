using GoldCard.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GoldCard.Data
{
    public class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext db)
        {
            var isEmpty =
                !await db.Users.AsNoTracking().AnyAsync() &&
                !await db.Cards.AsNoTracking().AnyAsync();

            if (!isEmpty) return;

            // Seed 10 users
            var users = new List<User>
            {
                new() { CustomerNumber = "A1044911", FirstName = "Malena", LastName = "Lieber", Town = "Strängnäs" },
                new() { CustomerNumber = "A1084685", FirstName = "Kermit", LastName = "Rondeau", Town = "Helsingborg" },
                new() { CustomerNumber = "A1098243", FirstName = "Deangelo", LastName = "Learned", Town = "Köping" },
                new() { CustomerNumber = "A1245764", FirstName = "Domenic", LastName = "Slaton", Town = "Göteborg" },
                new() { CustomerNumber = "A1405755", FirstName = "Aubrey", LastName = "York", Town = "Ängelholm" },
                new() { CustomerNumber = "A1683051", FirstName = "Nathaniel", LastName = "Beighley", Town = "Öregrund" },
                new() { CustomerNumber = "A1900595", FirstName = "Jimmy", LastName = "Banh", Town = "Djursholm" },
                new() { CustomerNumber = "A1931592", FirstName = "Demetrius", LastName = "McRutt", Town = "Skara" },
                new() { CustomerNumber = "A1971573", FirstName = "Kaci", LastName = "Rausch", Town = "Mariestad" },
                new() { CustomerNumber = "A1986213", FirstName = "Romeo", LastName = "Flagg", Town = "Halmstad" }
            };

            db.Users.AddRange(users);
            await db.SaveChangesAsync();

            // Seed alla cards
            var cards = new List<Card>
            {
                // DunderKatt 10
                new() { CardNumber = "K117247315", CardType = "Dunder-Katt" },
                new() { CardNumber = "K132457414", CardType = "Dunder-Katt" },
                new() { CardNumber = "K144171384", CardType = "Dunder-Katt" },
                new() { CardNumber = "K152915327", CardType = "Dunder-Katt" },
                new() { CardNumber = "K161135470", CardType = "Dunder-Katt" },
                new() { CardNumber = "K209478647", CardType = "Dunder-Katt" },
                new() { CardNumber = "K242872563", CardType = "Dunder-Katt" },
                new() { CardNumber = "K284813933", CardType = "Dunder-Katt" },
                new() { CardNumber = "K284819759", CardType = "Dunder-Katt" },
                new() { CardNumber = "K303838339", CardType = "Dunder-Katt" },
                
                // KristallHäst 7
                new() { CardNumber = "K549587658", CardType = "Kristall-Häst" },
                new() { CardNumber = "K574593993", CardType = "Kristall-Häst" },
                new() { CardNumber = "K598298903", CardType = "Kristall-Häst" },
                new() { CardNumber = "K599880106", CardType = "Kristall-Häst" },
                new() { CardNumber = "K616092046", CardType = "Kristall-Häst" },
                new() { CardNumber = "K620354764", CardType = "Kristall-Häst" },
                new() { CardNumber = "K634993396", CardType = "Kristall-Häst" },
               
                
                // ÖverPanda 10
                new() { CardNumber = "K741815436", CardType = "Över-Panda" },
                new() { CardNumber = "K742639121", CardType = "Över-Panda" },
                new() { CardNumber = "K784054851", CardType = "Över-Panda" },
                new() { CardNumber = "K834789453", CardType = "Över-Panda" },
                new() { CardNumber = "K852157464", CardType = "Över-Panda" },
                new() { CardNumber = "K854752475", CardType = "Över-Panda" },
                new() { CardNumber = "K858161987", CardType = "Över-Panda" },
                new() { CardNumber = "K858510023", CardType = "Över-Panda" },
                new() { CardNumber = "K859722150", CardType = "Över-Panda" },
                new() { CardNumber = "K861597278", CardType = "Över-Panda" },
                
                // EldApan 5
                new() { CardNumber = "K873081558", CardType = "Eld-Apan" },
                new() { CardNumber = "K873589343", CardType = "Eld-Apan" },
                new() { CardNumber = "K879744392", CardType = "Eld-Apan" },
                new() { CardNumber = "K909618038", CardType = "Eld-Apan" },
                new() { CardNumber = "K959603624", CardType = "Eld-Apan" },

                // GuldCard Guld Gåsen 1
                new() {CardNumber ="K99696867", CardType = "Guld-Gåsen" },
            };

            db.Cards.AddRange(cards);
            await db.SaveChangesAsync();
        }
    }
}
