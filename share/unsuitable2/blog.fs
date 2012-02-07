require lib/config.fs
require lib/articles-db.fs
require lib/article.fs
require lib/views.fs
require lib/templates.fs

: items		begin dup while indexItem 1- repeat drop ;
: n		#articles max-articles-on-index-page min ;
: -empty	empty? if diagnostic r> drop then ;
: content	-empty n items ;
: footer 	S" theme/index-footer" contents ;
: header 	S" theme/index-header" contents ;
: mime 		." Content-Type: text/html" cr cr ;
: indexPage 	mime header content footer ;
indexPage bye

