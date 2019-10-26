using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using helpmeal.Models;

namespace helpmeal.Services.UnitService
{
    public interface IUnitService
    {
        List<Unit> FindAll();
        Unit FindUnitByName(string ingredient_unit);
    }
}
