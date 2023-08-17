using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace SPID.AspNetCore.Authentication.Services
{
    public class DefaultIdpNameRetriever : IIdpNameRetriever
    {
        private readonly ILogger _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DefaultIdpNameRetriever(ILogger<DefaultIdpNameRetriever> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GetIdpName()
        {
            _httpContextAccessor.HttpContext.Request.Query.TryGetValue("idpName", out var idpName);
            if (_httpContextAccessor.HttpContext.Request.HasFormContentType && StringValues.IsNullOrEmpty(idpName))
                _httpContextAccessor.HttpContext.Request.Form.TryGetValue("idpName", out idpName);
                
            return await Task<string>.Run(() =>
            {
                return StringValues.IsNullOrEmpty(idpName) ? "" : (string)idpName;
            });
        }
    }
}