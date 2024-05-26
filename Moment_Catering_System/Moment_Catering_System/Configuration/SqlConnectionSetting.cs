// =============================================================================
// <summary>
// SQLServer 接続設定です。
// </summary>
// <copyright file="SqlConnectionSetting.cs" company="Works">
// Copyright(C) Works Co.,Ltd.
// </copyright>
// <author>
// Works
// </author>
// =============================================================================

namespace Moment_Catering_System.Framework.Configuration
{
    using System;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// SQLServer 接続設定です。
    /// </summary>
    [Serializable]
    public class SqlConnectionSetting
    {
        /// <summary>
        /// 接続設定の名前です。
        /// </summary>
        [XmlAttribute("settingName")]
        public string SettingName { get; set; }

        /// <summary>
        /// <see cref="System.Data.SqlClient.SqlConnection"/> の <see cref="System.Data.SqlClient.SqlConnection.ConnectionString"/> です。
        /// </summary>
        [XmlAttribute("sqlConnectionString")]
        public string SqlConnectionString { get; set; }

        /// <summary>
        /// デフォルトの接続先かを示します。
        /// </summary>
        [XmlAttribute("isDefault")]
        public bool IsDefault { get; set; }
    }
}
