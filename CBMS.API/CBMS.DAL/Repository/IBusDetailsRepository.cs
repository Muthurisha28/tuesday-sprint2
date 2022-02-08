using CBMS.Entity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CBMS.DAL.Repository
{
  public  interface IBusDetailsRepository
    {
        public void AddBusDetails(BusDetails busdetails);
        public void UpdateBusDetails(BusDetails busdetails);
        public void DeleteBusDetails(int busNo);
        public BusDetails GetBusNo(int busNo);
        IEnumerable<BusDetails> GetBusDetails();
    }
}
