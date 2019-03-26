﻿using TradeUnionCommittee.DAL.EF;
using TradeUnionCommittee.DAL.Entities;

namespace TradeUnionCommittee.DAL.Repositories.Directories
{
    public class HobbyRepository : Repository<Hobby>
    {
        public HobbyRepository(TradeUnionCommitteeContext db) : base(db)
        {
        }
    }
}