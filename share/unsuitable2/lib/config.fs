use /home/lighttpd/WWW/falvotech.com/htdocs/blog3/blocks.fb

: max-articles-on-index-page
  5 ;

: base-blog-http
  ." http://www.falvotech.com/blog3/blog.fs" ;

: diagnostic
  ." <p>The blog appears to have been installed correctly; "
  ." however, no articles exist in the message database.</p>"
;


                      1 constant /column
                     66 constant gosAddrsBlock
gosAddrsBlock /column + constant gosLensBlock

                    256 constant gosBlobBlock
                    512 constant /gos-space

