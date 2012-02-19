warnings off
marker done

variable src
include ../lib/permuter.fs
                 ( 0123456789ABCDEF )
: s		S" ABCDEFGHIJKLMNOP" drop src ! ;
: t103.0	s $DEADBEEF permute here 8 - 8 S" POOLNKON" compare abort" t103.0" ;
: t103.1	s $1541D154 permute here 8 - 8 S" EFBNBEFB" compare abort" t103.1" ;
: t103.2	s $FEEDFACE permute here 8 - 8 S" OMKPNOOP" compare abort" t103.2" ;
: t103 		t103.0 t103.1 t103.2 ;
t103

done

