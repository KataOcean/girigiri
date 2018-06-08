using UnityEditor;
using System.Text;
using UnityEditorInternal;
using System.Linq;

public class TagConstanter : ConstanterBase
{
    const string MENU_ITEM_NAME = MENU_ITEM_ROOT + CLASS_NAME;
    const string CLASS_NAME = "Tag";

    [MenuItem(MENU_ITEM_NAME)]
    public static void Create(){

        if (!CanCreate) return;

        Create( CLASS_NAME , "タグを定数化します。" , Content );

        EditorUtility.DisplayDialog(CLASS_NAME, "タグの定数化が完了しました。", "OK");

    }

    public static string Content {
        get
        {
            var sb = new StringBuilder();
            foreach (var n in InternalEditorUtility.tags.Select(s => RemoveInvalidCharacters(s)))
            {
                sb.Append("\t").AppendFormat(@"public const string {0} = ""{0}"";", n).AppendLine();
            }
            return sb.ToString();
        }
    }

}
