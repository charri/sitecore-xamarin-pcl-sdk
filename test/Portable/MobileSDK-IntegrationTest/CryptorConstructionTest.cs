﻿using Sitecore.MobileSDK.SessionSettings;
using Sitecore.MobileSDK.Items;
using Sitecore.MobileSDK.PublicKey;

namespace MobileSDKIntegrationTest
{
  using NUnit.Framework;

  [TestFixture]
  public class CryptorConstructionTest
  {
    private ScTestApiSession anonymousSession;
    private ScTestApiSession authenticatedSession;
    private TestEnvironment testData;
    [SetUp]
    public void SetUp()
    {
      testData = TestEnvironment.DefaultTestEnvironment();

      SessionConfig config = new SessionConfig(testData.AuthenticatedInstanceUrl, testData.Users.Anonymous.Username, testData.Users.Anonymous.Password);
      this.anonymousSession = new ScTestApiSession(config, ItemSource.DefaultSource());

      config = new SessionConfig(testData.AuthenticatedInstanceUrl, testData.Users.Admin.Username, testData.Users.Admin.Password);
      this.authenticatedSession = new ScTestApiSession(config, ItemSource.DefaultSource());
    }

    [TearDown]
    public void TearDown()
    {
      this.anonymousSession = null;
      this.authenticatedSession = null;
    }

    [Test]
    public async void TestAnonymousSessionDoesNotFetchPublicKey()
    {
      ICredentialsHeadersCryptor cryptor = await this.anonymousSession.GetCredentialsCryptorAsyncPublic();
      Assert.NotNull(cryptor);

      Assert.AreEqual(0, this.anonymousSession.GetPublicKeyInvocationsCount);
    }


    [Test]
    public async void TestAuthenticatedSessionDownloadsPublicKey()
    {
      ICredentialsHeadersCryptor cryptor = await this.authenticatedSession.GetCredentialsCryptorAsyncPublic();
      Assert.NotNull(cryptor);

      Assert.AreEqual(1, this.authenticatedSession.GetPublicKeyInvocationsCount);
    }
  }
}

