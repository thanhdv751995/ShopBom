using Volo.Abp.Settings;

namespace ShopBom.Settings
{
    public class ShopBomSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(ShopBomSettings.MySetting1));
        }
    }
}
