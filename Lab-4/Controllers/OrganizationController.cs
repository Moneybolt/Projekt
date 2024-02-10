using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entities;

namespace Laboratorium_nr3.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly AppDbContext _context;

        public OrganizationController(AppDbContext context)
        {
            _context = context;
        }

   
        public async Task<IActionResult> Index()
        {
              return _context.Organization != null ? 
                          View(await _context.Organization.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Organizations'  is null.");
        }

      
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Organization == null)
            {
                return NotFound();
            }

            var organizationEntity = await _context.Organization
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organizationEntity == null)
            {
                return NotFound();
            }

            return View(organizationEntity);
        }

     
        public IActionResult Create()
        {
            return View();
        }


 
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] OrganizationEntity organizationEntity)
        {
            _context.Add(organizationEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Create");
        }

  
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Organization == null)
            {
                return NotFound();
            }

            var organizationEntity = await _context.Organization.FindAsync(id);
            if (organizationEntity == null)
            {
                return NotFound();
            }
            return View(organizationEntity);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] OrganizationEntity organizationEntity)
        {
            if (id != organizationEntity.Id)
            {
                return NotFound();
            }


                try
                {
                    _context.Update(organizationEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizationEntityExists(organizationEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Organization == null)
            {
                return NotFound();
            }

            var organizationEntity = await _context.Organization
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organizationEntity == null)
            {
                return NotFound();
            }

            return View(organizationEntity);
        }

       
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Organization == null)
            {
                return Problem("Entity set 'AppDbContext.Organizations'  is null.");
            }
            var organizationEntity = await _context.Organization.FindAsync(id);
            if (organizationEntity != null)
            {
                _context.Organization.Remove(organizationEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizationEntityExists(int id)
        {
          return (_context.Organization?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
