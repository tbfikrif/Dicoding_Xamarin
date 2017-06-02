using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using Xamarin.Forms;
using CatatPengeluaran.Models;

namespace CatatPengeluaran.Accesses
{
    public class DataAccess
    {
        SQLiteConnection dbConn;
        
        public DataAccess()
        {
            dbConn = DependencyService.Get<ISQLite>().GetConnection();
            dbConn.CreateTable<Pengeluaran>();
        }

        public List<Pengeluaran> AmbilSemuaPengeluaran()
        {
            return dbConn.Query<Pengeluaran>("Select * From [Pengeluaran]");
        }

        //public double GetTotalExpense()
        //{
            //return dbConn.Query<Pengeluaran>("SELECT totalPengeluaran FROM [Pengeluaran]");
        //}

        public int SimpanPengeluaran(Pengeluaran pengeluaran)
        {
            return dbConn.Insert(pengeluaran);
        }

        public int HapusPengeluaran(Pengeluaran pengeluaran)
        {
            return dbConn.Delete(pengeluaran);
        }

        public int EditPengeluaran(Pengeluaran pengeluaran)
        {
            return dbConn.Update(pengeluaran);
        }
    }
}
