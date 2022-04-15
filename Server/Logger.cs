﻿using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    internal class Logger
    {
        public bool active = false;
        private const string LOGS_DIR_PATH = @"..\..\Logs";
        StreamWriter streamWriter;
        private string currentLogSessionFilePath;
        private string startingDateTime;

        public void StartSession()
        {
            active = true;
            startingDateTime = DateTime.Now.ToString();
            File.Create(LOGS_DIR_PATH + $@"\{startingDateTime}-....txt");
            currentLogSessionFilePath = $@"{LOGS_DIR_PATH}\{startingDateTime}-....txt";
            streamWriter = new StreamWriter(currentLogSessionFilePath);
        }

        public void StopSession()
        {
            active = false;
            streamWriter.Close();
            FileSystem.RenameFile(currentLogSessionFilePath, $@"{startingDateTime}-{DateTime.Now}.txt");
            currentLogSessionFilePath = "";
            startingDateTime = null;
        }

        public void AddLog()
        {

        }
    }
}
