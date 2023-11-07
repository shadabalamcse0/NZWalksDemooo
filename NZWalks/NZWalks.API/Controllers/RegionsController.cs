﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.Dto;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext dbContext , IRegionRepository regionRepository ,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get Data from database - domain  models
            var regionsDomain = await regionRepository.GetAllAsync();
            
            //return Dto
            return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task <IActionResult> GetById([FromRoute] Guid id)
        {
            var regionDomain = await regionRepository.GetByIdAsync(id);
            if(regionDomain==null)
            {
                return NotFound();
            }
            //Return DTo back to client
            return Ok(mapper.Map<RegionDto>(regionDomain));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            
            
                //Map or convert  DTO to Domain Model
                var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

                //Use Domain Model  tocreate Region
                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

                //Map  Domainmodel back to  Dto
                var regionDto = mapper.Map<RegionDto>(regionDomainModel);

                return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
           
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task< IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            
                //Map  DTO to Domain Model
                var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);


                //Check  if region exists
                regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

                if(regionDomainModel == null)
                {
                    return NotFound();
                }

                return Ok(mapper.Map<RegionDto>(regionDomainModel));
           
           
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task< IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);
            if(regionDomainModel==null)
            {
                return NotFound();
            }


            //return deleted  Region  back
            //map Domain Model to  Dto

            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }
    }
}
