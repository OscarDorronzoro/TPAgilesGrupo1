using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hangman.Data.Models;
using Hangman.Data;
using Hangman.infrastructure.Repository;

namespace Hangman.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IRepository<Users> _usersRepo;
        public UsersController(IRepository<Users> usersRepo)
        {
            _usersRepo = usersRepo;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var aux = await _usersRepo.GetAllAsync();
            return View(aux);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _usersRepo.GetByIdAsync(id.Value);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Age,Username,Id")] Users users)
        {
            if (ModelState.IsValid)
            {
                await _usersRepo.InsertAsync(users);
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _usersRepo.GetByIdAsync(id.Value);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Age,Username,Id")] Users users)
        {
            if (id != users.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _usersRepo.UpdateAsync(users);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var temp = UsersExistsAsync(users.Id);
                    if (temp == null) 
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
            return View(users);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _usersRepo.GetByIdAsync(id.Value);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _usersRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<Users> UsersExistsAsync(int id)
        {
            return await _usersRepo.GetByIdAsync(id);
        }
    }
}
