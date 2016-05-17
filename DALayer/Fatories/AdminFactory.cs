using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer
{
    public class AdminFactory
    {
        private static AdminContext ctx = null;
        public static AdminContext getAdminCtx() {
            if (ctx == null)
            {
                ctx = new AdminContext();
            }
            return ctx;
        }
    }
}
