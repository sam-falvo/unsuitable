: +=            src @ c@ [char] = = if 1 src +! exit then 2drop r> drop ;
: /=0           dup if exit then 2drop r> r> 2drop ;
: -=            src @ c@ [char] = xor if exit then r> drop ;
: -end          src @ endsrc @ u< if exit then r> drop ;
: str           begin -end -= 1 src +! again ;
: urlstr?       src @ str src @ over - urldecode ;
: urlstr        urlstr? /=0 ;
: substr        urlstr += urlstr? 2swap k=v ;

