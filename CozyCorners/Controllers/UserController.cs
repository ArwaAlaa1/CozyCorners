using AutoMapper;
using CozyCorners.Core.Models.Identity;
using CozyCorners.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CozyCorners.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public UserController(UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager, IMapper mapper, IWebHostEnvironment environment)
        {

            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _environment = environment;

        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.Select(u => new UserViewModel()
            {
                Id = u.Id,
                DisplayName = u.DisplayName,
                UserName = u.UserName,

                Email = u.Email,
                PhoneNumber = u.PhoneNumber,

                Photo = u.Photo,
                Roles = new List<string>()
            }).ToListAsync();


            foreach (var user in users)
            {
                user.Roles = await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(user.Id));
            }

            return View(users);
        }

        public async Task<IActionResult> AddUser()
        {

            UserFormViewModel user = new UserFormViewModel();
            var roles = await _roleManager.Roles.ToListAsync();
            var mappedRoles =  _mapper.Map<List<IdentityRole>, List<RoleUserViewModel>>(roles);
            user.Roles = mappedRoles;
            return View(user);
        }

        [HttpPost]

        public async Task<IActionResult> AddUser(UserFormViewModel addUser)
        {
            try
            {


                // Create a new AppUser object
                var user = new AppUser()
                {
                    UserName = addUser.UserName,
                    DisplayName = addUser.DisplayName,
                    Email = addUser.Email,
                    PhoneNumber = addUser.PhoneNumber,
                    Photo = addUser.Photo,

                };

                // Create the user in the system
                var createUserResult = await _userManager.CreateAsync(user, addUser.Password);

                if (createUserResult.Succeeded)
                {
                    // Add the role to the user after the user has been successfully created
                    var role = await _roleManager.FindByIdAsync(addUser.RoleId);

                    if (role != null)
                    {
                        var addRoleResult = await _userManager.AddToRoleAsync(user, role.Name);

                        if (!addRoleResult.Succeeded)
                        {
                            ModelState.AddModelError(string.Empty, "Failed to add role to the user.");
                            return View(addUser);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Role not found.");
                        return View(addUser);
                    }

                    return RedirectToAction("Index");
                }
                else
                {
                    // If user creation failed, add the errors to the ModelState
                    foreach (var error in createUserResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(addUser);
        }


    
        public async Task<AppUser> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            
            var mappesuser = _mapper.Map<AppUser, UserFormViewModel>(user);
           
            return View(mappesuser);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserFormViewModel editUser)
        {

            try
            {


                //if (editUser.PhotoFile != null)
                //{
                //    editUser.Photo = DocumentSetting.UploadFile(editUser.PhotoFile, "user");
                //}



                var user = new AppUser()
                {
                    Id = editUser.Id,

                    UserName = editUser.UserName,

                    Email = editUser.Email,
                    PhoneNumber = editUser.PhoneNumber,



                };

                await _userManager.UpdateAsync(user);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.InnerException.Message);
            }


            return View(editUser);
        }

        public async Task<IActionResult> Details(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var mappesuser = _mapper.Map<AppUser, UserFormViewModel>(user);
            return View(mappesuser);
        }





        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
            return RedirectToAction(nameof(Index));
        }




    }
}


