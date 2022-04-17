﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Modules
{
    internal class Param
    {
        public readonly string name;
        Timer timer;
        Random random;
        private int interval;

        public double Interval
        {
            get { return interval; }
        }

        private double minValue;

        public double MinValue
        {
            get { return minValue; }
        }

        private double maxValue;

        public double MaxValue
        {
            get { return maxValue; }
        }

        private bool isInteger;
        public GenerationModule gm;
        public RegistrationModule rm;

        private double value;
        public double Value
        {
            get { return value; }
            set { this.value = value; }
        }

        private bool active = false;
        public bool Active
        {
            get { return active; }
            set { active = value; timer.Enabled = value; }
        }

        public Param(string name, int interval, double minValue, double maxValue, bool isInteger)
        {
            this.interval = interval;
            this.name = name;
            timer = new Timer(interval);
            random = new Random();
            timer.Elapsed += Timer_Elapsed;
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.isInteger = isInteger;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Generate();
        }

        private void Generate()
        {
            if (isInteger)
                value = random.Next(Convert.ToInt32(minValue), Convert.ToInt32(maxValue));
            else
                value = Math.Round(random.NextDouble() * (maxValue - minValue) + minValue, 3);

            //Улучшится при новой системе логирования
            //Console.WriteLine("Сгенерирован: " + name + " = " + value);

            SendToServer($"{this.name} = {this.value}");
        }

        private void SendToServer(string param)
        {
            rm.SendParam(param);
        }
    }
}
