using SkillTrax.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTrax.Services
{
    public interface IEmployeeDataService
    {
        Task<EmployeeViewModel> GetEmployeeViewModel(int Id);
        Task<List<EmployeeViewModel>> GetEmployeeViewModels();
        Task<EmployeeViewModel> GetEmployeeViewModelByAdUniqueId(string adUniqueId);
        Task<int> AddEmployeeSkill(int employeeId, int skillId);
        Task<int> DeleteEmployeeSkill(int employeeSkillId);
    }
}
