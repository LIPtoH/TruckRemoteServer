﻿using System;
using System.Runtime.InteropServices;
using vJoyInterfaceWrap;

namespace TruckRemoteServer
{
    public static class InputEmulator
    {
        private static vJoy joyStick;
        private static uint joyId = 1;

        public static bool IsJoyInitialized()
        {
            return joyStick != null;
        }

        public static bool InitJoy()
        {
            joyStick = new vJoy();
            VjdStat status = joyStick.GetVJDStatus(joyId);

            if ((status == VjdStat.VJD_STAT_OWN) || ((status == VjdStat.VJD_STAT_FREE) && (!joyStick.AcquireVJD(joyId))))
            {
                Console.WriteLine("Failed to acquire vJoy device number {0}.\n", joyId);
                return false;
            }
            else
            {
                Console.WriteLine("Acquired: vJoy device number {0}.\n", joyId);
                joyStick.ResetVJD(joyId);
                return true;
            }
        }

        public static void ReleaseJoy()
        {
            if(joyStick != null)
            {
                joyStick.RelinquishVJD(joyId);
            }
        }

        public static void SetXAxis(int xAxisValue)
        {
            //xAxisValue can be from 0 to 32768
            joyStick.SetAxis(xAxisValue, joyId, HID_USAGES.HID_USAGE_X);
        }

        public static void KeyClick(short[] scanCode)
        {
            KeyPress(scanCode);
            KeyRelease(scanCode);
        }

        public static void KeyPress(short[] scanCode) 
        {
            INPUT input = new INPUT();
            input.type = (int)InputType.INPUT_KEYBOARD;
            input.ki.dwFlags = (int)KEYEVENTF.SCANCODE;
            input.ki.wScan = scanCode[1];

            bool extended = Convert.ToBoolean(scanCode[0]);
            if (extended)            
                input.ki.dwFlags = (int)KEYEVENTF.SCANCODE | (int)KEYEVENTF.EXTENDEDKEY; //For extended scan codes

            INPUT[] pInputs = new INPUT[] { input };

            SendInput((uint)pInputs.Length, pInputs, Marshal.SizeOf(input));
        }

        public static void KeyRelease(short[] scanCode)
        {
            INPUT input = new INPUT();
            input.type = (int)InputType.INPUT_KEYBOARD;
            input.ki.dwFlags = (int)KEYEVENTF.KEYUP | (int)KEYEVENTF.SCANCODE;
            input.ki.wScan = scanCode[1];

            bool extended = Convert.ToBoolean(scanCode[0]);
            if (extended)            
                input.ki.dwFlags = (int)KEYEVENTF.KEYUP | (int)KEYEVENTF.EXTENDEDKEY; //For extended scan codes

            INPUT[] pInputs = new INPUT[] { input };

            SendInput((uint)pInputs.Length, pInputs, Marshal.SizeOf(input));
        }




        /*................................................................................................*/
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        [StructLayout(LayoutKind.Explicit)]
        public struct INPUT
        {
            [FieldOffset(4)]
            public HARDWAREINPUT hi;
            [FieldOffset(4)]
            public KEYBDINPUT ki;
            [FieldOffset(4)]
            public MOUSEINPUT mi;
            [FieldOffset(0)]
            public int type;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public short wVk;
            public short wScan;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
        {
            public int uMsg;
            public short wParamL;
            public short wParamH;
        }

        [Flags]
        public enum InputType
        {
            INPUT_MOUSE = 0,
            INPUT_KEYBOARD = 1,
            INPUT_HARDWARE = 2
        }

        [Flags]
        public enum MOUSEEVENTF
        {
            MOVE = 0x0001, /* mouse move */
            LEFTDOWN = 0x0002, /* left button down */
            LEFTUP = 0x0004, /* left button up */
            RIGHTDOWN = 0x0008, /* right button down */
            RIGHTUP = 0x0010, /* right button up */
            MIDDLEDOWN = 0x0020, /* middle button down */
            MIDDLEUP = 0x0040, /* middle button up */
            XDOWN = 0x0080, /* x button down */
            XUP = 0x0100, /* x button down */
            WHEEL = 0x0800, /* wheel button rolled */
            MOVE_NOCOALESCE = 0x2000, /* do not coalesce mouse moves */
            VIRTUALDESK = 0x4000, /* map to entire virtual desktop */
            ABSOLUTE = 0x8000 /* absolute move */
        }

        [Flags]
        public enum KEYEVENTF
        {
            EXTENDEDKEY = 0x0001,
            KEYUP = 0x0002,
            UNICODE = 0x0004,
            SCANCODE = 0x0008,
        }
    }
}