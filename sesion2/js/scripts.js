var menu_data = [
    { text: 'Home', index: 0 },
    { text: 'Accordion', index: 1 },
    { text: 'Carousel', index: 2 },
    { text: 'Modal', index: 3 },
    { text: 'Tables', index: 4 },
];

function fnLoadMenu() {
    var menu_html = "";
    menu_data.forEach(m => {
        menu_html += '<a class="nav-link"onclick="fnOpenPage(' + m.index + ')">' + m.text + '</a>';
    });
    document.getElementById("menu").innerHTML = menu_html
}

function fnOpenPage(index) {
    //document.getElementById("app").innerHTML = "Página " + index
    fetch("./pages/page" + index + ".html")
    .then(response => response.text())
    .then(text => {
        //console.log(text);
        document.getElementById("app").innerHTML = text
    });
}

setTimeout(() => {
    fnLoadMenu();
}, 200);