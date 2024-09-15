using AutoMapper;
using CozyCorners.Core.Models.Identity;
using CozyCorners.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace CozyCorners.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            //CreateMap<IdentityRole, RoleViewModel>().ReverseMap();

            CreateMap<UserFormViewModel, AppUser>().ReverseMap();
            CreateMap<RoleUserViewModel, AppUser>().ReverseMap();
            CreateMap<RoleUserViewModel, IdentityRole>().ReverseMap();
            CreateMap<AppUser, UserViewModel>().ReverseMap();
            CreateMap<AppUser, UserRoleEdit>().ReverseMap();
        }
    }
}
