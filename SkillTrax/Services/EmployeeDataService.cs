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
            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                IsAdmin = employee.IsAdmin,
                AdUniqueIdentifier = employee.AdUniqueIdentifier,
                RoleType = employee.RoleType,
                Certifications = await _employeeRepo.GetEmployeeCertifications(Id),
                Skills = new List<SkillViewModel>()
            };
            List<Skill> skills = await _employeeRepo.GetEmployeeSkills(Id);
            foreach (Skill skill in skills)
            {
                employeeViewModel.Skills.Add(await _skillDataService.GetSkillViewModelById(skill.SkillId));
            }
            return employeeViewModel;
        }

        public async Task<List<EmployeeViewModel>> GetEmployeeViewModels()
        {
            List<Employee> employees = await _employeeRepo.GetEmployees();
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
            foreach (Employee employee in employees)
            {
                employeeViewModels.Add(await GetEmployeeViewModel(employee.EmployeeId));
            }
            return employeeViewModels;
        }

        public async Task<EmployeeViewModel> GetEmployeeViewModelByAdUniqueId(string adUniqueId)
        {
            Employee employee = await _employeeRepo.GetEmployeeByAdUniqueId(adUniqueId);
            return await GetEmployeeViewModel(employee.EmployeeId);
        }

        public async Task<int> DeleteEmployeeSkill(int employeeSkillId)
        {
            return await _employeeRepo.DeleteEmployeeSkill(employeeSkillId);
        }

        public async Task<int> AddEmployeeSkill(int employeeId, int skillId)
        {
            return await _employeeRepo.AddEmployeeSkill(employeeId, skillId);
        }
    }
}
