namespace Moment_Catering_System.Common.Const
{
    /// <summary>
    /// 共通定数定義クラス
    /// </summary>
    public static class CommonConst
    {
        /// <summary>最大取得件数</summary>
        public const int DEFAULT_MAX_SELECT_COUNT = 99;

        /// <summary>既定の移動先となるメニューのパス</summary>
        public const string SystemLoginLocation = "~/Common/SCRCM004A01_Login/";

        /// <summary>既定の移動先となるメニューのパス</summary>
        public const string SystemMenuLocation = "~/Common/SCRCM005A01_SystemMenu/";

        /// <summary>パスワード変更画面のパス</summary>
        public const string ChangePasswordLocation = "~/Common/SCRCM008A01_ChangePassword/";

        /// <summary>戻り先となるパラメータの名称</summary>
        public const string ParamSrc = "src";

        /// <summary>検索画面にて初期検索を行うかどうか</summary>
        public const string ParamIsExecuteInitialSearch = "isExecuteInitialSearch";

        /// <summary>新規/変更/削除 を行う画面の各モード</summary>
        public const string ParamEditMode = "editMode";

        /// <summary>ドロップダウンリストで未設定として表示される文字列</summary>
        public const string DropdownListEmptyString = "--";

        /// <summary>新規/変更/削除 を行う画面の各モード</summary>
        public enum EditMode
        {
            /// <summary>New Mode</summary>
            New,

            /// <summary>Modify Mode</summary>
            Modify,

            /// <summary>Delete Mode</summary>
            Delete,
        }
    }

    /// <summary>
    /// ViewDataに保持しているパラメータ
    /// </summary>
    public class ViewDataParam
    {
        /// <summary>画面タイトル</summary>
        public const string Title = "Title";

        /// <summary>画面ID</summary>
        public const string ScreenId = "ScreenId";

        /// <summary>サーバエラーのメッセージ</summary>
        public const string ErrorMessage = "ErrorMessage";
    }
}