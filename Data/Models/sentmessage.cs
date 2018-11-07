using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class sentmessage
    {
        public int id { get; set; }
        public string content { get; set; }
        public Nullable<System.DateTime> dateCreated { get; set; }
        public Nullable<int> conversation_id { get; set; }
        public Nullable<int> sender_id { get; set; }
        public virtual conversation conversation { get; set; }
        public virtual user user { get; set; }
    }
}
