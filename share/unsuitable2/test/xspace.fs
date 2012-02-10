warnings off
marker done

create buff
    $EF c, $BE c, $CE c, $FA c,
    $12 c, $34 c, $56 c, $78 c,

: update   ;
variable block-called
: block    drop buff block-called on ;
include ../lib/xspace.fs

: s       block-called off ;
: t10.0   0 x@32 drop block-called @ 0= abort" t10.0" ;
: t10.1   0 x@32 $FACEBEEF xor abort" t10.1" ;
: t10.2   4 x@32 $78563412 xor abort" t10.2" ;
: t10.3   1024 x@32 $FACEBEEF xor abort" t10.3" ;
: t10.4   1028 x@32 $78563412 xor abort" t10.4" ;
: t10     t10.0 t10.1 t10.2 t10.3 t10.4 ;
t10

done marker done

create buff
    16 allot
    buff 16 $CD fill
variable update-called
: update   update-called on ;
: block    drop buff ;
include ../lib/xspace.fs

create expected
    $CD c, $CD c, $EF c, $BE c, $AD c, $DE c, $CD c, $CD c,

: s       update-called off ;
: t11.0   s $DEADBEEF 2 x!32  buff 8 expected 8 compare abort" t11.0" ;
: t11.1   s $DEADBEEF 2 x!32  update-called @ 0= abort" t11.1" ;
: t11     t11.0 t11.1 ;
t11

done

