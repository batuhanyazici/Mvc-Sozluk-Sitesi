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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetList(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p).Where(x => x.IsRead == true).ToList();
        }

        public List<Message> GetListInbox(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p);
        }

        public List<Message> GetListSendbox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p);
        }

        public List<Message> GetListUnRead(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p).Where(x => x.IsRead == false).ToList();
        }

        public List<Message> GetSearch(string p,string d)
        {
            return _messageDal.List(x => x.MessageContent.Contains(p) && x.ReceiverMail==d);
        }

        public List<Message> ListAll()
        {
            return _messageDal.List();
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
