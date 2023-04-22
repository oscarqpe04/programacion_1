// Import our custom CSS
import '../scss/styles.scss'

// Import all of Bootstrap's JS
import * as bootstrap from 'bootstrap'

import template_menu from '../pages/menu.html';
import template_page0 from '../pages/page0.html';
import template_page1 from '../pages/page1.html';

var templates = [
    template_page0,
    template_page1
];

var menu_data = [
    { text: 'Home', index: 0 },
    { text: 'Accordion', index: 1 },
    { text: 'Carousel', index: 2 },
    { text: 'Modal', index: 3 },
    { text: 'Tables', index: 4 },
    { text: 'Forms', index: 5 }
];

function fnLoadMenu() {
    var menu_html = "";
    menu_data.forEach(m => {
        menu_html += `<li class="nav-item"><a name="item-menu"
            class="nav-link" data-index="` + m.index + `">` + m.text + `</a></li>`;
    });
    document.getElementById("menu_items").innerHTML = menu_html;
    attachEvenClickMenuItem();
}
function attachEvenClickMenuItem() {
    let menu_items = document.getElementsByName("item-menu");
    menu_items.forEach(item => {
        let index = item.getAttribute("data-index");
        item.addEventListener("click", function () {
            fnOpenPage(index);
        });
    })
}
function fnOpenPage(index) {
    document.getElementById("app").innerHTML = templates[index]
}
document.getElementById("menu").innerHTML = template_menu;
document.getElementById("app").innerHTML = template_page0;
fnLoadMenu();