using UnityEditor;
using System.IO;

public class BuildAssetBundles
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllBundles()
    {
        string path = "Assets/AssetBundles";
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}