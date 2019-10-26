using System;
using System.Collections.Generic;
using System.Linq;
using helpmeal.Models;
using Microsoft.EntityFrameworkCore;

namespace helpmeal.Services.UnitService
{
    public class UnitService : IUnitService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UnitService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public List<Unit> FindAll()
        {
            List<Unit> results = applicationDbContext.Units.ToList();
            return results;
        }

        public Unit FindUnitByName(string ingredient_unit)
        {
            Unit unit = applicationDbContext.Units
                .FirstOrDefault(t => t.Name.Equals(ingredient_unit));
            return unit;
        }
    }
}

