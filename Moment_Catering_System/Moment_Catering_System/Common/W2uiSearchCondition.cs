// =============================================================================
// <summary>
// W2uiSearchOrderCondtion
// </summary>
// <copyright file="W2uiSearchCondition.cs" company="Works">
// Copyright(C) Works Co.,Ltd.
// </copyright>
// <author>
// Works
// </author>
// =============================================================================

namespace Moment_Catering_System.Common
{
    /// <summary>
    /// W2uiSearchCondition
    /// </summary>
    public class W2uiSearchCondition
    {
        /// <summary>
        /// Field
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Operator
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Values
        /// </summary>
        public string[] Values { get; set; }
    }
}
