using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        public int GetInboxCount(string mail)
        {
            return List(x => x.ReceiverMail == mail).Count;
        }

        public int GetSendboxCount(string mail)
        {
            return List(x => x.SenderMail == mail).Count;
        }
    }
}
