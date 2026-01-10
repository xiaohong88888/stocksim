using Duende.IdentityServer.Models;

namespace DuendeIS;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("stocksim.priceapi"),
            new ApiScope("stocksim.tradeapi"),
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            // m2m client credentials flow client
            new Client
            {
                ClientId = "m2m.client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("eengrootgeheim".Sha256()) },

                AllowedScopes = { "stocksim.priceapi", "stocksim.tradeapi" }
            },
        };
}
