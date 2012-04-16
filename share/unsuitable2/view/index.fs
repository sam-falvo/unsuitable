variable out

max-articles-on-index-page constant N
create ids 	N cells allot
create tss      N cells allot
: -end          dup N cells u< if exit then r> 2drop ;
: ids0   	$FFFFFFFF over ids + ! ;
: tss0		$FFFFFFFF over tss + ! ;
: sort0		0 begin -end ids0 tss0 cell+ again ;

include ../lib/insertion-sort.fs

: ins           article id@ timestamp@ insert ;
: sort		sort0 ['] ins perform allArticles ;

: -empty 	dup $FFFFFFFF = if r> 2drop then ;
: -end          dup N u< if exit then r> 2drop ;
: list		0 begin -end dup cells ids + @ space -empty article indexItem space space 1+ again ;

: -empty	empty? if diagnostic r> drop then ;
: content	-empty sort list ;
: indexPage 	here src !  S" theme/indexPage" contents  here src @ - len !
                here out !  expand ;
indexPage
