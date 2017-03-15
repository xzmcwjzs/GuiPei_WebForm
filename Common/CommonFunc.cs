using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
   public class CommonFunc
    {
        public static string SafeGetStringFromObj(object o)
        {
            if (o == null)
            {
                return "";
            }
            if (o != DBNull.Value)
            {
                return o.ToString();
            }
            return "";
        }
        public static string FilterSpecialString(string specialString)
        {
            return specialString.Replace("'", "&#39;").Replace(",", "&#44;");
        }
        public static string EncodeString(string strUnEncode, int len)
        {
            if (string.IsNullOrEmpty(strUnEncode))
            {
                return "";
            }
            string text = strUnEncode.Replace("\r\n", "<br/>").Replace("'", "&#39;").Replace(",", "&#44;");
            text = CommonFunc.FilterHTML(text, len);
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.HtmlEncode(text);
            }
            return text;
        }
        public static string FilterHTML(string str, int len)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            str = Regex.Replace(str, "<iframe", "&lt;iframe", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "</iframe", "&lt;/iframe", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "<script", "&lt;script", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "</script", "&lt;/script", RegexOptions.IgnoreCase);
            if (len != 0)
            {
                str = ((str.Length > len) ? str.Substring(0, len) : str);
            }
            return str;
        }
        public static DateTime SafeGetDateTimeFromObj(object o)
        {
            if (o == null || o == DBNull.Value || o.ToString().Trim() == "")
            {
                return CommonFunc.DateTimeNull;
            }
            DateTime dateTimeNull = CommonFunc.DateTimeNull;
            DateTime.TryParse(o.ToString(), out dateTimeNull);
            return dateTimeNull;
        }
        public static DateTime DateTimeNull
        {
            get
            {
                return new DateTime(1, 1, 1);
            }
        }
        public static string SafeGetDateTimeStringFromObjectByFormat(object textvalue, string format)
        {
            if (textvalue == null || textvalue == DBNull.Value || textvalue.ToString().Trim() == "")
            {
                return string.Empty;
            }
            DateTime d = CommonFunc.DateTimeNull;
            try
            {
                d = DateTime.Parse(textvalue.ToString());
            }
            catch (Exception)
            {
            }
            if (d != CommonFunc.DateTimeNull)
            {
                return d.ToString(format);
            }
            return "";
        }
        public static int SafeGetIntFromObj(object o, int defaultValue)
        {
            if (o == null || o == DBNull.Value || o.ToString().Trim() == "")
            {
                return defaultValue;
            }
            int result = -1;
            if (!int.TryParse(o.ToString(), out result))
            {
                return defaultValue;
            }
            return result;
        }
        public static string SafeGetMyDateTimeStringFromObjectByFormat(object o, string format)
        {
            DateTime dt = CommonFunc.SafeGetDateTimeFromObj(o);
            string result;
            if (DateTime.Compare(dt, new DateTime(1900, 1, 1)) <= 0)
            {
                result = string.Empty;
            }
            else
            {
                result = CommonFunc.SafeGetDateTimeStringFromObjectByFormat(o, format);
            }
            return result;
        }

        public static decimal SafeGetDecimalFromObject(object objValue, decimal defaultvalue)
        {
            if (objValue == null || objValue == DBNull.Value || objValue.ToString().Trim() == "")
            {
                return defaultvalue;
            }
            decimal result = defaultvalue;
            try
            {
                result = Convert.ToDecimal(objValue);
            }
            catch (Exception)
            {
            }
            return result;
        }

        public static float SafeGetFloatFromString(string textvalue, float defaultvalue)
        {
            if (string.IsNullOrEmpty(textvalue))
            {
                return defaultvalue;
            }
            float result = defaultvalue;
            try
            {
                result = (float)Convert.ToDouble(textvalue);
            }
            catch (Exception)
            {
            }
            return result;
        }

        public static float SafeGetFloatFromObject(object textvalue, float defaultvalue)
        {
            if (textvalue == null || textvalue == DBNull.Value || textvalue.ToString().Trim() == "")
            {
                return defaultvalue;
            }
            float result = defaultvalue;
            try
            {
                result = (float)Convert.ToDouble(textvalue.ToString());
            }
            catch (Exception)
            {
            }
            return result;
        }


    }
}
