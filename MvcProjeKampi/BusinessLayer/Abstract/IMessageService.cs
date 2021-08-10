using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetList(string p);
        List<Message> GetSearch(string p, string d);
        List<Message> ListAll();
        List<Message> GetListInbox(string p);
        List<Message> GetListSendbox(string p);
        List<Message> GetListUnRead(string p);
        void MessageAdd(Message message);
        Message GetByID(int id);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
    }
}
