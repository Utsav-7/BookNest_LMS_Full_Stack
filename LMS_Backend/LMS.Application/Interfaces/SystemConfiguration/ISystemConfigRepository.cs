
using LMS_Backend.LMS.Domain.Entities;

namespace LMS_Backend.LMS.Application.Interfaces.SystemConfiguration
{
    public interface ISystemConfigRepository
    {
        public Task<string?> GetConfigValueByKeyQuery(string key);
        public Task<decimal> GetPenaltyPerDayQuery();
        public Task<int> GetMaxBorrowPeriodQuery();
        public Task<int> GetMaxBorrowLimitQuery();
        public Task<IEnumerable<SystemConfig>> GetAllConfigsQuery();
        public Task UpdateSystemConfigQuery(SystemConfig config, int updatedBy);
    }
}