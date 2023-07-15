using System;

#nullable disable

namespace basecs.Models
{
    public partial class LogDto
    {
        public Guid LogId { get; set; }

        public string Message { get; set; }

        public string Request { get; set; }

        public string Method { get; set; }

        public int? Response { get; set; }

        public Guid UserAddedId { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
