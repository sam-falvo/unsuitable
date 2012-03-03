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
  chmod -R a+r unsuitable
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

Next, you'll create a landing page for the blog, which is typically named <tt>blog.fs</tt>.  This page serves as a trampoline of sorts, allowing the blog software to run without actually requiring the blog software to exist at this location.  This improves website security, should the web server itself become compromised.

::

  #! /usr/local/env gforth
  require /opt/local/unsuitable/share/unsuitable2/blog.fs

The <tt>theme</tt> directory will need to be installed locally as well, for the blog software relies on relative paths.

::

  cp -r $UNSUITABLE/theme .

After you complete these installation steps, restart your web server software to make sure it picks up the new configurations.  If you access your configured location (e.g., <tt>http://www.example.com/blog</tt> or <tt>http://www.example.com/blog/blog.fs</tt>), you should see a diagnostic indicating a complete installation:

  The blog appears to have been installed correctly; however, no articles exist in the message database.

Later, once article submissions to the blog appear, a process explained later in this document, you'll see the top-level index page instead of the diagnostic.

Posting Articles
~~~~~~~~~~~~~~~~

You may post an article by visiting <tt>http://example.com/blog/blog.fs/preview/<tt> (don't forget the trailing slash!).  You'll see a form for entering various attributes of the article you wish to publish.  Start by choosing a title for the article, followed by an abstract or synopsis.  If your article is small enough, you can fit everything inside the abstract field, and ignore the body field.  Otherwise, you'll probably want to provide additional content in the body field.

If you do find yourself needing to split your article into an abstract and a main body, you would do well to follow this simple guideline for composing the abstract.  Provide one sentence to answer each of the following questions, in the order given: (1) what is the problem? (2) why is it a problem? (3) what is your proposed solution? (4) What benefits come from your proposal?

When you've completed typing in the information, click on the PREVIEW button to see how it will appear to a casual blog reader.  Make whatever changes are necessary, and repeat as required.  Once you are satisfied with the article, answer the challenge field to prove you possess the privilege to post an article to the blog, and click PREVIEW once more.

