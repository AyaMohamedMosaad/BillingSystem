using System.Drawing;
using System.Windows.Forms;

namespace BillingSystem.CustomControl
{
    public partial class ctl_CircularAvater : UserControl
    {
        public ctl_CircularAvater()
        {
            InitializeComponent();
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, picAvatar.Width, picAvatar.Height);
            picAvatar.Region = new Region(path);
        }
    }
}
