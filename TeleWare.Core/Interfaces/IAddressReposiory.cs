using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleWare.Core.Interfaces
{
    public interface IAddressReposiory
    {
        Task RemoveAllAdressByEmpId(int empId);
    }
}
