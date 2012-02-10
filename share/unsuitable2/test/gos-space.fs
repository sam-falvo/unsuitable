warnings off
marker done

create b
  1024 allot

: update   ;
: block    drop b ;
include ../lib/xspace.fs
include ../lib/metadata.fs
include ../lib/gos-space.fs

: t20.0   15360 b x!32  1024 reserve  b x@32 16384 xor abort" t20.0" ;
: t20   t20.0 ;
t20

done

