using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace testcustomlog.Controllers
{
    public class RollController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RollController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;

        }

        // GET: Roll
        public ActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }

        // GET: Roll/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Roll/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Roll/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string name)
        {
            var result = _roleManager.CreateAsync(new IdentityRole(name)).Result;
            if (result.Succeeded)
            {
                return new RedirectResult("Index");
            }

            return View();
        }

        // GET: Roll/Edit/5
        public async Task<IActionResult> Edit(string id)
        {

            return View();
        }

        // POST: Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, string name)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(id);
                if (role != null)
                {
                    role.Name = name;
                    var result = await _roleManager.UpdateAsync(role);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Roll/Delete/5
        public async Task<ActionResult> Delete(string id, string name)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(id);
                if (role != null)
                {
                    
                    var result = await _roleManager.DeleteAsync(role);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: Roles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}