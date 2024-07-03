﻿using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace PunctualSolutionsTool.Tool
{
    public static class WindowTool
    {
        [DllImport("user32.dll", EntryPoint = "FindWindowW", CharSet = CharSet.Unicode)]
        private static extern IntPtr FindWindowW(string lpClassName, string lpWindowName);

        private const uint SwpShowWindow = 0x0040;

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        public static void SetResolution(int width, int height, int posX = 0, int posY = 0)
        {
            var hWnd = FindWindowW(null, Application.productName);
            if (hWnd == IntPtr.Zero) return;
            SetWindowPos(hWnd, 0, posX, posY, width, height, SwpShowWindow);
        }
    }
}