using Core.Entities;
using Core.Utilities.Encryption;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.JWT
{
    public class JwtHelper :ITokenHelper
    { 
        private readonly TokenOptions _tokenOptions;
        //token test 01:14
        public JwtHelper(TokenOptions tokenOptions)
        {
            _tokenOptions = tokenOptions;
        }



        //jwt yi create edecek ve geriye döndürecek class 41.dk
        public AccessToken CreateToken(BaseUser user)
        {
            //özellikleri oku ve tokeni yaz.
            DateTime expirationTime = DateTime.Now.AddMinutes(_tokenOptions.ExpirationTime);
            SecurityKey key = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                claims: null,
                notBefore: DateTime.Now,
                expires: expirationTime,
                signingCredentials: signingCredentials);
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            string jwtToken =  jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken() { Token = jwtToken, ExpirationDate = expirationTime };
        }
    }
}
