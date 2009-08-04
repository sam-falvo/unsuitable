variable arn
: article     arn @ ;
: article!    arn ! ;
: articleId   articleIds arn @ + @f ;
: articleId!  articleIds arn @ + !f ;

: available   articleIds /afields over + begin 2dup < while over
              @f -1 = if drop articleIds - exit then swap cell+
              swap repeat abort" Out of article records" ;

