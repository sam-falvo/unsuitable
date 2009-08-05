require mappings.fs
require general.fs
require articles.fs

: id        a-nextId @ articleId! 1 a-nextId +! update ;
: t         put gob title! ;
: l         S" lead.txt" slurp-file put gob lead! ;
: b         -1 body! ;
: import    available article! id t l b ;

