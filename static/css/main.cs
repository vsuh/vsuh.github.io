body {
  font-family: "Roboto Condensed", Arial, sans-serif;
/*  background: url("/static/img/subtle_dots.png");*/
  background-color: #FAFAF0;
  line-height: 1.5em;
  font-weight: 300;
  font-size: 16px;
  color: #666;
}
hr {
  margin-top: 20px;
  margin-bottom: 20px;
  border: 0;
  border-top: 1px solid #E1F1F6;
  border-bottom: 1px solid #fff;
}
span.time, span.categories {
  color: #ADADAD;
  margin-bottom: 5px;
  font-size: 11px;
}
h1, h2, h3 {
  color: #696969;
  font-weight: normal;
}
h1 {
  margin-bottom: 10px;
  font-size: 25px;
  font-weight: 900;
}
h2, h3 {
  margin-bottom: 5px;
}
a, a:link, a:active {
  text-decoration: none;
  color: #5f5797;
}
a:hover {
  color: #53B353;
  text-decoration: underline;
}

/* Layout */
.main-layout {
  background: #fff;
}
.sidebar-nav {
  margin: 0;
  padding: 0;
}
.sidebar-nav li {
  margin: 0;
  list-style: none;
}
.sidebar-nav li::before {
  content: "»";
  margin-right: .5em;
}

/* Content */
div.content pre {
  background: #333333;
  padding: 10px;
  color: #FFF;
  overflow-x: auto;
  font-family: Menlo, Monaco, Consolas, 'Courier New', monospace;
  font-size: 12px;
  border: none;
}

ol.posts {
    list-style: circle;
}

div.content .highlight {
	background: #333333;
}
footer {
  border-top: 1px solid #F7F1F1;
  width: 100%;
  height: 10px;
  margin-top: 10px;
  margin-bottom: 3em;
  padding-top: 10px;
  color: #C2C2C2;
  font-size: 11px;
  bottom: 0;
  padding-bottom: 10px;
}

/* Left column */
div.col-sm-3 {
  margin-top: 100px;
  font-size: 11px;
  color: #666;
}
div.col-sm-3 strong {
  font-size: 16px;
  color: #4A4A4A;
  font-weight: normal;
}
div.col-sm-3 div.profile-about {
  margin-top: 10px;
  color: #8C8C8C;
}
div.profile-about {
  line-height: 0.9em;
}
div.author-name {
  font-size: 180%;

  color:#CACAA0;
  text-shadow: -1px -1px #99C;
}

/* Pagination */
.PageNavigation {
  font-size: 14px;
  display: block;
  width: auto;
  overflow: hidden;
}
.PageNavigation a {
  display: block;
  width: 50%;
  float: left;
  margin: 1em 0;
}
.PageNavigation .next {
  text-align: right;
}
.PageNavigation .prev {
  text-align: left;
}

/* Social Icons */
.social{
  display: block;
  margin: 10px 0;
}
.social ul {
  list-style-type: none;
  margin: 0;
  padding: 0;
}
.social ul li {
  display: inline-block;
  margin: 0 5px;
}
.social li a {
  font-size: 16px;
  color: #969394;
}
.social li a:hover {
  color: #6D6D6D;
}

.share-page {
  padding: 10px 10px 5px;
  border-top: 1px solid #f0f0f0;
  border-bottom: 1px solid #f0f0f0;
}
.post-content img,
.content img {
  max-width: 100%
}

/* Responsive Conditional */
@media (min-width: 1024px) {
  .fixed-condition {
    position: fixed;
    max-width: 255px;
  }
}
@media (max-width: 768px) {
  div.col-sm-3 {
    margin-top: 30px;
  }
}
