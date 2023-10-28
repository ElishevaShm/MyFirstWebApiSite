async function loginServer() {
    try {

        const userName = document.getElementById("txtUserName").value;
        const password = document.getElementById("txtPassword").value;

        //const user = {
        //    userName, password
        //}
        const res = await fetch(`api/user?userName=${userName}&password=${password}`)
        //    , {
        //    method: "GET",
        //    headers: {
        //        "Content-Type": "application/json"
        //    },
        //    body: user
        //}
        if (!res.ok)
            throw new Error("pleas register")
        const data = await res.json()
        window.location.href = './updateUser.html';

        sessionStorage.setItem("currentUser", JSON.stringify(data))
    }
    catch (ex) {
        alert(ex.message)
    }
}


function newUser() {
    const new1 = document.getElementById("new")
    new1.style.visibility = "initial"
}

async function addUserToServer() {
    try {
        const userName = document.getElementById("txtNewUserName").value
        const password = document.getElementById("txtNewPassword").value
        const firstName = document.getElementById("txtFirstName").value
        const lastName = document.getElementById("txtLastName").value

        const user = { userName, password, firstName, lastName }
        console.log(user)

        const res = await fetch("api/user", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(user)
        })
        if (!res.ok)
            throw new Error("Error add user to server")
        const data = await res.json()
        alert(`user ${data.userName} was added`)
        sessionStorage.setItem("currentUser", JSON.stringify(data))
    }
    catch (ex) {
        alert("error")
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
    var password = document.getElementById("txtNewPassword").value;
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
