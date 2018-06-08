using UnityEditor;
using System.Text;
using System.Linq;

public class SceneNameConstanter : ConstanterBase
{
    const string MENU_ITEM_NAME = MENU_ITEM_ROOT + CLASS_NAME;
    const string CLASS_NAME = "SceneName";

    [MenuItem(MENU_ITEM_NAME)]
    public static void Create(){

        if (!CanCreate) return;

        Create( CLASS_NAME , "シーン名を定数化します。" , Content );

        EditorUtility.DisplayDialog(CLASS_NAME, "シーン名の定数化が完了しました。", "OK");

    }

    /// <summary>
    /// 与えられたパスからシーン名の部分を抜き出します。
    /// </summary>
    /// <param name="path">シーンのパス</param>
    /// <returns></returns>
    public static string GetSceneName( string path )
    {
        int start = path.LastIndexOf('/');
        int end = path.LastIndexOf('.');
        return path.Substring( start + 1, (end - start) - 1 );
    }

    public static string Content {
        get
        {
            var sb = new StringBuilder();
            foreach (var n in EditorBuildSettings.scenes.Where( s => s.enabled ).Select(s => RemoveInvalidCharacters(GetSceneName(s.path) ) ))
            {
                sb.Append("\t").AppendFormat(@"public const string {0} = ""{0}"";", n).AppendLine();
            }
            return sb.ToString();
        }
    }

}
