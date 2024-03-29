/*!
 * Krajee Font Awesome Theme configuration for bootstrap-star-rating.
 * This file must be loaded after 'star-rating.js'.
 *
 * @see http://github.com/kartik-v/bootstrap-star-rating
 * @author Kartik Visweswaran <kartikv2@gmail.com>
 */
(function ($) {
    "use strict";
    $.fn.ratingThemes['krajee-fa'] = {
        filledStar: '<i class="fas fa-dollar-sign"></i>',
        emptyStar: '<i class="fas fa-dollar-sign"></i>',
        clearButton: '<i class="fa fa-lg fa-minus-circle"></i>'
    };
})(window.jQuery);
