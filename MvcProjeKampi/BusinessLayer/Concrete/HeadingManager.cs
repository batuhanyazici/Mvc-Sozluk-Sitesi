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
            return _headingdal.Get(x => x.HeadingId == id);
        }

        public List<Heading> GetList()
        {
            return _headingdal.List();
        }

        public void HeadingAdd(Heading heading)
        {
            _headingdal.Insert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
            _headingdal.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingdal.Update(heading);
        }
    }
}
