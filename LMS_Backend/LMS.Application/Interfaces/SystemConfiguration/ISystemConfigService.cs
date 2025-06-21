using LMS_Backend.LMS.Domain.Entities;

namespace LMS_Backend.LMS.Application.Interfaces.SystemConfiguration
{
    public interface ISystemConfigService
    {
        public Task<string?> GetConfigValueByKeyAsync(string key);
        public Task<decimal> GetPenaltyPerDayAsync();
        public Task<int> GetMaxBorrowPeriodAsync();
        public Task<int> GetMaxBorrowLimitAsync();
        public Task<IEnumerable<SystemConfig>> GetAllConfigsAsync();
        public Task UpdateSystemConfigAsync(SystemConfig config, int updatedBy);
    }
}