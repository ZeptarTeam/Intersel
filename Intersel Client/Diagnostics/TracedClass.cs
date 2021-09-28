using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace System.Diagnostics
{
    public class TracedClass : MarshalByRefObject
    {

        #region ctor

        public TracedClass(TraceSource source)
        {

            Trace = source;
        }

        public TracedClass()
        {
            Trace = new TraceSource("xSolon");
        }

        public TracedClass(string sourceName)
        {
            Trace = new TraceSource(sourceName);

        }

        #endregion

        #region Tracing


        public void Indent()
        {
            Trace.Indent();
        }
        public void UnIndent()
        {
            Trace.Unindent();
        }

        //
        // Summary:
        //     Writes trace data to the trace listeners in the System.Diagnostics.TraceSource.Listeners
        //     collection using the specified event type, event identifier, and trace data array.
        //
        // Parameters:
        //   eventType:
        //     One of the enumeration values that specifies the event type of the trace data.
        //
        //   id:
        //     A numeric identifier for the event.
        //
        //   data:
        //     An object array containing the trace data.
        //
        // Exceptions:
        //   T:System.ObjectDisposedException:
        //     An attempt was made to trace an event during finalization.
        [Conditional("TRACE")]
        public void TraceData(TraceEventType eventType, int id, params object[] data)
        {
            Trace.TraceData(eventType, id, data);
        }

        //
        // Summary:
        //     Writes trace data to the trace listeners in the System.Diagnostics.TraceSource.Listeners
        //     collection using the specified event type, event identifier, and trace data.
        //
        // Parameters:
        //   eventType:
        //     One of the enumeration values that specifies the event type of the trace data.
        //
        //   id:
        //     A numeric identifier for the event.
        //
        //   data:
        //     The trace data.
        //
        // Exceptions:
        //   T:System.ObjectDisposedException:
        //     An attempt was made to trace an event during finalization.
        [Conditional("TRACE")]
        public void TraceData(TraceEventType eventType, int id, object data)
        {
            Trace.TraceData(eventType, id, data);
        }

        //
        // Summary:
        //     Writes a trace event message to the trace listeners in the System.Diagnostics.TraceSource.Listeners
        //     collection using the specified event type and event identifier.
        //
        // Parameters:
        //   eventType:
        //     One of the enumeration values that specifies the event type of the trace data.
        //
        //   id:
        //     A numeric identifier for the event.
        //
        // Exceptions:
        //   T:System.ObjectDisposedException:
        //     An attempt was made to trace an event during finalization.
        [Conditional("TRACE")]
        public void TraceEvent(TraceEventType eventType, int id)
        {
            Trace.TraceEvent(eventType, id);
        }

        //
        // Summary:
        //     Writes a trace event message to the trace listeners in the System.Diagnostics.TraceSource.Listeners
        //     collection using the specified event type, event identifier, and message.
        //
        // Parameters:
        //   eventType:
        //     One of the enumeration values that specifies the event type of the trace data.
        //
        //   id:
        //     A numeric identifier for the event.
        //
        //   message:
        //     The trace message to write.
        //
        // Exceptions:
        //   T:System.ObjectDisposedException:
        //     An attempt was made to trace an event during finalization.
        [Conditional("TRACE")]
        public void TraceEvent(TraceEventType eventType, int id, string message)
        {
            Trace.TraceEvent(eventType, id, message);
        }
        //
        // Summary:
        //     Writes a trace event to the trace listeners in the System.Diagnostics.TraceSource.Listeners
        //     collection using the specified event type, event identifier, and argument array
        //     and format.
        //
        // Parameters:
        //   eventType:
        //     One of the enumeration values that specifies the event type of the trace data.
        //
        //   id:
        //     A numeric identifier for the event.
        //
        //   format:
        //     A composite format string (see Remarks) that contains text intermixed with zero
        //     or more format items, which correspond to objects in the args array.
        //
        //   args:
        //     An object array containing zero or more objects to format.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     format is null.
        //
        //   T:System.FormatException:
        //     format is invalid.-or- The number that indicates an argument to format is less
        //     than zero, or greater than or equal to the number of specified objects to format.
        //
        //   T:System.ObjectDisposedException:
        //     An attempt was made to trace an event during finalization.
        [Conditional("TRACE")]
        public void TraceEvent(TraceEventType eventType, int id, string format, params object[] args)
        {
            Trace.TraceEvent(eventType, id, format, args);
        }

        //
        // Summary:
        //     Writes an informational message to the trace listeners in the System.Diagnostics.TraceSource.Listeners
        //     collection using the specified message.
        //
        // Parameters:
        //   message:
        //     The informative message to write.
        //
        // Exceptions:
        //   T:System.ObjectDisposedException:
        //     An attempt was made to trace an event during finalization.
        [Conditional("TRACE")]
        public void TraceInformation(string message)
        {

            Trace.TraceInformation(message);
        }

        //
        // Summary:
        //     Writes an informational message to the trace listeners in the System.Diagnostics.TraceSource.Listeners
        //     collection using the specified object array and formatting information.
        //
        // Parameters:
        //   format:
        //     A composite format string (see Remarks) that contains text intermixed with zero
        //     or more format items, which correspond to objects in the args array.
        //
        //   args:
        //     An array containing zero or more objects to format.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     format is null.
        //
        //   T:System.FormatException:
        //     format is invalid.-or- The number that indicates an argument to format is less
        //     than zero, or greater than or equal to the number of specified objects to format.
        //
        //   T:System.ObjectDisposedException:
        //     An attempt was made to trace an event during finalization.
        [Conditional("TRACE")]
        public void TraceInformation(string format, params object[] args)
        {
            Trace.TraceInformation(format, args);
        }

        #endregion

        public TraceSource Trace { get; private set; }

    }

}
