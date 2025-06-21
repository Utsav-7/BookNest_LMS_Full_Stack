using AutoMapper;
using LMS_Backend.LMS.Application.Interfaces.SystemConfiguration;
using LMS_Backend.LMS.Common.Exceptions;
using LMS_Backend.LMS.Domain.Entities;
using LMS_Backend.LMS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LMS_Backend.LMS.Infrastructure.Repository
{
    public class SystemConfigRepository : GenericRepository<SystemConfig>, ISystemConfigRepository
    {
        private readonly IMapper _mapper;

        public SystemConfigRepository(ApplicationDBContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<SystemConfig>> GetAllConfigsQuery()
        {
            return await _context.SystemConfigs
                .AsNoTracking()
                .Select(s => new SystemConfig
                {
                    ConfigId = s.ConfigId,
                    ConfigKey = s.ConfigKey,
                    ConfigValue = s.ConfigValue,
                    Description = s.Description
                })
                .ToListAsync();
        }

        public async Task<string?> GetConfigValueByKeyQuery(string key)
        {
            var config = await _context.SystemConfigs
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.ConfigKey == key);

            return config?.ConfigValue;
        }

        public async Task<int> GetMaxBorrowLimitQuery()
        {
            var config = await _context.SystemConfigs
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.ConfigKey == "MaxBorrowLimit");

            return config != null && int.TryParse(config.ConfigValue, out var result)
                ? result
                : 0;
        }

        public async Task<int> GetMaxBorrowPeriodQuery()
        {
            var config = await _context.SystemConfigs
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.ConfigKey == "MaxBorrowPeriod");

            return config != null && int.TryParse(config.ConfigValue, out var result)
                ? result
                : 0;
        }

        public async Task<decimal> GetPenaltyPerDayQuery()
        {
            var config = await _context.SystemConfigs
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.ConfigKey == "PenaltyPerDay");

            return config != null && decimal.TryParse(config.ConfigValue, out var result)
                ? result
                : 0;
        }

        public async Task UpdateSystemConfigQuery(SystemConfig updatedConfig, int updatedBy)
        {
            var existingConfig = await _context.SystemConfigs
                .FirstOrDefaultAsync(c => c.ConfigKey == updatedConfig.ConfigKey);

            if (existingConfig is null)
                throw new KeyNotFoundException($"System config with ID {updatedConfig.ConfigId} not found.");

            _mapper.Map(updatedConfig, existingConfig);
            existingConfig.ConfigValue = updatedConfig.ConfigValue;
            existingConfig.UpdatedBy = updatedBy;
            existingConfig.UpdatedAt = DateTime.UtcNow;

            _context.SystemConfigs.Update(existingConfig);
            await _context.SaveChangesAsync();
        }
    }
}
