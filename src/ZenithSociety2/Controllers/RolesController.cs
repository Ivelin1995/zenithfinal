using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ZenithSociety2.Models.RoleViewModels;

namespace ZenithSociety2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        // GET: Roles
        public ActionResult Index()
        {
            // Get all the roles 
            var roles = _roleManager.Roles.ToList();

            List<IdentityRoleViewModel> rolesView = new List<IdentityRoleViewModel>();

            foreach (IdentityRole r in roles)
            {
                rolesView.Add(new IdentityRoleViewModel()
                {
                    RoleId = r.Id,
                    RoleName = r.Name,
                    NormalizedName = r.NormalizedName
                });
            }

            // Display
            return View(rolesView);
        }

        // GET: Roles/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var roleView = await getRoleViewById(id);
            if (roleView == null)
            {
                return NotFound();
            }
            return View(roleView);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IdentityRoleViewModel roleView)
        {
            if (ModelState.IsValid)
            {

                var newRole = new IdentityRole();
                newRole.Name = roleView.RoleName;
                var newRoleResult = await _roleManager.CreateAsync(newRole);

                if (newRoleResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to create role");
                }
            }


            return View(roleView);
        }

        // GET: Roles/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var roleView = await getRoleViewById(id);
            if (roleView == null)
            {
                return NotFound();
            }
            return View(roleView);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("RoleId,RoleName")] IdentityRoleViewModel roleView)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(roleView.RoleId);
                role.Name = roleView.RoleName;
                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to update role");
                }
            }

            return View(roleView);
        }

        // GET: Roles/Delete/5
        public async Task<ActionResult> Delete(string id)
        {

            var roleView = await getRoleViewById(id);

            if (roleView == null)
            {
                return NotFound();
            }
            return View(roleView);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);


            if (role.NormalizedName != "ADMIN" && role != null)
            {

                var result = await _roleManager.DeleteAsync(role);
            }

            return RedirectToAction("Index");
        }

        private async Task<IdentityRoleViewModel> getRoleViewById(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return null;
            }

            var roleView = new IdentityRoleViewModel()
            {
                RoleId = role.Id,
                RoleName = role.Name,
                NormalizedName = role.NormalizedName
            };

            return roleView;
        }
    }
}