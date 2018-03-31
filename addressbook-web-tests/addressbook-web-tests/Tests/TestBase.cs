﻿using System;
using System.Text;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHECKS = false;
        protected ApplicationManager manager;
        public static Random rnd = new Random();
        [SetUp]
        public void SetupApplicationManager()
        {
            manager = ApplicationManager.GetInstance();
        }

        public static string GenerateRandomString(int max)
        {
            
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }
    }
}