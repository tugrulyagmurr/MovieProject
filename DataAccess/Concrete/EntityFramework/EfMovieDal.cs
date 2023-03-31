using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMovieDal:EfEntityRepositoryBase<Movie,MovieContext>,IMovieDal
    {
        public List<MovieDetailDto> GetMovieDetails()
        {
            using (MovieContext context=new MovieContext())
            {
                var result = from m in context.Movies
                    join r in context.Ratings 
                        on m.Id equals r.Id
                    select new MovieDetailDto
                    {
                        Title = m.Title, BackdropPath = m.BackdropPath, OriginalLanguage = m.OriginalLanguage,
                        Overview = m.Overview, PosterPath = m.PosterPath, ReleaseDate = m.ReleaseDate,
                        Note = r.Note, Point = r.Point
                    };
                return result.ToList();
            }
        }
    }
}
