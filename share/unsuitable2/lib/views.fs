: .-s 		s>d <# #s #> type ;
: url 		base-blog-http ." /article/" id .-s ;
: q 		34 emit ;
: a( 		." <a href=" q url q ." >" ;
: a) 		." </a>" ;
: div(          ." <div class=" q type q ." >" ;
: div)          ." </div>" ;
: .title 	S" blogArticleIndexTitle" div( a( title type a) div) ;
: timestamp     S" 2011 Apr 14 12:35 PDT" ;
: .timestamp	timestamp type ;
: .author	author type ;
: .when		S" blogArticleIndexTimestamp" div( .timestamp ."  &mdash; " .author div) ;
: .abstract	S" blogArticleIndexLead" div( abstract type div) ;
: .continued	hasBody? if S" blogArticleIndexContinued" div( ." (continued...)" div) then ;
: indexItem	.title .when .abstract .continued ;

: .title	S" blogArticleTitle" div( title type div) ;
: .contact 	S" blogArticleAuthor" div( author type ." <br />" email type div) ;
: .timestamp    S" blogArticleTimestamp" div( timestamp type div) ;
: .published	S" blogArticleTimestampAuthor" div( .contact .timestamp div) ;
: .abstract	S" blogArticleLead" div( abstract type div) ;
: .body 	hasBody? if S" blogArticleBody" div( body type div) then ;
: articleItem	.title .published .abstract .body ;
