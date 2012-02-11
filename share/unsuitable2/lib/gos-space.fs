\ Depends on the following words defined prior:
\
\ src ( - a ) Variable that points to the source of a blob.
\             Depending on the operation performed, the address
\             may be an xspace pointer or a core pointer.
\ dst ( - a ) Variable pointing to the destination of a blob.  This
\             is only used by retrieve at present, and thus is
\             always a core pointer.
\ len ( - a ) Variable containing the length of the blob to transfer.
\ 
\ gosWofs@ ( - n ) returns the current GOS space write pointer offset.
\ gosWofs! ( n - ) updates the current GOS space write pointer offset.
\ core ( xa - ca ) converts an xspace address into a core address.

: reserve   gosWofs@ + gosWofs! ;

: ct        1024 gosWofs@ 1023 and -  len @  min ;
: advanced  ct >r  r@ src +!  r@ reserve  r> negate len +! ;
: out       src @ ct gosWofs@ core swap move update advanced ;
: keep      begin len @ while out repeat ;

: ct        1024 src @ 1023 and -  len @ min ;
: advanced  ct >r  r@ src +!  r@ dst +!  r> negate len +! ;
: inp       src @ core dst @ ct move advanced ;
: retrieve  begin len @ while inp repeat ;

