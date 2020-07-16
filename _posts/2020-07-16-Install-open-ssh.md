---
book: world1c
title: Установка open-ssh сервера на windows
---

# Установка
Для работы с удаленными папками на windows сервере по ssh из VSCode плагином [Remote-SSH](https://github.com/Microsoft/vscode-remote-release) на стороне windows сервера требуется служба ssh-сервера. Давайте его установим.

- Скачиваем последнюю версию [дистрибутива OpenSSH](https://github.com/PowerShell/Win32-OpenSSH/releases)

Сейчас доступна версия v8.0.0.0p1-Beta. Скачиваем `OpenSSH-Win64.zip`.

![](https://lh3.googleusercontent.com/Aqkwx8NzHbuy71nwBWNhM6TrpRLz4eB8MEq6AxVGQC8Fo3xmuidvXm5vH3wVqydzGaUrkQG9Tloy9qr_Gxvl-VUlcMl1RIWyTlo4VLw7cgvs44TRNdsx9UtSVYeSuiX9PNcqIswDKKg=w2400)

- Создаем каталог C:\Program Files\OpenSSH и распаковываем в неё содержимое архива.

![](https://lh3.googleusercontent.com/LkfWMkwRNsdE31HVtB_vnCheVGuA6YTg5G7LSmpbHcLqF3WW3htK9tq2VgS3LeqnPVHl4idt5C_fJljMPu1EGVelJMEJnQ2X3p-H8H-P5SynuFA_MAYjiQiYJSChNonKWtTdZXdf-m0=w2400)

- Запускаем powershell от имени администратора.

![](https://lh3.googleusercontent.com/v5mWGOaF_DI60iCzzYQVVbxhOwioWIjdR3QteckDlOh6J04u7YLulKkwz1DZ6PJECoJBK368XM3wgUZoDvqFd3_ZRVDhk4riKUR5a_IlssbBzQDM4CRnRMQIwdLrYmLSn50_OTqzkvk=w2400)

- Выполняем скрипт установки:

```
cd "\Program Files\OpenSSH"
.\install-sshd.ps1
```

> sshd and ssh-agent services successfully installed 

Если произошла ошибка политики безопасности, то можно выполнить установку так:

powershell -ExecutionPolicy Bypass -File .\install-sshd.ps1

![](https://lh3.googleusercontent.com/0pYe8rH5nAQSTff5-S4V_8qH4q20jZVOfh2iXzwXQeSj_VETMyh5Fugng3yPcuFRp3wS0VkRAQwyOoi8uvKWuVFKAbyok9MRD08cZSQ9fS2s4yargPHU3vjp0oG6aVTRDbJnqdhyWII=w2400)

- Генерируем серверные ключи:

```
.\ssh-keygen.exe -A
```

Если при этом появляется ошибка

![](https://lh3.googleusercontent.com/pi-8wjVYghm3340GIYM2r874q8aV0g1Rfcqpu76S2fO_D_p8NKZSfFdESkU4H9UgzPM00R8bWdC8pdvuRI5stRZs7bcOZMuXJUjQ1VEv3nmCktsHreu5AYhOGEx43lTL4nyRDsUGdvQ=w2400)

Нужно в папке `C:\ProgramData` создать вручную директорию `ssh`

- Снова пытаемся сгенерировать серверные ключи:

```
.\ssh-keygen.exe -A
```

На этот раз процедура выполняется успешно.

![](https://lh3.googleusercontent.com/3CaMCuR08kDuOelVfLFxsWtcBg5n3gguqUqX2-b79lDiwV1-XY0yJMG2UZLsuHo1P-ltz71CWWIj7FAQnhNOeVjQ6jlbITSnenjiaQ98JQk8ZkCjRAhq5_9Hn-Wsih6-nJUYwjFSfjw=w2400)

- Настраиваем владельца и права доступа на файлы ключей и каталоги сервера :

```
PowerShell -ExecutionPolicy Bypass -File .\FixHostFilePermissions.ps1
```
На каждый вопрос отвечаем "A".


![](https://lh3.googleusercontent.com/PFWaQRkcrK0BkRn9ftBJvyT6Ck2dyuzw3SzncNdk_dFC6cWkEeaTFCETHZ8VRFZyZa2k7B4NBclwQGSqEj0k8qRj6spdQqMDel1VuFApgnj_zKNVH13g0vzcugSsv_SvtT_CQfPh5ZI=w2400)

- Открываем 22 порт

OpenSSH работает по порту TCP 22. Откроем доступ в Firewall:

```
New-NetFirewallRule -Protocol TCP -LocalPort 22 -Direction Inbound -Action Allow -DisplayName SSH
```

![](https://lh3.googleusercontent.com/GMIFHo3sFqm2LTeu1G0y-sXZzF9-gVoVdrYK0UVSuRFo4M27mrzRD1IEme_7QYpn-B-XA6MTsAukJTQBGXO7vXkgsQsITM-2pPSZDPBsItyaVvsmi7lu1wlUGIhfMN4B4rCTaTk8Ues=w2400)

Эта команда сработает на Windows Server 12 и моложе. На более старых серверах порт можно открыть через GUI в оснастке Windows Firewall with Advanced Security.

![](https://lh3.googleusercontent.com/0_lFoBoT53_m4eMkbbndsWMcLLd3Rf0k3tDnTioqJ7SCUcX21TiMkNFzym1SpubOmeeH8ElVXYldHO0jy5CB52mcN044TEImfpQK4S8xvJ9wJ3FdQR3gTzUn5tyKDOtd3BHW8AW1sCA=w2400)

- Запуск службы OpenSSH

Открываем список служб:

```
services.msc
```

Находим службу "OpenSSH SSH Server". В свойствах службы устанавливаем автоматический запуск и запускаем её.

![](https://lh3.googleusercontent.com/-sjyvvfmhJfs77QZSGOvjdFDKrA5Nfbbhmu7JNeAJHWHo2TB8_iahf9g-yIChk09AHhdxHj45_zqD_n1g0CCRpz-CyFJTL_2bYx3PdQjXtuhNJJkrK5C62NgkZbuakTEHmPch_6ZuqE=w2400)

Проверим что 22 порт работает:

```
netstat -tan | find "22"
```

![](https://lh3.googleusercontent.com/IpQNsUaT6VE0vNdyxKp7BfkW4Pg3Xy0sKcPaRSeResHy_bzoH-HsJXVSxsHaThdgM63ylkJedVOKftxJdo-VDaXZzNcj3GK9Qv-NXFyaVCHlJUwM8izIdJ0zCWGjxSrluV9KwHBy8b4=w2400)

22 порт слушается.

- Проверка OpenSSH

Проверим с помощью WinSCP. Для доменного пользователя используется логин вида domain\username.

![](https://lh3.googleusercontent.com/GiF01ivuuqsR2cMZt-LEYkhM4uufnmA2gHI8WOhVqqg3zBf9FTKHSSG7OPI-3LNt5RiQ3v_celajt6_STMuNtSys_rOu4sTxRIU6dSKpzasnlqn8uPWrid95hJGCGjcZohRR2TN6Sg4=w2400)

При первом входе появится окно:

![](https://lh3.googleusercontent.com/STV6Hz-I7ay_aZNVUpwtWxq5dZkKYA4Wtwu64rxeowiIxAZznLHzyywtNsewRsro5MsnOoMHTRoPKMABykoA8SsRNaMOCqGkFkND9F7TmMuTYW9P7Qlg3p-OQFOnMtusTj0et3a-Cps=w2400)

Yes.

Установка завершена.


