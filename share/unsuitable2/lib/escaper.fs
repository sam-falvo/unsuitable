: pl		dup >r here swap move r> allot ;
: -&		dup [char] & xor if exit then drop s" &amp;" pl r> drop ;
: -<		dup [char] < xor if exit then drop s" &lt;" pl r> drop ;
: ->		dup [char] > xor if exit then drop s" &gt;" pl r> drop ;
: -"		dup [char] " xor if exit then drop s" &quot;" pl r> drop ;
: ch		-" -> -< -& c, ;
: esc		begin dup while over c@ ch 1- swap 1+ swap repeat 2drop ;
: escape	here -rot esc here over - ;

