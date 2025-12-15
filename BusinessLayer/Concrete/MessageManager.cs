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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        public Message GetByIdBL(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

        public int GetInboxCount(string mail)
        {
            return _messageDal.GetInboxCount(mail);        
        }

        public List<Message> GetListInboxBL(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p);
        }

        public List<Message> GetListSendboxBL(string p)
        {
            return _messageDal.List(x => x.SenderMail == p);
        }

        public int GetSendboxCount(string mail)
        {
            return _messageDal.GetSendboxCount(mail);

        }

        public void MessageAddBL(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDeleteBL(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdateBL(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
