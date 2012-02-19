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
variable dst ( unused in this test )
variable len

256 constant gosBlobBlock
512 constant /gos-space
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

256 constant gosBlobBlock
512 constant /gos-space
include ../lib/gos-space.fs

: s       srcbuf src !  100 dst !  1024 len !  out ;
: t40.0   s src @ srcbuf - 924 xor abort" t40.0" ;
: t40.1   s len @ 100 xor abort" t40.1" ;
: t40.2   s gosWofs@ 1024 xor abort" t40.2" ;
: t40     t40.0 t40.1 t40.2 ;
t40

\ Saving blobs -- aligned chunks

: s       srcbuf src !  0 dst ! 2048 len !  out ;
: t41.0   s src @ srcbuf - 1024 xor abort" t41.0" ;
: t41.1   s len @ 1024 xor abort" t41.1" ;
: t41.2   s gosWofs@ 1024 xor abort" t41.2" ;
: t41     t41.0 t41.1 t41.2 ;
t41

\ Saving blobs -- partial tail

: s       srcbuf src !  0 dst !  150 len ! out ;
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

256 constant gosBlobBlock
512 constant /gos-space
include ../lib/gos-space.fs

: s       savbuf 10240 0 fill  datbuf src ! 150 dst ! 3072 len ! ;
: t43.0   s  keep savbuf 10240 expected 10240 compare abort" t43.0" ;
: t43.1   s  gosWofs@ >r keep gosWofs@ r> - 3072 xor abort" t43.1" ;
: t43     t43.0 t43.1 ;
t43

\ Loading partial blobs

done marker done

create srcbuf
  10240 allot
  srcbuf 10240 0 fill
  srcbuf 150 + 4090 $CD fill

create ldbuf
  4096 allot

create expected
  4096 allot
  expected 4096 0 fill
  expected 4090 $CD fill

: update  ;
: block   1024 * srcbuf + ;
include ../lib/xspace.fs
include ../lib/metadata.fs
variable src
variable dst
variable len
: gosWofs!  src ! ;
: gosWofs@  src @ ;
256 constant gosBlobBlock
512 constant /gos-space
include ../lib/gos-space.fs

: s       ldbuf 4096 0 fill  150 src !  ldbuf dst ! 1024 len !  inp ;
: t44.0   s  src @ 1024 xor abort" t44.0" ;
: t44.1   s  dst @ ldbuf - 874 xor abort" t44.1" ;
: t44.2   s  len @ 150 xor abort" t44.2" ;
: t44.3   s  ldbuf c@ $CD xor abort" t44.3" ;
: t44     t44.0 t44.1 t44.2 t44.3 ;
t44

: s       ldbuf 4096 0 fill 0 src !  ldbuf dst !  2048 len !  inp ;
: t45.0   s  src @ 1024 xor abort" t45.0" ;
: t45.1   s  dst @ ldbuf - 1024 xor abort" t45.1" ;
: t45.2   s  len @ 1024 xor abort" t45.2" ;
: t45     t45.0 t45.1 t45.2 ;
t45

: s       ldbuf 4096 0 fill  0 src !  ldbuf dst !  204 len !  inp ;
: t46.0   s  src @ 204 xor abort" t46.0" ;
: t46.1   s  dst @ ldbuf - 204 xor abort" t46.1" ;
: t46.2   s  len @ abort" t46.2" ;
: t46     t46.0 t46.1 t46.2 ;
t46

: s       ldbuf 4096 0 fill  150 src !  ldbuf dst ! 4096 len ! retrieve ;
: t47.0   s  expected 4096 ldbuf 4096 compare abort" t47.0" ;
: t47     t47.0 ;
t47

done

