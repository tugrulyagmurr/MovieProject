using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class MovieManager:IMovieService
    {
        IMovieDal _movieDal;

        public MovieManager(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }

        public IDataResult<List<Movie>> GetAll()
        {
            //İş kodları 
            //Yetkisi var mı

            return new SuccessDataResult<List<Movie>>(_movieDal.GetAll(), Messages.MoviesListed);
        }

        public IDataResult<Movie> GetById(long id)
        {
            return new SuccessDataResult<Movie>(_movieDal.Get(m => m.Id == id),Messages.MoviesListed);
        }

        public IDataResult<List<MovieDetailDto>> GetMovieDetails()
        {
            return new SuccessDataResult<List<MovieDetailDto>>(_movieDal.GetMovieDetails(),Messages.MoviesListed) ;
        }
    }
}
