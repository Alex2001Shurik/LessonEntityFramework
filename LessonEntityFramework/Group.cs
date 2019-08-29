using System;
using System.Collections.Generic;

namespace LessonEntityFramework
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }

        public string Type { get; set; } // Миграции(когда хотим добавить столбцы): 
        // вид-другие окна-консоль диспетчера пакетов-вводим команды "enable-migrations","add-migration AddGroupType" и "update-database"

        public virtual ICollection<Song> Songs { get; set; }
    }
}
