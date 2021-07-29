using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager: IHeadingService
    {
        IHeadingDal _headingdal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingdal = headingDal;
        }

        public Heading GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Heading> GetList()
        {
            return _headingdal.List();
        }

        public void HeadingAdd(Heading heading)
        {
            throw new NotImplementedException();
        }

        public void HeadingDelete(Heading heading)
        {
            throw new NotImplementedException();
        }

        public void HeadingUpdate(Heading heading)
        {
            throw new NotImplementedException();
        }
    }
}
