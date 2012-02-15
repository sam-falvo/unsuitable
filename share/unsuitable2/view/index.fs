variable out

: items		begin dup while indexItem 1- repeat drop ;
: n		#articles max-articles-on-index-page min ;
: -empty	empty? if diagnostic r> drop then ;
: content	-empty n items ;
: indexPage 	here src !  S" theme/indexPage" contents  here src @ - len !
                here out !  expand  out @ here over - type ;
indexPage
