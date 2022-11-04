#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

[assembly: CLSCompliant(true)]

namespace InformationInTransit.ProcessLogic
{
/*
2022-11-03T15:49:00 ... 2022-11-03T18:53:00 string[] queryElements = new string[]{ query }; //query.Split(jesusInTheLambs[jesusInTheLambsIndex].QuerySeparator);
Vickie Stone
Company	Pixelberry Studios
Work e-mail	vickie@pixelberrystudios.com
Work phone	(619) 889-2354
Website	codingame.com/evaluate/?id=49064728eaa11923fbf33690657e4768c9dc55c
Notes	2021-12-13T11:04:00 I appreciate your call on Friday. We send the coding assessment to all engineering candidates that apply for our Eng jobs. I'm sorry to hear you were not comfortable finishing either the Assoc Eng one or the SW Eng-Fullstack assessment. Thank you for making time to speak with me last week. Hopefully there will be a more appropriate opportunity for you out there. Regards, Vickie Stone 2021-12-12T20:57:00
*/
    #region JesusInTheLamb definition
    /// <summary>
    /// 2004-11-10 www.JesusInTheLamb.com Walking in the Lamb, you shall follow Me.
    /// </summary>
    public partial class JesusInTheLamb : IFormattable
    {
        #region Constructors
        public JesusInTheLamb
        (
            string columnName
        )
        :this
        (
            null, //databaseName
            null, //scheme
            null, //tableName
            columnName,
            null, //Database composition join
            null //Query separator
        )
        {}

        public JesusInTheLamb
        (
            string databaseName,
            string schema,
            string tableName,
            string columnName,
            string databaseNameCompositionJoinDefault,
            Char[] querySeparator
        )
        {
            this.databaseName = databaseName;
            this.schema = schema;
            this.tableName = tableName;
            this.columnName = columnName;
            if (databaseNameCompositionJoinDefault != null)
                this.databaseNameCompositionJoinDefault = databaseNameCompositionJoinDefault;
            if (querySeparator != null)
                this.querySeparator = querySeparator;
        }
        #endregion

        #region Fields
        private string databaseName;
        private string schema;
        private string tableName;
        private string columnName;
        /// <summary>
        /// For example, in Microsoft's SQL Server, the dot separates the names of the server, 
        /// databaseName, scheme formerly owner, tableName, and columnNameName.
        /// </summary>
        private string databaseNameCompositionJoinDefault = DatabaseCompositionJoinDefault; //Field initializer
        /// <summary>
        /// The separator used to separate the query parts, normally in the English language the space character
        /// is used to separate the words.
        /// </summary>
        private Char[] querySeparator = QuerySeparatorDefault; ////Field initializer

        public const string DatabaseCompositionJoinDefault = ".";
        public static readonly char[] QuerySeparatorDefault;
        #endregion

        #region Properties
        public Char[] QuerySeparator
        {
            get
            {
                return querySeparator;
            }
        }
        #endregion

        #region Methods
        public static string Join(List<JesusInTheLamb> jesusInTheLambs, string query)
        {
            StringBuilder sb = new StringBuilder();
            if (String.IsNullOrEmpty(query)) return null;
            for (int jesusInTheLambsIndex = 0; jesusInTheLambsIndex < jesusInTheLambs.Count; ++jesusInTheLambsIndex)
            {
                string[] queryElements = new string[]{ query }; //query.Split(jesusInTheLambs[jesusInTheLambsIndex].QuerySeparator);
                bool queryElementOrSeparator = false;
                for (int queryElementIndex = 0; queryElementIndex < queryElements.Length; ++queryElementIndex)
                {
                    if (String.IsNullOrEmpty(queryElements[queryElementIndex])) 
                        continue;
                    queryElementOrSeparator = true;
                    sb.AppendFormat
                    (
                        "{0} LIKE '%{1}%'",
                        jesusInTheLambs[jesusInTheLambsIndex],
                        queryElements[queryElementIndex]
                    );
                    if (queryElementIndex < queryElements.Length - 1)
                        sb.Append(" OR ");
                }
                if (jesusInTheLambsIndex < jesusInTheLambs.Count - 1 && queryElementOrSeparator)
                    sb.Append(" OR ");
            }
            return sb.ToString();
        }

        public override String ToString() { return ToString(null, null); }

        public String ToString(String format, IFormatProvider fp)
        {
            StringBuilder sb = new StringBuilder();
            if (format == null)
            {
                if (databaseName != null) { sb.AppendFormat("{0}{1}", databaseName, databaseNameCompositionJoinDefault); }
                if (schema != null) { sb.AppendFormat("{0}{1}", schema, databaseNameCompositionJoinDefault); }
                if (tableName != null) { sb.AppendFormat("{0}{1}", tableName, databaseNameCompositionJoinDefault); }
                if (columnName != null) { sb.AppendFormat("{0}", columnName); }
                return sb.ToString();
            }
            // For any unrecognized format, throw an exception.
            throw new FormatException(String.Format("Invalid format string: '{0}'.", format));
        }

        static JesusInTheLamb()
        {
            QuerySeparatorDefault = (new Char[] {' '});
        }
        #endregion
    }
    #endregion
}