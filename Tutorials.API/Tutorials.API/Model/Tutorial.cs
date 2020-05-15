using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorials.API.Model
{
    public class Tutorial
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        public TutorialType TutorialType { get; set; }

        public TimeSpan Duration { get; set; }

        public Uri Uri { get; set; }

        public string Description { get; set; }

    }
}
