
Outlook TFS Integration
-----------------------

This little plugin allows you to attach emails to TFS work items from Outlook in a easy way. Allowing you to choose as many task you want to attach the email to.

Downloads
---------

[ClickOnce Installer](http://bit.ly/outlooktfs_clickonce)

[ClickOnce Installer Package](bit.ly/outlooktfs_package)


Known Issues
------------

It seems that the combination of either Windows 8 and Outlook 2013 or Outlook 2013 itself is causing the application not to install due that the certificate im using is temporal and not a CA validated cert.

I will update with a new version that includes a valid cert so that installations in those systems would succeed.

Change Log
----------

*2015/04/26 v1.0.0.9*

    * Renamed the Title to depict you can add attachments to work items (bugs, tasks, etc.)

*2015/01/28 v1.0.0.8*

    * Added Background Worker to avoid UI freeze.
    * Fixed bug when adding email to multiple tasks.

*2014/10/31 v1.0.0.6*

    * Initial Commit.

Usage
-----

* Install it by runing the setup.exe.
* Open an email you want to attach to task.
* Click "Attach to TFS" button, select your TFS server in screen shown.
* Input task number and click + button.
* Click Save.
