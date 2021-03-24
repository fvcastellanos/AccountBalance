using System;
using System.Collections.Generic;
using System.Linq;
using AccountBalance.Domain;
using AccountBalance.Model;
using LanguageExt;
using Microsoft.Extensions.Logging;

namespace AccountBalance.Services
{
    public class ProviderService
    {
        private const string DefaultTenant = "default";

        private readonly ILogger _logger;
        private readonly BalanceContext _dbContext;

        public ProviderService(ILogger<ProviderService> logger, BalanceContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public Either<string, IEnumerable<ProviderView>> GetProviders(int top = 30, string name = "", string country = "GT")
        {
            try
            {
                _logger.LogInformation($"get top: {top} provider for tenant: {DefaultTenant}");

                return _dbContext.Providers
                    .Where(provider => provider.Tenant.Equals(DefaultTenant)
                        && provider.Name.Contains(name)
                        && provider.Country.Contains(country))
                    .Select(ToView)
                    .Take(top)
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"can't get provider list for tenant: {DefaultTenant} - ", ex.Message);
                return "Can't get Provider list";
            }
        }

        public Either<string, ProviderView> Add(ProviderView view)
        {
            try
            {
                _logger.LogInformation($"add provider with name: {view.Name} for tenant: {DefaultTenant}");
                var provider = ToModel(view);
                _dbContext.Providers.Add(provider);
                _dbContext.SaveChanges();

                view.Id = provider.Id;

                return view;
            }
            catch (Exception ex)
            {
                _logger.LogError($"can't add provider with name: {view.Name} - ", ex.Message);
                return "Can't add Provider";
            }
        }

        public Either<string, ProviderView> Update(ProviderView view)
        {
            try
            {
                _logger.LogInformation($"update provider: {view.Name} for tenant: {DefaultTenant}");

                var provider = _dbContext.Providers.Find(view.Id);

                if (provider == null)
                {
                    return $"Provider: {view.Name} not found";
                }

                provider.Name = view.Name;
                provider.Country = view.Country;

                _dbContext.Providers.Update(provider);
                _dbContext.SaveChanges();

                return view;
            }
            catch (Exception ex)
            {
                _logger.LogError($"can't update provider: {view.Name} - ", ex.Message);
                return $"Can't update Provider: {view.Name}";
            }

        }

        // --------------------------------------------------------------------------------------------------

        private static ProviderView ToView(Provider provider)
        {
            return new ProviderView()
            {
                Id = provider.Id,
                Name = provider.Name,
                Country = provider.Country
            };
        }

        private static Provider ToModel(ProviderView providerView)
        {
            return new Provider()
            {
                Country = providerView.Country,
                Name = providerView.Name,
                Tenant = DefaultTenant
            };
        }
    }
}