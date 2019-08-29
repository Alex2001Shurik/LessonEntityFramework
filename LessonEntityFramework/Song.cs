using System;


namespace LessonEntityFramework
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
    }
}
