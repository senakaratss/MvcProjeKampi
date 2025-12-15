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
        List<Message> GetListInboxBL(string p);
        List<Message> GetListSendboxBL(string p);
        void MessageAddBL(Message message);
        void MessageDeleteBL(Message message);
        void MessageUpdateBL(Message message);
        Message GetByIdBL(int id);
        int GetInboxCount(string mail);
        int GetSendboxCount(string mail);
    }
}
