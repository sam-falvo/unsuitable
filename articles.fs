variable arn
: article     arn @ ;
: article!    arn ! ;
: articleId   articleIds arn @ + @f ;
: articleId!  articleIds arn @ + !f ;
: title       titles arn @ + @f ;
: title!      titles arn @ + !f ;
: lead        leads arn @ + @f ;
: lead!       leads arn @ + !f ;
: body        bodies arn @ + @f ;
: body!       bodies arn @ + !f ;
: timestamp   timestamps arn @ + @f ;
: timestamp!  timestamps arn @ + !f ;

: available   articleIds /afields over + begin 2dup < while over
              @f -1 = if drop articleIds - exit then swap cell+
              swap repeat abort" Out of article records" ;

