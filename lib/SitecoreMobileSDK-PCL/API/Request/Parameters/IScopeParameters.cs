namespace Sitecore.MobileSDK.API.Request.Parameters
{
    using System.Collections.Generic;
    using Sitecore.MobileSDK.UrlBuilder.QueryParameters;

    public interface IScopeParameters
  {
    IScopeParameters ShallowCopyScopeParametersInterface();
    IEnumerable<ScopeType> OrderedScopeSequence { get; }


    bool ParentScopeIsSet   { get; }
    bool SelfScopeIsSet     { get; }
    bool ChildrenScopeIsSet { get; }
  }
}
