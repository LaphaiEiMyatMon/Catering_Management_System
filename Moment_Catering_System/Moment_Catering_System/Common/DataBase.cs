// =============================================================================
// <summary>
// データベース接続クラス
// </summary>
// <copyright file="DataBase.cs" company="Works">
// Copyright(C) Works Co.,Ltd.
// </copyright>
// <author>
// Works
// </author>
// =============================================================================

namespace Moment_Catering_System.Common
{
    using System.Data;
    using System.Data.Common;

    /// <summary>
    /// データベース接続クラス
    /// </summary>
    public class DataBase :
        DataBaseFoundation
    {
        /// <summary>
        /// SQL文の実行(テーブルを返す)
        /// </summary>
        /// <param name="sql">SQL文</param>
        /// <param name="queryParam">パラメータリスト</param>
        /// <returns>データテーブル</returns>
        public static DataTable ExecuteAdapter(string sql, QueryParamList queryParam)
        {
            using (DbConnection connection = DataBase.GetConnection())
            {
                return DataBaseFoundation.ExecuteAdapter(connection, sql, queryParam);
            }
        }

        /// <summary>
        /// SQL文の実行(テーブルを返す)
        /// </summary>
        /// <param name="sql">SQL文</param>
        /// <returns>データテーブル</returns>
        public static DataTable ExecuteAdapter(string sql)
        {
            using (DbConnection connection = DataBase.GetConnection())
            {
                return DataBaseFoundation.ExecuteAdapter(connection, sql, new QueryParamList());
            }
        }

        /// <summary>
        /// SQL文の実行
        /// </summary>
        /// <param name="sql">SQL文</param>
        /// <returns>取得結果</returns>
        public static object ExecuteScalar(string sql)
        {
            return DataBase.ExecuteScalar(sql, new QueryParamList());
        }

        /// <summary>
        /// SQL文の実行
        /// </summary>
        /// <param name="sql">SQL文</param>
        /// <param name="queryParam">パラメータリスト</param>
        /// <returns>取得結果</returns>
        public static object ExecuteScalar(string sql, QueryParamList queryParam)
        {
            using (DbConnection connection = DataBase.GetConnection())
            {
                return DataBaseFoundation.ExecuteScalar(connection, sql, queryParam);
            }
        }
    }
}