using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReMenu.Data;
using ReMenu.Models;

namespace ReMenu.Controllers
{
    public class FoodiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Foodies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Foodie.Include(f => f.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Foodies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodie = await _context.Foodie
                .Include(f => f.IdentityUser)
                .FirstOrDefaultAsync(m => m.FoodieId == id);
            if (foodie == null)
            {
                return NotFound();
            }

            return View(foodie);
        }

        // GET: Foodies/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Foodies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodieId,FirstName,LastName,Email,IdentityUserId")] Foodie foodie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", foodie.IdentityUserId);
            return View(foodie);
        }

        // GET: Foodies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodie = await _context.Foodie.FindAsync(id);
            if (foodie == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", foodie.IdentityUserId);
            return View(foodie);
        }

        // POST: Foodies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodieId,FirstName,LastName,Email,IdentityUserId")] Foodie foodie)
        {
            if (id != foodie.FoodieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodieExists(foodie.FoodieId))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", foodie.IdentityUserId);
            return View(foodie);
        }

        // GET: Foodies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodie = await _context.Foodie
                .Include(f => f.IdentityUser)
                .FirstOrDefaultAsync(m => m.FoodieId == id);
            if (foodie == null)
            {
                return NotFound();
            }

            return View(foodie);
        }

        // POST: Foodies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodie = await _context.Foodie.FindAsync(id);
            _context.Foodie.Remove(foodie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodieExists(int id)
        {
            return _context.Foodie.Any(e => e.FoodieId == id);
        }

        // POST: FoodiesController/CreateMeal
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<ActionResult> CreateMeal([Bind("MealId, FoodieId, RestaurantId, FoodOrder, Category, Price, Rating, FutureModification, FutureOrder, Photo")] MealCreateViewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //Foodie foodie = await _repo.Foodie.GetFoodieAsync(userId);

            var foodie = _context.Foodies.Where(f => f.IdentityUserId.Equals(userId)).FirstOrDefault();
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            try
            {
                Meal newMeal = new Meal();
                newMeal.FoodieId = model.FoodieId;
                newMeal.RestaurantId = model.RestaurantId;
                newMeal.FoodOrder = model.FoodOrder;
                newMeal.Category = model.Category;
                newMeal.Price = model.Price;
                newMeal.Rating = model.Rating;
                newMeal.FutureModification = model.FutureModification;
                newMeal.FutureOrder = model.FutureOrder;
                newMeal.PhotoPath = uniqueFileName;
                _context.Add(newMeal);
                await _context.SaveChangesAsync();
                return RedirectToAction("MealDetails", new { id = newMeal.FoodieId });
            }

            catch (Exception e)
            {
                return View(e);
            }

        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReMenu.Data.Repositories
{
    public class MealImageRepository : RepositoryBase<MealImage>, IMealImageRepository
    {
        public MealImageRepository(ApplicationDbContext applicationDb) : base(applicationDb)
        {
            public void CreateMealImage(MealImage mealImage) => Create(mealImage);
            public void EditMealImage(MealImage mealImage) => Update(mealImage);
            public void DeleteMealImage(MealImage mealImage) => Delete(mealImage);
            public List<MealImage> GetMealImages(int foodieId) => FindAll().ToList();
            public MealImage GetMealImage(int mealImageId) => FindByCondition(m => m.MealImageId.Equals(mealImageId)).FirstOrDefault();
            public MealImage GetMealImage(string mealImageId) => FindByCondition(m => m.MealImageId.Equals(mealImageId)).FirstOrDefault();
        }
    }
}

using ReMenu.Interfaces;
using ReMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReMenu.Contracts
{
    interface IMealImageRepository : IRepositoryBase<MealImage>
    {
        void CreateMealImage(MealImage mealImage);
        MealImage GetMealImage(int mealImageId);
        MealImage GetMealImage(string mealImageId);
        void EditMealImage(MealImage mealImage);
        void DeleteMealImage(MealImage mealImage);
        List<MealImage> GetMealImages(int mealImageId);
    }
