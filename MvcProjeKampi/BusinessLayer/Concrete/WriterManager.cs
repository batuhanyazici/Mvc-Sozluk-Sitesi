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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerdal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerdal = writerDal;
        }
        public Writer GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetList()
        {
            return _writerdal.List();
        }

        public void WriterAdd(Writer writer)
        {
            throw new NotImplementedException();
        }

        public void WriterDelete(Writer writer)
        {
            throw new NotImplementedException();
        }

        public void WriterUpdate(Writer writer)
        {
            throw new NotImplementedException();
        }
    }
}
