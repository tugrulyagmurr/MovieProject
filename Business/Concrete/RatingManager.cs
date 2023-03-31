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

namespace Business.Concrete
{
    public class RatingManager:IRatingService
    {
        private IRatingDal _ratingDal;

        public RatingManager(IRatingDal ratingDal)
        {
            _ratingDal = ratingDal;
        }

        public IResult Add(Rating rating)
        {
            if (rating.Point>=1 && rating.Point<=10 )
            {
                return new ErrorDataResult(Messages.RatingPointCanNotAdded);
            }

            _ratingDal.Add(rating);
            return new SuccessResult(Messages.RatingAdded);
        }

        public IResult Update(Rating rating)
        {
            _ratingDal.Update(rating);
           return new SuccessResult(Messages.RatingUpdated);
        }

        public IResult Delete(Rating rating)
        {
            _ratingDal.Update(rating);
            return new SuccessResult(Messages.RatingDeleted);
        }
    }
}
