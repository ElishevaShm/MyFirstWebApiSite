async function loginServer() {
    try {

        const userName = document.getElementById("txtUserName").value;
        const password = document.getElementById("txtPassword").value;
        const userLoginDTO = { userName, password }

        const res = await fetch('api/user/login',
            {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(userLoginDTO)
            })
        if (!res.ok)
            throw new Error("pleas register")
        const data = await res.json()
        sessionStorage.setItem("currentUser", JSON.stringify(data))

        if (sessionStorage.getItem('products'))
            window.location.href = './ShoppingBag.html';

        else
            window.location.href = './updateUser.html';

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
    const strength = {
        0: "Worst",
        1: "Bad",
        2: "Weak",
        3: "Good",
        4: "Strong"
    }
    const password = document.getElementById("txtNewPassword").value;
    const pr = document.getElementById('pr');
    const text = document.getElementById('strength');

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
    pr.value = res;
    pr.max = 4;

    if (password !== "") {
        text.innerHTML = "Strength: " + strength[res];
    } else {
        text.innerHTML = "";
    }
}
