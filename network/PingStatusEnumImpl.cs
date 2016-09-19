using System;
using System.Linq;
using System.Collections.Generic;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Net.NetworkInformation;

namespace OneScriptNetwork
{
	[SystemEnum("СостояниеПрозвона", "PingStatus")]
	public class PingStatusEnumImpl : EnumerationContext
	{
		readonly Dictionary<IPStatus, IValue> _valuesCache = new Dictionary<IPStatus, IValue>();

		private PingStatusEnumImpl(TypeDescriptor typeRepresentation, TypeDescriptor valuesType)
			: base (typeRepresentation, valuesType)
		{
		}

		public IValue FromNativeValue(IPStatus native)
		{
			IValue val;
			if (_valuesCache.TryGetValue(native, out val))
				return val;

			val = this.ValuesInternal.First(x => ((CLREnumValueWrapper<IPStatus>)x).UnderlyingObject == native);
			_valuesCache.Add(native, val);
			return val;
		}

		public static PingStatusEnumImpl CreateInstance()
		{
			PingStatusEnumImpl instance;
			var type = TypeManager.RegisterType("ПеречислениеСостояниеПрозвона", typeof(PingStatusEnumImpl));
			var enumValueType = TypeManager.RegisterType("СостояниеПрозвона", typeof(CLREnumValueWrapper<IPStatus>));

			instance = new PingStatusEnumImpl(type, enumValueType);

			instance.AddValue("Успешно", "Success", new CLREnumValueWrapper<IPStatus>(instance, IPStatus.Success));
			instance.AddValue("ЦелеваяСетьНедостижима", "DestinationNetworkUnreachable", new CLREnumValueWrapper<IPStatus>(instance, IPStatus.DestinationNetworkUnreachable));
			instance.AddValue("ЦелевойУзелНедостижим", "DestinationHostUnreachable", new CLREnumValueWrapper<IPStatus>(instance, IPStatus.DestinationHostUnreachable));
			instance.AddValue("ЦелевойПротоколНедостижим", "DestinationProtocolUnreachable", new CLREnumValueWrapper<IPStatus>(instance, IPStatus.DestinationProtocolUnreachable));
			instance.AddValue("ЦелевойПортНедостижим", "DestinationPortUnreachable", new CLREnumValueWrapper<IPStatus>(instance, IPStatus.DestinationPortUnreachable));
			instance.AddValue("ЦельПодЗапретом", "DestinationProhibited", new CLREnumValueWrapper<IPStatus>(instance, IPStatus.DestinationProhibited));
			instance.AddValue("НедостаточноСредств", "NoResources", new CLREnumValueWrapper<IPStatus>(instance, IPStatus.NoResources));
			instance.AddValue("ОшибкаНастройки", "BadOption", new CLREnumValueWrapper<IPStatus>(instance, IPStatus.BadOption));

			instance.AddValue("АппаратнаяОшибка", "HardwareError", new CLREnumValueWrapper<IPStatus>(instance, IPStatus.HardwareError));
			instance.AddValue("СлишкомБольшойПакет", "PacketTooBig", new CLREnumValueWrapper<IPStatus>(instance, IPStatus.PacketTooBig));
			instance.AddValue("ВремяОжиданияИстекло", "TimedOut", new CLREnumValueWrapper<IPStatus>(instance, IPStatus.TimedOut));
			instance.AddValue("ПлохойМаршрут", "BadRoute", new CLREnumValueWrapper<IPStatus>(instance, IPStatus.BadRoute));
			instance.AddValue("TTLИстек", "TTLExpired", new CLREnumValueWrapper<IPStatus>(instance, IPStatus.TtlExpired));

			// TODO: Что это?!
			instance.AddValue("ПревышеноВремяПересборкиTTL", "TtlReassemblyTimeExceeded", new CLREnumValueWrapper<IPStatus>(instance, IPStatus.TtlReassemblyTimeExceeded));

			instance.AddValue("ОшибкаПараметров", "ParameterProblem", new CLREnumValueWrapper<IPStatus>(instance, IPStatus.ParameterProblem));

			// TODO: Что это?!
			instance.AddValue("ИсточникПогас", "SourceQuench", new CLREnumValueWrapper<IPStatus>(instance, IPStatus.SourceQuench));

			instance.AddValue("ПлохаяЦель", "BadDestination", new CLREnumValueWrapper<IPStatus>(instance, IPStatus.BadDestination));
			instance.AddValue("ЦельНедостижима", "DestinationUnreachable", new CLREnumValueWrapper<IPStatus>(instance, IPStatus.DestinationUnreachable));

			// TODO: Что это?!
			instance.AddValue("ПревышеноВремяЗапроса", "TimeExceeded", new CLREnumValueWrapper<IPStatus>(instance, IPStatus.TimeExceeded));


			instance.AddValue("ПлохойЗаголовок", "BadHeader", new CLREnumValueWrapper<IPStatus>(instance, IPStatus.BadHeader));
			instance.AddValue("НеопознанныйЗаголовок", "UnrecognizedNextHeader", new CLREnumValueWrapper<IPStatus>(instance, IPStatus.UnrecognizedNextHeader));
			instance.AddValue("ОшибкаICMP", "ICMPError", new CLREnumValueWrapper<IPStatus>(instance, IPStatus.IcmpError));

			// TODO: Что это?!
			instance.AddValue("НесовпадениеЦелевойОбласти", "DestinationScopeMismatch", new CLREnumValueWrapper<IPStatus>(instance, IPStatus.DestinationScopeMismatch));

			instance.AddValue("НеизвестнаяОшибка", "Unknown", new CLREnumValueWrapper<IPStatus>(instance, IPStatus.Unknown));

			return instance;
		}
	}
}
