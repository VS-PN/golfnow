using System;
using System.IO;
using System.Text;
using Golfnow.Entities;

namespace Golfnow.ViewModels
{
    /// <summary>
    /// This ViewModel is used to display directly details about TeeTimes as string props in UI.
    /// </summary>
    public class TeeTimeEntryViewModel
    {
        public string StartsAt { get; set; }
        public string CourseDescription { get; set; }
        public TeeTime Entry { get; set; }
        public bool IsPast { get; set; }

        public TeeTimeEntryViewModel(TeeTime entry)
        {
            if (!entry.StartsAt.HasValue) throw new InvalidDataException("Error loading data into ViewModel: Missing DateTime");
            Entry = entry;
            StartsAt = DateTime.Now.Day != entry.StartsAt.Value.Day
                ? entry.StartsAt.Value.ToString("HH:mm - dd.MM.yyyy")
                : entry.StartsAt.Value.ToString("HH:mm");

            var courseDescriptionBuilder = new StringBuilder(entry.Course.Tees.ToString() + " Tees");
            if (!String.IsNullOrEmpty(entry.Course.Description)) courseDescriptionBuilder.Append(" " + entry.Course.Description);
            CourseDescription = courseDescriptionBuilder.ToString();
            if (DateTime.Now > entry.StartsAt) IsPast = true;
        }
    }
}