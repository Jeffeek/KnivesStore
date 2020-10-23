using KnivesStore.DAL.DataAccessors.DB.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace KnivesStore.PL.Extensions
{
    public static class UnitOfWorkServiceProvider
    {
        public static void AddUnitOfWorkAndRepository(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, KnivesDbUnitOfWork>();
        }
    }
}
