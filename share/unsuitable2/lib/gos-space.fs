: reserve   gosWofs@ + gosWofs! ;

: ct        1024 gosWofs@ 1023 and -  len @  min ;
: advanced  ct >r  r@ src +!  r@ reserve  r> negate len +! ;
: copy      src @ ct gosWofs@ core swap move update advanced ;
: keep      begin len @ while copy repeat ;

