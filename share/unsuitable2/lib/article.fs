: id            id@ ;
: g             get len ! src ! here dst ! retrieve
                here dst @ over - dup allot ;
: title         title@ g ;
: author        author-name ;
: email         author-email ;
: abstract      abstract@ g ;
: hasBody?      body@ $FFFFFFFF xor ;
: body          body@ g ;
: timestamp     timestamp@ ;

