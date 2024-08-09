using KemiaBridge.Infra.Data.Repository.Abstract;
using KemiaBridge.Service.Interface;

namespace KemiaBridge.Service.Validators
{
    public abstract class AddressValidator : IAddressValidator
    {
        private readonly IAddressRepository _addressRepository;

        public AddressValidator(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public bool Exists(int addressId)
        {
            if (_addressRepository.GetByIdAsync(addressId) != null)
                return true;
            return false;
        }
    }
}
