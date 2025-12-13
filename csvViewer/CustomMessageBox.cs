using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace csvViewer
{
    public class CustomMessageBox : Form
    {
        private Label _label;
        private Button _okButton;

        public CustomMessageBox(string title, string message)
        {
            //Window behavior
            Text = title;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ControlBox = true;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            TopMost = true;

            ClientSize = new Size(150, 150);

            _label = new Label
            {
                Text = String.IsNullOrEmpty(message) ? "No data" : message,
                Location = new Point(10, 10),
                Size = new Size(ClientSize.Width - 15, ClientSize.Height - 60),
                Font = new Font(
                    "Segoe UI",
                    11f,
                    FontStyle.Regular
                    ),
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(10)
            };

            _okButton = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Anchor = AnchorStyles.Bottom,
                Size = new Size(80, 28),
                Location = new Point((ClientSize.Width - 80) / 2, ClientSize.Height - 40)
            };

            Controls.Add(_label);
            Controls.Add(_okButton);
            _okButton.BringToFront();
            AcceptButton = _okButton;
        }
    }
}
