using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IMovieService
    {
        IDataResult<List<Movie>> GetAll();
        IDataResult<Movie> GetById(long movieId);
        IDataResult<List<MovieDetailDto>> GetMovieDetails();
    }
}
