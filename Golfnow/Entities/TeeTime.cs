using System;
using System.Runtime.CompilerServices;
using Golfnow.ViewModels;

namespace Golfnow.Entities
{
    public class TeeTime
    {
        public DateTime? StartsAt { get; set; }
        public Course Course { get; set; }
        
        public TeeTime (DateTime startAt, Course course)
        {
            StartsAt = startAt;
            Course = course;
        }

        public TeeTimeEntryViewModel ToViewModel()
        {
            return new TeeTimeEntryViewModel(this);
        }
    }
}
