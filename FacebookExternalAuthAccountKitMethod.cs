﻿using System.Web.Routing;
using Nop.Core.Plugins;
using Nop.Services.Authentication.External;
using Nop.Services.Configuration;

namespace Nop.Plugin.ExternalAuth.FacebookAccountKit
{
    /// <summary>
    /// Facebook account kit externalAuth processor
    /// </summary>
    public class FacebookExternalAuthAccountKitMethod:BasePlugin, IExternalAuthenticationMethod
    {
        #region Fields

        private readonly ISettingService _settingService;

        #endregion

        #region Ctor

        public FacebookExternalAuthAccountKitMethod(ISettingService settingService)
        {
            _settingService = settingService;
        }

        #endregion

        #region Method


        /// <summary>
        /// Gets a route for provider configuration
        /// </summary>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        public void GetConfigurationRoute(out string actionName, out string controllerName,
            out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "ExternalAuthFacebookAccountKit";
            routeValues = new RouteValueDictionary
            {
                {"Namespaces", "Nop.Plugin.ExternalAuth.FacebookAccountKit.Controllers"},
                {"area", null}
            };
        }

        /// <summary>
        /// Gets a route for displaying plugin in public store
        /// </summary>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        public void GetPublicInfoRoute(out string actionName, out string controllerName,
            out RouteValueDictionary routeValues)
        {
            actionName = "PublicInfo";
            controllerName = "ExternalAuthFacebookAccountKit";
            routeValues = new RouteValueDictionary
            {
                {"Namespaces", "Nop.Plugin.ExternalAuth.FacebookAccountKit.Controllers"},
                {"area", null}
            };
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            //settings
            var settings = new FacebookExternalAuthAccountKitSettings
            {
                FacebookAppId = 123
            };
            _settingService.SaveSetting(settings);

            //locales
            //this.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.Facebook.Login", "Login using Facebook account");
            //this.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.Facebook.ClientKeyIdentifier", "App ID/API Key");
            //this.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.Facebook.ClientKeyIdentifier.Hint",
            //    "Enter your app ID/API key here. You can find it on your FaceBook application page.");
            //this.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.Facebook.ClientSecret", "App Secret");
            //this.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.Facebook.ClientSecret.Hint",
            //    "Enter your app secret here. You can find it on your FaceBook application page.");

            base.Install();
        }

        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<FacebookExternalAuthAccountKitSettings>();

            //locales
            //this.DeletePluginLocaleResource("Plugins.ExternalAuth.Facebook.Login");
            //this.DeletePluginLocaleResource("Plugins.ExternalAuth.Facebook.ClientKeyIdentifier");
            //this.DeletePluginLocaleResource("Plugins.ExternalAuth.Facebook.ClientKeyIdentifier.Hint");
            //this.DeletePluginLocaleResource("Plugins.ExternalAuth.Facebook.ClientSecret");
            //this.DeletePluginLocaleResource("Plugins.ExternalAuth.Facebook.ClientSecret.Hint");

            base.Uninstall();
        }

        #endregion

    }
}
