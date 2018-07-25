using SkillTrax.Models;
using SkillTrax.Repositories;
using SkillTrax.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.Services
{
    public class FilterDataService: IFilterDataService
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly ISkillRepository _skillRepo;
        private readonly ICertificationRepository _certificationRepo;
        private readonly IRoleRepository _roleRepo;
        public FilterDataService(IEmployeeRepository employeeRepo,
            ISkillRepository skillRepo,
            ICertificationRepository certificationRepo,
            IRoleRepository  roleRepo)
        {
            _employeeRepo = employeeRepo;
            _skillRepo = skillRepo;
            _certificationRepo = certificationRepo;
            _roleRepo = roleRepo;
        }

        public async Task<List<FilterViewModel>> getFilters()
        {
            List<Employee> employees = await _employeeRepo.GetEmployees();
            List<Skill> skills = await _skillRepo.GetSkills();
            List<Certification> certifications = await _certificationRepo.GetCertifications();
            List<RoleType> roles = await _roleRepo.getRoles();
            List<FilterViewModel> filters = new List<FilterViewModel>();
            foreach (Employee employee in employees)
            {
                filters.Add(new FilterViewModel(employee));

            }
            foreach (Skill skill in skills)
            {
                filters.Add(new FilterViewModel(skill));
            }
            foreach (Certification certification in certifications)
            {
                filters.Add(new FilterViewModel(certification));
            }
            foreach (RoleType role in roles)
            {
                filters.Add(new FilterViewModel(role));
            }
            return filters;
        }
    }
}
