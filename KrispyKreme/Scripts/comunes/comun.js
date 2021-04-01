var Krispy = Krispy || {};
Krispy.Comun = Krispy.Comun || {};

Krispy.Comun = (function () {
    "use strict";
    let ComunLoad = function () {

        this.Initialize = function () {
            this.Plantilla();
        };      

        this.Plantilla = function () {
            jQuery(document).ready(function ($) {
                $('.fadeshop').hover(
                    function () {
                        $(this).find('.captionshop').fadeIn(150);
                    },
                    function () {
                        $(this).find('.captionshop').fadeOut(150);
                    }
                );
            });
        }
        
    };

    return new ComunLoad();
})();
(function ($, window, document) {
    "use strict";
    $(function () {
        Krispy.Comun.Initialize();
    });
})(window.jQuery, window, document);
