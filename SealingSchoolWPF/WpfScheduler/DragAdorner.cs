using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfScheduler
{
    public class DragAdorner : Adorner
    {
        double XCenter, YCenter;
        UIElement _child;
        UIElement _owner;

        public DragAdorner(UIElement owner, UIElement adornElement, bool useVisualBrush, double opacity)
            : base(owner)
        {
            _owner = owner;
            if (useVisualBrush)
            {
                VisualBrush _brush = new VisualBrush(adornElement);
                _brush.Opacity = opacity;
                Rectangle r = new Rectangle();
                r.RadiusX = 3;
                r.RadiusY = 3;
                r.Width = adornElement.DesiredSize.Width;
                r.Height = adornElement.DesiredSize.Height;

                XCenter = adornElement.DesiredSize.Width / 2;
                YCenter = adornElement.DesiredSize.Height / 2;

                r.Fill = _brush;
                _child = r;

            }
            else
                _child = adornElement;

        }
    }
}
