﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExampleRepoApp.BusinessLogic.Domain;
using ExampleRepoApp.BusinessLogic.Interfaces;
using ExampleRepoApp.DataLayer.Entities;
using ExampleRepoApp.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExampleRepoApp.BusinessLogic.Services
{
    public abstract class AbstractService<TEntity, TDto> : IService<TDto>
        where TEntity : DbEntity
        where TDto : DomainObject
    {
        private readonly IRepository<TEntity> _repo;
        protected readonly IMapper Mapper;

        protected AbstractService(IRepository<TEntity> repo, IMapper mapper)
        {
            _repo = repo;
            Mapper = mapper;
        }

        public async Task<TDto> GetById(long id)
        {
            // potential 'cartesian explosion' here as using ProjectTo and not Includes:
            // https://github.com/dotnet/efcore/issues/21234
            // https://docs.microsoft.com/en-us/ef/core/querying/single-split-queries
            return await _repo.GetById(id)
                .ProjectTo<TDto>(Mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<TDto>> GetAll()
        {
            return await _repo.GetAll()
                .ProjectTo<TDto>(Mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task Delete(long id)
        {
            await _repo.Delete(id);
        }
    }
}