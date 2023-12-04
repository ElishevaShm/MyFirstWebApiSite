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
    const clone = temp.content.cloneNode(true)
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

    const user = sessionStorage.getItem('currentUser')
    if (!user) 
        window.location.href = './home.html'
    else {
        try {
            const products = JSON.parse(sessionStorage.getItem('products'))
            const userId = JSON.parse(user).userId
            const orderSum = allPrice
            const orderDate = new Date();
            const orderItem = []

            products.map(p => orderItem.push({ "ProductId": p.productId, "Quantity": 1 }))

            const order = { "UserId": userId, "OrderSum": orderSum, "OrderDate": orderDate, "OrderItems": orderItem }
            

            const res = await fetch("api/order", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(order)
            })
            if (!res.ok)
                throw new Error("Error add order to server")
            const data = await res.json()
            alert(`your order num ${data.orderId} placed successfully`)
            sessionStorage.setItem('products', [])
            window.location.href = './Products.html';
        }

        catch (ex) {
            alert("error")
        }
    }
}
