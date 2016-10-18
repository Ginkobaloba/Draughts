using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows.Forms;

namespace Draughts
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }
    public class DatabaseContext : DbContext
    {
        public DbSet<GameInfo> gameInfo { get; set; }
        public DbSet<GameInfoHistory> gameInfoHistory { get; set; }
    }

}
