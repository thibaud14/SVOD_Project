/**
 * Created with JetBrains RubyMine.
 * User: Arnaud
 * Date: 1/11/12
 * Time: 16:05
 * To change this template use File | Settings | File Templates.
 */
(function(d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/fr_FR/all.js#xfbml=1";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));
