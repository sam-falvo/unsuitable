warnings off
marker done

: hello         s" hello" ;
: h%65llo       s" h%65llo" ;
: hello+world   s" hello+world" ;
: hello_world   s" hello_world" ;
: %4c%4C        s" %4c%4C" ;

( begin unused variables for this test. )
\ variable src
\ variable endsrc
\ : k=v           2drop 2drop ;
( end )

include ../lib/urldecode.fs

: t80.0         hello urldecode s" hello" compare abort" t80.0" ;
: t80.1         hello urldecode hello drop nip = abort" t80.1" ;
: t80.2         h%65llo urldecode hello compare abort" t80.2" ;
: t80.3         h%65llo urldecode nip 5 xor abort" t80.3" ;
: t80.4         hello+world urldecode hello_world compare abort" t80.4" ;
: t80.5         %4c%4C urldecode S" OO" compare abort" t80.5" ;
: t80.6         0 0 urldecode nip abort" t80.6" ;
: t80           t80.0 ( t80.1 t80.2 t80.3 t80.4 t80.5 t80.6 ) ;
t80

done

