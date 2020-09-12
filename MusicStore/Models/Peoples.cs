using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Models
{
    public class Peoples
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Years { get; set; }

        public int StateId { get; set; }
        public virtual States State { get; set; } 
    }
}
