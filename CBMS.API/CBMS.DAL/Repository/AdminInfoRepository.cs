using CBMS.DAL.Data;
using CBMS.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBMS.DAL.Repository
{
    public class AdminInfoRepository : IAdminInfoRepository
    {
        CityBusManagementDbContext _admininfoDbContext;
        public AdminInfoRepository(CityBusManagementDbContext admininfoDbContext)
        {
            _admininfoDbContext = admininfoDbContext;
        }



        public AdminInfo Login(AdminInfo user)
        {
            AdminInfo userInfo = null;
            var result = _admininfoDbContext.adminInfo.Where(obj => obj.AdminId == user.AdminId && obj.Password == user.Password).ToList();
            if (result.Count > 0)
            {
                userInfo = result[0];
            }
            return userInfo;
        }
    }
}