namespace Moment_Catering_System.Common
{
    using System.Collections.Generic;

    /// <summary>
    /// 検索結果返却用オブジェクト
    /// </summary>
    public class SearchResultObject
    {
        /// <summary>検索総件数</summary>
        public int totalCount { get; set; }

        /// <summary>検索結果レコード</summary>
        public List<SearchResultRecordBase> records { get; set; }

        /// <summary>
        /// sortTypeFlg
        /// </summary>
        public string sortTypeFlg { get; set; }
    }
}