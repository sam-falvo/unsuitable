warnings off
marker done

variable src
variable endsrc

variable klen
variable vlen
variable kptr
variable vptr
variable urldecode-called
variable k=v-called
: urldecode     1 urldecode-called +! ;
: k=v           1 k=v-called +!  klen ! kptr ! vlen ! vptr ! ;

include ../lib/kvparse-substr.fs

: s             over src ! + endsrc !  urldecode-called off  k=v-called off ;
: s1            s" key=value" s ;
: s2            s" key=" s ;
: s3            s" =value" s ;
: t90.0         s1 substr klen @ 0= abort" t90.0" ;
: t90.1         s1 substr vlen @ 0= abort" t90.1" ;
: t90.2         s2 substr vlen @ abort" t90.2" ;
: t90.3         s2 substr kptr @ vptr @ = abort" t90.3" ;
: t90.4         s1 substr urldecode-called @ 2 xor abort" t90.4" ;
: t90.5         s2 substr urldecode-called @ 2 xor abort" t90.5" ;
: t90.6         s1 substr k=v-called @ 1 xor abort" t90.6" ;
: t90.7         s2 substr k=v-called @ 1 xor abort" t90.7" ;
: t90.8         s3 substr k=v-called @ abort" t90.8" ;
: t90           t90.0 t90.1 t90.2 t90.3 t90.4 t90.5 t90.6 t90.7 t90.8 ;
t90

done marker done

variable substr-called
variable ptr
variable len
variable src
variable endsrc
: substr        1 substr-called +! ;
include ../lib/kvparse.fs

: s             len ! ptr ! 0 substr-called !  kvparse ;
: input1        s" k=v" ;
: input2        s" a=b&c=d" ;
: input3        s" a=b&&c=d" ;
: s1            input1 s ;
: s2            input2 s ;
: s3            input3 s ;
: t100.0        s1 len @ abort" t100.0" ;
: t100.1        s1 ptr @ input1 + xor abort" t100.1" ;
: t100.2        s1  substr-called @ 1 xor abort" t100.2" ;
: t100.3        s2  substr-called @ 2 xor abort" t100.3" ;
: t100.4        s3  substr-called @ 3 xor abort" t100.4" ;
: t100          t100.0 t100.1 t100.2 t100.3 t100.4 ;
t100

done

