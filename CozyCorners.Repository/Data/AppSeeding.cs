using CozyCorners.Core.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyCorners.Repository.Data
{
	public static class AppSeeding
	{
		
		public static async Task SeedAsync(UserManager<AppUser> usermanager, RoleManager<IdentityRole> roleManager)
		{
			if(usermanager.Users.Count() == 0)
			{
				AppUser user2 = new AppUser()
				{
					Email="arwaalaa24682468@gmail.com",
					UserName="Arwa1",
					PhoneNumber="01011037458",
					DisplayName="Arwa"
				
				};

				var result =await usermanager.CreateAsync(user2,"P@ssWord1");
				 var resultrole=await roleManager.CreateAsync(new IdentityRole() 
				{ 
				   Name="Admin"
				});
				var resultaddrole=await usermanager.AddToRoleAsync(user2, "Admin");
			}

			
		}
	}
}
