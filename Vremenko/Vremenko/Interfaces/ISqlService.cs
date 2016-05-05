using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Vremenko.Interfaces
{
    public interface ISqlService
    {
        SQLiteConnection GetConnection();
    }
}
