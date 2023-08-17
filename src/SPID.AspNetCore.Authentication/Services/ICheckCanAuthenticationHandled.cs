
using System.Threading.Tasks;

namespace SPID.AspNetCore.Authentication.Services
{
  public interface ICheckCanAuthenticationHandled
  {
    Task<bool> CanIHandle();
  }  
}