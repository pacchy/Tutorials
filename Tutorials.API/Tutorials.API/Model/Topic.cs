using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorials.API.Model
{
    public class Topic
    {
        public Topic()
        {
            Tutorials = new List<Tutorial>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public List<Tutorial> Tutorials;

        public TimeSpan Duration 
        {
            get 
            {
                TimeSpan duration = Tutorials.Aggregate(TimeSpan.Zero, (sumSofar, nextObject) => sumSofar + nextObject.Duration);
                if (duration.TotalSeconds < 0) return TimeSpan.Zero;
                return duration;
            }
        }
    }
}
