using System;
namespace Golfnow.Entities
{
    public class Course
    {
        public Course(int tees, string description = null)
        {
            Tees = tees;
            Description = description;
        }

        public int Tees { get; set; }
        public string Description { get; set; }
    }
}
