using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SPID.AspNetCore.Authentication.Services
{
  public interface IIdpNameRetriever
  {
    Task<string> GetIdpName();
  }  
}