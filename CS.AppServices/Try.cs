using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core.AppServices
{
    public static class Try
    {
        public static void Action(Action action)
        {
            Require.ArgNotNull(action, "action");
            try
            {
                action();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }

    public static class Require
    {
        public static void That(bool expression, string message = null)
        {
            if (!expression)
            {
                throw new Exception(message ?? "");
            }
        }

        public static void ArgNotNull(object value, string property)
        {
            if (value == null)
            {
                throw new ArgumentNullException(property);
            }
        }

        public static void NotEmptyOrWhiteSpace(string value, string property)
        {
            That(!string.IsNullOrWhiteSpace(value) && !string.IsNullOrEmpty(value), string.Format(CultureInfo.InvariantCulture,
                "The value of [{0}] cannot be empty or whitespace.", property));
        }
    }


}
