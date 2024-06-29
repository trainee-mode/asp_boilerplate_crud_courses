using System.Threading.Tasks;
using test123.Configuration.Dto;

namespace test123.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
