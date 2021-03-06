---
book: world1c
title: Подсветка строк протокола в oscript
---

# Подсветка строк лога

При использовании библиотеки `logos`, как известно, если вызывается метод `УстановитьРаскладку`, выводимая на экран строка получается из функции `ПолучитьФорматированноеСообщение`
В этой функции строки можно раскрасить, в зависимости от уровня протокола:

```bsl
   Функция ПолучитьФорматированноеСообщение(Знач СобытиеЛога) Экспорт
	Если ВремяНачалаРаботы = Неопределено Тогда
		ВремяНачалаРаботы = ТекущаяДата();
	КонецЕсли;

	УровеньЛога = СобытиеЛога.ПолучитьУровень();
	НаименованиеУровня = Лев(УровниЛога.НаименованиеУровня(УровеньЛога), 8);
	Сообщение = СобытиеЛога.ПолучитьСообщение();
	ИмяЛога = СобытиеЛога.ПолучитьИмяЛога();
	ИстеклоСекунд = 1+Окр((СобытиеЛога.ПолучитьВремяСобытия() - ВремяНачалаРаботы) / 1000,0);

	Если УровеньЛога = 1 или УровеньЛога = 2 Тогда
		Подсвет = "[32;40m";
	ИначеЕсли  УровеньЛога = 3 или УровеньЛога = 4 Тогда
		Подсвет = "[31;40m";
	Иначе
		Подсвет = "[0;0m";
	КонецЕсли;
	Несвет = "[0;0m";
	ФорматированноеСообщение = СтрШаблон("%1 %2 - %4%3%5", Формат('00010101'+ИстеклоСекунд, "ДФ=HH:mm.ss"), НаименованиеУровня, Сообщение, Подсвет, Несвет);

	Возврат ФорматированноеСообщение;
КонецФункции
```

Если при копировании функции символ `эскейп` перед "[" не скопировался, его можно заменить выражением `Символ(27)`
