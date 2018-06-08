using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// マルチシーンエディティング機能を用いてシーンの読み込み回りを行うクラスです。
/// 新たにシーンの読み込み等を行う場合は、Unity標準のSceneManagerではなく、このクラスのメソッドを用いて下さい。
/// </summary>
public static class SceneLoader
{

    /// <summary>
    /// 引数として取ったシーン名のシーンをアクティブ状態にします。
    /// </summary>
    /// <param name="name">アクティブにするシーン名</param>
    public static void SetActive( string name)
    {
        var scene = SceneManager.GetSceneByName(name);
        if (scene.isLoaded)
        {

            SceneManager.SetActiveScene(scene);

        }

    }

    /// <summary>
    /// シーンの上書きを行います。基本的には使用しません。
    /// </summary>
    /// <param name="name">上書きするシーン名</param>
    public static void Replace( string name)
    {

        SceneManager.LoadScene(name, LoadSceneMode.Single);

    }

    /// <summary>
    /// シーンを追加します。
    /// </summary>
    /// <param name="name">追加するシーン</param>
    public static void Add( string name)
    {

        if ( !SceneManager.GetSceneByName( name ).isLoaded)
        {

            SceneManager.LoadScene( name , LoadSceneMode.Additive );
        }

    }

    /// <summary>
    /// 既に読み込まれたシーンを削除します。
    /// </summary>
    /// <param name="name">削除するシーン</param>
    public static void Remove( string name )
    {
        if (SceneManager.GetSceneByName(name).isLoaded)
        {

            SceneManager.UnloadSceneAsync(name);

        }

    }

    /// <summary>
    /// オブジェクトのシーン間移動を行います。
    /// </summary>
    /// <param name="obj">移動するオブジェクト</param>
    /// <param name="name">移動先シーン</param>
    public static void MoveGameObject(GameObject obj , string name)
    {
        var scene = SceneManager.GetSceneByName(name);
        if (scene.isLoaded && !obj.scene.name.Equals( name) ) {

            SceneManager.MoveGameObjectToScene(obj,scene);

        }

    }

    /// <summary>
    /// 指定されたシーンが読み込み済であるかどうかを返します。
    /// </summary>
    /// <param name="name">確認したいシーン名</param>
    /// <returns></returns>
    public static bool IsSceneLoaded( string name)
    {
        var scene = SceneManager.GetSceneByName(name);
        return scene.isLoaded;
    }


}
