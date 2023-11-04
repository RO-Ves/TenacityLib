using GorillaNetworking;
using HarmonyLib;
using UnityEngine;
using Valve.VR;
using CommonUsages = UnityEngine.XR.CommonUsages;

namespace TenacityLib
{
    public class ControllerInputManager : MonoBehaviour
    {
        public static bool leftGrip, rightGrip, leftTrigger, rightTrigger, leftPrimary, rightPrimary, rightAxis2DClick, leftAxis2DClick;
        public static Vector2 leftAxis2D, rightAxis2D;

        void Update()
        {
            leftGrip = ControllerInputPoller.instance.leftGrab;
            rightGrip = ControllerInputPoller.instance.rightGrab;
            leftPrimary = ControllerInputPoller.instance.leftControllerPrimaryButton;
            rightPrimary = ControllerInputPoller.instance.rightControllerPrimaryButton;
            rightAxis2D = ControllerInputPoller.instance.rightControllerPrimary2DAxis;

            bool IsSteamVR = Traverse.Create(PlayFabAuthenticator.instance).Field("platform").GetValue().ToString().ToLower() == "steam";

            if (IsSteamVR)
            {
                leftAxis2D = SteamVR_Actions.gorillaTag_LeftJoystick2DAxis.GetAxis(SteamVR_Input_Sources.LeftHand);
                rightAxis2DClick = SteamVR_Actions.gorillaTag_RightJoystickClick.GetState(SteamVR_Input_Sources.RightHand);
                leftAxis2DClick = SteamVR_Actions.gorillaTag_LeftJoystickClick.GetState(SteamVR_Input_Sources.LeftHand);
                leftTrigger = SteamVR_Actions.gorillaTag_LeftTriggerClick.GetState(SteamVR_Input_Sources.LeftHand);
                rightTrigger = SteamVR_Actions.gorillaTag_RightTriggerClick.GetState(SteamVR_Input_Sources.RightHand);
            }
            else
            {
                ControllerInputPoller.instance.leftControllerDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out leftAxis2D);
                ControllerInputPoller.instance.rightControllerDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out rightAxis2DClick);
                ControllerInputPoller.instance.leftControllerDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out leftAxis2DClick);
                ControllerInputPoller.instance.rightControllerDevice.TryGetFeatureValue(CommonUsages.triggerButton, out rightTrigger);
                ControllerInputPoller.instance.leftControllerDevice.TryGetFeatureValue(CommonUsages.triggerButton, out leftTrigger);
            }
        }
    }
}
