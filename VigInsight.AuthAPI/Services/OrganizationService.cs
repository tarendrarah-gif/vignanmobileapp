using System.Threading.Tasks;
using VigInsight.Core.Interfaces;
using VigInsight.Core.Models;
using System.Collections.Generic;

namespace VigInsight.AuthAPI.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<int> AddOrganizationAsync(OrganizationModel organization)
        {
            return await _organizationRepository.InsertOrganizationAsync(organization);
        }

        public async Task<IEnumerable<OrganizationModel>> GetAllOrganizationsAsync()
        {
            return await _organizationRepository.GetAllOrganizationsAsync();
        }
    }
}
