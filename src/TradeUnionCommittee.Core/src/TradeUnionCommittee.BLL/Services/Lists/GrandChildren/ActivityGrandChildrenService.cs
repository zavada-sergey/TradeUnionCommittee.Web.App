﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeUnionCommittee.BLL.ActualResults;
using TradeUnionCommittee.BLL.DTO.GrandChildren;
using TradeUnionCommittee.BLL.Enums;
using TradeUnionCommittee.BLL.Helpers;
using TradeUnionCommittee.BLL.Interfaces.Lists.GrandChildren;
using TradeUnionCommittee.DAL.EF;
using TradeUnionCommittee.DAL.Entities;

namespace TradeUnionCommittee.BLL.Services.Lists.GrandChildren
{
    internal class ActivityGrandChildrenService : IActivityGrandChildrenService
    {
        private readonly TradeUnionCommitteeContext _context;
        private readonly IMapper _mapper;

        public ActivityGrandChildrenService(TradeUnionCommitteeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActualResult<IEnumerable<ActivityGrandChildrenDTO>>> GetAllAsync(string hashIdGrandChildren)
        {
            try
            {
                var id = HashHelper.DecryptLong(hashIdGrandChildren);
                var activity = await _context.ActivityGrandChildrens
                    .Include(x => x.IdActivitiesNavigation)
                    .Where(x => x.IdGrandChildren == id)
                    .OrderByDescending(x => x.DateEvent)
                    .ToListAsync();
                var result = _mapper.Map<IEnumerable<ActivityGrandChildrenDTO>>(activity);
                return new ActualResult<IEnumerable<ActivityGrandChildrenDTO>> { Result = result };
            }
            catch (Exception exception)
            {
                return new ActualResult<IEnumerable<ActivityGrandChildrenDTO>>(DescriptionExceptionHelper.GetDescriptionError(exception));
            }
        }

        public async Task<ActualResult<ActivityGrandChildrenDTO>> GetAsync(string hashId)
        {
            try
            {
                var id = HashHelper.DecryptLong(hashId);
                var activity = await _context.ActivityGrandChildrens
                    .Include(x => x.IdActivitiesNavigation)
                    .FirstOrDefaultAsync(x => x.Id == id);
                if (activity == null)
                {
                    return new ActualResult<ActivityGrandChildrenDTO>(Errors.TupleDeleted);
                }
                var result = _mapper.Map<ActivityGrandChildrenDTO>(activity);
                return new ActualResult<ActivityGrandChildrenDTO> { Result = result };
            }
            catch (Exception exception)
            {
                return new ActualResult<ActivityGrandChildrenDTO>(DescriptionExceptionHelper.GetDescriptionError(exception));
            }
        }

        public async Task<ActualResult<string>> CreateAsync(ActivityGrandChildrenDTO item)
        {
            try
            {
                var activityGrandChildren = _mapper.Map<ActivityGrandChildrens>(item);
                await _context.ActivityGrandChildrens.AddAsync(activityGrandChildren);
                await _context.SaveChangesAsync();
                var hashId = HashHelper.EncryptLong(activityGrandChildren.Id);
                return new ActualResult<string> { Result = hashId };
            }
            catch (Exception exception)
            {
                return new ActualResult<string>(DescriptionExceptionHelper.GetDescriptionError(exception));
            }
        }

        public async Task<ActualResult> UpdateAsync(ActivityGrandChildrenDTO item)
        {
            try
            {
                _context.Entry(_mapper.Map<ActivityGrandChildrens>(item)).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return new ActualResult();
            }
            catch (Exception exception)
            {
                return new ActualResult(DescriptionExceptionHelper.GetDescriptionError(exception));
            }
        }

        public async Task<ActualResult> DeleteAsync(string hashId)
        {
            try
            {
                var id = HashHelper.DecryptLong(hashId);
                var result = await _context.ActivityGrandChildrens.FindAsync(id);
                if (result != null)
                {
                    _context.ActivityGrandChildrens.Remove(result);
                    await _context.SaveChangesAsync();
                }
                return new ActualResult();
            }
            catch (Exception exception)
            {
                return new ActualResult(DescriptionExceptionHelper.GetDescriptionError(exception));
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}