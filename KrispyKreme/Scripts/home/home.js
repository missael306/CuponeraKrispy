var Krispy = Krispy || {};
Krispy.Home = Krispy.Home || {};

Krispy.Home = (function () {
    "use strict";
    let HomeLoad = function () {
        let Comun = Krispy.Comun;
        let Controller = "/Home";

        this.initialize = function () {            
        };      
    };

    return new HomeLoad();
})();
(function ($, window, document) {
    "use strict";
    $(function () {
        Krispy.Home.initialize();
    });
})(window.jQuery, window, document);
