using LMS_Backend.LMS.Application.Interfaces.SystemConfiguration;
using LMS_Backend.LMS.Domain.Entities;

namespace LMS_Backend.LMS.Application.Services
{
    public class SystemConfigService : ISystemConfigService
    {
        private readonly ISystemConfigRepository _systemConfigRepository;

        public SystemConfigService(ISystemConfigRepository systemConfigService)
        {
            _systemConfigRepository = systemConfigService;
        }

        public async Task<IEnumerable<SystemConfig>> GetAllConfigsAsync()
        {
            return await _systemConfigRepository.GetAllConfigsQuery();
        }

        public async Task<string?> GetConfigValueByKeyAsync(string key)
        {
            return await _systemConfigRepository.GetConfigValueByKeyQuery(key);
        }

        public async Task<int> GetMaxBorrowLimitAsync()
        {
            return await _systemConfigRepository.GetMaxBorrowLimitQuery();
        }

        public async Task<int> GetMaxBorrowPeriodAsync()
        {
            return await _systemConfigRepository.GetMaxBorrowPeriodQuery();
        }

        public async Task<decimal> GetPenaltyPerDayAsync()
        {
            return await _systemConfigRepository.GetPenaltyPerDayQuery();
        }

        public async Task UpdateSystemConfigAsync(SystemConfig config, int updatedBy)
        {
            await _systemConfigRepository.UpdateSystemConfigQuery(config,updatedBy);
        }
    }
}