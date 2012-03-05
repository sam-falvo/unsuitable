: max-articles-on-index-page
  5 ;

: base-blog-http
  ." http://www.falvotech.com/blog3/blog.fs" ;

: diagnostic
  ." <p>The blog appears to have been installed correctly; "
  ." however, no articles exist in the message database.</p>"
;

: author-name
  s" Samuel A. Falvo II" ;

: author-email
  s" kc5tja -at- arrl.net" ;

                      1 constant /column
                     66 constant gosAddrsBlock
gosAddrsBlock /column + constant gosLensBlock

                    256 constant gosBlobBlock
                    512 constant /gos-space

              $76543210 constant authKey

                           2 constant /artDbColumn
                          68 constant articleIds
   articleIds /artDbColumn + constant titles
       titles /artDbColumn + constant abstracts
    abstracts /artDbColumn + constant bodies
       bodies /artDbColumn + constant timestamps

