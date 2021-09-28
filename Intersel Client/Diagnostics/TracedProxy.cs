using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

namespace System.Diagnostics
{
    public class TracedProxy<T> : RealProxy where T : TracedClass
    {

        private readonly T _dal;

        public TracedProxy(T dal)
            : base(dal.GetType())
        {
            _dal = dal;

            typeName = _dal.GetType().Name;

        }

        private string typeName = "";

        Func<object, string> _Serialize = null;
        public Func<object, string> Serialize
        {
            get
            {
                if (_Serialize == null)
                {
                    return Extensions.GlobalSerializer;
                }
                else
                {
                    return _Serialize;
                }
            }
            set
            {
                _Serialize = value;
            }
        }

        private Dictionary<string, object> GetParams(IMethodCallMessage methodCall)
        {
            var res = new Dictionary<string, object>();

            for (var i = 0; i < methodCall.InArgCount; i++)
            {
                var key = methodCall.GetInArgName(i);
                var val = methodCall.GetInArg(i);

                var stringVal = Serialize(val);

                res.Add(key, stringVal);
            }

            return res;
        }

        TimeSpan Elapsed(Action action)
        {

            var stopWatch = new Stopwatch();

            stopWatch.Start();

            action();

            stopWatch.Stop();

            return stopWatch.Elapsed;

        }

        void TraceParameters(Dictionary<string, object> callParams)
        {

            _dal.Indent();

            try
            {

                foreach (var kv in callParams)
                {
                    var msg = string.Format("{0}: {1}", kv.Key, kv.Value);

                    _dal.TraceData(TraceEventType.Verbose, 1602, msg);
                }
            }
            finally
            {
                _dal.UnIndent();

            }

        }

        public override IMessage Invoke(IMessage msg)
        {
            var methodCall = msg as IMethodCallMessage;
            var methodInfo = methodCall.MethodBase as MethodInfo;
            try
            {
                object result = null;
                TimeSpan elapsed;

                if ("TraceInformation|TraceData|TraceEvent|get_Trace|Indent|UnIndent".Contains(methodCall.MethodName))
                {
                    result = methodInfo.Invoke(_dal, methodCall.InArgs);
                }
                else
                {
                    var inParams = GetParams(methodCall);

                    using (var scope = new ActivityScope(_dal.Trace, methodCall.MethodName))
                    {
                        elapsed = Elapsed(() =>
                        {
                            result = methodInfo.Invoke(_dal, methodCall.InArgs);
                        });

                        inParams.Add("Result", Serialize(result));

                        _dal.TraceEvent(TraceEventType.Verbose, 1601, "{1} - {0}: {2}", methodCall.MethodName, typeName, elapsed);

                        TraceParameters(inParams);
                    }

                }

                return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
            }
            catch (Exception e)
            {
                _dal.TraceEvent(TraceEventType.Error, 1603, "{1} - Exception {0} executing '{1}'", e, methodCall.MethodName, typeName);

                _dal.TraceData(TraceEventType.Error, 1604, e.ToString());

                throw;
            }
        }

        public new T GetTransparentProxy()
        {

            return base.GetTransparentProxy() as T;
        }

    }

}
