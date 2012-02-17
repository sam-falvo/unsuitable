: -&            ptr @ c@ [char] & xor if exit then r> drop ;
: -done         len @ 0= if r> drop then ;
: span          begin -done -&  1 ptr +! -1 len +! again ;
: assoc         ptr @ src ! span ptr @ endsrc ! substr ;
: +& 		ptr @ c@ [char] & = if exit then r> drop ;
: kvparse       begin -done assoc +& 1 ptr +! -1 len +! again ;

