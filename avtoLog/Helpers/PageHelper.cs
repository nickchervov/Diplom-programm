using avtoLog.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace avtoLog.Helpers
{
    internal class PageHelper
    {
        public static Frame MainFrame;
        
        public static avtoLogDbEntities DbConnect = new avtoLogDbEntities();

        public static int role;
    }
}
