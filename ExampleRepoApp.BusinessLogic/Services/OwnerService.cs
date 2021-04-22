using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExampleRepoApp.BusinessLogic.Domain;
using ExampleRepoApp.BusinessLogic.Interfaces;
using ExampleRepoApp.BusinessLogic.Models;
using ExampleRepoApp.DataLayer.Entities;
using ExampleRepoApp.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExampleRepoApp.BusinessLogic.Services
{
    public class OwnerService : AbstractService<ExampleOwner, Owner>, IOwnerService
    {
        private readonly IOwnerRepository _ownerRepo;
        private readonly IOwnerAddressRepository _addressRepo;

        public OwnerService(IOwnerRepository ownerRepo, IOwnerAddressRepository addressRepo, IMapper mapper)
            : base(ownerRepo, mapper)
        {
            _ownerRepo = ownerRepo;
            _addressRepo = addressRepo;
        }

        public async Task CreateOwner(CreateOwnerModel owner)
        {
            var address = new OwnerAddress
            {
                HouseNumber = owner.HouseNumber, 
                StreetName = owner.StreetName, 
                City = owner.City, 
                County = owner.County, 
                PostCode = owner.PostCode
            };
            
            var addressEntity = await _addressRepo
                .GetAddress(owner.HouseNumber, owner.StreetName, owner.City, owner.County, owner.PostCode)
                .SingleOrDefaultAsync(); 
            
            if (addressEntity == null)
            {
                addressEntity = Mapper.Map<ExampleOwnerAddress>(address);
                await _addressRepo.Add(addressEntity);
            }

            var entity = Mapper.Map<ExampleOwner>(owner);
            entity.Address = addressEntity;
            await _ownerRepo.Add(entity);
        }
        
        public async Task<ExtendedOwner> GetExtendedOwnerById(long id)
        {
            return await _ownerRepo.GetById(id)
                .ProjectTo<ExtendedOwner>(Mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<Owner> GetOwnerByEmail(string email)
        {
            return await _ownerRepo.GetOwnerByEmailAddress(email)
                .ProjectTo<Owner>(Mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }
    }
}