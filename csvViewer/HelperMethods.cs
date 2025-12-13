using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csvViewer
{
    public static class HelperMethods
    {
        public static void openDialog(string title, string message, Form mainForm)
        {
            CustomMessageBox dialog = new CustomMessageBox(title, message);
            dialog.StartPosition = FormStartPosition.Manual;

            dialog.Location = new Point(
                mainForm.Left + (mainForm.Width - dialog.Width) / 2,
                mainForm.Top + (mainForm.Height - dialog.Height) / 2
            );
            dialog.ShowDialog(mainForm);
        }
    }
}
