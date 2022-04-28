namespace Legerity.Web.Elements.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using Legerity.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="IWebElement"/> wrapper for the core web Table control.
    /// </summary>
    public class Table : WebElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Table"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IWebElement"/> reference.
        /// </param>
        public Table(IWebElement element)
            : this(element as RemoteWebElement)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Table"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="RemoteWebElement"/> reference.
        /// </param>
        public Table(RemoteWebElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether the first row in the table is a header row.
        /// </summary>
        public virtual bool IsFirstRowHeaders { get; set; } = true;

        /// <summary>
        /// Gets the header names for the table.
        /// </summary>
        public virtual IEnumerable<string> Headers => this.IsFirstRowHeaders ? this.Rows.FirstOrDefault().GetAllChildElements().Select(x => x.Text) : this.Element.FindElements(WebByExtras.TableHeaderCell()).Select(x => x.Text);

        /// <summary>
        /// Gets the collection of rows associated with the table. If a header row exists, that will be included.
        /// </summary>
        public virtual IEnumerable<TableRow> Rows => this.Element.FindElements(WebByExtras.TableRow()).Select(e => new TableRow(e));

        /// <summary>
        /// Gets the collection of rows associated with the table only containing the data values (not headers).
        /// </summary>
        public virtual IEnumerable<TableRow> DataRows => this.Rows.Where(x => x.FindElements(WebByExtras.TableHeaderCell()).Count == 0);

        /// <summary>
        /// Allows conversion of a <see cref="IWebElement"/> to the <see cref="Table"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Table"/>.
        /// </returns>
        public static implicit operator Table(RemoteWebElement element)
        {
            return new Table(element);
        }

        /// <summary>
        /// Retrieves the column names and associated column values for a specific row in the table by index.
        /// </summary>
        /// <param name="idx">The specified row data index to retrieve data for.</param>
        /// <returns>A dictionary of key-value pairs containing the column header and the column value for the row.</returns>
        public virtual IReadOnlyDictionary<string, string> GetRowDataByIndex(int idx)
        {
            void AddRowData(IDictionary<string, string> dictionary, string header, TableRow tableRow, int valueIdx)
            {
                dictionary.Add(header, tableRow.Values.ElementAt(valueIdx));
            }

            var headers = this.Headers.ToList();

            int dataRowIdx = this.IsFirstRowHeaders ? idx + 1 : idx;
            TableRow dataRow = this.Rows.ElementAt(dataRowIdx);

            var rowValues = new Dictionary<string, string>();

            if (headers.Any())
            {
                for (int i = 0; i < headers.Count; i++)
                {
                    AddRowData(rowValues, headers.ElementAt(i), dataRow, i);
                }
            }
            else
            {
                for (int i = 0; i < dataRow.Values.Count(); i++)
                {
                    AddRowData(rowValues, $"Col{i}", dataRow, i);
                }
            }

            return rowValues;
        }

        /// <summary>
        /// Retrieves the column values for a specific column by header name.
        /// </summary>
        /// <param name="header">The column header name.</param>
        /// <returns>A collection of values for each row in the column.</returns>
        public virtual IEnumerable<string> GetColumnDataByHeader(string header)
        {
            var headers = this.Headers.ToList();
            int idx = headers.IndexOf(header);
            return this.GetColumnDataByIndex(idx);
        }

        /// <summary>
        /// Retrieves the column values for a specific column by index.
        /// </summary>
        /// <param name="idx">The specified column index of data to retrieve.</param>
        /// <returns>A collection of values for each row in the column.</returns>
        public virtual IEnumerable<string> GetColumnDataByIndex(int idx)
        {
            if (idx == -1)
            {
                return null;
            }

            var dataRows = this.DataRows.ToList();
            return dataRows.Select(row => row.Values.ElementAt(idx)).ToList();
        }
    }
}
