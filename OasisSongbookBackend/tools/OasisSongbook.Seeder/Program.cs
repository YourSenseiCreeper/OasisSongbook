using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OasisSongbook.Business.Context;
using OasisSongbook.Business.Model;
using OasisSongbook.Business.Model.Song;
using OasisSongbook.Business.Model.Songbook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OasisSongbook.Seeder
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Run().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static async Task Run()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .Build();

            var options = config.GetSection("OasisSongbookNoSqlOptions").Get<OasisSongbookNoSqlOptions>();
            var context = new OasisSongbookNoSqlContext(Options.Create(options));

            var jsonUsers = File.ReadAllText("Data/users.json");
            var users = JsonConvert.DeserializeObject<IEnumerable<User>>(jsonUsers);
            await context.Users.AddRange(users);
            Console.WriteLine($"Created {users.Count()} users");

            var jsonSongs = File.ReadAllText("Data/songs_new.json");
            var songs = JsonConvert.DeserializeObject<IEnumerable<Song>>(jsonSongs);
            await context.Songs.AddRange(songs);
            Console.WriteLine($"Created {songs.Count()} songs");

            var jsonSongbooks = File.ReadAllText("Data/songbooks.json");
            var songbooks = JsonConvert.DeserializeObject<IEnumerable<Songbook>>(jsonSongbooks);
            await context.Songbooks.AddRange(songbooks);
            Console.WriteLine($"Created {songbooks.Count()} songbooks");
        }
    }
}