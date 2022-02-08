using CBMS.DAL.Repository;
using CBMS.Entity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CBMS.BAL.Service
{
    public class AdminInfoService
    {
        private IAdminInfoRepository _adminInfoRepository;
        public AdminInfoService(IAdminInfoRepository adminInfoRepository)
        {
            _adminInfoRepository = adminInfoRepository;
        }

        public AdminInfo Login(AdminInfo userInfo)
        {
            throw new NotImplementedException();
        }
    }
}