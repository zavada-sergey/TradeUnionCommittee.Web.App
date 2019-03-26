﻿using TradeUnionCommittee.DAL.EF;
using TradeUnionCommittee.DAL.Entities;

namespace TradeUnionCommittee.DAL.Repositories.Lists
{
    public class ActivityChildrensRepository : Repository<ActivityChildrens>
    {
        public ActivityChildrensRepository(TradeUnionCommitteeContext db) : base(db)
        {
        }
    }
}