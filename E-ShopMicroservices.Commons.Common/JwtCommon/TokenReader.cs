using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace E_ShopMicroservices.Commons.Common.JwtCommon
{
    public static class TokenReader
    {
        public static string ReadToken(object headerTokenValue)
        {
            var jwt = headerTokenValue.ToString();
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);
            var TokenSections = token.ToString().Split(".");
            var jsonToken = TokenSections[1];
            TokenDeserialized tokenDeserialized = JsonConvert.DeserializeObject<TokenDeserialized>(jsonToken);
            return tokenDeserialized.nameid;
        }
    }
}
