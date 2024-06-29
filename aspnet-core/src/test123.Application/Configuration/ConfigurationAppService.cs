using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using test123.Configuration.Dto;

namespace test123.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : test123AppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
