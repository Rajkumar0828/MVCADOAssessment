using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCADOAssessment.Models
{
    public class    Training
    {
        public int TrainingID { get; set; }
        public string TrainingName { get; set; }

        public string TrainingMode { get; set; }
        public string Domain { get; set; }

        public string TrainingDuration { get; set; }

        public string Location { get; set; }

    }
}