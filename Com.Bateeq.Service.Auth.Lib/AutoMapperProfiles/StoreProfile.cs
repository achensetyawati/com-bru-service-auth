using Com.Bateeq.Service.Auth.Lib.Models;
using Com.Bateeq.Service.Auth.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Bateeq.Service.Auth.Lib.AutoMapperProfiles
{
    public class StoreProfile : BaseProfile
    {
        public StoreProfile() : base()
        {
            CreateMap<Store, StoreViewModel>()
                .ForPath(d => d.address, opt => opt.MapFrom(s => s.Address))
                .ForPath(d => d.city, opt => opt.MapFrom(s => s.City))
                .ForPath(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForPath(d => d.closedDate, opt => opt.MapFrom(s => s.ClosedDate))
                .ForPath(d => d.code, opt => opt.MapFrom(s => s.Code))
                .ForPath(d => d.description, opt => opt.MapFrom(s => s.Description))
                .ForPath(d => d.monthlyTotalCost, opt => opt.MapFrom(s => s.MonthlyTotalCost))
                .ForPath(d => d.name, opt => opt.MapFrom(s => s.Name))
                .ForPath(d => d.onlineOffline, opt => opt.MapFrom(s => s.OnlineOffline))
                .ForPath(d => d.openedDate, opt => opt.MapFrom(s => s.OpenedDate))
                .ForPath(d => d.phone, opt => opt.MapFrom(s => s.Phone))
                .ForPath(d => d.pic, opt => opt.MapFrom(s => s.Pic))
                .ForPath(d => d.salesCapital, opt => opt.MapFrom(s => s.SalesCapital))
                .ForPath(d => d.salesCategory, opt => opt.MapFrom(s => s.SalesCategory))
                .ForPath(d => d.salesTarget, opt => opt.MapFrom(s => s.SalesTarget))
                .ForPath(d => d.status, opt => opt.MapFrom(s => s.Status))
                .ForPath(d => d.storeArea, opt => opt.MapFrom(s => s.StoreArea))
                .ForPath(d => d.storeCategory, opt => opt.MapFrom(s => s.StoreCategory))
                .ForPath(d => d.storeWide, opt => opt.MapFrom(s => s.StoreWide))
                .ReverseMap();

            CreateMap<AccountRole, RoleViewModel>()
               .ForPath(d => d.code, opt => opt.MapFrom(s => s.Role.Code))
               .ForPath(d => d.description, opt => opt.MapFrom(s => s.Role.Description))
               .ForPath(d => d.name, opt => opt.MapFrom(s => s.Role.Name))
               .ForPath(d => d._id, opt => opt.MapFrom(s => s.RoleId))
               .ForPath(d => d.permissions, opt => opt.MapFrom(s => s.Role.Permissions))
               .ReverseMap();

            CreateMap<Permission, PermissionViewModel>()
                .ForPath(d => d.id, opt => opt.MapFrom(s => s.Id))
                .ForPath(d => d.permission, opt => opt.MapFrom(s => s.permission))
                .ForPath(d => d.roleId, opt => opt.MapFrom(s => s.RoleId))
                .ForPath(d => d.unit.Code, opt => opt.MapFrom(s => s.UnitCode))
                .ForPath(d => d.unit.Name, opt => opt.MapFrom(s => s.Unit))
                .ForPath(d => d.unit._id, opt => opt.MapFrom(s => s.UnitId))
                .ForPath(d => d.unit.Division.Name, opt => opt.MapFrom(s => s.Division))
                .ReverseMap();

            CreateMap<Account, AccountViewModel>()
                .ForPath(d => d.username, opt => opt.MapFrom(s => s.Username))
                .ForPath(d => d.password, opt => opt.MapFrom(s => s.Password))
                .ForPath(d => d.isLocked, opt => opt.MapFrom(s => s.IsLocked))
                .ForPath(d => d.profile, opt => opt.MapFrom(s => s.AccountProfile))
                .ForPath(d => d.roles, opt => opt.MapFrom(s => s.AccountRoles))
                .ForPath(d => d.stores, opt => opt.MapFrom(s => s.Stores))
                .ReverseMap();
        }
    }
}
