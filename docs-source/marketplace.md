![Version][version-badge-url]
[![License][license-badge]](https://github.com/luminous-software/developer-news/blob/master/LICENSE)
[![Donate][paypal-badge]](https://www.paypal.me/yannduran/5)

[version-badge-url]: http://vsmarketplacebadge.apphb.com/version-short/YannDuran.DeveloperNews.svg?label=version&colorB=7E57C2&style=flat-square
[license-badge]: https://img.shields.io/badge/license-MIT-7E57C2.svg?style=flat-square
[license-url]: https://github.com/luminous-software/developer-news/blob/master/LICENSE
[paypal-badge]: https://img.shields.io/badge/donate-paypal-green.svg?style=flat-square
[paypal-url]: https://www.paypal.me/yannduran/10

You can download this extension [from the Visual Studio Marketplace][marketplace-url]

[marketplace-url]: https://marketplace.visualstudio.com/items?itemName=YannDuran.DeveloperNews

---

## Where's My Developer News?


When Visual Studio 2019 was released, many developers were dismayed to find that the _Start Page_ had been completely
replaced by the new _Start Window_ (a big **modal** dialog, which had no room for _Developer News_).

### Community Outcry

There was a **huge** outpouring of disatification on the [Developer Community forum][developer-community-forum-url] that
not only had the _Start Page_ been taken away (& _Developer News_ with it), but we were left with **no way to get _Developer News_**
in Visual Studio 2019 anymore.

[developer-community-forum-url]: https://developercommunity.visualstudio.com/idea/399833/bring-back-the-developer-news-on-startup.html

### Microsoft's Response

Increduously, Microsoft's response was to simply add a watered-down version of the old *Developer News* to the
[right-hand column of the Visual Studio installer][microsoft-announcement-url].

But nobody wants to have to open the installer just to view their morning developer news.
They want to see it as soon as they open Visual Studio, as they had done for years. And the installer only displays **three** news items,
with a link to click on to _see more online_. Except clicking on the link doesn't show you the rest of the developer news feed, 
instead it opens a browser window to the Visual Studio Blog.

It was a very poor _Developer News_ replacement!

![VS Installer](https://github.com/luminous-software/developer-news/raw/master/docs/assets/images/installer.png)

[microsoft-announcement-url]: https://developercommunity.visualstudio.com/comments/469066/view.html

### Forum Announcement

I [wrote a post in the Developer Community Forum][my-announcement-url] to announce that 
"_I've decided to write a little extension to add a tool window to display the missing Developer News,
either as a stop-gap until MS decide to see sense, or to use instead for the future going forward if they don't_".

[my-announcement-url]: https://developercommunity.visualstudio.com/comments/513534/view.html

### Start Page Is Back (or is it?)

Another developer, [Jan Kučera][jan-kučera-url], released an extension called  [Start Page on Startup][start-page-on-startup-url]
to restore access to the old VS 2017 _Start Page_. The page's code still existed in VS 2019,
but Microsoft simply "hid" access to it in the settings UI.

This of course therefore also restored _Developer News_, but at first it was "broken" and there was no UI for us to be able to "fix" it.
However, after a few tweaks to the extension Jan had the news feed up and running again.

The only problem is that Jan's extension, as well as a few other people's extensions, 
relied on simply displaying the "hidden" VS 2017 _Start Page_.

After my announcement in the forum, a [Microsoft employee ominously pointed out][microsoft-employee-url],
that this code "_is subject to **vanish at anytime**_".
And Microsoft did in fact rip the code out of VS 2019 in a later update, 
in spite of a **large** number of developers either **_demanding_** or **_begging_** for it to be returned. 

So,

  - first we had access to the old VS 2017 Start Page (when VS 2019 was released)
  - when Microsoft found people were still using the old _Start Page_ they "hid" it
  - then Jan's extension brought it back (it could also be displayed manually if you knew the trick)
  - then Microsoft ripped the _Start Page_code out of VS 2019 all together so it could no longer be displayed
  - so any extensions that relied on the code for the old start page just stopped working

My next extension, called [Start Page+][start-page-plus-url], was written to create a **new** start page **from scratch**,
with all of my own code. This meant that Microsoft had no control over and could not simply take it away from us.

My hope was to combine the best from the **_non-modal_** VS 2017 _Start **Page**_ (including _Developer News_)
with the layout of the much hated **_modal_** VS 2019 _Start **Window**, so hopefully everyone would feel at home.

[start-page-plus-url]: https://luminous-software.solutions/start-page-plus
[jan-kučera-url]: https://developercommunity.visualstudio.com/users/863/047cb52a-d0ac-4677-9337-118da1c525e4.html
[start-page-on-startup-url]: https://marketplace.visualstudio.com/items?itemName=JanKucera.StartPageOnStartup
[microsoft-employee-url]: https://developercommunity.visualstudio.com/comments/513807/view.html

## Developer News Is Back!

The [Developer News][developer-news-url] extension adds a new **dockable tool window** to display the same developer news feed
that VS 2017's _Start Page_ used to provide, without relying on any Microsoft controlled code.

To open the new _Developer News_ window:

- select **View** | **Developer News**

![Dev News](https://github.com/luminous-software/developer-news/raw/master/docs/assets/images/dev-news.png)

The old _Developer News_ feed is just the **first** developer-focused feed to be added to the new _Developer News_ window,
with **more feeds to come** in the near future (check out [the roadmap][roadmap-url] for more details).

[developer-news-url]: https://marketplace.visualstudio.com/items?itemName=YannDuran.DeveloperNews
[roadmap-url]: https://luminous-software.solutions/developer-news/roadmap
[give-back-start-page-url]: https://developercommunity.visualstudio.com/idea/434456/start-page-please-give-it-back.html

## More Information

You can read more about _Developer News_ on its website:

[Overview][website-url] **|** [Getting Started][getting-started-url] **|** [Features][features-url] **|** [Changelog][changelog-url] **|** [Roadmap][roadmap-url]

[website-url]: https://luminous-software.solutions/developer-news
[getting-started-url]: https://luminous-software.solutions/developer-news/getting-started
[features-url]: https://luminous-software.solutions/developer-news/features
[changelog-url]: https://luminous-software.solutions/developer-news/changelog
[roadmap-url]: https://luminous-software.solutions/developer-news/roadmap

## Support the Project

If *Developer News* has saved you time and hassle, please come back and show your support:

- you could [***rate *Developer News****][rate-or-review-url] (only takes a couple of seconds)
- or [***review *Developer News****][rate-or-review-url] (help others benefit from your experience)
- or [***shout me a coke***](https://www.paypal.me/yannduran/5) (I don't drink coffee or beer lol)

[rate-or-review-url]: https://marketplace.visualstudio.com/items?itemName=YannDuran.DeveloperNews#review-details
[qna-url]: https://marketplace.visualstudio.com/items?itemName=YannDuran.DeveloperNews#qna
[suggestions-url]: https://marketplace.visualstudio.com/items?itemName=YannDuran.DeveloperNews#qna

[icon-url]: /assets/images/favicon.ico

[contributing-url]: https://github.com/luminous-software/developer-news/blob/master/.github/CONTRIBUTING.md
