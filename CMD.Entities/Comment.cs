using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentMessage { get; set; }
        [Required]
        public virtual Appointment Appointment { get; set; }
    }
}
