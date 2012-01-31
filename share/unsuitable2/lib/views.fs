: .-s 		s>d <# #s #> type ;
: url 		base-blog-http ." /article/" id .-s ;
: q 		34 emit ;
: a( 		." <a href=" q url q ." >" ;
: a) 		." </a>" ;
: .title 	a( title type a) ;
: .posted	." 2011 Apr 14 12:35 PDT" ;
: .author	author type ;
: .abstract	abstract type ;
: .continued	hasBody? if ." (continued...)" then ;
: indexItem	.title .posted .author .abstract .continued ;

