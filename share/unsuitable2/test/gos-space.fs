warnings off

marker done

\ Space Reservation

create b
  1024 allot

: update   ;
: block    drop b ;

include ../lib/xspace.fs
include ../lib/metadata.fs

variable src
variable len

include ../lib/gos-space.fs

: t20.0   15360 1024 x!32  1024 reserve  1024 x@32 16384 xor abort" t20.0" ;
: t20   t20.0 ;
t20

done marker done

\ Saving blobs -- unaligned first chunk

create b
  1024 allot

create srcbuf
  1024 allot

: update   ;
: block    drop b ;

include ../lib/xspace.fs
include ../lib/metadata.fs

variable src
variable dst
variable len

: gosWofs@   dst @ ;
: gosWofs!   dst ! ;

: foo len ;

include ../lib/gos-space.fs

: s       srcbuf src !  100 dst !  1024 len !  copy ;
: t40.0   s src @ srcbuf - 924 xor abort" t40.0" ;
: t40.1   s len @ 100 xor abort" t40.1" ;
: t40.2   s gosWofs@ 1024 xor abort" t40.2" ;
: t40     t40.0 t40.1 t40.2 ;
t40

\ Saving blobs -- aligned chunks

: s       srcbuf src !  0 dst ! 2048 len !  copy ;
: t41.0   s src @ srcbuf - 1024 xor abort" t41.0" ;
: t41.1   s len @ 1024 xor abort" t41.1" ;
: t41.2   s gosWofs@ 1024 xor abort" t41.2" ;
: t41     t41.0 t41.1 t41.2 ;
t41

\ Saving blobs -- partial tail

: s       srcbuf src !  0 dst !  150 len ! copy ;
: t42.0   s src @ srcbuf - 150 xor abort" t42.0" ;
: t42.1   s len @ abort" t42.1" ;
: t42.2   s gosWofs@ 150 xor abort" t42.2" ;
: t42     t42.0 t42.1 t42.2 ;
t42

\ Saving a complete blob
done marker done

create savbuf
  10240 allot

create datbuf
  3072 allot
  datbuf 3072 $CD fill

create expected
  10240 allot
  expected 10240 0 fill
  expected 150 + 3072 $CD fill

: block   1024 * savbuf + ;
: update  ;

include ../lib/xspace.fs
include ../lib/metadata.fs

variable src
variable len
variable dst
: gosWofs!  dst ! ;
: gosWofs@  dst @ ;

include ../lib/gos-space.fs

: s       savbuf 10240 0 fill  datbuf src ! 150 dst ! 3072 len ! ;
: i       savbuf 1024 dump ;
: t43.0   s  keep i savbuf 10240 expected 10240 compare abort" t43.0" ;
: t43.1   s  gosWofs@ >r keep gosWofs@ r> - 3072 xor abort" t43.1" ;
: t43     t43.0 t43.1 ;
t43

done

