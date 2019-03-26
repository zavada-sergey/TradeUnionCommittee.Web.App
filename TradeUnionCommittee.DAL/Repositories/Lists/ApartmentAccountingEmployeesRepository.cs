﻿using TradeUnionCommittee.DAL.EF;
using TradeUnionCommittee.DAL.Entities;

namespace TradeUnionCommittee.DAL.Repositories.Lists
{
    public class ApartmentAccountingEmployeesRepository : Repository<ApartmentAccountingEmployees>
    {
        public ApartmentAccountingEmployeesRepository(TradeUnionCommitteeContext db) : base(db)
        {
        }
    }
}