using AutoMapper;
using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Repository;
using KemiaBridge.Service.Interface;
using KemiaBridge.Service.Mappers;
using KemiaBridge.Service.Mappers.Profiles;

namespace KemiaBridge.Service.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository addressRepository) 
        {
            _addressRepository = addressRepository;
            _mapper = MapperConfig.GetMapper<AddressProfile>();
        }

        public async Task AddAsync(AddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            await _addressRepository.AddAsync( address );
            addressDto.setNewId(address.AddressId);
        }

        public async Task<IEnumerable<Address>> GetAllAsync()
        {
            return await _addressRepository.GetAllAsync();
        }

        public async Task<Address?> GetByIdAsync(int id)
        {
            return await _addressRepository.GetByIdAsync( id );
        }

        public async Task UpdateAsync(int id, AddressDto addressDto)
        {
            var address = await _addressRepository.GetByIdAsync( id );
            if (address == null) 
                throw new KeyNotFoundException($"Address with Id {id} not found");
            
            _mapper.Map(addressDto, address);
            await _addressRepository.UpdateAsync( address );
        }

        public async Task DeleteAsync(int id)
        {
            await _addressRepository.DeleteAsync( id );
        }
    }
}
