---
layout: page
---

# История бложека

{% assign arcs_y = site.archives | where_exp: "item", "item.type == 'year'" %}
{% for arcy in arcs_y %}
- [{{ arcy.date | date: "%Y" }} год]({{ arcy.url }})
  {% for ara in arcy.posts %}
  - <i class='small-data'>{{ ara.date | date: "%d.%m.%Y" }}</i> [{{ ara.title }}]({{ ara.url | relative_url }}) 
  {% endfor %}
{% endfor %}
