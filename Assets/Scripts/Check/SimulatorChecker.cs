using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SimulatorChecker
{
    /// <summary>
    /// 获取设备固件版本号
    /// </summary>
    /// <returns></returns>
    private static string GetAndroidRadioVersion()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass buildClass = new AndroidJavaClass("android.os.Build");
            string radioVersion = buildClass.CallStatic<string>("getRadioVersion");
            return radioVersion;
        }
        
        return "No";
    }

    public static bool IsRunningOnSimulator()
    {
        // 只判断安卓平的模拟器
        if (Application.platform != RuntimePlatform.Android)
        {
            return false;
        }
        
        var radioVersion = GetAndroidRadioVersion();
        if (string.IsNullOrEmpty(radioVersion))
        {
            Debug.Log($"SimulatorChecker check radio version success");
            return true;
        }

        if (SystemInfo.graphicsDeviceID == 0 && SystemInfo.graphicsDeviceVendorID == 0)
        {
            Debug.Log($"SimulatorChecker check graphics id success");
            return true;
        }
        
        Debug.Log($"SimulatorChecker check {radioVersion} {SystemInfo.graphicsDeviceID} {SystemInfo.graphicsDeviceVendorID}");

        return false;
    }
}
