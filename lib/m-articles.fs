require mappings.fs
require general.fs
require articles.fs
require slurp.fs
require time.fs
require respond.fs

end-of-url &parameters - constant /parameters
: oops              s" m-index.fs" included bye ;
: |parameters|>=2   /parameters 2 u< if oops then ;
|parameters|>=2


variable id  0 id !
variable p   -1 p !
variable n   -1 n !
variable which

: -span    s\" <span style=\"color: #ddd;\">" respond ;
: -/span   s" </span>" respond ;
: -label   s" No article written yet." respond ;

: invoke   >r ;
: safely   r>  article >r  which @ @ articleWithId!  invoke  r> article! ;

: url      safely s" http://www.falvotech.com/blog2/blog.fs/articles/" respond  articleId s>d <# #s #> respond ;
: +span    s\" <a href=\"" respond url s\" \">" respond ;
: +/span   s" </a>" respond ;
: +label   safely title gob! get, ;

create +/-
  ' +span ,   ' +/span ,   ' +label ,   0 ,
  ' -span ,   ' -/span ,   ' -label ,   0 ,

: go       which @ @ -1 = 4 cells and + @ execute ;
: span     [ +/- ] literal go ;
: /span    [ +/- cell+ ] literal go ;
: label    [ +/- 2 cells + ] literal go ;
: succ     n which ! ;
: pred     p which ! ;


variable s
variable end
: mime   ." Content-type: text/html" cr cr ;
: valid   mime  here s ! s" theme/article.html" slurp here end ! s" response.fs" included bye ;


: exists:     dup -1 = if r> 2drop then ;
: .f          id @ articleWithId! execute exists: gob! get, ;
: title       ['] title .f ;
: lead        ['] lead .f ;
: body        ['] body .f ;
: timestamp   >web id @ articleWithId! timestamp .time >con ;


: n!          articleId n @ <   n @ -1 =  or if articleId n ! then ;
: nxt         articleId id @ > if n! then ;
: prv         articleId id @ <  articleId p @ >  and if articleId p ! then ;
: exists      nxt prv ;
: row         dup articleIds - article! articleId -1 xor if exists then ;
: -all        [ articleIds /afields + ] literal u< ;
: scan        articleIds begin dup -all while row cell+ repeat drop ;


&parameters 1+ constant &id
: -eon     dup end-of-url u>= if drop scan valid then ;
: -0-9     dup [char] 0 < swap [char] 9 > or ;
: *10+     dup c@ [char] 0 - id @ 10 * + id ! ;
: digit    dup c@ -0-9 if drop oops then *10+ ;
: numeric  &id begin -eon digit char+ again ;
numeric

