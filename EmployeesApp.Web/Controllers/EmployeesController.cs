﻿using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using EmployeesApp.Web.Models;
using EmployeesApp.Web.Views.Employees;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesApp.Web.Controllers;

public class EmployeesController(IEmployeeService service) : Controller
{
    [HttpGet("")]
    public async Task<IActionResult> IndexAsync()
    {
        var model = await service.GetAllAsync();

        var viewModel = new IndexVM()
        {
            EmployeeVMs = [.. model
            .Select(e => new IndexVM.EmployeeVM()
            {
                Id = e.Id,
                Name = e.Name,
                Company = e.Company, // Include the Company navigation property
                ShowAsHighlighted = service.CheckIsVIP(e),
            })]
        };

        return View(viewModel);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")]
    [ServiceFilter(typeof(MyLogServiceFilterAttribute))]
    public IActionResult Create(CreateVM viewModel)
    {
        if (!ModelState.IsValid)
            return View();

        Employee employee = new()
        {
            Name = viewModel.Name,
            Email = viewModel.Email,
            Salary = viewModel.Salary,
        };

        service.AddAsync(employee);
        return RedirectToAction(nameof(IndexAsync).Replace("Async", string.Empty));
    }

    [HttpGet("details/{id}")]
    [TypeFilter(typeof(MyLogTypeFilterAttribute))]
    public async Task<IActionResult> DetailsAsync(int id)
    {
        var model = await service.GetByIdAsync(id);

        DetailsVM viewModel = new()
        {
            Id = model!.Id,
            Name = model.Name,
            Email = model.Email,
            Salary = model.Salary,
        };

        return View(viewModel);
    }
}
