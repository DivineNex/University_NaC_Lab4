﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Client
{
    public class ChartSerie : Control
    {
        private ClientChart chart;

        public ClientChart Chart
        {
            get { return chart; }
        }

        public readonly string name;
        private Param param;
        private List<PointF> allPoints;
        public Color color;
        Random random = new Random();
        public ChartInfoPanelSerie seriePanel;
        public float maxValue;
        public float minValue;
        public float intervalCoeff;
        public int lineThickness = 1;

        public List<PointF> Points
        {
            get { return allPoints; }
        }

        public ChartSerie(Param param, ClientChart chart)
        {
            if (param.Interval < chart.minInterval)
                chart.minInterval = param.Interval;

            intervalCoeff = param.Interval / 1000;

            Width = chart.Width - ClientChart.BORDER_THICKNESS * 2;
            Height = chart.drawArea.Height - ClientChart.BORDER_THICKNESS * 2;
            Left = ClientChart.BORDER_THICKNESS;
            Top = ClientChart.BORDER_THICKNESS;
            allPoints = new List<PointF>();
            this.param = param;
            this.chart = chart;
            name = param.Name;
            minValue = param.MinValue;
            maxValue = param.MaxValue;
            color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

            seriePanel = new ChartInfoPanelSerie(this, chart.infoPanel);
            
            InitSerieSettingsPanel();
        }

        public void AddPoint(float x, float y)
        {
            //if (param.Interval == chart.minInterval)
            //{
            //    foreach (var serie in chart.Series)
            //    {
            //        for (int i = 0; i < serie.Points.Count; i++)
            //        {
            //            PointF interPoint = serie.Points[i];
            //            interPoint.Y -= ClientChart.AXIS_Y_DEFAULT_STEP;
            //            serie.Points[i] = interPoint;
            //        }
            //    }
            //}

            float interpolatedX = InterpolateX(param.MinValue, 20, param.MaxValue, chart.drawArea.Width - 35, x);
            allPoints.Add(new PointF(interpolatedX, y));
        }

        public void InitSerieSettingsPanel()
        {
            ChartSettingsSeriePanel seriePanel = new ChartSettingsSeriePanel(chart, this);
        }

        private float InterpolateX(float x1, float y1, float x2, float y2, float x)
        {
            return y1 + (y2 - y1) * (x - x1) / (x2 - x1);
        }
    }
}
