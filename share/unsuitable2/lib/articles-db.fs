: newArticle    artDbId@ 1+ artDbId! ;

variable offset
: found         articleIds blocks - offset !  drop -1 ;
: -eq           2dup x@32 xor if exit then found r> r> 2drop ;
: -end          dup titles blocks u< if exit then r> drop ;
: -match        begin -end -eq 4 + again ;
: search        articleIds blocks -match 2drop 0 ;
: article       search 0= abort" E010 Expected article not found" ;

: available	$FFFFFFFF search 0= abort" E011 No more room in articles table" ;

: field         blocks offset @ + ;
: id@           articleIds field x@32 ;
: id!           articleIds field x!32 ;
: title@        titles field x@32 ;
: title!        titles field x!32 ;
: abstract@     abstracts field x@32 ;
: abstract!     abstracts field x!32 ;
: body@         bodies field x@32 ;
: body!         bodies field x!32 ;
: timestamp@    timestamps field x@32 ;
: timestamp!    timestamps field x!32 ;

: posted        available timestamp! body! abstract! title! artDbId@ id! ;

: -free         dup x@32 $FFFFFFFF xor if exit then  swap 1+ swap ;
: ct            begin -end -free 4 + again ;
: articlesFree  0 articleIds blocks ct drop ;

: #articles     /artDbColumn blocks 2 rshift articlesFree - ;
: empty?        #articles 0= ;

variable callback
variable end

: perform       callback ! ;
: consider      dup x@32 callback @ execute ;
: start         articleIds blocks ;
: -end          dup end @ u< if exit then r> 2drop ;
: -used         dup x@32 $FFFFFFFF xor if consider then ;
: allArticles   start dup /artDbColumn blocks + end !
                begin -end -used 4 + again ;

