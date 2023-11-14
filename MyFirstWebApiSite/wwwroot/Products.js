async function getAllProduct() {
    try {
        const res = await fetch('api/product')
        if (!res.ok)
            throw new Error("failed")
        const products = await res.json()

        if (products)
            drawProduct(products);
        else
            alert("not found product");

        //sessionStorage.setItem("currentUser", JSON.stringify(data))
    }
    catch (ex) {
        alert(ex.message)
    }
}

async function drawProduct(products) {
    const temp = document.getElementById('temp-card')
    const t = temp.clone()//chack
    products.map(p => 
        t.img.src = "./pictures" + p.image
        
    )
} 