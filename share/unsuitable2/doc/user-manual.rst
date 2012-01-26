~~~~~~~~~~~~~~~~~~~~~~~~~~
Unsuitable 2 User's Manual
~~~~~~~~~~~~~~~~~~~~~~~~~~

Requirements
~~~~~~~~~~~~

Unsuitable 2 requires some things from the host computer on which it's installed.

* GForth 0.6.2 or later (0.7.0 preferred)
* Any web server capable of invoking CGI handlers.

The instructions included here cannot possibly cover all possible web servers out there.  I prefer to use Lighttpd because of its ease of configuration.  To replicate my set up, you'll want this web server:

* Lighttpd 1.4 or later.

Obtaining Unsuitable 2
~~~~~~~~~~~~~~~~~~~~~~

Presently, you can obtain Unsuitable 2 most easily using the Mercurial version control system.  The steps listed below should work, formatted for easy cut-and-paste execution in any Linux or BSD Bash shell environment.

::

  sudo su -   (become root user)
  mkdir -p /opt/local
  cd /opt/local
  hg clone https://bitbucket.org/kc5tja/unsuitable
  exit  (become a normal user again)
  export UNSUITABLE=/opt/local/unsuitable/share/unsuitable2

Configuring your Web Server for Invoking Forth CGI Scripts
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

After acquiring a copy of Unsuitable 2, you'll want to configure your web server to respond to Forth-based CGI requests.  If you're using Lighttpd, the following configuration should work::

  $HTTP["host"] =~ "example\.com" {
    server.document-root = "/Files/WWW/example.com/htdocs"
    server.errorlog = "/Files/WWW/example.com/error.log"
    accesslog.filename = "/Files/WWW/example.com/access.log"

    $HTTP["url"] =~ "^/blog" {
      cgi.assign = ( ".fs" => "/usr/bin/gforth" )
    }
  }

After completing this step, you'll need to create the directories where the blog interface will reside.

::

  mkdir -p /Files/WWW/example.com/htdocs/blog
  cd /Files/WWW/example.com/htdocs/blog

Next, you'll create a landing page for the blog, which is typically named <tt>blog.fs</tt>.  This page serves as a trampoline of sorts, allowing the blog software to run without actually requiring the blog software to exist at this location.  This improves website security.

::

  #! /usr/local/env gforth
  require /opt/local/unsuitable/share/unsuitable2/blog.fs

After you save the trampoline <tt>blog.fs</tt>, restart your web server software to make sure it picks up the new configurations.

