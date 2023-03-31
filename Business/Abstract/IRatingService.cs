﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRatingService
    {
        IResult Add(Rating rating);
        IResult Update(Rating rating);
        IResult Delete(Rating rating);
    }
}
