
namespace Moment_Catering_System.Framework.Configuration
{
    using System;
    using System.Linq;

    /// <summary>
    /// <see cref="SqlConnectionSetting"/> に関する拡張メソッド定義クラスです。
    /// </summary>
    public static class SqlConnectionSettingExtension
    {
        /// <summary>
        /// デフォルトの <see cref="SqlConnectionSetting"/> を取得します。
        /// </summary>
        /// <param name="target"><see cref="SqlConnectionSetting"/> 一覧。</param>
        /// <returns>取得した <see cref="SqlConnectionSetting"/> 。</returns>
        /// <exception cref="ArgumentException"><see cref="FrameworkSettings"/> の設定に誤りがあります。</exception>
        /// <remarks>
        /// <see cref="SqlConnectionSettingExtension.GetSetting(SqlConnectionSetting[], string)"/> を使用します。
        /// </remarks>
        public static SqlConnectionSetting GetSetting(this SqlConnectionSetting[] target)
        {
            return target.GetSetting(string.Empty);
        }

        /// <summary>
        /// <see cref="SqlConnectionSetting"/> を取得します。
        /// </summary>
        /// <param name="target"><see cref="SqlConnectionSetting"/> 一覧。</param>
        /// <param name="settingName">設定名。</param>
        /// <returns>取得した <see cref="SqlConnectionSetting"/> 。</returns>
        /// <exception cref="ArgumentException"><see cref="FrameworkSettings"/> の設定に誤りがあります。</exception>
        /// <remarks>
        /// <para>
        /// [対象設定名が未設定の場合]
        /// デフォルト設定を返します。
        /// </para>
        /// <para>
        /// [その他]
        /// 設定名が合致する設定を返します。
        /// </para>
        /// </remarks>
        public static SqlConnectionSetting GetSetting(this SqlConnectionSetting[] target, string settingName)
        {
            if (string.IsNullOrEmpty(settingName))
            {
                var settings = target.Where(x => x.IsDefault).ToList();

                if (settings.Count != 1)
                {
                    throw new ArgumentException(
                        "Framework.config のデータベース接続設定に誤りがあります。\nデフォルトの接続設定が行われていないか、複数設定されています。");
                }

                return settings.First();
            }
            else
            {
                var settings = target.Where(x => x.SettingName == settingName).ToList();

                if (settings.Count == 0)
                {
                    throw new ArgumentException(
                        "Framework.config のデータベース接続設定がありません。settingName=" + settingName);
                }

                return settings.First();
            }
        }
    }
}
