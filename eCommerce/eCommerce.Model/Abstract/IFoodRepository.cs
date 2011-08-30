using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eCommerce.Model;

namespace eCommerce.Model.Abstract
{
    public interface IFoodRepository
    {
        IQueryable<FOOD> Foods { get; }

        IQueryable<FOODTYPE> Types { get; }

        IQueryable<ORDER> Orders { get; }
    }
}
