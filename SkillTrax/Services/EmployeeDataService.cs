using SkillTrax.Models;
using SkillTrax.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly ISkillDataService _skillDataService;

        public EmployeeDataService(
            IEmployeeRepository employeeRepo,
            ISkillDataService skillDataService)
        {
            _skillDataService = skillDataService;
            _employeeRepo = employeeRepo;
            
        }

        public async Task<EmployeeViewModel> GetEmployeeViewModel(int Id)
        {
            Employee employee = await _employeeRepo.GetEmployee(Id);
            if(employee == null)
            {
                return null;
            }
            EmployeeViewModel employeeViewModel = new EmployeeViewModel(employee);
            return employeeViewModel;
        }

        public async Task<List<EmployeeViewModel>> GetEmployeeViewModels()
        {
            List<Employee> employees = await _employeeRepo.GetEmployees();
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
            foreach (Employee employee in employees)
            {
                employeeViewModels.Add(new EmployeeViewModel(employee));
            }
            return employeeViewModels;
        }

        public async Task<EmployeeViewModel> GetEmployeeViewModelByAdUniqueId(string adUniqueId)
        {
            Employee employee = await _employeeRepo.GetEmployeeByAdUniqueId(adUniqueId);
            if (employee == null)
            {
                return null;
            }
            return new EmployeeViewModel(employee);
        }

        public async Task<int> DeleteEmployeeSkill(int employeeId, int skillId)
        {
            return await _employeeRepo.DeleteEmployeeSkill(employeeId, skillId);
        }

        public async Task<int> AddEmployeeSkill(int employeeId, int skillId)
        {
            return await _employeeRepo.AddEmployeeSkill(employeeId, skillId);
        }
    }
}
