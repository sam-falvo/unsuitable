require lib/config.fs
require lib/articles-db.fs
require lib/article.fs
require lib/views.fs
require lib/contents.fs

variable src
variable len

require lib/template.fs

variable out

: items		begin dup while indexItem 1- repeat drop ;
: n		#articles max-articles-on-index-page min ;
: -empty	empty? if diagnostic r> drop then ;
: content	-empty n items ;
: indexPage 	here src !  S" theme/indexPage" contents  here src @ - len !
                here out !  expand  out @ here over - type ;

indexPage bye

