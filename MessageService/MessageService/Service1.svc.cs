using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace MessageService
{

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        private object serviceLock = new object();


     
        public List<Message> AddMessages(string message)
        {
            
            lock (serviceLock)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    MessagesDatabase.Add(message);

                }
            }
            return MessagesDatabase.Messages();
        }


        public List<Message> DeleteMessages(string ID)
        {
            lock (serviceLock)
            {
               MessagesDatabase.Delete(ID);
            }
            return MessagesDatabase.Messages();
        }


        public List<Message> GetMessages()
        {
            return MessagesDatabase.Messages();
        }


    }
}
