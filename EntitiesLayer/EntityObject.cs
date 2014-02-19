using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public abstract class EntityObject
    {
        public static int numberEntities;
        public int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public EntityObject()
        {
            id = ++numberEntities;
        }

        public int getId() {
            return id;
        }

        public override bool Equals(object obj)
        {
            var item = obj as EntityObject;

            if (item == null)
            {
                return false;
            }

            return this.Id.Equals(item.Id);
        }
        
    }
}
