using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Newtonsoft.Json;

namespace WebAPI
{
    public class MovieResult
    {
        [JsonProperty("results")]
        public IEnumerable<Movie> Results { get; set; }
    }
}
