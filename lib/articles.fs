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

: -found           ." Content-type: text/plain" cr cr ." Article ID " drop . ." doesn't exist." bye ;
: -eoi             dup [ articleIds /afields + ] literal u>= if -found r> drop then ;
: found            articleIds - article! drop ;
: -=               2dup @f = if found r> drop then ;
: articleWithId!   articleIds begin -eoi -= cell+ again ;

: available   articleIds /afields over + begin 2dup < while over
              @f -1 = if drop articleIds - exit then swap cell+
              swap repeat abort" Out of article records" ;

