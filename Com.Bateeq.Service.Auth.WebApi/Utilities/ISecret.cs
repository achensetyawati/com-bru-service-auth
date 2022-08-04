using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Bateeq.Service.Auth.WebApi.Utilities
{
    public interface ISecret
    {
        string SecretString { get; }
    }
}
