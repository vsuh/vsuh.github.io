---
layout: book
---

    <ul> 
      {% for post in site.posts %}
        {% for tag in post.tags %}
          <li class="archive_list">
            <time>{{ post.date | date_to_string }}</time>
            <a class="archive_list_article_link" href='{{ post.url | relative_url }}'>{{post.title}}</a>
            <p>{{post.description}}</p>
          </li>
        {% endfor %}
      {% endfor %}
    </ul>
