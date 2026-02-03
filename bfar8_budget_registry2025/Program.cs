using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.WinForms.Helpers.GraphicsHelper;
using System.Text;


namespace bfar8_budget_registry2025
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // ✅ ADD THIS LINE (VERY IMPORTANT FOR EXCEL)
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new dashboard());
        }
    }
}
