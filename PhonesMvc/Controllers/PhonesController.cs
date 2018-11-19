using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhonesMvc.Models;

namespace PhonesMvc.Controllers
{
    public class PhonesController : Controller
    {
        private readonly PhonesMvcContext _context;

        public PhonesController(PhonesMvcContext context)
        {
            _context = context;
        }

        // GET: Phones
        public async Task<IActionResult> Index(string sortOrder, 
            string searchString,
            string currentFilter,
            int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["OwnerSortParam"] = String.IsNullOrEmpty(sortOrder) ? "owner_desc" : "";
            ViewData["MakeSortParam"] = sortOrder == "Make" ? "make_desc" : "Make";
            ViewData["CurrentFilter"] = searchString;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var phones = from t in _context.Phone select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                phones = phones.Where(s => s.Owner.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Make":
                    phones = phones.OrderBy(s => s.Make);
                    break;
                case "owner_desc":
                    phones = phones.OrderByDescending(s => s.Owner);
                    break;
                case "make_desc":
                    phones = phones.OrderByDescending(s => s.Make);
                    break;
                default:
                    phones = phones.OrderBy(s => s.Owner);
                    break;

            }

            int pageSize = 3;
            return View(await PaginatedList<Phone>.CreateAsync(phones.AsNoTracking(), page ?? 1, pageSize));
            //return View(await phones.AsNoTracking().ToListAsync());

        }

        // GET: Phones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phone
                .SingleOrDefaultAsync(m => m.ID == id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        // GET: Phones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Phones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Owner,Sim,PhoneNumber,Color,Make,Model,ScreenSize")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phone);
        }

        // GET: Phones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phone.SingleOrDefaultAsync(m => m.ID == id);
            if (phone == null)
            {
                return NotFound();
            }
            return View(phone);
        }

        // POST: Phones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Owner,Sim,PhoneNumber,Color,Make,Model,ScreenSize")] Phone phone)
        {
            if (id != phone.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneExists(phone.ID))
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
            return View(phone);
        }

        // GET: Phones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phone
                .SingleOrDefaultAsync(m => m.ID == id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        // POST: Phones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phone = await _context.Phone.SingleOrDefaultAsync(m => m.ID == id);
            _context.Phone.Remove(phone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhoneExists(int id)
        {
            return _context.Phone.Any(e => e.ID == id);
        }
    }
}
