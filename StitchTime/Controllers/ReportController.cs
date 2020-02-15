﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StitchTime.Core.Abstractions.Services;
using StitchTime.Core.Dto;

namespace StitchTime.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("[controller]")]
    [ApiController]
    
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService service)
        {
            _reportService = service;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<ReportDto>> GetReports()
        {
            try
            {
                var result = _reportService.GetAll();
                return  Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ReportDto>> GetReport(int id)
        {
            try
            {
                var result = await _reportService.GetById(id);
                return Ok(result);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        [Authorize]

        public ActionResult<ReportDto> PutReport(int id, ReportDto report)
        {        
            try
            {
                if(report.Id != id)
                {
                    return BadRequest("Id doesn`t match");
                }
                var result = _reportService.Update(report);
                return Ok(result);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost]
        [Authorize]

        public async Task<ActionResult<ReportDto>> PostReport(ReportDto report)
        {
            try
            {
                await _reportService.Insert(report);

                return Ok(report);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]

        public async Task<ActionResult> DeleteReport(int id)
        {
            try
            {
                await _reportService.Delete(id);
                return NoContent();
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
            catch
            {
                return Problem();
            }
        }       
    }
}