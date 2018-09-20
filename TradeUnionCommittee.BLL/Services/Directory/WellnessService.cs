﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeUnionCommittee.BLL.BL;
using TradeUnionCommittee.BLL.DTO;
using TradeUnionCommittee.BLL.Interfaces.Directory;
using TradeUnionCommittee.BLL.Utilities;
using TradeUnionCommittee.Common.ActualResults;
using TradeUnionCommittee.Common.Enums;
using TradeUnionCommittee.DAL.Entities;
using TradeUnionCommittee.DAL.Interfaces;

namespace TradeUnionCommittee.BLL.Services.Directory
{
    public class WellnessService : IWellnessService
    {
        private readonly IUnitOfWork _database;
        private readonly IAutoMapperUtilities _mapperService;
        private readonly ICheckerService _checkerService;

        public WellnessService(IUnitOfWork database, IAutoMapperUtilities mapperService, ICheckerService checkerService)
        {
            _database = database;
            _mapperService = mapperService;
            _checkerService = checkerService;
        }

        public async Task<ActualResult<IEnumerable<WellnessDTO>>> GetAllAsync() =>
            await Task.Run(() => _mapperService.Mapper.Map<ActualResult<IEnumerable<WellnessDTO>>>(_database.EventRepository.Find(x => x.TypeId == 2)));

        public async Task<ActualResult<WellnessDTO>> GetAsync(string hashId)
        {
            var check = await _checkerService.CheckDecryptAndTupleInDbWithId(hashId, Enums.Services.Wellness);
            return check.IsValid
                ? _mapperService.Mapper.Map<ActualResult<WellnessDTO>>(_database.EventRepository.Get(check.Result))
                : new ActualResult<WellnessDTO>(check.ErrorsList);
        }

        public async Task<ActualResult> CreateAsync(WellnessDTO dto)
        {
            if (!await CheckNameAsync(dto.Name))
            {
                _database.EventRepository.Create(_mapperService.Mapper.Map<Event>(dto));
                return _mapperService.Mapper.Map<ActualResult>(await _database.SaveAsync());
            }
            return new ActualResult(Errors.DuplicateData);
        }

        public async Task<ActualResult> UpdateAsync(WellnessDTO dto)
        {
            var check = await _checkerService.CheckDecryptAndTupleInDbWithId(dto.HashId, Enums.Services.Wellness);
            if (check.IsValid)
            {
                if (!await CheckNameAsync(dto.Name))
                {
                    _database.EventRepository.Update(_mapperService.Mapper.Map<Event>(dto));
                    return _mapperService.Mapper.Map<ActualResult>(await _database.SaveAsync());
                }
                return new ActualResult(Errors.DuplicateData);
            }
            return new ActualResult(check.ErrorsList);
        }

        public async Task<ActualResult> DeleteAsync(string hashId)
        {
            var check = await _checkerService.CheckDecryptAndTupleInDbWithId(hashId, Enums.Services.Wellness, false);
            if (check.IsValid)
            {
                _database.EventRepository.Delete(check.Result);
                return _mapperService.Mapper.Map<ActualResult>(await _database.SaveAsync());
            }
            return new ActualResult(check.ErrorsList);
        }

        public async Task<bool> CheckNameAsync(string name) =>
            await Task.Run(() => _database.EventRepository.Find(p => p.Name == name).Result.Any());

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}