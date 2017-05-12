using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace CatatPengeluaran.Models
{
    public class Pengeluaran
    {
        [PrimaryKey, AutoIncrement] public long idTransaksi { get; set; }
        [NotNull] public string namaTransaksi { get; set; }
        [NotNull] public double biayaPengeluaran { get; set; }
        public string tanggalPengeluaran { get; set; }
        public string infoPengeluaran { get; set; }
        public double totalPengeluaran { get; set; }
    }
}
