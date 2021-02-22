using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ken.Portal.Web.Services.Users
{
    public interface IUserService
    {
        Guid GetCurrentlyLoggedInUser();
    }
}
