﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using TradeUnionCommittee.BLL.DTO;
using TradeUnionCommittee.BLL.Enums;
using TradeUnionCommittee.BLL.Interfaces.Directory;
using TradeUnionCommittee.BLL.Interfaces.SystemAudit;
using TradeUnionCommittee.ViewModels.ViewModels;

namespace TradeUnionCommittee.Web.Api.Controllers.Directory
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivilegesController : ControllerBase
    {
        private readonly IPrivilegesService _services;
        private readonly ISystemAuditService _systemAuditService;
        private readonly IMapper _mapper;

        public PrivilegesController(IPrivilegesService services, ISystemAuditService systemAuditService, IMapper mapper)
        {
            _services = services;
            _systemAuditService = systemAuditService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles = "Admin,Accountant", AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _services.GetAllAsync());
        }

        [HttpGet]
        [Route("Get/{id}")]
        [Authorize(Roles = "Admin,Accountant", AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Get([Required] string id)
        {
            var result = await _services.GetAsync(id);
            if (result.IsValid)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Route("Create")]
        [Authorize(Roles = "Admin,Accountant", AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Create([FromBody] CreatePrivilegesViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.CreateAsync(_mapper.Map<DirectoryDTO>(vm));
                if (result.IsValid)
                {
                    await _systemAuditService.AuditAsync(User.Identity.Name, Operations.Insert, Tables.Privileges);
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Update")]
        [Authorize(Roles = "Admin,Accountant", AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Update([FromBody] UpdatePrivilegesViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.UpdateAsync(_mapper.Map<DirectoryDTO>(vm));
                if (result.IsValid)
                {
                    await _systemAuditService.AuditAsync(User.Identity.Name, Operations.Update, Tables.Privileges);
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Delete([Required] string id)
        {
            var result = await _services.DeleteAsync(id);
            if (result.IsValid)
            {
                await _systemAuditService.AuditAsync(User.Identity.Name, Operations.Delete, Tables.Privileges);
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        [Route("CheckName/{name}")]
        [Authorize(Roles = "Admin,Accountant", AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> CheckName([Required] string name)
        {
            return Ok(!await _services.CheckNameAsync(name));
        }
    }
}