using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Net.NetworkInformation;

namespace OneScriptNetwork
{
    [ContextClass("Звень", "Ping")]
    public class PingImpl : AutoContext<PingImpl>
    {

		private Ping _ping = new Ping();

        public PingImpl()
        {
        }

		[ContextMethod("Послать", "Send")]
		public PingReplyImpl Send(string host, IValue timeout = null)
		{
			if (timeout == null)
				return new PingReplyImpl(_ping.Send(host));

			return new PingReplyImpl(_ping.Send(host, decimal.ToInt32(timeout.AsNumber())));
		}

        [ScriptConstructor]
        public static IRuntimeContextInstance Constructor()
        {
            return new PingImpl();
        }
    }
}

