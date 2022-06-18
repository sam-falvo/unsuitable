variable arn
: article     arn @ ;
: article!    arn ! ;
: articleId   articleIds arn @ + @f32 ;
: articleId!  articleIds arn @ + !f32 ;
: title       titles arn @ + @f32 ;
: title!      titles arn @ + !f32 ;
: lead        leads arn @ + @f32 ;
: lead!       leads arn @ + !f32 ;
: body        bodies arn @ + @f32 ;
: body!       bodies arn @ + !f32 ;
: timestamp   timestamps arn @ + @f32 ;
: timestamp!  timestamps arn @ + !f32 ;

: -found           ." Content-type: text/plain" cr cr ." Article ID " drop . ." doesn't exist." bye ;
: -eoi             dup [ articleIds /afields + ] literal u>= if -found r> drop then ;
: found            articleIds - article! drop ;
: -=               2dup @f32 = if found r> drop then ;
: articleWithId!   articleIds begin -eoi -= word+ again ;

: available   articleIds /afields over + begin 2dup < while over
              @f32 -1 = if drop articleIds - exit then swap word+
              swap repeat abort" Out of article records" ;

