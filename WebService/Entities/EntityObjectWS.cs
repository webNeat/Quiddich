using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebService
{
    [DataContract]
    public abstract class EntityObjectWS
    {
        public static int numberEntities;
        public int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public EntityObjectWS()
        {
            id = ++numberEntities;



        }

        public int getId() {
            return id;
        }        
    }
}
