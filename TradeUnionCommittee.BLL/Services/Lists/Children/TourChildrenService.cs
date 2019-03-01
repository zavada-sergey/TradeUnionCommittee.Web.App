﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradeUnionCommittee.BLL.Configurations;
using TradeUnionCommittee.BLL.DTO.Children;
using TradeUnionCommittee.BLL.Interfaces.Lists.Children;
using TradeUnionCommittee.Common.ActualResults;
using TradeUnionCommittee.DAL.Interfaces;

namespace TradeUnionCommittee.BLL.Services.Lists.Children
{
    public class TourChildrenService : ITourChildrenService
    {
        private readonly IUnitOfWork _database;
        private readonly IAutoMapperConfiguration _mapperService;
        private readonly IHashIdConfiguration _hashIdUtilities;

        public TourChildrenService(IUnitOfWork database, IAutoMapperConfiguration mapperService, IHashIdConfiguration hashIdUtilities)
        {
            _database = database;
            _mapperService = mapperService;
            _hashIdUtilities = hashIdUtilities;
        }

        public Task<ActualResult<IEnumerable<TourChildrenDTO>>> GetAllAsync(string hashIdEmployee)
        {
            throw new NotImplementedException();
        }

        public Task<ActualResult<TourChildrenDTO>> GetAsync(string hashId)
        {
            throw new NotImplementedException();
        }

        public Task<ActualResult> CreateAsync(TourChildrenDTO item)
        {
            throw new NotImplementedException();
        }

        public Task<ActualResult> UpdateAsync(TourChildrenDTO item)
        {
            throw new NotImplementedException();
        }

        public Task<ActualResult> DeleteAsync(string hashId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _database.Dispose();
        }

        public Task<string> GetHashIdEmployee(string hashIdHeir)
        {
            throw new NotImplementedException();
        }
    }
}