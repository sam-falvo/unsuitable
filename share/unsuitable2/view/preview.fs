: .blog-title 		." Sam's All New, New and Improved, New News News" ;
: .article-error 	;
: .article-title 	;
: .article-abstract 	;
: .article-body		;

variable outp
: preview 	here src !  S" theme/PreviewPage" contents  src @ here over - len !
		here outp !  expand  here outp @ - type ;
preview

