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
            return _writerdal.Get(x => x.WriterId == id);
        }

        public List<Writer> GetList()
        {
            return _writerdal.List();
        }

        public Writer GetWriter(string username, string password)
        {
            return _writerdal.Get(x => x.WriterMail == username && x.WriterPassword == password);
        }

        public void WriterAdd(Writer writer)
        {
            _writerdal.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerdal.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writerdal.Update(writer);
        }
    }
}
