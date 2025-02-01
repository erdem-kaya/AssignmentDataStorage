using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Data.Repositories;

public class ProjectEmployeeRepository(DataContext context) : BaseRepository<ProjectEmployeeEntity>(context), IProjectEmployeeRepository
{
    private readonly DataContext _context = context;

    public async Task<IEnumerable<ProjectEmployeeEntity>> GetByProjectIdForEmployeesAsync(int projectId)
    {
        try
        {
            var projectEmployees = await _context.ProjectEmployees.Where(p => p.ProjectId == projectId).Include(e => e.Employee).ToListAsync();
            return projectEmployees;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error getting project employees by project id : {ex.Message}");
            return [];
        }
    }
}



