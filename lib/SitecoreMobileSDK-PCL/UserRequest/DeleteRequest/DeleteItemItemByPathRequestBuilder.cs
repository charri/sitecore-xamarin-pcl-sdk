﻿namespace Sitecore.MobileSDK.UserRequest.DeleteRequest
{
  using Sitecore.MobileSDK.API.Request;
  using Sitecore.MobileSDK.Items.Delete;
  using Sitecore.MobileSDK.UrlBuilder.DeleteItem;
  using Sitecore.MobileSDK.Validators;

  public class DeleteItemItemByPathRequestBuilder : AbstractDeleteItemRequestBuilder<IDeleteItemsByPathRequest>
  {
    private string itemPath;

    public DeleteItemItemByPathRequestBuilder(string itemPath)
    {
      ItemPathValidator.ValidateItemPath(itemPath);
      this.itemPath = itemPath;
    }

    public override IDeleteItemsByPathRequest Build()
    {
      return new DeleteItemByPathParameters(null, this.scopeParameters, this.database, this.itemPath);
    }
  }
}
