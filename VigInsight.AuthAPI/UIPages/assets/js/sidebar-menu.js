/**
 * sidebar-menu.js
 * =============================================================
 * Single source of truth for the sidebar navigation menu.
 *
 * HOW TO USE IN EVERY HTML PAGE
 * -------------------------------------------------------------
 * STEP 1 – Replace the entire <aside id="layout-menu">...</aside>
 *           block with this single line:
 *
 *              <div id="sidebar-menu-container"></div>
 *
 * STEP 2 – Add ONE script tag just before </body>
 *           (after jquery.js, but before menu.js / main.js):
 *
 *              <script src="./assets/js/sidebar-menu.js"></script>
 *
 * That's it. The active menu item is detected automatically
 * from the current page filename – no per-page changes needed.
 * =============================================================
 */

(function () {

    // ?? MENU DEFINITION ??????????????????????????????????????
    // Edit ONLY this array to add / remove / rename menu items.
    // hidden: true  ?  item rendered but kept display:none
    var MENU_ITEMS = [
        { href: 'ClientDashboard.html', icon: 'bx-home-circle', label: 'Dashboard'                  },
        { href: 'MachineOverview.html', icon: 'bx-home-circle', label: 'Home page'                  },
        { href: 'Page2.html',           icon: 'bx-collection',  label: 'Page2'                      },
        { href: 'Page3.html',           icon: 'bx-collection',  label: '3 (Mold close1)'            },
        { href: 'Page4.html',           icon: 'bx-collection',  label: '4 (Mold close2)'            },
        { href: 'Page5.html',           icon: 'bx-collection',  label: '5 (Mold open1)'             },
        { href: 'Page6.html',           icon: 'bx-collection',  label: '6 (Mold open2)'             },
        { href: 'Page7.html',           icon: 'bx-collection',  label: '7 (Hydro. Ejector)'         },
        { href: 'Page10.html',          icon: 'bx-collection',  label: '10 (Core1)'                 },
        { href: 'Page15.html',          icon: 'bx-collection',  label: '15 (Injection)'             },
        { href: 'Page18.html',          icon: 'bx-collection',  label: '18 (Refill &amp; suckback)' },
        { href: 'Page21.html',          icon: 'bx-collection',  label: '21 (Temp. Settings)'        },
        { href: 'Page29.html',          icon: 'bx-collection',  label: '29 (Timer settings)'        },
        // Secondary / hidden pages
        { href: 'Page20.html', icon: 'bx-collection', label: '20 (Carriage)',            hidden: true },
        { href: 'Page14.html', icon: 'bx-collection', label: '14 (Air Ejector)',         hidden: true },
        { href: 'Page11.html', icon: 'bx-collection', label: '11 (Core2)',               hidden: true },
        { href: 'Page26.html', icon: 'bx-collection', label: '26 (Mold Height)',         hidden: true },
        { href: 'Page44.html', icon: 'bx-collection', label: '44 (Analog Calibration)',  hidden: true },
        { href: 'Page32.html', icon: 'bx-collection', label: '32 (Motor Settings)',      hidden: true },
        { href: 'Page53.html', icon: 'bx-collection', label: '53 (Maximum Value1)',      hidden: true },
        { href: 'Page34.html', icon: 'bx-collection', label: '34 (Lubrication Page)',    hidden: true }
    ];

    // ?? AUTO-DETECT CURRENT PAGE ??????????????????????????????
    var currentPage = window.location.pathname.split('/').pop() || 'index.html';

    // ?? BUILD <li> LIST ???????????????????????????????????????
    var listHTML = MENU_ITEMS.map(function (item) {
        var active  = item.href === currentPage ? ' active' : '';
        var display = item.hidden ? ' style="display:none"' : '';
        return '<li class="menu-item' + active + '"' + display + '>'
             +   '<a href="' + item.href + '" class="menu-link">'
             +     '<i class="menu-icon tf-icons bx ' + item.icon + '"></i>'
             +     '<div data-i18n="Analytics">' + item.label + '</div>'
             +   '</a>'
             + '</li>';
    }).join('');

    // ?? BUILD <aside> ?????????????????????????????????????????
    var aside = '<aside id="layout-menu" class="layout-menu menu-vertical menu bg-menu-theme">'
              +   '<div class="app-brand demo">'
              +     '<a href="index.html" class="app-brand-link">'
              +       '<img src="./assets/img/favicon/vignan.png" alt="Logo" style="max-width:80px;" />'
              +       '<span class="app-brand-text demo menu-text fw-bolder">Vignan</span>'
              +     '</a>'
              +     '<a href="javascript:void(0);" class="layout-menu-toggle menu-link text-large ms-auto d-block d-xl-none">'
              +       '<i class="bx bx-chevron-left bx-sm align-middle"></i>'
              +     '</a>'
              +   '</div>'
              +   '<div class="menu-inner-shadow"></div>'
              +   '<ul class="menu-inner py-1">' + listHTML + '</ul>'
              + '</aside>';

    // ?? INJECT ????????????????????????????????????????????????
    var placeholder = document.getElementById('sidebar-menu-container');
    if (placeholder) {
        placeholder.outerHTML = aside;
    }

})();
