using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShipR.Data
{
    public class DataHelper
    {
        internal static int ConvertToInt(object value)
        {
            int intValue = 0;
            if (!Convert.IsDBNull(value))
            {
                int.TryParse(value.ToString(), out intValue);
            }
            return intValue;
        }

        internal static string ConvertToString(object value)
        {
            string strValue = string.Empty;
            if (!Convert.IsDBNull(value))
            {
                strValue = Convert.ToString(value);
            }
            return strValue;
        }

        internal static decimal ConvertToDecimal(object value)
        {
            decimal decValue = 0;
            if (!Convert.IsDBNull(value))
            {
                decimal.TryParse(value.ToString(), out decValue);
            }
            return decValue;
        }

        internal static double ConvertToDouble(object value)
        {
            double decValue = 0;
            if (!Convert.IsDBNull(value))
            {
                double.TryParse(value.ToString(), out decValue);
            }
            return decValue;
        }

        internal static bool ConvertToBool(object value)
        {
            bool boolValue = false;
            if (!Convert.IsDBNull(value))
            {
                boolValue = Convert.ToBoolean(value);
            }
            return boolValue;
        }

        internal static DateTime? ConvertToDate(object value)
        {
            DateTime? dateValue = null;
            if (!Convert.IsDBNull(value))
            {
                dateValue = (DateTime?)value;
            }
            return dateValue;
        }

        internal static byte[] ConvertToByteArray(object value)
        {
            byte[] byteArrayValue = null;
            if (!Convert.IsDBNull(value))
            {
                byteArrayValue = (byte[])value;
            }
            return byteArrayValue;
        }


        internal static bool ColumnExists(IDataReader idr, string columnName)
        {
            if (idr != null)
            {
                idr.GetSchemaTable().DefaultView.RowFilter = string.Format("ColumnName= ‘{0}’", columnName);
                return (idr.GetSchemaTable().DefaultView.Count > 0);
            }
            else
                return false;
        }
               

        internal static bool ColumnExists(SqlDataReader idr, string columnName)
        {
            if (idr != null)
            {
                return idr.GetSchemaTable().Columns.Contains(columnName);
            }
            else
                return false;
        }

        internal static bool ColumnExists(IDataRecord idr, string columnName)
        {
            try
            {
                if (idr != null)
                {
                    int ordinal = idr.GetOrdinal(columnName);
                    if (ordinal > 0) return true;
                }
                else
                    return false;
            }
#pragma warning disable CS0168 // The variable 'exc' is declared but never used
            catch (Exception exc)
#pragma warning restore CS0168 // The variable 'exc' is declared but never used
            {
                return false;
            }
            return false;
        }

        internal static SortedDictionary<string, string> ReturnColumnList(IDataReader idr)
        {
            if (idr != null)
            {
                SortedDictionary<string, string> columnList = new SortedDictionary<string, string>();
                DataTable dt = idr.GetSchemaTable();
                foreach (DataRow dRow in dt.Rows)
                {
                    string value = dRow[0].ToString();
                    columnList.Add(value, value);
                }
                return columnList;
            }
            else
            {
                return null;
            }
        }

        internal static SortedDictionary<string, string> ReturnColumnList(SqlDataReader idr)
        {
            if (idr != null)
            {
                SortedDictionary<string, string> columnList = new SortedDictionary<string, string>();
                DataTable dt = idr.GetSchemaTable();
                foreach (DataRow dRow in dt.Rows)
                {
                    string value = dRow[0].ToString();
                    columnList.Add(value, value);
                }
                return columnList;
            }
            else
            {
                return null;
            }
        }
    }
}
