using Microsoft.VisualBasic.ApplicationServices;
using ProductCatalog.Service;

namespace ProductCatalog
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            /*MessageBox.Show("UserRoles list:");
            using (DbContextService db = new DbContextService())
            {
                // получаем объекты из бд и выводим на консоль
                var users = db.users.ToList();
                MessageBox.Show("UserRoles list:");
                foreach (Model.UserModel u in users)
                {
                    MessageBox.Show($"{u.id}.{u.name}");
                }
            }
            */

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}