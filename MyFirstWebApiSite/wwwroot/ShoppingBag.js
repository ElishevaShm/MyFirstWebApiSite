let allPrice = 0
async function getProductCart() {
    try {
        const products = JSON.parse(sessionStorage.getItem('products'))

        if (products) {
            document.getElementById('itemCount').innerText = products.length;
            document.querySelector('tbody').replaceChildren([]);
            products.map(p =>
                drawProduct(p)
            );
            document.getElementById('totalAmount').innerText = allPrice;
        }


        else
            alert("not found product");
    }
    catch (ex) {
        alert(ex.message)
    }
}


async function drawProduct(p) {
    allPrice += p.price
    const temp = document.getElementById('temp-row')
    const clone = temp.content.cloneNode(true)//chack
    clone.querySelector(".image").src = "./pictures/" + p.image.trim()
    clone.querySelector(".itemName").innerText = p.name
    clone.querySelector(".price").innerText = p.price
    clone.querySelector("button").addEventListener('click', () => deleteProduct(p))

    const tbody = document.querySelector('tbody');
    tbody.appendChild(clone)
} 

async function deleteProduct(p) {
    allPrice -= p.price
    const products = JSON.parse(sessionStorage.getItem('products'))
    const prodCart = products.filter(prod => prod.productId != p.productId);
    sessionStorage.setItem('products', [])
    sessionStorage.setItem('products', JSON.stringify(prodCart))

    getProductCart()
}


async function placeOrder() {
    try {
        //const userName = document.getElementById("txtNewUserName").value
        //const password = document.getElementById("txtNewPassword").value
        //const firstName = document.getElementById("txtFirstName").value
        const orderSum = document.getElementById('totalAmount').value

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