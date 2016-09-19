using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Net.NetworkInformation;

namespace OneScriptNetwork
{
	[ContextClass("Озвень", "PingReply")]
	public class PingReplyImpl : AutoContext<PingReplyImpl>
	{
		private readonly PingReply _reply;

		public PingReplyImpl(PingReply reply)
		{
			_reply = reply;
		}

		[ContextProperty("Состояние", "Status")]
		public IValue Status
		{
			get
			{
				return GlobalsManager.GetEnum<PingStatusEnumImpl>().FromNativeValue(_reply.Status);
			} 
		}

	}
}
