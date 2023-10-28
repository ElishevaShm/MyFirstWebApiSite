let userString = sessionStorage.getItem('currentUser')
let name = JSON.parse(userString)

function helloTo() {
    const hello = document.getElementById("hello")
    hello.innerHTML = `hello to ${name.firstName}`

}
function toUpdate() {
    const update = document.getElementById("update")
    update.style.visibility = "initial"
}

async function updateUser() {
    const userString = sessionStorage.getItem('currentUser')
    const id = JSON.parse(userString).userId
    const userName = document.getElementById("txtUpdateUserName").value
    const password = document.getElementById("txtUpdatePassword").value
    const firstName = document.getElementById("txtUpdateFirstName").value
    const lastName = document.getElementById("txtUpdateLastName").value

    const user = { userName, password, firstName, lastName }
    try {


        const res = await fetch(`api/user/${id}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(user)
        })
        if (!res.ok)
            throw new Error("Error update user to server")
        sessionStorage.setItem("currentUser", JSON.stringify(user))
        let userString = sessionStorage.getItem('currentUser')
        let cu = JSON.parse(userString)

        alert(`user ${cu.userName} was updated`)
        window.location.href = './home.html';

    }
    catch (ex) {
        alert(ex.message)
    }
}
async function checkPassword() {
    var res;
    var strength = {
        0: "Worst",
        1: "Bad",
        2: "Weak",
        3: "Good",
        4: "Strong"
    }
    var password = document.getElementById("txtUpdatePassword").value;
    var pr = document.getElementById('pr');
    var text = document.getElementById('strength');

    await fetch('api/user/check',
        {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(password)

        })
        .then(r => r.json())
        .then(data => res = data)




    if (res <= 2) alert("your password is weak!! try again")
    // Update the password strength meter
    pr.value = res;
    pr.max = 4;

    // Update the text indicator
    if (password !== "") {
        text.innerHTML = "Strength: " + strength[res];
    } else {
        text.innerHTML = "";
    }
}