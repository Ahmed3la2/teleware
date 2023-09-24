using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeleWare.Core.Interfaces;
using TeleWareAssessment.Data;
using TeleWareAssessment.DTOs;
using TeleWareAssessment.Entities;

namespace TeleWare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeReposiory;
        private readonly IAddressReposiory _AddressReposiory;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeRepository employee, IMapper mapper, IAddressReposiory addressReposiory)
        {
            _employeeReposiory = employee;
            _mapper = mapper;
            _AddressReposiory = addressReposiory;
        }
        [HttpPost("addemplyee")]
        public async Task<EmployeeDTO> AddEmployee(EmployeeDTO EmployeeDTO)
        {
            var empolyee = _mapper.Map<Employee>(EmployeeDTO);
            var empToReturn = _mapper.Map<EmployeeDTO>(await _employeeReposiory.AddEmployeeAsync(empolyee));
            return empToReturn;
        }

        [HttpGet]
        public async Task<List<EmployeeDTO>> GetAllEmpolyee()
        {
            var x = _mapper.Map<List<EmployeeDTO>>(await _employeeReposiory.GetAllEmployeeAsync());
            return x.Take(4).ToList();
        }

        [HttpGet("GetEmpbyId")]
        public async Task<EmployeeDTO> GetEmpById(int id)
        {

            var employee = await _employeeReposiory.GetEmployeeByIdAsync(id);
            var employeeDto = _mapper.Map<EmployeeDTO>(employee);

            return employeeDto;
        }


        [HttpDelete]
        public async Task<EmployeeDTO> DeleteEmployee(int id)
        {
            var employee = await _employeeReposiory.GetEmployeeByIdAsync(id);
            var DeletedEmpolyee = await _employeeReposiory.DeleteEmployeeAsync(employee);
            var DeletedEmpolyeeDto = _mapper.Map<EmployeeDTO>(DeletedEmpolyee);

            return DeletedEmpolyeeDto;
        }

        [HttpPut]

        public async Task<ActionResult<EmployeeDTO>> UpdateEmployee(EmployeeDTO EmployeeDTO)
        {

            var UpdatedEmpolyee = _mapper.Map<Employee>(EmployeeDTO);

            await _AddressReposiory.RemoveAllAdressByEmpId(UpdatedEmpolyee.Id);

            var EmpToReturn = await _employeeReposiory.updateEmployeeAsync(UpdatedEmpolyee);

            var EmpToReturnDto = _mapper.Map<EmployeeDTO>(EmpToReturn);


            return Ok(EmpToReturnDto);
        }


        [HttpGet("GetPaginatedEmp")]
        public async Task<ActionResult<List<EmployeeDTO>>> GetPaginatedEmployee(int page, int pageSize = 3)
        {
            var empolyees = await _employeeReposiory.GetlPaginatedEmployeeAsync(page, pageSize);

            var EmployeeToReurnDTO = _mapper.Map<List<EmployeeDTO>>(empolyees);

            return EmployeeToReurnDTO;
        }

        [HttpGet("GetCountOfEmp")]
        public async Task<int> GetPaginatedEmployee()
        {
            var empolyees = await _employeeReposiory.GetAllEmployeeAsync();

            return empolyees.Count();
        }

    }
}
