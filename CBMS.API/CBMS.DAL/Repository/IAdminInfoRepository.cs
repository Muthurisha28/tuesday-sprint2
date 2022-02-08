using CBMS.Entity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CBMS.DAL.Repository
{
    public interface IAdminInfoRepository
    {
        AdminInfo Login(AdminInfo user);
    }
}
