var menu_data = [
    { text: 'Home', index: 0 },
    { text: 'Accordion', index: 1 },
    { text: 'Carousel', index: 2 },
    { text: 'Modal', index: 3 },
    { text: 'Tables', index: 4 },
    { text: 'Forms', index: 5 }
];

var data_usuarios = [];
var modo_edicion = false;
var id_usuario_edicion = null;

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

function fnRegistrarUsuario() {
    let form1 = document.getElementById("form1");
    form1.classList.add("was-validated");
    if (!form1.checkValidity()) {
        return;
    }
    if (modo_edicion) {
        let item = data_usuarios.find(x => x.id == id_usuario_edicion)
        item.nombres = document.getElementById("txtNombres").value;
        item.apellidos = document.getElementById("txtApellidos").value;
        item.correo = document.getElementById("txtCorreo").value;
        modo_edicion = false;
    } else {
        let data = {
            id: new Date().getTime(),
            nombres: document.getElementById("txtNombres").value,
            apellidos: document.getElementById("txtApellidos").value, 
            correo: document.getElementById("txtCorreo").value
        }
        data_usuarios.push(data);
    }
    fnRenderizarUsuarios();
    fnResetForm();
}
function fnResetForm() {
    document.getElementById("txtNombres").value = "";
    document.getElementById("txtApellidos").value = "";
    document.getElementById("txtCorreo").value = "";
}
function fnRenderizarUsuarios() {
    let items_usuarios = document.getElementById("items_usuarios");
    let html = "";
    data_usuarios.forEach(x => {
        html += `<tr><td>` + x.nombres + `</td>
        <td>` + x.apellidos + `</td>
        <td>` + x.correo + `</td>
        <td>
            <button class="btn btn-sm btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal" type="button" onclick="fnEditarUsuario(` + x.id + `)">Editar</button>
            <button class="btn btn-sm btn-danger" type="button" onclick="fnEliminarUsuario(` + x.id + `)">Eliminar</button>
        </td></tr>`;
    });
    items_usuarios.innerHTML = html
}

function fnEditarUsuario(id) {
    let item = data_usuarios.find(x => x.id = id);
    id_usuario_edicion = id;
    document.getElementById("txtNombres").value = item.nombres;
    document.getElementById("txtApellidos").value = item.apellidos;
    document.getElementById("txtCorreo").value = item.correo;
    modo_edicion = true;
}

function fnEliminarUsuario(id) {
    let item = data_usuarios.find(x => x.id == id);
    let index = data_usuarios.indexOf(item);
    if (index != -1) {
        data_usuarios.splice(index, 1);
        fnRenderizarUsuarios();
    }
}

setTimeout(() => {
    fnLoadMenu();
    fnOpenPage(5);
}, 200);