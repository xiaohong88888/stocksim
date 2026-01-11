using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace DuendeIS;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource(
                name:"myuserroles",
                userClaims: new[] {
                    JwtClaimTypes.Role
                    })
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("stocksim.priceapi.read"),
            new ApiScope("stocksim.priceapi.write"),
            new ApiScope("stocksim.tradeapi")
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            // m2m client credentials flow client
            new Client
            {
                ClientId = "postman.client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("eenpostmangeheim".Sha256()) },

                AllowedScopes = { "stocksim.priceapi.read" }
            },
            // stockapi client
            new Client
            {
                ClientId = "stockapi.client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("eenstockapigeheim".Sha256()) },

                AllowedScopes = { "stocksim.priceapi.read", "stocksim.priceapi.write" , "stocksim.tradeapi" }
            },
            // frontend client
            new Client
            {
                ClientId = "stocksim.frontend",
                AllowedGrantTypes = GrantTypes.Code,
                ClientSecrets = {new Secret("eenfrontendgeheim".Sha256())},
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "stocksim.priceapi.read",
                    "stocksim.priceapi.write",
                    "stocksim.tradeapi",
                    "myuserroles"
                },
                RedirectUris = { "http://localhost:5173/" },
                PostLogoutRedirectUris = { "http://localhost:5173/" },
                AllowedCorsOrigins = { "http://localhost:5173" },
            }
        };
}
