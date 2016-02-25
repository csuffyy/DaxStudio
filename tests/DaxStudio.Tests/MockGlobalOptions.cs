﻿using DaxStudio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;

namespace DaxStudio.Tests
{
    class MockGlobalOptions : IGlobalOptions
    {
        public bool EditorEnableIntellisense { get; set; }

        public string EditorFontFamily { get; set; }

        public double EditorFontSize { get; set; }

        public bool EditorShowLineNumbers { get; set; }

        public string ProxyAddress {get; set;}

        public SecureString ProxySecurePassword { get; set; }

        public string ProxyUser { get; set; }

        public bool ProxyUseSystem { get; set; }

        public int QueryHistoryMaxItems { get; set; }

        public bool QueryHistoryShowTraceColumns { get; set; }
    }
}
