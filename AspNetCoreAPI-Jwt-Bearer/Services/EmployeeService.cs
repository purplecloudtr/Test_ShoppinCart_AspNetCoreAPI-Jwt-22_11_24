using AspNetCoreAPI_Jwt_Bearer.DTOs;
using AspNetCoreAPI_Jwt_Bearer.Entities;
using AspNetCoreAPI_Jwt_Bearer.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreAPI_Jwt_Bearer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)  //DI Container
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        //public async Task<EmployeeDto> Create(EmployeeDto employee)
        //{
        //    var addedEmployee = await _employeeRepository.CreateAsync(_mapper.Map<Employee>(employee));
        //    return _mapper.Map<EmployeeDto>(addedEmployee);
        //}


        public async Task<EmployeeDto> CreateAsync(EmployeeDto employee)
        {
            var addedEmployee = await _employeeRepository.CreateAsync(_mapper.Map<Employee>(employee));
            return _mapper.Map<EmployeeDto>(addedEmployee);
        }

        //_mapper.Map<EmployeeDto>(employee);
        //    var addedEmployee = await _employeeRepository.CreateAsync(employee);
        //    return _mapper.Map<EmployeeDto>(addedEmployee);

        //public async Task<EmployeeDto> CreateAsync(EmployeeDto employee)
        //{
        //    await _context.Cities.AddAsync(city);   //Ara katmana ekler.
        //    await _context.SaveChangesAsync();      //Veritabanına ekler.
        //    return city;    //Sql'in verdiği id değeriyle birlikte döner.
        //}


        public async Task<EmployeeDto> Get(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            return _mapper.Map<EmployeeDto>(employee);
        }
        public async Task<List<EmployeeDto>> GetAll()
        {
            var list = await _employeeRepository.GetAllAsync();
            return _mapper.Map<List<EmployeeDto>>(list);
        }
    }   
}
