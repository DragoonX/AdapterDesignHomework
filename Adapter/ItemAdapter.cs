using AdapterDesignOdev.Interface;
using AdapterDesignOdev.Model;
using System.Linq;

namespace AdapterDesignOdev.Adapter
{
    class ItemAdapter : ICrud
    {

        public T Insert<T>(T model) where T : class
        {
            using (AdapterDesignContext adapterDesignContext = new AdapterDesignContext())
            {
                adapterDesignContext.Set<T>().Add(model);
                adapterDesignContext.SaveChanges();
            }
            return model;
        }

        public T Update<T>(T model) where T : class
        {
            using (AdapterDesignContext adapterDesignContext = new AdapterDesignContext())
            {
                adapterDesignContext.Set<T>().Update(model);
                adapterDesignContext.SaveChanges();
            }
            return model;
        }

        public IQueryable<T> Get<T>() where T : class
        {
            IQueryable<T> models;

            using (AdapterDesignContext adapterDesignContext = new AdapterDesignContext())
            {
                models = adapterDesignContext.Set<T>();
            }

            return models;
        }

        public void Delete<T>(int id) where T : class
        {
            T model = Find<T>(id);

            using (AdapterDesignContext adapterDesignContext = new AdapterDesignContext())
            {
                adapterDesignContext.Set<T>().Remove(model);
                adapterDesignContext.SaveChanges();
            }
        }

        public T Find<T>(int id) where T : class
        {
            T item;

            using (AdapterDesignContext adapterDesignContext = new AdapterDesignContext())
            {
                item = adapterDesignContext.Set<T>().Find(id);
            }
            return item;
        }

    }
}
