﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Client
{
    public class ChartTimeAxis : Control
    {
        private static readonly Color BACKGROUND_COLOR = Color.PeachPuff;
        private ClientChart chart;

        public ChartTimeAxis(ClientChart chart)
        {
            this.chart = chart;
            Parent = chart;
            Width = 60;
            Height = chart.Height - ClientChart.BORDER_THICKNESS * 2 - 90;
            Top = ClientChart.BORDER_THICKNESS + 90;
            Left = ClientChart.BORDER_THICKNESS;
            BackColor = BACKGROUND_COLOR;
            DoubleBuffered = true;

            chart.Controls.Add(this);
            Show();

            Paint += ChartTimeAxis_Paint;
        }

        private void ChartTimeAxis_Paint(object sender, PaintEventArgs e)
        {
            DrawTimeStamps(e);
        }

        private void DrawTimeStamps(PaintEventArgs e)
        {
            if (chart.timeStamps.Count > 0)
            {
                Brush brush = new SolidBrush(Color.Black);
                Font font = new Font(ClientChart.TEXT_FONT_FAMILY, 10);
                List<PointF> stampPoints = new List<PointF>();

                for (int i = 0; i < chart.timeStamps.Count; i++)
                {
                    PointF tsPoint = new PointF();

                    if (stampPoints.Count == 0)
                    {
                        tsPoint.X = 2;
                        tsPoint.Y = Height - 22;
                    }
                    else
                    {
                        tsPoint.X = 2;
                        tsPoint.Y = stampPoints[i - 1].Y - ClientChart.AXIS_Y_DEFAULT_STEP * chart.zoomCoeff;
                    }
                    stampPoints.Add(tsPoint);
                }

                for (int i = 0; i < chart.timeStamps.Count; i++)
                {
                    e.Graphics.DrawString(chart.timeStamps[i], font, brush, stampPoints[i]);
                }

                //for (int i = 0; i < chart.timeStamps.Count; i++)
                //{
                //    stampPoint.X = 2;
                //    stampPoint.Y = Height - (chart.timeStamps.Count - i) * (ClientChart.AXIS_Y_DEFAULT_STEP * chart.zoomCoeff) - 5;
                //    e.Graphics.DrawString(chart.timeStamps[i], font, brush, stampPoint);
                //}
            }
        }
    }
}
