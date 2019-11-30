﻿using System;

namespace TruckRemoteServer
{
    class PCController
    {
        public static int Sensitivity = 30;

        private int prevMovement;

        //Controller
        private bool prevBreakClicked, prevGasClicked;
        private bool prevLeftSignal, prevRightSignal;
        private bool wasParkingBreakEnabled;
        private int prevLightsState;
        private bool prevHornState;

        private int lastConditionNumber = -1;

        private const int DIK_S_SCAN = 0x1F;
        private byte DIK_W_SCAN = 0x11;
        private byte DIK_OPEN_BRACKET_SCAN = 0x1A;
        private byte DIK_CLOSE_BRACKET_SCAN = 0x1B;
        private byte DIK_F_SCAN = 0x21;
        private byte DIK_SPACE_SCAN = 0x39;
        private byte DIK_L_SCAN = 0x26;
        private byte DIK_K_SCAN = 0x25;
        private byte DIK_H_SCAN = 0x23;

        //Panel
        private bool prevDiffBlock;
        private int prevWipersState;
        private bool prevLiftingAxle;
        private bool prevFlashingBeacon;

        private const int DIK_V_SCAN = 0x2F;
        private const int DIK_P_SCAN = 0x19;
        private const int DIK_U_SCAN = 0x16;
        private const int DIK_O_SCAN = 0x18;


        /* Controller */
        public void initializeJoy()
        {
            InputEmulator.InitJoy();
        }

        public void setControllerStartValues(bool leftSignal, bool rightSignal, bool isParking, int lightsState)
        {
            prevLeftSignal = leftSignal;
            prevRightSignal = rightSignal;
            wasParkingBreakEnabled = isParking;
            prevLightsState = lightsState;
        }

        public void updateAccelerometerValue(double accelerometerValue)
        {
            int xAxisValue;
            if(accelerometerValue < 0)
            {
                xAxisValue = 16384 - (int) (Math.Abs(accelerometerValue) / 10 * Sensitivity);
            } else
            {
                xAxisValue = 16384 + (int) (Math.Abs(accelerometerValue) / 10 * Sensitivity);
            }
            InputEmulator.MoveTo(xAxisValue);
        }

        public void updateBreakGasState(bool breakClicked, bool gasClicked)
        {
            if (breakClicked != prevBreakClicked)
            {
                if (breakClicked)
                {
                    InputEmulator.KeyPress(DIK_S_SCAN);
                }
                else
                {
                    InputEmulator.KeyRelease(DIK_S_SCAN);
                }
                prevBreakClicked = breakClicked;
            }
            //Gas
            if (gasClicked != prevGasClicked)
            {
                if (gasClicked)
                {
                    InputEmulator.KeyPress(DIK_W_SCAN);
                }
                else
                {
                    InputEmulator.KeyRelease(DIK_W_SCAN);
                }
                prevGasClicked = gasClicked;
            }
        }

        public void updateTurnSignals(bool leftSignal, bool rightSignal)
        {
            //All was disabled
            if (!prevLeftSignal && !prevRightSignal)
            {
                //Enabling emergency signal
                if (leftSignal && rightSignal)
                {
                    if (lastConditionNumber != 0)
                    {
                        toggleEmergencySignal();
                        lastConditionNumber = 0;
                    }
                }
                //Enabling left
                else if (leftSignal)
                {
                    if (lastConditionNumber != 1)
                    {
                        toggleLeftTurnSignal();
                        lastConditionNumber = 1;
                    }
                }
                //Enabling right
                else if (rightSignal)
                {
                    if (lastConditionNumber != 2)
                    {
                        toggleRightTurnSignal();
                        lastConditionNumber = 2;
                    }
                }

            }
            //All was enabled
            else if (prevLeftSignal && prevRightSignal)
            {
                //Disabling emergency signal
                if (!leftSignal && !rightSignal)
                {
                    if (lastConditionNumber != 3)
                    {
                        toggleEmergencySignal();
                        lastConditionNumber = 3;
                    }
                }
            }
            //Left was enabled
            else if (prevLeftSignal)
            {
                //Enabling emergency signal with disabling turn signal
                if (leftSignal && rightSignal)
                {
                    if (lastConditionNumber != 4)
                    {
                        toggleLeftTurnSignal();
                        toggleEmergencySignal();
                        lastConditionNumber = 4;
                    }
                }
                //Enabling right
                else if (rightSignal)
                {
                    if (lastConditionNumber != 5)
                    {
                        toggleRightTurnSignal();
                        lastConditionNumber = 5;
                    }
                }
                //Disabling left
                else if (!leftSignal)
                {
                    if (lastConditionNumber != 6)
                    {
                        toggleLeftTurnSignal();
                        lastConditionNumber = 6;
                    }
                }
            }
            //Right was enabled
            else
            {
                if (leftSignal && rightSignal)
                {
                    if (lastConditionNumber != 7)
                    {
                        toggleRightTurnSignal();
                        toggleEmergencySignal();
                        lastConditionNumber = 7;
                    }
                }
                else if (leftSignal)
                {
                    if (lastConditionNumber != 8)
                    {
                        toggleLeftTurnSignal();
                        lastConditionNumber = 8;
                    }
                }
                else if (!rightSignal)
                {
                    if (lastConditionNumber != 9)
                    {
                        toggleRightTurnSignal();
                        lastConditionNumber = 9;
                    }
                }
            }

            prevLeftSignal = leftSignal;
            prevRightSignal = rightSignal;
        }

        private void toggleLeftTurnSignal()
        {
            InputEmulator.KeyClick(DIK_OPEN_BRACKET_SCAN);
        }

        private void toggleRightTurnSignal()
        {
            InputEmulator.KeyClick(DIK_CLOSE_BRACKET_SCAN);
        }

        private void toggleEmergencySignal()
        {
            InputEmulator.KeyClick(DIK_F_SCAN);
        }

        public void updateParkingBrake(bool isParkingBrakeEnabled)
        {
            if (wasParkingBreakEnabled != isParkingBrakeEnabled)
            {
                wasParkingBreakEnabled = isParkingBrakeEnabled;
                InputEmulator.KeyClick(DIK_SPACE_SCAN);
            }
        }

        public void updateLights(int lightsState)
        {
            if(lightsState != prevLightsState)
            {
                prevLightsState = lightsState;

                switch(lightsState)
                {
                    case 0:
                        InputEmulator.KeyClick(DIK_K_SCAN);
                        InputEmulator.KeyClick(DIK_L_SCAN);
                        break;
                    case 1:
                        InputEmulator.KeyClick(DIK_L_SCAN);
                        break;
                    case 2:
                        InputEmulator.KeyClick(DIK_L_SCAN);
                        break;
                    case 3:
                        InputEmulator.KeyClick(DIK_K_SCAN);
                        break;
                }
            }
        }

        public void updateHorn(bool isHorn)
        {
            if(isHorn != prevHornState)
            {
                if(isHorn)
                {
                    InputEmulator.KeyPress(DIK_H_SCAN);
                } else
                {
                    InputEmulator.KeyRelease(DIK_H_SCAN);
                    Console.WriteLine("released H");
                }
                prevHornState = isHorn;
            }
        }

        private int getNewCursorOffset(double accelerometerValue)
        {
            return (int)(accelerometerValue * (Sensitivity * 1.5));
        }

        /* Panel */
        public void setPanelStartValues(bool diffBlock, int wipersState, bool liftingAxle, bool flashingBeacon)
        {
            prevDiffBlock = diffBlock;
            prevWipersState = wipersState;
            prevLiftingAxle = liftingAxle;
            prevFlashingBeacon = flashingBeacon;
        }

        public void updateDiffBlock(bool diffBlock)
        {
            if(prevDiffBlock != diffBlock)
            {
                prevDiffBlock = diffBlock;
                InputEmulator.KeyClick(DIK_V_SCAN);
            }
        }

        public void updateWipers(int wipersState)
        {
            if (prevWipersState != wipersState)
            {
                prevWipersState = wipersState;
                InputEmulator.KeyClick(DIK_P_SCAN);
            }
        }

        public void updateLiftingAxle(bool liftingAxle)
        {
            if (prevLiftingAxle != liftingAxle)
            {
                prevLiftingAxle = liftingAxle;
                InputEmulator.KeyClick(DIK_U_SCAN);
            }
        }

        public void updateFlashingBeacon(bool flashingBeacon)
        {
            if (prevFlashingBeacon != flashingBeacon)
            {
                prevFlashingBeacon = flashingBeacon;
                InputEmulator.KeyClick(DIK_O_SCAN);
            }
        }
    }
}