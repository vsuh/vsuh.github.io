---
title: Тонкая настройка темы clean-dark
book: jekyll
share: true
tags:
 - настройка
 - jekyll
accent: "#3CA2A2"
toc: true
---

# Цветовой акцент

Цветовой акцент - это цвет важных элементов страницы таких как ссылки, кнопки, иконки. 
Текущий цветовой акцент <button class="btn" 
style="background-color:{{ page.accent }}; color:#444444;"> {{ page.accent }} </button> 
В нашей теме имееются и другие предопределенные значения для цветового акцента. см. файл **theme.scss**:

>theme.scss
{:.filename}
{% highlight scss %}
// Several accent colors, choose one or create your own!
$accent-color: #3CA2A2;     // original =)
// $accent-color: #C38FD6;   velvet
// $accent-color: #8FD6B3;   greenish
// $accent-color: #35B4DE;   bluish
// $accent-color: #D2E354;   yellowish
// $accent-color: #52B54B;   green

{% endhighlight %}

Можете использовать один из них (просто нажмите на кнопку) или определите свой собственный.

<button class="btn" style="background-color:#C38FD6; color:#444444">#C38FD6</button>, <button class="btn" style="background-color:#8FD6B3; color:#444444">#8FD6B3</button>, <button class="btn" style="background-color:#35B4DE; color:#444444">#35B4DE</button>, <button class="btn" style="background-color:#D2E354; color:#444444">#D2E354</button>, <button class="btn" style="background-color:#52B54B; color:#444444">#52B54B</button>.
 
<script>
  $('.btn').click(function(){
    var color = $(this).text();
    [].forEach.call($('a'), function(item) {
      item.style.color = color
    })
  })
</script>

<style>
  .label{
    cursor: default;
    border-radius: 5px;
    padding: 5px 8px;
  }
</style>

# Другие цвета

Так как Jekyll поддерживает SASS, то и другие основные цвета темы настраиваются через переменные в том же **theme.scss**


>theme.scss
{:.filename}
{% highlight scss %}
$font-color: #dddddd;
$background-color: #292929;
$post-panel-color: #444;
$footer-background-color: #292c2f;
$note-color: #87CEFA;
$warning-color: #ffff00;
{% endhighlight %}

# Фоновое изображение


Попробуйте еще изменить фон страницы, просто нажав на него.
Подходящий фон можно подобрать на сайте [transparenttextures.com](https://www.transparenttextures.com/).

<style>
.pattern-list{
    list-style-type: none;
    padding: 0;
}
.pattern{
    height: 100px;
    box-shadow: 0 0 3px 2px rgba(0,0,0,.1);

}
.pattern:hover {
    box-shadow: 0 0 3px 2px rgba(0,0,0,.3);
    transition: box-shadow .2s ease;
    cursor: pointer;
}
.smthg{
    max-width: none !important;
}
.col-sm-6 {
    padding: 5px !important;
}
</style>

<table width='100%' border='0' margin='0' padding='0'>
<TR>
<td>
<div class="pattern" style="background-image:url('{{ '/assets/css/pics/background/3px-tile.png' | relative_url }}')" title='3px-tile.png'></div>
</td>
<td>
<div class="pattern" style="background-image:url('{{ '/assets/css/pics/background/asfalt-light.png' | relative_url }}')" title='asfalt-light.png'></div>
</td>
<td>
<div class="pattern" style="background-image:url('{{ '/assets/css/pics/background/black-linen.png' | relative_url }}')" title='black-linen.png'></div> 
</td>
</TR><TR>
<td>
<div class="pattern" style="background-image:url('{{ '/assets/css/pics/background/food.png' | relative_url }}')" title='food.png'></div>
</td>
<td>
<div class="pattern" style="background-image:url('{{ '/assets/css/pics/background/gplay.png' | relative_url }}')" title='gplay.png'></div> 
</td>
<td>
<div class="pattern" style="background-image:url('{{ '/assets/css/pics/background/green-dust-and-scratches.png' | relative_url }}')" title='green-dust-and-scratches.png'></div> 
</td>
</TR><TR>
<td>
<div class="pattern" style="background-image:url('{{ '/assets/css/pics/background/hexellence.png' | relative_url }}')" title='hexellence.png'></div>
</td>
<td>
<div class="pattern" style="background-image:url('{{ '/assets/css/pics/background/random-grey-variations.png' | relative_url }}')" title='random-grey-variations.png'></div>
</td>
<td>
<div class="pattern" style="background-image:url('{{ '/assets/css/pics/background/shley-tree-1.png' | relative_url }}')" title='shley-tree-1.png'></div> 
</td>
</TR><TR>
<td>
<div class="pattern" style="background-image:url('{{ '/assets/css/pics/background/subtle-grey.png' | relative_url }}')" title='subtle-grey.png'></div>
</td>
<td>
<div class="pattern" style="background-image:url('{{ '/assets/css/pics/background/xv.png' | relative_url }}')" title='xv.png'></div>
</td>
<td>
<div class="pattern" style="background-image:url('{{ '/assets/css/pics/background/triangles.png' | relative_url }}')" title='triangles.png'></div> 
</td>
</TR>
</table>

<script>
  $('.pattern').click(function(){
    var source = this.style.backgroundImage;
    document.getElementsByTagName('body')[0].style.backgroundImage = source;
    console.log("url('" + source + "'))");
  })
</script>

Чтобы изменить фоновое изображение, укажите имя файла новой картинки в переменной `background-pattern` файла **theme.scss**.
Чтобы использовать другую картинку в качестве фона, загрузите ее с сайта
[transparenttextures.com](https://www.transparenttextures.com/) и положите в каталог 
 **assets/css/pics/background**.

>theme.scss
{:.filename}
{% highlight scss %}
// use this or pick any from /css/pics/background folder or from transparenttextures.com
$background-pattern: 'random-grey-variations.png';
{% endhighlight %}
