let getAllBtn = document.getElementById("btn1");
let getById = document.getElementById("btn2");
let getByIdInput = document.getElementById("input2");

var port = "5069";
let getAllNotes = async () => {
    let url = "http://localhost:" + port + "api/Users";

    let response = await fetch(url);
    console.log(response);
    debugger;
    let data = await response.json();
    console.log(data);
};

let getNoteById = async () => {
    let url = "http://localhost:" + port + "api/Users" + getByIdInput.value;
    debugger;
    let response = await fetch(url);
    let data = await response.text();
    console.log(data);
};