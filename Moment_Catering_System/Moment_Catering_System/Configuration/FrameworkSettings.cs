namespace Moment_Catering_System.Framework.Configuration
{
    using System;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Reflection;
    using System.Web;
    using System.Xml;
    using System.Xml.Serialization;

    [Serializable]
    [XmlRoot("FrameworkSettings")]
    public class FrameworkSettings
    {
        [XmlIgnore]
        public const string AppConfigKey = "Framework.Config";

        [XmlIgnore]
        private static object lockObject = new object();

        /// <summary>
        /// 唯一のインスタンスです。
        /// </summary>
        [XmlIgnore]
        private static FrameworkSettings instance;

        [XmlIgnore]
        public static FrameworkSettings Default
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new FrameworkSettings();

                        var path = ConfigurationManager.AppSettings[AppConfigKey];
                        instance.LoadSettings(path);
                    }
                }

                return instance;
            }
        }

        [XmlElement("Framework.Core.ProductName")]
        public SimpleValueSetting ProductName { get; set; }

        [XmlElement("Framework.Core.ProductLogicalName")]
        public SimpleValueSetting ProductLogicalName { get; set; }

        /// <summary>
        /// <see cref="Works.Framework.Configuration.MessageSettings"/> の設定値一覧です。
        /// </summary>
        //[XmlElement("Framework.Core.MessageSettings")]
        //public MessageSettings MessageSettings { get; set; }

        /// <summary>
        /// <see cref="Works.Framework.Configuration.LogSettings"/> の設定値一覧です。
        /// </summary>
        //[XmlElement("Framework.Core.LogSettings")]
        //public LogSettings LogSettings { get; set; }

        /// <summary>
        /// <see cref="Works.Framework.Configuration.RegularExpressionSettings"/> の設定値一覧です。
        /// </summary>
        //[XmlElement("Framework.Core.RegularExpressionSettings")]
        //public RegularExpressionSettings RegularExpressionSettings { get; set; }

        /// <summary>
        /// <see cref="Works.Framework.Configuration.WindowsFormSettings"/> の設定値一覧です。
        /// </summary>
        //[XmlElement("Framework.Windows.Forms.WindowsFormSettings")]
        //public WindowsFormSettings WindowsFormSettings { get; set; }

        /// <summary>
        /// <see cref="Works.Framework.Configuration.WebServiceAgentSettings"/> の設定値一覧です。
        /// </summary>
        //[XmlElement("Framework.Web.Services.Agent.WebServiceAgentSettings")]
        //public WebServiceAgentSettings WebServiceAgentSettings { get; set; }

        /// <summary>
        /// <see cref="Works.Framework.Configuration.SqlConnectionSettings"/> の設定値一覧です。
        /// </summary>
        [XmlElement("Framework.Data.SqlConnectionSettings")]
        public SqlConnectionSettings SqlConnectionSettings { get; set; }

        /// <summary>
        /// <see cref="Works.Framework.Configuration.TransactionSettings"/> の設定値一覧です。
        /// </summary>
        //[XmlElement("Framework.Transaction.TransactionSettings")]
        //public TransactionSettings TransactionSettings { get; set; }
        /// <summary>
        /// <see cref="Works.Framework.Configuration.TransactionSettings"/> の設定値一覧です。
        /// </summary>
        //[XmlElement("Framework.BlobStorageName.BlobStorageNameSettings")]
        //public BlobStorageNameSetting BlobStorageNameSetting { get; set; }
        /// <summary>
        /// <see cref="Works.Framework.Configuration.TransactionSettings"/> の設定値一覧です。
        /// </summary>
        //[XmlElement("Framework.BlobStorageKey.BlobStorageKeySettings")]
        //public BlobStorageKeySetting BlobStorageKeySetting { get; set; }

        /// <summary>
        /// セッティングを保存します。
        /// </summary>
        /// <param name="path">保存先のパス。</param>
        /// <exception cref="ArgumentException">パスの指定に誤りがあります。</exception>
        /// <remarks>
        /// <para>Web の場合は <see cref="HttpRuntime.BinDirectory"/> を基準にパスを補完します。</para>
        /// <para>Client の場合で対象ファイルが存在しない場合は <see cref="Assembly.Location"/> を基準にパスを補完します。</para>
        /// <para><see cref="XmlSerializer.Serialize(TextWriter, object)"/> を使用し保存します。</para>
        /// </remarks>
        [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "シングルトンによる実装のためすべてをインスタンスメンバとする")]
        public void SaveSettings(
            string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException(
                    "app.config に Framework.config の設定がありません",
                    "path");
            }

            if (HttpContext.Current != null)
            {
                if (!string.IsNullOrEmpty(HttpRuntime.BinDirectory))
                {
                    path = Path.Combine(
                        HttpRuntime.BinDirectory,
                        path);
                }
            }
            else
            {
                if (!File.Exists(path))
                {
                    var entryLocation = Assembly.GetEntryAssembly().Location;

                    var f = Path.Combine(
                        Path.GetDirectoryName(entryLocation),
                        path);

                    if (File.Exists(f))
                    {
                        path = f;
                    }
                }
            }

            if (!File.Exists(path))
            {
                throw new ArgumentException(
                    "Framework.config が見つかりません" + Environment.NewLine + path,
                    "path");
            }

            using (var sw = new StreamWriter(path))
            {
                var xs = new XmlSerializer(FrameworkSettings.Default.GetType());
                xs.Serialize(sw, FrameworkSettings.Default);
            }
        }

        /// <summary>
        /// コンフィグファイルに記載された相対パスから絶対パスを取得します。
        /// </summary>
        /// <param name="pathOnConfig">コンフィグファイルに記載されたパス。</param>
        /// <returns>絶対パス。</returns>
        /// <remarks>
        /// <para>Web の場合は <see cref="HttpRuntime.BinDirectory"/> を基準にパスを補完します。</para>
        /// <para>Client の場合で対象ファイルが存在しない場合は <see cref="Assembly.Location"/> を基準にパスを補完します。</para>
        /// </remarks>
        [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "シングルトンによる実装のためすべてをインスタンスメンバとする")]
        public string GetFilePath(
            string pathOnConfig)
        {
            if (string.IsNullOrWhiteSpace(pathOnConfig))
            {
                return string.Empty;
            }

            var path = pathOnConfig;

            if (HttpContext.Current != null)
            {
                if (!string.IsNullOrEmpty(HttpRuntime.BinDirectory))
                {
                    path = Path.Combine(
                        HttpRuntime.BinDirectory,
                        path);
                }
            }
            else
            {
                if (!File.Exists(path))
                {
                    var entryLocation = Assembly.GetEntryAssembly().Location;

                    var f = Path.Combine(
                        Path.GetDirectoryName(entryLocation),
                        path);

                    if (File.Exists(f))
                    {
                        path = f;
                    }
                }
            }

            return path;
        }

        /// <summary>
        /// セッティングを読み込みます。
        /// </summary>
        /// <param name="path">読み込み先のパス。</param>
        /// <exception cref="ArgumentException">パスの指定に誤りがあります。</exception>
        /// <remarks>
        /// <para>Web の場合は <see cref="HttpRuntime.BinDirectory"/> を基準にパスを補完します。</para>
        /// <para>Client の場合で対象ファイルが存在しない場合は <see cref="Assembly.Location"/> を基準にパスを補完します。</para>
        /// <para><see cref="XmlSerializer.Deserialize(TextReader)"/> を使用し読み込みます。</para>
        /// </remarks>
        [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "シングルトンによる実装のためすべてをインスタンスメンバとする")]
        public void LoadSettings(
            string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException(
                    "app.config に Framework.config の設定がありません",
                    "path");
            }

            if (HttpContext.Current != null)
            {
                if (!string.IsNullOrEmpty(HttpRuntime.BinDirectory))
                {
                    path = Path.Combine(
                        HttpRuntime.BinDirectory,
                        path);
                }
            }
            else
            {
                if (!File.Exists(path))
                {
                    var entryLocation = Assembly.GetEntryAssembly().Location;

                    var f = Path.Combine(
                        Path.GetDirectoryName(entryLocation),
                        path);

                    if (File.Exists(f))
                    {
                        path = f;
                    }
                }
            }

            if (!File.Exists(path))
            {
                throw new ArgumentException(
                    "Framework.config が見つかりません" + Environment.NewLine + path,
                    "path");
            }

            using (var sr = new StreamReader(path))
            {
                var xs = new XmlSerializer(FrameworkSettings.Default.GetType());
                FrameworkSettings.instance = xs.Deserialize(sr) as FrameworkSettings;
            }
        }
    }
}