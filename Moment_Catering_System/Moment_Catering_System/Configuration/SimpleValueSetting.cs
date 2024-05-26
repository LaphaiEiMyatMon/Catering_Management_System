namespace Moment_Catering_System.Framework.Configuration
{
    using System;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// 単純な値用の設定キーです。
    /// </summary>
    [Serializable]
    public class SimpleValueSetting
    {
        /// <summary>
        /// 値です。
        /// </summary>
        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}