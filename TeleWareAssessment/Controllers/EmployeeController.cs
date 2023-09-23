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
            await _employeeReposiory.AddEmployeeAsync(empolyee);
            return EmployeeDTO;
        }

        [HttpGet]
        public async Task<List<EmployeeDTO>> AddEmployee()
        {
            var x = _mapper.Map<List<EmployeeDTO>>(await _employeeReposiory.GetAllEmployeeAsync());
            return x;
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

            await _employeeReposiory.updateEmployeeAsync(UpdatedEmpolyee);

            return Ok(EmployeeDTO);
        }

       

    }
}
