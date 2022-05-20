using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WorkingHourManager : IWorkingHourService
    {
        IWorkingHourDal _workingHourDal;

        public WorkingHourManager(IWorkingHourDal workingHourDal)
        {
            _workingHourDal = workingHourDal;
        }

        public void TAdd(WorkingHour t)
        {
            _workingHourDal.Insert(t);
        }

        public void TDelete(WorkingHour t)
        {
            _workingHourDal.Delete(t);
        }

        public WorkingHour TGetById(int id)
        {
            return _workingHourDal.GetById(id);
        }

        public List<WorkingHour> TGetList()
        {
            return _workingHourDal.GetList();
        }

        public void TUpdate(WorkingHour t)
        {
            _workingHourDal.Update(t);
        }
    }
}
