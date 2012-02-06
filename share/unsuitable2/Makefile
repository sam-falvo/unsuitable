PRJ=unsuitable
LYXDOC=${PRJ}.lyx
NWDOC=${PRJ}.nw
LIBS=lib/views.fs

${NWDOC}: ${LYXDOC}
	lyx -e literate $< > $@

blog.fs: ${NWDOC}
	notangle -Rblog.fs $< >blog.fs

test-blog.fs: ${NWDOC}
	notangle -Rtest-blog.fs $< >test-blog.fs

test: test-blog.fs blog.fs ${LIBS}
	gforth test-blog.fs

lib/views.fs: ${NWDOC}
	mkdir -p lib
	notangle -Rlib/views.fs $< >lib/views.fs

t: blog.fs ${LIBS}
	gforth blog.fs

clean:
	rm -f blog.fs ${NWDOC}
	rm -f ${LIBS}

