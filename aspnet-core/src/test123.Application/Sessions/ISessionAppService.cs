using System.Threading.Tasks;
using Abp.Application.Services;
using test123.Sessions.Dto;

namespace test123.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
