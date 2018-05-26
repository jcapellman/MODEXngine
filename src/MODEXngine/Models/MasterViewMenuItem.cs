using System;

namespace MODEXngine.Models
{
    public class MasterViewMenuItem
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}