// =============================================================================
// <summary>
// SqlClient に対するユーティリティークラスです。
// </summary>
// <copyright file="SqlClientUtility.cs" company="Works">
// Copyright(C) Works Co.,Ltd.
// </copyright>
// <author>
// Works
// </author>
// =============================================================================

namespace Moment_Catering_System.Common
{
    using Moment_Catering_System.Framework.Configuration;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// <see cref="System.Data.SqlClient"/> に対するユーティリティークラスです。
    /// </summary>
    public static class SqlClientUtility
    {
        /// <summary>
        /// 規定値に設定された SQLServer への <see cref="SqlConnection"/> を生成します。
        /// </summary>
        /// <returns>規定値に設定された SQLServer への <see cref="SqlConnection"/> 。</returns>
        /// <exception cref="ArgumentException"><see cref="FrameworkSettings"/> の設定に誤りがあります。</exception>
        /// <remarks>
        /// <see cref="CreateSqlConnection(string)"/> を使用します。
        /// </remarks>
        public static SqlConnection CreateSqlConnection()
        {
            return CreateSqlConnection(null);
        }

        /// <summary>
        /// 指定された接続設定の SQLServer への <see cref="SqlConnection"/> を生成します。
        /// </summary>
        /// <param name="sqlConnectionSettingName">対象の設定名。</param>
        /// <returns>指定された接続設定の SQLServer への <see cref="SqlConnection"/> 。</returns>
        /// <exception cref="ArgumentException"><see cref="FrameworkSettings"/> の設定に誤りがあります。</exception>
        /// <remarks>
        /// <para>
        /// [<see cref="SqlConnection.ConnectionString"/>]
        /// <see cref="SqlConnectionSetting.SqlConnectionString"/> の設定値を反映します。
        /// </para>
        /// </remarks>
        public static SqlConnection CreateSqlConnection(
            string sqlConnectionSettingName)
        {
            var setting = FrameworkSettings.Default.SqlConnectionSettings.Settings.GetSetting(sqlConnectionSettingName);

            var cn = new SqlConnection(setting.SqlConnectionString);

            return cn;
        }

        /// <summary>
        /// 規定値に設定された SQLServer への <see cref="SqlConnection"/> を生成し、接続を開いた上で返します。
        /// </summary>
        /// <returns>規定値に設定された SQLServer への <see cref="SqlConnection"/> 。</returns>
        /// <exception cref="ArgumentException"><see cref="FrameworkSettings"/> の設定に誤りがあります。</exception>
        /// <remarks>
        /// <see cref="CreateSqlConnectionWithOpen(string)"/> を使用します。
        /// </remarks>
        public static SqlConnection CreateSqlConnectionWithOpen()
        {
            return CreateSqlConnectionWithOpen(null);
        }

        /// <summary>
        /// 指定された接続設定の SQLServer への <see cref="SqlConnection"/> を生成し、接続を開いた上で返します。
        /// </summary>
        /// <param name="sqlConnectionSettingName">対象の設定名。</param>
        /// <returns>指定された接続設定の SQLServer への <see cref="SqlConnection"/> 。</returns>
        /// <exception cref="ArgumentException"><see cref="FrameworkSettings"/> の設定に誤りがあります。</exception>
        /// <remarks>
        /// <see cref="CreateSqlConnection(string)"/> を使用します。
        /// <see cref="SqlConnection.State"/> が <see cref="ConnectionState.Closed"/> であれば、 <see cref="SqlConnection.Open"/> を実行します。
        /// </remarks>
        public static SqlConnection CreateSqlConnectionWithOpen(
            string sqlConnectionSettingName)
        {
            var cn = SqlClientUtility.CreateSqlConnection(
                sqlConnectionSettingName);

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            return cn;
        }
    }
}