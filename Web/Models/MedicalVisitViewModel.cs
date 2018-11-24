using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.fonts
{
    public class MedicalVisitViewModel
    {
        public int id { get; set; }
        public string description { get; set; }
        public bool medicalState { get; set; }
        public int rating { get; set; }
        public long createdAt { get; set; }

        public string des { get; set; }

    }
}