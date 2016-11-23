﻿namespace Sitecore.Feature.Accounts.Attributes
{
  using System.Web.Mvc;
  using Sitecore.Feature.Accounts.Contracts.Services;
  using Sitecore.Foundation.SitecoreExtensions.Extensions;

  public class AccountsRedirectAuthenticatedAttribute : RedirectAuthenticatedAttribute
  {
    private readonly IAccountsSettingsService accountsSettingsService;

    public AccountsRedirectAuthenticatedAttribute(IAccountsSettingsService accountsSettingsService)
    {
      this.accountsSettingsService = accountsSettingsService;
    }

    public AccountsRedirectAuthenticatedAttribute()
    {
        this.accountsSettingsService = (IAccountsSettingsService)Sitecore.DependencyInjection.ServiceLocator.ServiceProvider.GetService(typeof(IAccountsSettingsService));
    }

    protected override string GetRedirectUrl(ActionExecutingContext filterContext)
    {
      return this.accountsSettingsService.GetPageLinkOrDefault(Context.Item, Templates.AccountsSettings.Fields.AfterLoginPage, Context.Site.GetRootItem());
    }
  }
}