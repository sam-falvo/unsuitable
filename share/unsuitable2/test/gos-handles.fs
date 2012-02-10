warnings off
marker done


variable abort-called
variable ctr
create bfr   1024 allot

: (abort")   abort-called on ;
: abort"     34 parse 2drop  postpone (abort") ; immediate
: /column    1 ;
: gosAddrsBlock   66 ;
: gosLensBlock    gosAddrsBlock /column + ;
: /gos-space  10240 ;
: update     ;
: block      drop bfr ;
: x@32       drop ctr @ if 12345 else $FFFFFFFF then  -1 ctr +! ;
include ../lib/xspace.fs
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

: s          257 ctr !  abort-called off  bfr 1024 $CD fill ;
: t32.0      s  0 0 257 set  abort-called @ 0= abort" t32.0" ;
: t32.1      s  0 0 1 set  abort-called @ abort" t32.1" ;
: t32.2      s  $FFFFFFFF 0 1 set  abort-called @ 0= abort" t32.2" ;
: t32.3      s  0 10240 1 set  abort-called @ 0= abort" t32.3" ;
: t32.4      s  10238 5 set  abort-called @ 0= abort" t32.4" ;
: t32.5      s  10238 2 set  abort-called @ abort" t32.5" ;
: t32.6      s  $DEAD $BEEF 1 set bfr @ $FFFFFFFF and $CDCDCDCD xor abort" t32.6" ;
: t32.7      s  $DEAD $BEEF 1 set bfr 4 + @ $FFFFFFFF and $0000DEAD xor abort" t32.7" ;
: t32        t32.0 t32.1 t32.2 t32.3 t32.4 t32.5 t32.6 t32.7 ;
t32

done


