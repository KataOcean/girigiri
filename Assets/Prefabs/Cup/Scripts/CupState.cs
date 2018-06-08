namespace Girigiri
{
    public enum CupState
    {
        Wait,//まだ受け入れ体制が整っていない
        Ready,//注がれ準備完了
        Pouring,//注がれ中
        Complete,//注がれ終わり
        Broken//どっかーん
    }
}