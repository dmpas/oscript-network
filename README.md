# Сетевые фукнции для Односкрипта

## Пинги

```
	Звень = Новый Звень;
	Озвень = Звень.Послать("localhost", 5);

	Если Озвень.Состояние <> СостояниеПрозвона.Успешно Тогда
		ВызватьИсключение "Хост недоступен!";
	КонецЕсли;
```