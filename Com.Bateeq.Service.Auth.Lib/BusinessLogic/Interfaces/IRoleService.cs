using Com.Bateeq.Service.Auth.Lib.Models;
using Com.Bateeq.Service.Auth.Lib.Utilities.BaseInterface;
using Com.Bateeq.Service.Auth.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Bateeq.Service.Auth.Lib.BusinessLogic.Interfaces
{
    public interface IRoleService : IBaseService<Role>
    {
        bool CheckDuplicate(int id, string code);
    }
}
