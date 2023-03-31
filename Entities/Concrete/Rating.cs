using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Newtonsoft.Json;

namespace Entities.Concrete
{
    public class Rating:IEntity
    {
        public int RatingId { get; set; }
        public long Id { get; set; }
        public virtual Movie Movie { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int Point { get; set; }
        public string Note { get; set; }
        
        
    }
}
