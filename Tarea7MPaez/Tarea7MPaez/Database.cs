using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea7MPaez
{
    public interface Database
    {
        SQLiteAsyncConnection GetConnection();
    }
}
