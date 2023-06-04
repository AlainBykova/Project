using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_AP
{
    internal class GetRightSizes
    {
        public List<int> FindNeededSizes(int parentWidth, int parentHeight, int childWidth, int childHeight)
        {
            List<int> properties = new();

            double width = ((double)parentWidth / childWidth);
            double height = ((double)parentHeight / childHeight);
            double minValue = Math.Min(width, height);
            int widthLoc = (int)Math.Round(childWidth * minValue);
            int heightLoc = (int)Math.Round(childHeight * minValue);
            properties.Add(widthLoc);
            properties.Add(heightLoc);
            return properties;
        }
        public List<int> FindNeededSizes2(int panelWidth, int panelHeight, int truepanelWidth, int truepanelHeight, int rW, int rH, bool flag)
        {
            int rackWidth;
            int rackHeight;
            if (flag == true)
            {
                rackWidth = rH;
                rackHeight = rW;
            }
            else
            {
                rackWidth = rW;
                rackHeight = rH;
            }
            int width1 = (int)(((double)rackWidth / truepanelWidth) * panelWidth);
            int height1 = (int)(((double)rackHeight / truepanelHeight) * panelHeight);
            List<int> prop = new();
            prop.Add(width1);
            prop.Add(height1);
            return prop;
        }
    }
}
