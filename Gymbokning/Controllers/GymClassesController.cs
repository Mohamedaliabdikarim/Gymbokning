
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gymbokning.Models;
using Gymbokning.Data;

public class GymClassesController : Controller
{
    private readonly ApplicationDbContext _context;

    public GymClassesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: GYMCLASSS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.GymClasses.ToListAsync());
    }

    // GET: GYMCLASSS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var gymclass = await _context.GymClasses
            .FirstOrDefaultAsync(m => m.Id == id);
        if (gymclass == null)
        {
            return NotFound();
        }

        return View(gymclass);
    }

    // GET: GYMCLASSS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: GYMCLASSS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,StartTime,Duration,EndTime,Description,AttendingMembers")] GymClass gymclass)
    {
        if (ModelState.IsValid)
        {
            _context.Add(gymclass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(gymclass);
    }

    // GET: GYMCLASSS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var gymclass = await _context.GymClasses.FindAsync(id);
        if (gymclass == null)
        {
            return NotFound();
        }
        return View(gymclass);
    }

    // POST: GYMCLASSS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,StartTime,Duration,EndTime,Description,AttendingMembers")] GymClass gymclass)
    {
        if (id != gymclass.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(gymclass);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GymClassExists(gymclass.Id))
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
        return View(gymclass);
    }

    // GET: GYMCLASSS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var gymclass = await _context.GymClasses
            .FirstOrDefaultAsync(m => m.Id == id);
        if (gymclass == null)
        {
            return NotFound();
        }

        return View(gymclass);
    }

    // POST: GYMCLASSS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var gymclass = await _context.GymClasses.FindAsync(id);
        if (gymclass != null)
        {
            _context.GymClasses.Remove(gymclass);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool GymClassExists(int? id)
    {
        return _context.GymClasses.Any(e => e.Id == id);
    }
}
