using SistemaContable.Forms; 
using System;
using System.Windows.Forms;

namespace SistemaContable
{
    internal class Program
    {
        [STAThread] 
        static void Main()
        {
            // Iniciar la aplicación de Windows Forms
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm()); 
        }
    }
}
