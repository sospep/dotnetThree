using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dotnetThree.Data;
using dotnetThree.Models;
using Microsoft.AspNetCore.Identity;
using dotnetThree.Models.AccountViewModels;
using Microsoft.AspNetCore.Authorization;

namespace dotnetThree.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
         
        public ArticlesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            if(User.Identity.Name != null)
            {
                ApplicationUser currentUser = await _userManager.FindByEmailAsync(User.Identity.Name);

                ViewData["currentUserId"] = currentUser.Id;
                ViewData["isAdmin"] = await _userManager.IsInRoleAsync(currentUser,"ADMIN");
            }
            else
            {
                ViewData["currentUserId"] = "Unregistered";
                ViewData["isAdmin"] = false;
            }
            return View(await _context.Article.ToListAsync());
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            // ApplicationUser currentUser = await _userManager.FindByEmailAsync(User.Identity.Name);

            // test id is valid 
            if (id == null)
            {
                return NotFound();
            }
            // new viewModel instance
            var twoModels = new ArticleComment();
            if (id == null)
            {
                return NotFound();
            }
            // article 
            twoModels.Article = await _context.Article
                .FirstOrDefaultAsync(m => m.Id == id);
            if (twoModels.Article == null)
            {
                return NotFound();
            }
            // comments 
             var comments = await _context.Comment
                .Where(m => m.Article_Id == id)
                .ToListAsync();
            
            if (comments == null)
            {
                return NotFound();
            }
            twoModels.comments = (List<Comment>)comments;
            
            // current user 
            if (User.Identity.Name != null)
            {
                twoModels.currentUser = await _userManager.FindByEmailAsync(User.Identity.Name);
            }
            else {
                twoModels.currentUser = null;
            }

            return View(twoModels);
        }

        // GET: Articles/Create
        [Authorize(Roles = "MEMBER,ADMIN")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content,Price")] Article article)
        {
            ApplicationUser currentUser = await _userManager.FindByEmailAsync(User.Identity.Name);
            article.CreatedAt = DateTime.Now;
            article.Author = currentUser.Id;
            
            if (ModelState.IsValid)
            {
                _context.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Articles/Edit/5
        [Authorize(Roles = "MEMBER,ADMIN")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Article.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,CreatedAt,Content,Price")] Article article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.Id))
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
            return View(article);
        }

        // GET: Articles/Delete/5
         [Authorize(Roles = "MEMBER,ADMIN")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Article
                .FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _context.Article.FindAsync(id);
            _context.Article.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _context.Article.Any(e => e.Id == id);
        }
    }
}
