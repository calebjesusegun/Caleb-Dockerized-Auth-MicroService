using System;
using System.Threading.Tasks;
using Auth.API.Interface;
using Auth.API.Models;

namespace Auth.API.Interface {
    public interface IAuthenticateService {
        Task<string> RegisterUser (RegisterModel model);
    }
}