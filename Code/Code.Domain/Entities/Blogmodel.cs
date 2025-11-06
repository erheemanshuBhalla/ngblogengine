using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Domain.Entities
{
    public class Blogmodel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Isactive { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Addedby { get; set; } = string.Empty;

        public List<Tagsmodel> Tags { get; set; } = new List<Tagsmodel>();
    }
}
