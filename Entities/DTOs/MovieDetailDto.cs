using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class MovieDetailDto:IDto
    {
        public string BackdropPath { get; set; }
        public long MovieId { get; set; }
        public string Title { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public double VoteAverage { get; set; }
        public int Point { get; set; }
        public string Note { get; set; }
    }
}
