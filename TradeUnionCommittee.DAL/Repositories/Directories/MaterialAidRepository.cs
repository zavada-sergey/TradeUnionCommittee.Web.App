﻿using TradeUnionCommittee.DAL.EF;
using TradeUnionCommittee.DAL.Entities;

namespace TradeUnionCommittee.DAL.Repositories.Directories
{
    public class MaterialAidRepository : Repository<MaterialAid>
    {
        public MaterialAidRepository(TradeUnionCommitteeContext db) : base(db)
        {
        }
    }
}