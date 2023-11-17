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
    const products = JSON.parse(sessionStorage.getItem('products'))
    const prodCart = products.filter(prod => prod.productId != p.productId);
    sessionStorage.setItem('products', [])
    sessionStorage.setItem('products', JSON.stringify(prodCart))

    getProductCart()
}