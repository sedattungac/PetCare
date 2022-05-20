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
    public class FeaturedBoxManager : IGenericService<FeaturedBox>
    {
        IFeaturedBoxDal _featuredBoxDal;

        public FeaturedBoxManager(IFeaturedBoxDal featuredBoxDal)
        {
            _featuredBoxDal = featuredBoxDal;
        }

        public void TAdd(FeaturedBox t)
        {
            _featuredBoxDal.Insert(t);
        }

        public void TDelete(FeaturedBox t)
        {
            _featuredBoxDal.Delete(t);
        }

        public FeaturedBox TGetById(int id)
        {
            return _featuredBoxDal.GetById(id);
        }

        public List<FeaturedBox> TGetList()
        {
            return _featuredBoxDal.GetList();
        }

        public void TUpdate(FeaturedBox t)
        {
            _featuredBoxDal.Update(t);
        }
    }
}
