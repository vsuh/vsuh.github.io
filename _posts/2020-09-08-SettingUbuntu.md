---
book: linux
description: Настройки Ubuntu Desktop 20.04.1 после установки
title: Настройки Ubuntu Desktop 20.04.1
---

# Настройки Ubuntu Desktop

> Пришла пора мне обновить операционку на моём мини-РС. Раньше на нём стояла Ubuntu 18 LTS и я подумал было, что, может появилось что-то более подходящее для моего слабого домашнего недосервера.
Попробовал [elementary OS](https://elementary.io/ru) и [MX-19](https://mxlinux.org)... И, в итоге,
поставил [Ubuntu 20.04.1 LTS (focal fossa)](https://help.ubuntu.ru).  

Перед установкой, я выбрал вариант минимальной установки.
Итак, операционка установлена, что дальше?  
Дальше, я установил пакеты: `spotify`, `code`, `htop`, `tmux`, `mc`, `git`, `firefox`, `net-tools`, `openssh-server`, `remmina`, `rygel`, `transmission-daemon`, `openvpn-systemd-resolved`,`ubuntu-restricted-extras`, `libavcodec-extra`, `libdvd-pkg`

`sudo apt install gnome-tweak-tool`

## Настройка openvpn клиента

> upd: Черт! оказывается, можно установить компонент сетевого менеджера `sudo apt install network-manager-openvpn*` и настроить OpenVPN из настроек. В следующий раз попробую..


Доступ в локальную сеть предприятия у нас происходит по VPN. Сетевой бог выдает сотруднику `ovpn` файл, с его помощью работник и подключается к сети.  
Для того, чтобы заработало разрешенине имен из локальной сети, мне пришлось добавить в ovpn файл следующие строки:

```
auth-user-pass /etc/openvpn/.vpn.auth

script-security 2
up /etc/openvpn/update-systemd-resolved
down /etc/openvpn/update-systemd-resolved
down-pre
dhcp-option DOMAIN-ROUTE .
dhcp-option DNS 192.168.3.3
dhcp-option DOMAIN mydomain.local

```
Затем, скопировал получившийся файл в каталог `/etc/openvpn` с именем `mydomain.conf`, создал файл 
`/etc/openvpn/.vpn.auth` с именем и паролем от учетной записи в домене и установил права на оба файла `600`.

После этого проверил работу `openvpn` запуском команды `systemctl start openvpn@mydomain` и, убедившись, что все работает, добавил строчку `AUTOSTART=mydomain` в файл `/etc/default/openvpn`
Теперь VPN поднимается сразу при загрузке сервера.


## Внешний HDD

Мой внешний винчестер после загрузки linux монтировался в пользовательское пространство по пути типа, `/media/vsuh/XXXX-XXXXXXXX-XXXXXXX-XXXX-XXXX`. Мне это не понравилось и я добавил в /etc/fstab 

```
/dev/sdb1	/media/HDD 	ext4 	users,rw,nosuid,nodev,relatime,stripe=8191,uhelper=udisks2
```

теперь винт виден всегда по одному и тому же адресу: `/media/HDD`

## Переключение раскладки

В установленной дополнительно программе __gnome-tweaks__ по пути *Keyboards & Mouse -> Additional Layout Options -> Switching to another layout* можно выбрать способ переключения раскладки __Ctrl-Shift__

## transmission-daemon

см. [мануал](https://wiki.archlinux.org/index.php/OpenVPN#systemd_service_configuration)

Для того, чтобы скаченные файлы были сразу доступны мне, пришлось сделать следующее:

1. Скопировать файлы настроек в домашний каталог:

    ```
    sudo cp -R /etc/transmission-daemon /home/user_name/.config/
    sudo chown -R user_name /home/user_name/.config/transmission-daemon
    ```

1. Изменить значение переменной  `CONFIG_DIR` в файле `/etc/default/transmission-daemon`
1. Изменить значение переменной `User` в файле сервиса `/lib/systemd/system/transmission-daemon.service` на **user_name**

    > я еще менял значения переменных `USER` и `NAME` на свё имя  в файле `/etc/init.d/transmission-daemon` но, кажется, это не влияет.

1. Отредактировать settings.ini под свои вкусы (пароль, белый список, каталоги incomplete и watch)

## keepass

Для хранения паролей, я везде использую базу keepass 2й версии. Чтобы установить сервер базы паролей, выполняем команду `sudo apt install keepassx`.  
Файл с базой лежит в облаке, поэтому дописываем в список источников APT репозитарий dropbox:

```
sudo echo "deb http://linux.dropbox.com/ubuntu bionic main" > /etc/apt/sources.list.d/dropbox.list
```
при обновлении источников пакетов получаем ошибку об отсутствии PGP ключа репозитория _FC918B335044912E_ регистрируем:

```
sudo apt-key adv --keyserver keyserver.ubuntu.com --recv-keys FC918B335044912E
```
и устанавливаем dropbox: `sudo apt install dropbox`
ии... что-то пошло не так. Установщик gnome потребовал запустить приложение (демон), потом открылась страница входа в аккаунт dropbox в браузере. После входа в аккаунт ничего не происходит.
Продолжаю наблюдение.
Оказывается, демон запустился, создал папку `~/Dropbox` и работает.  

> upd: dropbox мне не нравится тем, что допускает не более 3 подключенных к аккакнту устройств - буду переходить в другое облако.

В Firefox устанавливается адд-он [KeePassHttp-Connector](https://addons.mozilla.org/en-US/firefox/addon/keepasshttp-connector/?src=search), в систему - плагин **KeePassHttp**: `sudo apt install keepass2-plugin-keepasshttp`  
мда.. плагин оказался от родного **keepass2**, **keepassx** вообще пока не поддерживает плагины.  Пришлось **keepassx** снести и установить **keepass2** (который работает из-под mono).  
Не без танцев, но заработало. В Firefox пароли подставляет.

- В автозагрузку (_gnome-tweaks_ "Startup Applications")

## OneDrive

Как и собирался, переехал с `dropbox` на `onedrive`. Для синхронизации с **OneDrive** установил `cloudcross`.

```
echo 'deb http://download.opensuse.org/repositories/home:/MasterSoft24/xUbuntu_19.10/ /' | sudo tee /etc/apt/sources.list.d/home:MasterSoft24.list
curl -fsSL https://download.opensuse.org/repositories/home:MasterSoft24/xUbuntu_19.10/Release.key | gpg --dearmor | sudo tee /etc/apt/trusted.gpg.d/home:MasterSoft24.gpg > /dev/null
sudo apt update
sudo apt install cloudcross
```

Создал папку `~/OneDrive` и каждые 4 минуты из крона выполняю строчку:

```
/usr/bin/ccross  --provider onedrive -p ~/OneDrive  --prefer remote
```

## docker

В общем то по [мануалу](https://docs.docker.com/engine/install/ubuntu/)
и, дополнительно, `docker-compose`:

```
sudo curl -L https://github.com/docker/compose/releases/download/1.21.2/docker-compose-`uname -s`-`uname -m` -o /usr/local/bin/docker-compose
sudo chmod +x /usr/local/bin/docker-compose
docker-compose --version
```

читать про это можно в статье [Настройка среды непрерывного интеграционного тестирования с помощью Docker и Docker Compose в Ubuntu 16.04](https://www.digitalocean.com/community/tutorials/how-to-configure-a-continuous-integration-testing-environment-with-docker-and-docker-compose-on-ubuntu-16-04)

## vlc

Добавляем репозиторий разработчиков  `sudo add-apt-repository ppa:videolan/stable-daily`
и устанавливаем плеер `sudo apt install vlc`

## Kodi

`sudo apt install kodi kodi-pvr-iptvsimple`  
Каналы для PVR https://smarttvnews.ru/apps/iptvchannels.m3u

