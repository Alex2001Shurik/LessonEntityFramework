using System;
using System.Collections.Generic;
using System.Linq;

namespace LessonEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new MyDbContext()) // с помощью using БД автоматически закрывается
            {
                var group = new Group()
                {
                    Name = "Rammstein",
                    Year = 1994
                };

                var group2 = new Group()
                {
                    Name = "Linkin Park"
                };

                context.Groups.Add(group); // пока не в базе данных, а в кешированном хранилище
                context.Groups.Add(group2);
                context.SaveChanges(); // все изменения ушли в базу данных

                var songs = new List<Song>
                {
                    new Song() { Name = "In the end", GroupId = group2.Id},
                    new Song() { Name = "Numb", GroupId = group2.Id},
                    new Song() { Name = "Mutter", GroupId = group.Id}
                };
                context.Songs.AddRange(songs); // добавляем коллекцию
                context.SaveChanges();

                var s = context.Groups.Single(x => x.Id == group.Id);
                s.Name = "u2";
                context.SaveChanges();
                
                foreach(var song in songs)
                {
                    Console.WriteLine($"Song name: {song.Name}, Group name: {song.Group.Name}");
                }

                //Console.WriteLine($"id: {group.Id}, name: {group.Name}, year: {group.Year}");
                Console.ReadLine();

            }
        }
    }
}
