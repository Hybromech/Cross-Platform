using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
//! Handles project builds
public class BuildScript
{
    const string filename = "Ball_Runner";
    public static void BuildProject()
    {
        //Names the build based on the current date.
        string asset_folder_path = Application.dataPath;
        string filename = asset_folder_path + "../../Artifacts/BuildMe.exe";

        //Must specify scenes manually
        EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
        string[] levels = scenes.Select(s => s.path).ToArray();

        var cmds = System.Environment.GetCommandLineArgs();

        bool build_windows = true;
        bool build_android = true;

        for (int i = 0; i < cmds.Length; i++)
        {
            //If platform switch is set
            if (cmds[i] == "platforms")
            {
                build_windows = false;
                build_android = false;
                //Check for platforms
                for (; i < cmds.Length; ++i)
                {
                    if (cmds[i] == "win")
                    {
                        build_windows = true;
                    }
                    else if (cmds[i] == "android")
                    {
                        build_android = true;
                    }
                }
            }
            if (build_windows)
                BuildWindows(levels, asset_folder_path);
            if (build_android)
                BuildAndroid(levels, asset_folder_path);
        }
    }

    /**
    @brief Build game for windows
    @param string[], string
    @return void 
    */
    static internal void BuildWindows(string[] levels, string path)
    {
        var version = PlayerSettings.bundleVersion;
        string filename = path + "../../Artifacts/"+ version + "/" + BuildScript.filename + "_" + version + ".exe";
        //builds the player for windows.
        BuildPipeline.BuildPlayer(levels, filename, BuildTarget.StandaloneWindows, BuildOptions.None);
    }
    /**
    @brief Build game for android
    @param string[], string
    @return void 
    */
    static internal void BuildAndroid(string[] levels, string path)
    {
        var version = PlayerSettings.bundleVersion;
        string filename = path + "../../ArtifactsAndroid/" + BuildScript.filename + "_" + version + ".apk";
        //builds the player for windows.
        BuildPipeline.BuildPlayer(levels, filename, BuildTarget.Android, BuildOptions.None);
    }
}














//using UnityEditor;
//using UnityEngine;
//using UnityEditor.Build.Reporting;

//// Output the build size or a failure depending on BuildPlayer.

//public class BuildPlayerExample : MonoBehaviour
//{
//    [MenuItem("Build/Build iOS")]
//    public static void MyBuild()
//    {
//        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
//        buildPlayerOptions.scenes = new[] { "Credits.unity", "Help_menu.unity", "Main_menu.unity", "Scene6.unity" };
//        buildPlayerOptions.locationPathName = "iOSBuild";
//        buildPlayerOptions.target = BuildTarget.iOS;
//        buildPlayerOptions.options = BuildOptions.None;

//        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
//        BuildSummary summary = report.summary;

//        if (summary.result == BuildResult.Succeeded)
//        {
//            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
//        }

//        if (summary.result == BuildResult.Failed)
//        {
//            Debug.Log("Build failed");
//        }
//    }
//}



