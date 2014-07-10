﻿
namespace Sitecore.MobileSDK.UrlBuilder.QueryParameters
{
  using System.Collections.Generic;

  public interface IQueryParameters
  {
    IQueryParameters DeepCopy();

    ScopeParameters ScopeParameters{ get; }
    PayloadType? Payload { get; }
    ICollection<string> Fields {get;}
  }
}
