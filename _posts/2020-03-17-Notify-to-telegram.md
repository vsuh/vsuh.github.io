---
book: world1c
title: Уведомление об ошибке скрипта
---

# Отправка результатов работы скрипта в telegram

Несколько дней писал и отлаживал скрипт для обновления локальной информационной базы - платформы для разработки обработок и печатных форм.
Скрипт (cmd) должен делать следующее:

- получать значения общих переменных из одного файла настроек `settings.ini`
- запускаться поочередно, по алфавиту одним скриптом `run.bat`
- копировать последний dt файл с сетевого хранилища
- загрузить dt файл в локальную информационную базу
- выгрузить из серверной базы конфигурацию в cf файл
- загрузить конфигурацию из cf файла в локальную информационную базу
- применить изменения конфигурации
- установить новый заголовок приложения типа _Локальная копия от 24.02.2002 г._
- отправить уведомление на e-mail и/или в telegram

с последним пунктом вышла незадача: [telegram](https://api.telegram.org/) с территории нашего предприятия то виден, то не виден, спасибо РКН.
А на современные почтовые сервера и вовсе без поллитры ничего не отправить.  
В результате, почтовое сообщение отправил, формируя и тут же отправляя сообщение [MS Outlook](https://docs.microsoft.com/ru-ru/office/vba/api/outlook.mailitem)  

_Уточнение: при успешном завершении обновления, уведомление как раз не требуется. А вот,в случае возникновения ошибки, ее описание, имя файла в котором произошла ошибка и заголовок процесса с датой и временем начала исполнения должны быть зафиксированы в протоколе и включены в уведомление.
и ещё важно: цепочка скриптов должна прекратиться при возникновении первой ошибки. Дальнейше действия смысла не имеют. Т.о. когда
флаг ошибки взведен, процесс должен прекращаться и сообщение об ошибке отправляться мне._


```bat
...

call :createVBS %vb%

call %vb% ^
	/mailto:"VSukhikh@gmail.com"^
        /Subject:"%date% обновление mc_bnu_oru"^
        /BodyText:"%txt%"^
	/Attach:%temp%\prt.txt

exit
:createVBS
2>nul md>%1
@echo Dim OutLookApp		>>%1
@echo Dim OutLookItem		>>%1
@echo On Error Resume Next	>>%1
@echo Set OutLookApp = GetObject(, "Outlook.Application") >>%1
@echo Set OutLookApp = CreateObject("Outlook.Application")>>%1
@echo Set objNamedArgs = WScript.Arguments.Named          >>%1
@echo Set OutLookItem = OutLookApp.CreateItem(0)          >>%1
@echo With OutLookItem                                    >>%1
@echo     .Subject = objNamedArgs.Item("Subject")         >>%1
@echo     .to = objNamedArgs.Item("MailTo")      	  >>%1
@echo     .HtmlBody = objNamedArgs.Item("BodyText")       >>%1
@echo     .Attachments.Add objNamedArgs.Item("Attach")    >>%1
@echo     .Display                                        >>%1
@echo     .Send                                           >>%1
@echo End With                                            >>%1
exit /b
```

Возникла идея отправлять уведомления через сервис [IFTTT](https://ifttt.com/maker_webhooks/).
Создал там приложение (applet): "Если приходят данные на вебхук `OBRrefreshing` - отправить их в телеграм".
![applet screen](https://lh3.googleusercontent.com/FbdPxUPeUE4RuShskdpHiJT_80jCNoeZ0kdvLrs9V3Jy4Nkckg-3vw42t63PDL8CtsbOzkGcL06J_foL4CVeOp7_8BHZuZz1fv6ATF3wZZyeDEemWBbk5RQ6FkKvSVq6RvoKcZBesA=w2400)

Данные отправляются так:

```bat
echo {"value1": "%txt:#=<br>%"} >%out%
if exist %out% (
	curl -X POST -H "Content-Type: application/json" -d @%out% "https://maker.ifttt.com/trigger/OBRrefreshing/with/key/cd7[API-key]KNDEx"
)

```



Результат доступен на [github]()



