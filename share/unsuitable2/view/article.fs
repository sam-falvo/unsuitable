\ Dependencies
\   search ( -- n )   0 if article not found; article ID otherwise.
\   articleItem ( -- )  Renders an article, found via search, in HTML.
\   404page ( -- )      Renders a 404 Not Found response.
\   piPtr ( -- a )      PATH_INFO parsing: pointer to next character
\   piLen ( -- a )      PATH_INFO parsing: length of remaining text

variable n
: eat        1 piPtr +!  -1 piLen +! ;
: rndr       n @ search if articleItem else 404page then ;
: accumulate n @ 10 * piPtr @ c@ '0 - + n ! eat ;
: +digit     piPtr @ c@ '0 '9 1+ within if accumulate else 404page r> r> 2drop then ;
: -end       piLen @ 0= if r> drop then ;
: +number    0 n ! begin -end +digit again ;
: index      S" index.fs" included ;
: +length    piLen @ 0= if index r> drop then ;
: sl         +length +number rndr ;
: -slash     piPtr @ c@ [char] / = if eat sl r> drop then ;
: artikle    +length -slash 404page ;
artikle

