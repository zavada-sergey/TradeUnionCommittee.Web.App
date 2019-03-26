﻿using TradeUnionCommittee.DAL.EF;
using TradeUnionCommittee.DAL.Entities;

namespace TradeUnionCommittee.DAL.Repositories.General
{
    public class FamilyRepository : Repository<Family>
    {
        public FamilyRepository(TradeUnionCommitteeContext db) : base(db)
        {
        }
    }
}