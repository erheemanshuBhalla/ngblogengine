using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Domain.Entities
{
    public class Tagsmodel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Isactive { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Addedby { get; set; } = string.Empty; 
    }
}
