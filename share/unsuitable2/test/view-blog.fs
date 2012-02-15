warnings off
marker done

variable piLen
variable piPtr
: getPathInfo 	;

variable 404pg-called
: 404Page       404pg-called on ;

variable ml
variable mn

marker subdone
: included      2dup s" view/abc.fs" compare if -514 throw then  ml ! mn ! ;
include ../lib/dispatch.fs

: p             S" /abc/" piLen ! piPtr ! ;
: q             S" /abc" piLen ! piPtr ! ;
: s             404pg-called off  blog ;
: t70.0         p s  mn @ ml @ s" view/abc.fs" compare abort" t70.0" ;
: t70.1         q s  mn @ ml @ s" view/abc.fs" compare abort" t70.1" ;
: t70.2 	p s  404pg-called @ abort" t70.2" ;
: t70           t70.0 t70.1 t70.2 ;
t70

subdone marker subdone
: included      2dup s" view/index.fs" compare if -514 throw then  ml ! mn ! ;
include ../lib/dispatch.fs

: p             s" /" piLen ! piPtr ! ;
: q             s" " piLen ! piPtr ! ;
: s             404pg-called off  blog ;
: t71.0         p s  mn @ ml @ s" view/index.fs" compare abort" t71.0" ;
: t71.1         q s  mn @ ml @ s" view/index.fs" compare abort" t71.1" ;
: t71.2 	p s  404pg-called @ abort" t71.2" ;
: t71           t71.0 t71.1 t71.2 ;
t71

subdone marker subdone
: included 	-514 throw ;
include ../lib/dispatch.fs

: s 		S" asdjkh" piLen ! piPtr !  404pg-called off  blog ;
: t72.0 	s  404pg-called @ 0= abort" t72.0" ;
: t72 		t72.0 ;
t72

done

