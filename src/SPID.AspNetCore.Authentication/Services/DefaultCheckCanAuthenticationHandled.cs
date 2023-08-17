using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SPID.AspNetCore.Authentication.Services
{
  public class DefaultCheckCanAuthenticationHandled : ICheckCanAuthenticationHandled
  {
    public DefaultCheckCanAuthenticationHandled()
    {
    }

    public async Task<bool> CanIHandle() {
      return await Task<bool>.Run(() => { return true; });
    }
  }  
}