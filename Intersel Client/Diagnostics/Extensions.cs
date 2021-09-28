
namespace System.Diagnostics
{
    public static class Extensions
    {
        /// <summary>
        /// Function used to serialize parameters in the TracedProxy class
        /// Set this function if custom serialization is needed
        /// Alternatively you can pass a custom serializer in the TracedProxy constructor
        /// or you can set its Serializer property
        /// </summary>
        public static Func<object, string> GlobalSerializer = (obj) =>
        {

            var res = string.Empty;

            if (obj == null)
            {
                res = "NULL";
            }
            else
            {
                try
                {
                    //res = JsonConvert.SerializeObject(obj, Formatting.Indented); //Newtonsoft dependency
                    res = obj.ToString();
                }
                catch (Exception ex)
                {
                    res = ex.ToString();
                }
            }

            return res;
        };

        public static T Wrap<T>(this T target) where T : TracedClass
        {
            var proxy = new TracedProxy<T>(target);

            var res = (T)proxy.GetTransparentProxy();

            return res;
        }

        public static T Wrap<T>(this T target, Func<object,string> serialize) where T : TracedClass
        {
            var proxy = new TracedProxy<T>(target);
            proxy.Serialize = serialize;
            var res = (T)proxy.GetTransparentProxy();

            return res;
        }

        public static void Indent(this TraceSource target)
        {

            foreach (TraceListener listener in target.Listeners)
            {
                listener.IndentLevel++;
            }
        }

        public static void Unindent(this TraceSource target)
        {

            foreach (TraceListener listener in target.Listeners)
            {
                listener.IndentLevel--;
            }

        }
    }
}
