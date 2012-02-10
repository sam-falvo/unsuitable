warnings off
marker done

variable abort-called
variable ctr

: (abort")   abort-called on ;
: abort"     34 parse 2drop  postpone (abort") ; immediate
: /column    1 ;
: gosAddrsBlock   66 ;
: x@32       drop ctr @ if 12345 else $FFFFFFFF then  -1 ctr +! ;
include ../lib/gos-handles.fs

: s          5 ctr !  abort-called off ;
: t30.0      s  alloc 5 xor abort" t30.0" ;
: t30.1      s  alloc drop -1 ctr @ xor abort" t30.1" ;
: t30.2      s  alloc drop abort-called @ abort" t30.2" ;
: t30        t30.0 t30.1 t30.2 ;
t30

: s          257 ctr !  abort-called off ;
: t31.0      s alloc abort-called @ 0= abort" t31.0" ;
: t31.1      s alloc ctr @ 1 xor abort" t31.1" ;
: t31        t31.0 t31.1 ;
t31

done

