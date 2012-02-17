warnings off
marker done

include ../lib/escaper.fs

: scare-quotes  here 34 c, S" scare" pl 34 c, here over - ;

: t101.0	S" &amp;" escape S" &amp;amp;" compare abort" t101.0" ;
: t101.1 	s" <hr />" escape S" &lt;hr /&gt;" compare abort" t101.1" ;
: t101.2	scare-quotes escape 2dup s" &quot;scare&quot;" compare abort" t101.2" ;
: t101.3	S" Hello world" escape S" Hello world" compare abort" t101.3" ;
: t101.4 	S" test" drop 0 escape nip abort" t101.4" ;
: t101		t101.0 t101.1 t101.2 t101.3 t101.4 ;
t101

done

