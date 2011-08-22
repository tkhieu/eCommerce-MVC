using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eCommerce.Model.Entities;

namespace eCommerce.Model.Abstract
{
    public interface IFoodRepository
    {
        IQueryable<Food> Foods { get; }
    }
}
