using UnityEngine;
using UnityEditor;
using System.Text;
using UnityEditorInternal;
using System.Linq;

public class LayerNameConstanter : ConstanterBase
{
    const string MENU_ITEM_NAME = MENU_ITEM_ROOT + CLASS_NAME;
    const string CLASS_NAME = "LayerName";

    [MenuItem(MENU_ITEM_NAME)]
    public static void Create(){

        if (!CanCreate) return;

        Create( CLASS_NAME , "レイヤー名を定数化します。" , Content );

        EditorUtility.DisplayDialog(CLASS_NAME, "レイヤーの定数化が完了しました。", "OK");

    }

    public static string Content {
        get
        {
            var sb = new StringBuilder();
            foreach (var n in InternalEditorUtility.layers.Select(s => new { name = RemoveInvalidCharacters(s), val = LayerMask.NameToLayer(s) }))
            {
                sb.Append("\t").AppendFormat(@"public const int {0} = {1};", n.name, n.val).AppendLine();
            }
            foreach (var n in InternalEditorUtility.layers.Select(s => new { name = RemoveInvalidCharacters(s), val = 1 << LayerMask.NameToLayer(s) }))
            {
                sb.Append("\t").AppendFormat(@"public const int {0}Mask = {1};", n.name, n.val).AppendLine();
            }
            return sb.ToString();
        }
    }

}
