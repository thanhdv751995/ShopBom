using ShopBom.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ShopBom.Permissions
{
    public class ShopBomPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ShopBomPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(ShopBomPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ShopBomResource>(name);
        }
    }
}
