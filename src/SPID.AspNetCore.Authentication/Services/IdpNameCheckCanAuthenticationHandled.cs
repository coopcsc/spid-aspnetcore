using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SPID.AspNetCore.Authentication.Services
{
    public class IdpNameCheckCanAuthenticationHandled : ICheckCanAuthenticationHandled
    {
        private readonly IIdpNameRetriever _nameRetriever;

        public IdpNameCheckCanAuthenticationHandled(IIdpNameRetriever nameRetriever)
        {
            _nameRetriever = nameRetriever;
        }

        public async Task<bool> CanIHandle()
        {
            return !String.IsNullOrEmpty(await _nameRetriever.GetIdpName());
        }
    }
}