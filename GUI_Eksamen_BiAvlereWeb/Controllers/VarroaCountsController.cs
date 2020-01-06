using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GUI_Eksamen_BiAvlereWeb.Data;
using GUI_Eksamen_BiAvlereWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace GUI_Eksamen_BiAvlereWeb.Controllers
{
    public class VarroaCountsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VarroaCountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VarroaCounts
        //[Authorize("IsBeeKeeper")]
        [Authorize]
        public async Task<IActionResult> Index(string searchString)
        {
            //NYT---------------------------------
            var beehive = from b in _context.VariCounts select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                beehive = beehive.Where(s => s.BeeHive.Contains(searchString));
            }


            return View(await beehive.ToListAsync());

            //return View(await _context.VariCounts.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> IndexOwnData([FromServices]UserManager<ApplicationUser> userManager)
        {
            var currentUser = await userManager.GetUserAsync(User);
            return View(await _context.VariCounts.Where(b => b.AuthorOfData == currentUser)
                .ToListAsync());
        }


        // GET: VarroaCounts/Details/5
        public async Task<IActionResult> OwnDetails(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var varroaCount = await _context.VariCounts
                .FirstOrDefaultAsync(m => m.VarroaCountId == id);
            if (varroaCount == null)
            {
                return NotFound();
            }

            return View(varroaCount);
        }


        
        // GET: VarroaCounts/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var varroaCount = await _context.VariCounts
                .FirstOrDefaultAsync(m => m.VarroaCountId == id);
            if (varroaCount == null)
            {
                return NotFound();
            }

            return View(varroaCount);
        }

        // GET: VarroaCounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VarroaCounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VarroaCountId,BeeHive,DateForCount,NumberOfDaysObserved,Comment, ZipCode")] VarroaCount varroaCount, [FromServices]UserManager<ApplicationUser> userManager)
        {
            if (ModelState.IsValid)
            {
                varroaCount.AuthorOfData = await userManager.GetUserAsync(User);
                varroaCount.IdOfAuthor = varroaCount.AuthorOfData.Id;
                varroaCount.ZipCode = varroaCount.AuthorOfData.ZipCode;
                _context.Add(varroaCount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(varroaCount);
        }

        // GET: VarroaCounts/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var varroaCount = await _context.VariCounts.FindAsync(id);
            if (varroaCount == null)
            {
                return NotFound();
            }
            return View(varroaCount);
        }

        // POST: VarroaCounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("VarroaCountId,BeeHive,DateForCount,NumberOfDaysObserved,Comment")] VarroaCount varroaCount)
        {
            if (id != varroaCount.VarroaCountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(varroaCount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VarroaCountExists(varroaCount.VarroaCountId))
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
            return View(varroaCount);
        }

        // GET: VarroaCounts/Delete/5
        public async Task<IActionResult> Delete(long? id, [FromServices]UserManager<ApplicationUser> userManager)
        {
            var currentUser = await userManager.GetUserAsync(User);
            var vc = await _context.VariCounts.FirstOrDefaultAsync(m => m.VarroaCountId == id);
            string aid = vc.IdOfAuthor;


            if (currentUser.Id == aid)
            {

                //NORMALT KUN DETTE HERINDE!
                if (id == null)
                {
                    return NotFound();
                }

                var varroaCount = await _context.VariCounts
                    .FirstOrDefaultAsync(m => m.VarroaCountId == id);
                if (varroaCount == null)
                {
                    return NotFound();
                }

                return View(varroaCount);
            }

            return View("~/Views/Shared/_LoginPartial.cshtml");
        }

        // POST: VarroaCounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var varroaCount = await _context.VariCounts.FindAsync(id);
            _context.VariCounts.Remove(varroaCount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VarroaCountExists(long id)
        {
            return _context.VariCounts.Any(e => e.VarroaCountId == id);
        }
    }
}
