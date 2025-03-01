﻿using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Data.Repositories;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
    private readonly DataContext _context = context;

    public async Task<IEnumerable<ProjectEntity>> GetAllMoreDetails()
    {
        try
        {
            return await _context.Projects
                .Include(p => p.Customer)
                .Include(p => p.StatusType)
                .Include(p => p.ProjectEmployees)
                //Chat GPT hjälpte mig för .ThenInclude
                .ThenInclude(pe => pe.Employee)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error getting all projects with more details : {ex.Message}");
            return [];
        }
    }

    public async Task DeleteProjectEmployeesByProjectId(int projectId)
    {
        var projectEmployees = await _context.ProjectEmployees
            .Where(pe => pe.ProjectId == projectId)
            .ToListAsync();

        if (projectEmployees.Any())
        {
            // ChatGpt hjälpte för RemoveRange
            _context.ProjectEmployees.RemoveRange(projectEmployees);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateProjectEmployeesByProjectId(int projectId)
    {
        var projectEmployees = await _context.ProjectEmployees
            .Where(pe => pe.ProjectId == projectId)
            .ToListAsync();

        if (projectEmployees.Any())
        {
            _context.ProjectEmployees.UpdateRange(projectEmployees);
            await _context.SaveChangesAsync();
        }
    }
}

