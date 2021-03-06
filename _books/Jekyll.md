---
book: jekyll
title: О Jekyll
root: true
description: О Jekyll с любовью
---


# {{ page.title }}
---

Этот блог построен на [jekyll](https://jekyllrb.com), поэтому поневоле пришлось поизучать вопрос. Вопрос лучше изучать по хорошей [документации](http://prgssr.ru/documentation/01_welcome)

После трех попыток, как в сказке, остановился на теме [clean-dark](https://github.com/streetturtle/jekyll-clean-dark). В теме есть даже [динамический конфигуратор двух настроек](/2020/01/03/links.html) - цветового акцента и фонового рисунка страниц сайта.

Сайт на [jekyll](https://jekyllrb.com) может работать из-под [github](https://github.com), при этом [github](https://github.com) станет хостингом сайта, для этого пользователю github 
c именем USER нужно создать репозиторий с именем `USER/USER.github.io`. 
Каталог `_site` из этого репозитория будет отображаться [github](https://github.com) по адресу https://USER.github.io


Так вот, после каждого коммита в репозиторий [github](https://github.com), гитхабовский [jekyll](https://jekyllrb.com) будет собирать файлы, обрабатывать их и складывать в каталог `_site`.
Правила сборки и обработки файлов описаны в единственном конфигурационном файле формата YML `_config.yml`

Впрочем, каталог `_site` можно собрать и самостоятельно, безо всяких jekyll'ов из обыкновенных статических _html_ файлов и [github](https://github.com) будет исправно отображать его содержимое как сайт https://USER.github.io

Второй вариант запуска сайта - локально, командой `jekyll server` для этого нужно установить
Ruby development environment. Процесс установки для различных операционных систем прекрасно описан на странице [документации](https://jekyllrb.com/docs/installation/).


