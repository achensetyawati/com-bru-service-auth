using Com.Bateeq.Service.Auth.Lib.BusinessLogic.Interfaces;
using Com.Bateeq.Service.Auth.Lib.Models;
using Com.Bateeq.Service.Auth.Lib.Services.IdentityService;
using Com.Bateeq.Service.Auth.Lib.Utilities;
using Com.Moonlay.Models;
using Com.Moonlay.NetCore.Lib;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Bateeq.Service.Auth.Lib.BusinessLogic.Services
{
    public class RoleService : IRoleService
    {
        private const string UserAgent = "auth-service";
        protected DbSet<Role> DbSet;
        protected IIdentityService IdentityService;
        public AuthDbContext DbContext;

        public RoleService(IServiceProvider serviceProvider, AuthDbContext dbContext)
        {
            DbContext = dbContext;
            this.DbSet = dbContext.Set<Role>();
            this.IdentityService = serviceProvider.GetService<IIdentityService>();
        }

        public async Task<int> CreateAsync(Role model)
        {
            EntityExtension.FlagForCreate(model, IdentityService.Username, UserAgent);
            foreach(var item in model.Permissions)
            {
                EntityExtension.FlagForCreate(item, IdentityService.Username, UserAgent);
            }
            DbSet.Add(model);

            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            Role model = await ReadByIdAsync(id);
            EntityExtension.FlagForDelete(model, IdentityService.Username, UserAgent, true);
            foreach (var item in model.Permissions)
            {
                EntityExtension.FlagForDelete(item, IdentityService.Username, UserAgent, true);
            }
            DbSet.Update(model);
            return await DbContext.SaveChangesAsync();
        }

        public ReadResponse<Role> Read(int page, int size, string order, List<string> select, string keyword, string filter)
        {
            IQueryable<Role> query = DbSet.Include(x => x.Permissions).Where(x => !x.IsDeleted);

            List<string> searchAttributes = new List<string>()
            {
                "Code", "Name"
            };

            query = QueryHelper<Role>.Search(query, searchAttributes, keyword);

            Dictionary<string, object> filterDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(filter);
            query = QueryHelper<Role>.Filter(query, filterDictionary);

            List<string> selectedFields = new List<string>()
                {
                    "_id", "code", "name"
                };

            Dictionary<string, string> orderDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(order);
            query = QueryHelper<Role>.Order(query, orderDictionary);

            Pageable<Role> pageable = new Pageable<Role>(query, page - 1, size);
            List<Role> data = pageable.Data.ToList();
            int totalData = pageable.TotalCount;

            return new ReadResponse<Role>(data, totalData, orderDictionary, selectedFields);
        }

        public async Task<Role> ReadByIdAsync(int id)
        {
            var result = await DbSet
                .Include(x => x.Permissions)
                .FirstOrDefaultAsync(x => x.Id.Equals(id) && !x.IsDeleted);

            return result;
        }

        public async Task<int> UpdateAsync(int id, Role model)
        {
            var data = await ReadByIdAsync(id);

            data.Code = model.Code;
            data.Description = model.Description;
            data.Name = model.Name;

            var updatedPermissions = model.Permissions.Where(x => data.Permissions.Any(y => y.Id == x.Id));
            var addedPermissions = model.Permissions.Where(x => !data.Permissions.Any(y => y.Id == x.Id));
            var deletedPermissions = data.Permissions.Where(x => !model.Permissions.Any(y => y.Id == x.Id));
            
            foreach (var item in updatedPermissions)
            {
                var permission = data.Permissions.SingleOrDefault(x => x.Id == item.Id);

                permission.Division = item.Division;
                permission.permission = item.permission;
                permission.Unit = item.Unit;
                permission.UnitCode = item.UnitCode;
                permission.UnitId = item.UnitId;

                EntityExtension.FlagForUpdate(permission, IdentityService.Username, UserAgent);
            }
            List<Permission> addPermissions = new List<Permission>();
            foreach(var item1 in addedPermissions)
            {
                item1.RoleId = id;
                EntityExtension.FlagForCreate(item1, IdentityService.Username, UserAgent);
                addPermissions.Add(item1);
            }
            foreach(var item in addPermissions)
            {
                data.Permissions.Add(item);
            }

            foreach (var item2 in deletedPermissions)
            {
                EntityExtension.FlagForDelete(item2, IdentityService.Username, UserAgent, true);
            }

            EntityExtension.FlagForUpdate(data, IdentityService.Username, UserAgent);
           
            DbSet.Update(data);
            return await DbContext.SaveChangesAsync();
        }

        public bool CheckDuplicate(int id, string code)
        {
            return DbSet.Any(r => r.IsDeleted.Equals(false) && r.Id != id && r.Code.Equals(code));
        }
    }
}
