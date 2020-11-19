using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neydarsimi.Model;

namespace Neydarsimi.Helper
{
    class DataContextSingleton
    {
        private static volatile DataContextSingleton instance;
        private static object syncRoot = new object();
        public Neydarsimi1_dbEntities Context { get; private set; }

        public DataContextSingleton()
        {
            Context = new Neydarsimi1_dbEntities();
        }

        public static DataContextSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new DataContextSingleton();
                        }
                    }
                }
                return instance;
            }
        }
    }
}
