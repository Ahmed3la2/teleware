using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleWareAssessment.Data;

namespace TeleWare.Core.Interfaces
{
    public class AddressReposiory : IAddressReposiory
    {
        private readonly TeleWareContext _context;

        public AddressReposiory(TeleWareContext context)
        {
            _context = context;
        }

        public async Task RemoveAllAdressByEmpId(int empId)
        {
            var Address = _context.Addresses.Where(l=>l.EmployeeId == empId).ToList();
            _context.Addresses.RemoveRange(Address);
            await _context.SaveChangesAsync();
        }
    }
}
