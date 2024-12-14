using UnityEditor;

public static class BuildScript
{
    public static void BuildAndroidDebug()
    {
        string[] scenes = { "Assets/Scenes/Main.unity" }; // Add your scenes
        string buildPath = "D:\\UnityBuilds\\Builds\\Android/Tic-Tac-Toe.apk"; // Output APK path for debug build
        BuildPlayerOptions buildOptions = new BuildPlayerOptions
        {
            scenes = scenes,
            locationPathName = buildPath,
            target = BuildTarget.Android,
            options = BuildOptions.Development | BuildOptions.AllowDebugging  // Debug build options
        };
        BuildPipeline.BuildPlayer(buildOptions);
    }
}
