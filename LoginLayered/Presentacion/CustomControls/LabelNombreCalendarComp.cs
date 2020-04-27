using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.CustomControls
{
    public partial class LabelNombreCalendarComp : UserControl
    {
        public LabelNombreCalendarComp()
        {
            InitializeComponent();
        }

        private void LabelNombreCalendarComp_Paint(object sender, PaintEventArgs e)
        {
            Graphics l = e.Graphics;
            Pen p = new Pen(Color.Red, 5);
            l.DrawEllipse(p, 50, 50, 200, 200);
            l.Dispose();
        }
    }
}
