// =============================================================================
// <summary>
// SQLServer 接続設定郡です。
// </summary>
// <copyright file="SqlConnectionSettings.cs" company="Works">
// Copyright(C) Works Co.,Ltd.
// </copyright>
// <author>
// Works
// </author>
// =============================================================================

namespace Moment_Catering_System.Framework.Configuration
{
    using System;
    using System.Data.SqlClient;
    using System.Diagnostics.CodeAnalysis;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// SQLServer 接続設定郡です。
    /// </summary>
    [Serializable]
    public class SqlConnectionSettings
    {
        /// <summary>
        /// SQLServer 接続設定郡です。
        /// </summary>
        [XmlArray("SqlConnectionSettings")]
        [XmlArrayItem("SqlConnectionSetting")]
        [SuppressMessage("Microsoft.Performance", "CA1819", Justification = "設定ファイルであるため配列の公開とする")]
        public SqlConnectionSetting[] Settings { get; set; }

        /// <summary>
        /// <see cref="SqlCommand"/> の <see cref="SqlCommand.CommandTimeout"/> 設定値です。
        /// 秒で指定します。
        /// </summary>
        [XmlElement("SqlCommandTimeoutSeconds")]
        public SimpleValueSetting SqlCommandTimeoutSeconds { get; set; }
    }
}
